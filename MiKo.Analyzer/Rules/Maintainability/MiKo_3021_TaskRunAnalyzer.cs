﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MiKoSolutions.Analyzers.Rules.Maintainability
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class MiKo_3021_TaskRunAnalyzer : MaintainabilityAnalyzer
    {
        public const string Id = "MiKo_3021";

        private const string TaskRunInvocation = nameof(Task) + "." + nameof(Task.Run);

        public MiKo_3021_TaskRunAnalyzer() : base(Id)
        {
        }

        protected override IEnumerable<Diagnostic> AnalyzeMethod(IMethodSymbol method)
        {
            var returnType = method.ReturnType;

            return returnType.IsTask()
                       ? AnalyzeTask(method)
                       : Enumerable.Empty<Diagnostic>();
        }

        private IEnumerable<Diagnostic> AnalyzeTask(IMethodSymbol method)
        {
            var methodName = method.Name;

            foreach (var methodNode in method.DeclaringSyntaxReferences.Select(_ => _.GetSyntax()))
            {
                foreach (var taskRunExpression in methodNode.DescendantNodes().OfType<MemberAccessExpressionSyntax>().Where(_ => _.ToString() == TaskRunInvocation))
                {
                    var expression = taskRunExpression.GetEnclosing<InvocationExpressionSyntax>();
                    var node = expression.GetEnclosing(SyntaxKind.AwaitExpression, SyntaxKind.ReturnStatement, SyntaxKind.VariableDeclarator, SyntaxKind.ArrowExpressionClause);
                    switch (node?.Kind())
                    {
                        case SyntaxKind.ReturnStatement:
                        case SyntaxKind.ArrowExpressionClause:
                            yield return ReportIssue(taskRunExpression, methodName);

                            break;

                        case SyntaxKind.VariableDeclarator:
                            var variable = (VariableDeclaratorSyntax)node;
                            var variableName = variable.Identifier.ValueText;

                            foreach (var unused in methodNode.DescendantNodes()
                                                             .OfType<ReturnStatementSyntax>()
                                                             .Select(_ => _.Expression)
                                                             .OfType<IdentifierNameSyntax>()
                                                             .Where(_ => _.Identifier.ValueText == variableName))
                            {
                                yield return ReportIssue(taskRunExpression, methodName);
                            }

                            break;
                    }
                }
            }
        }

        private Diagnostic ReportIssue(CSharpSyntaxNode expression, string methodName) => ReportIssue(TaskRunInvocation, expression.GetLocation(), methodName);
    }
}