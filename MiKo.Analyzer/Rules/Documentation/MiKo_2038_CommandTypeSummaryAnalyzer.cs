﻿using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MiKoSolutions.Analyzers.Rules.Documentation
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class MiKo_2038_CommandTypeSummaryAnalyzer : SummaryDocumentationAnalyzer
    {
        public const string Id = "MiKo_2038";

        public MiKo_2038_CommandTypeSummaryAnalyzer() : base(Id, SymbolKind.NamedType)
        {
        }

        protected override bool ShallAnalyzeType(INamedTypeSymbol symbol) => symbol.IsCommand();

        protected override IEnumerable<Diagnostic> AnalyzeSummary(ISymbol symbol, IEnumerable<string> summaries)
        {
            const string Phrase = Constants.Comments.CommandSummaryStartingPhrase;

            return summaries.All(_ => !_.StartsWith(Phrase, StringComparison.Ordinal))
                       ? new[] { ReportIssue(symbol, Constants.XmlTag.Summary, Phrase) }
                       : Enumerable.Empty<Diagnostic>();
        }
    }
}