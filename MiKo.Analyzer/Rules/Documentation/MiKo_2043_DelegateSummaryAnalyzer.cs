﻿using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MiKoSolutions.Analyzers.Rules.Documentation
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class MiKo_2043_DelegateSummaryAnalyzer : SummaryDocumentationAnalyzer
    {
        public const string Id = "MiKo_2043";

        private const string Phrase = Constants.Comments.DelegateSummaryStartingPhrase;

        public MiKo_2043_DelegateSummaryAnalyzer() : base(Id, SymbolKind.NamedType)
        {
        }

        protected override bool ShallAnalyzeType(INamedTypeSymbol symbol) => symbol.TypeKind == TypeKind.Delegate;

        protected override IEnumerable<Diagnostic> AnalyzeSummary(ISymbol symbol, IEnumerable<string> summaries) => summaries.Any(_ => _.Contains(Phrase))
                                                                                                                        ? Enumerable.Empty<Diagnostic>()
                                                                                                                        : new[] { ReportIssue(symbol, Constants.XmlTag.Summary, Phrase) };
    }
}