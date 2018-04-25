﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Windows.Input;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis
{
    internal static class SymbolExtensions
    {
        internal static bool IsEventHandler(this IMethodSymbol method)
        {
            var parameters = method.Parameters;
            return parameters.Length == 2 && parameters[0].Type.SpecialType == SpecialType.System_Object && parameters[1].Type.IsEventArgs();
        }

        internal static bool IsInterfaceImplementationOf<T>(this IMethodSymbol method)
        {
            if (method.ContainingType.Implements<T>())
            {
                var fullName = typeof(T).FullName;
                var methodSymbols = method.ContainingType.AllInterfaces
                                          .Where(_ => _.Name == fullName)
                                          .SelectMany(_ => _.GetMembers().OfType<IMethodSymbol>());
                return methodSymbols.Any(_ => method.ContainingType.FindImplementationForInterfaceMember(_).Equals(method));
            }

            return false;
        }

        internal static bool IsTestClass(this ITypeSymbol symbol)
        {
            foreach (var name in symbol.GetAttributes().Select(_ => _.AttributeClass.Name))
            {
                switch (name)
                {
                    case "TestFixture":
                    case "TestFixtureAttribute":
                    case "TestClass":
                    case "TestClassAttribute":
                        return true;
                }
            }

            return false;
        }

        internal static bool IsTestMethod(this IMethodSymbol method)
        {
            foreach (var name in method.GetAttributes().Select(_ => _.AttributeClass.Name))
            {
                switch (name)
                {
                    case "Test":
                    case "TestAttribute":
                    case "TestCase":
                    case "TestCaseAttribute":
                    case "TestCaseSource":
                    case "TestCaseSourceAttribute":
                    case "Theory":
                    case "TheoryAttribute":
                    case "Fact":
                    case "FactAttribute":
                    case "TestMethod":
                    case "TestMethodAttribute":
                        return true;
                }
            }

            return false;
        }

        internal static bool IsTestSetupMethod(this IMethodSymbol method)
        {
            foreach (var name in method.GetAttributes().Select(_ => _.AttributeClass.Name))
            {
                switch (name)
                {
                    case "SetUp":
                    case "SetUpAttribute":
                    case "TestInitialize":
                    case "TestInitializeAttribute":
                        return true;
                }
            }

            return false;
        }

        internal static bool IsTestTeardownMethod(this IMethodSymbol method)
        {
            foreach (var name in method.GetAttributes().Select(_ => _.AttributeClass.Name))
            {
                switch (name)
                {
                    case "TearDown":
                    case "TearDownAttribute":
                    case "TestCleanup":
                    case "TestCleanupAttribute":
                        return true;
                }
            }

            return false;
        }

        internal static bool IsSpecialAccessor(this IMethodSymbol method)
        {
            switch (method.MethodKind)
            {
                case MethodKind.EventAdd:
                case MethodKind.EventRemove:
                case MethodKind.PropertyGet:
                case MethodKind.PropertySet:
                case MethodKind.ExplicitInterfaceImplementation:
                    return true;
                default:
                    return false;
            }
        }

        internal static bool IsConstructor(this ISymbol symbol) => symbol is IMethodSymbol m && m.MethodKind == MethodKind.Constructor;

        internal static bool IsImportingConstructor(this ISymbol symbol)
        {
            if (!symbol.IsConstructor()) return false;

            foreach (var name in symbol.GetAttributes().Select(_ => _.AttributeClass.Name))
            {
                switch (name)
                {
                    case "ImportingConstructor":
                    case nameof(ImportingConstructorAttribute):
                        return true;
                }
            }

            return false;
        }

        internal static bool IsImport(this ISymbol symbol)
        {
            foreach (var name in symbol.GetAttributes().Select(_ => _.AttributeClass.Name))
            {
                switch (name)
                {
                    case "Import":
                    case nameof(ImportAttribute):
                    case "ImportMany":
                    case nameof(ImportManyAttribute):
                        return true;
                }
            }

            return false;
        }

        internal static bool InheritsFrom<T>(this ITypeSymbol symbol) => InheritsFrom(symbol, typeof(T).FullName);

        internal static bool InheritsFrom(this ITypeSymbol symbol, string baseClass)
        {
            while (true)
            {
                if (symbol.ToString() == baseClass) return true;

                var baseType = symbol.BaseType;
                if (baseType == null) return false;

                symbol = baseType;
            }
        }

        internal static bool Implements<T>(this ITypeSymbol symbol) => Implements(symbol, typeof(T).FullName);

        internal static bool Implements(this ITypeSymbol symbol, string interfaceType)
        {
            if (symbol.ToString() == interfaceType) return true;

            foreach (var implementedInterface in symbol.AllInterfaces)
            {
                if (implementedInterface.ToString() == interfaceType) return true;
            }

            return false;
        }

        internal static bool ImplementsPotentialGeneric(this ITypeSymbol symbol, Type interfaceType) => ImplementsPotentialGeneric(symbol, interfaceType.FullName);

        internal static bool ImplementsPotentialGeneric(this ITypeSymbol symbol, string interfaceType)
        {
            var index = interfaceType.IndexOf('`');
            var interfaceTypeWithoutGeneric = index > -1
                                                  ? interfaceType.Substring(0, index)
                                                  : interfaceType;

            if (symbol.ToString().StartsWith(interfaceTypeWithoutGeneric, StringComparison.OrdinalIgnoreCase))
                return true;

            foreach (var implementedInterface in symbol.AllInterfaces)
            {
                if (implementedInterface.ToString().StartsWith(interfaceTypeWithoutGeneric, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        internal static bool IsEventArgs(this ITypeSymbol symbol)
        {
            if (symbol.TypeKind != TypeKind.Class) return false;
            if (symbol.SpecialType != SpecialType.None) return false;

            return symbol.InheritsFrom<EventArgs>();
        }

        internal static bool IsException(this ITypeSymbol symbol)
        {
            if (symbol.TypeKind != TypeKind.Class) return false;
            if (symbol.SpecialType != SpecialType.None) return false;

            return symbol.InheritsFrom<Exception>();
        }

        internal static bool IsEnumerable(this ITypeSymbol symbol)
        {
            switch (symbol.SpecialType)
            {
                case SpecialType.System_String:
                    return false;

                case SpecialType.System_Array:
                case SpecialType.System_Collections_IEnumerable:
                case SpecialType.System_Collections_Generic_IEnumerable_T:
                case SpecialType.System_Collections_Generic_IList_T:
                case SpecialType.System_Collections_Generic_ICollection_T:
                case SpecialType.System_Collections_Generic_IReadOnlyList_T:
                case SpecialType.System_Collections_Generic_IReadOnlyCollection_T:
                    return true;

                default:
                    return symbol.Implements<IEnumerable>();
            }
        }

        internal static IEnumerable<ITypeSymbol> IncludingAllBaseTypes(this ITypeSymbol symbol)
        {
            var baseTypes = new List<ITypeSymbol> { symbol };
            while (true)
            {
                var baseType = symbol.BaseType;
                if (baseType == null) break;

                baseTypes.Add(baseType);
                symbol = baseType;
            }

            return baseTypes;
        }

        internal static bool IsEnum(this ITypeSymbol symbol) => symbol.TypeKind == TypeKind.Enum;

        internal static bool IsTask(this ITypeSymbol symbol) => symbol?.Name == nameof(System.Threading.Tasks.Task);

        internal static INamedTypeSymbol FindContainingType(this SyntaxNodeAnalysisContext context) => FindContainingType(context.ContainingSymbol);

        internal static INamedTypeSymbol FindContainingType(this ISymbol symbol)
        {
            while (symbol != null)
            {
                if (symbol is INamedTypeSymbol s) return s;

                symbol = symbol.ContainingType;
            }

            return null;
        }

        internal static bool IsFactory(this ITypeSymbol symbol) => symbol.Name.EndsWith("Factory", StringComparison.Ordinal) && symbol.Name.EndsWith("TaskFactory", StringComparison.Ordinal) == false; // ignore special situation for task factory

        internal static bool IsCancellationToken(this ITypeSymbol symbol) => symbol.TypeKind == TypeKind.Struct && symbol.ToString() == typeof(System.Threading.CancellationToken).FullName;

        internal static bool IsNullable(this ITypeSymbol symbol) => symbol.IsValueType && symbol.Name == nameof(Nullable);

        internal static ISymbol GetSymbol(this SyntaxToken token, SemanticModel semanticModel)
        {
            var position = token.GetLocation().SourceSpan.Start;
            var name = token.ValueText;

            if (token.Parent is ParameterSyntax node)
            {
                var method = node.GetEnclosing<MethodDeclarationSyntax>();
                var methodName = method.Identifier.ValueText;
                var methodSymbols = semanticModel.LookupSymbols(position, name: methodName).OfType<IMethodSymbol>();
                var parameterSymbol = methodSymbols.SelectMany(_ => _.Parameters).FirstOrDefault(_ => _.Name == name);
                return parameterSymbol;

                // if it's no method parameter, then it is a local one (but Roslyn cannot handle that currently)
                //var symbol = semanticModel.LookupSymbols(position).First(_ => _.Kind == SymbolKind.Local);
            }

            return semanticModel.LookupSymbols(position, name: name).First();
        }

        internal static IMethodSymbol GetEnclosingMethod(this SyntaxNode node, SemanticModel semanticModel)
        {
            var symbol = semanticModel.GetEnclosingSymbol(node.GetLocation().SourceSpan.Start);
            return symbol as IMethodSymbol;
        }

        internal static T GetEnclosing<T>(this SyntaxNode node) where T : SyntaxNode
        {
            while (true)
            {
                switch (node)
                {
                    case null: return null;
                    case T t: return t;
                }

                node = node.Parent;
            }
        }

        internal static SyntaxNode GetEnclosing(this SyntaxNode node, params SyntaxKind[] syntaxKinds)
        {
            while (true)
            {
                if (node == null)
                    return null;

                foreach (var syntaxKind in syntaxKinds)
                {
                    if (node.IsKind(syntaxKind))
                        return node;
                }

                node = node.Parent;
            }
        }

        internal static bool IsCommand(this IErrorTypeSymbol symbol) => symbol.Name == nameof(ICommand);

        internal static bool IsCommand(this ITypeSymbol symbol)
        {
            if (symbol.Implements<ICommand>())
                return true;

            // TODO: refactor this as we do this for tests
            return symbol.IncludingAllBaseTypes().Concat(symbol.AllInterfaces).OfType<IErrorTypeSymbol>().Any(IsCommand);
        }

        internal static bool IsCommand(this TypeSyntax syntax, SemanticModel semanticModel)
        {
            var name = syntax.ToString();

            return name.Contains("Command")
                && semanticModel.LookupSymbols(syntax.GetLocation().SourceSpan.Start, name: name).FirstOrDefault() is ITypeSymbol symbol
                && symbol.IsCommand();
        }

        internal static bool IsAsyncTaskBased(this IMethodSymbol method) => method.IsAsync || method.ReturnType.IsTask();
    }
}