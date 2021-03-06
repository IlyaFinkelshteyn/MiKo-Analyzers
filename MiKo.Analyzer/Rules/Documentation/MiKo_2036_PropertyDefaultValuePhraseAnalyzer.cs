﻿using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MiKoSolutions.Analyzers.Rules.Documentation
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class MiKo_2036_PropertyDefaultValuePhraseAnalyzer : ReturnsValueDocumentationAnalyzer
    {
        public const string Id = "MiKo_2036";

        public MiKo_2036_PropertyDefaultValuePhraseAnalyzer() : base(Id)
        {
        }
        protected override void InitializeCore(AnalysisContext context) => InitializeCore(context, SymbolKind.Property);

        protected override bool ShallAnalyzeProperty(IPropertySymbol symbol)
        {
            var returnType = symbol.GetReturnType();
            if (returnType == null) return false;

            return returnType.SpecialType == SpecialType.System_Boolean || returnType.IsEnum();
        }

        protected override IEnumerable<Diagnostic> AnalyzeReturnType(ISymbol owningSymbol, ITypeSymbol returnType, string comment, string xmlTag)
        {
            string proposedEndingPhrase;
            string[] endingPhrases;

            if (returnType.SpecialType == SpecialType.System_Boolean)
            {
                proposedEndingPhrase = string.Format(Constants.Comments.DefaultLangwordPhrase, "...");
                endingPhrases = Constants.Comments.DefaultBooleanLangwordPhrases;
            }
            else
            {
                proposedEndingPhrase = string.Format(Constants.Comments.DefaultCrefPhrase, "...");
                endingPhrases = returnType.GetMembers()
                                          .OfType<IFieldSymbol>()
                                          .SelectMany(_ => Constants.Comments.DefaultCrefPhrases, (symbol, phrase) => string.Format(phrase, symbol))
                                          .ToArray();
            }

            return comment.EndsWithAny(StringComparison.Ordinal, endingPhrases)
                       ? Enumerable.Empty<Diagnostic>()
                       : new[] { ReportIssue(owningSymbol, owningSymbol.Name, xmlTag, proposedEndingPhrase) };
        }
    }
}