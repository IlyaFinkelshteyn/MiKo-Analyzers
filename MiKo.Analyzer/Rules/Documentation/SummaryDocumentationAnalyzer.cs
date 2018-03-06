﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

using Microsoft.CodeAnalysis;

namespace MiKoSolutions.Analyzers.Rules.Documentation
{
    public abstract class SummaryDocumentationAnalyzer : DocumentationAnalyzer
    {
        protected SummaryDocumentationAnalyzer(string diagnosticId, SymbolKind symbolKind) : base(diagnosticId, symbolKind)
        {
        }

        protected sealed override IEnumerable<Diagnostic> AnalyzeType(INamedTypeSymbol symbol, string commentXml) => AnalyzeSummary(symbol, commentXml);

        protected override IEnumerable<Diagnostic> AnalyzeMethod(IMethodSymbol symbol, string commentXml) => AnalyzeSummary(symbol, commentXml);

        protected virtual IEnumerable<Diagnostic> AnalyzeSummary(ISymbol symbol, IEnumerable<string> summaries) => Enumerable.Empty<Diagnostic>();

        protected IEnumerable<Diagnostic> AnalyzeSummary(ISymbol symbol) => AnalyzeSummary(symbol, symbol.GetDocumentationCommentXml());

        protected IEnumerable<Diagnostic> AnalyzeSummary(ISymbol symbol, string commentXml)
        {
            if (commentXml.IsNullOrWhiteSpace()) return Enumerable.Empty<Diagnostic>();

            var summaries = GetSummaries(commentXml);
            return summaries.Any() ? AnalyzeSummary(symbol, summaries) : Enumerable.Empty<Diagnostic>();
        }

        protected static ImmutableHashSet<string> GetSummaries(string commentXml) => GetComments(commentXml, "summary").WithoutParaTags().Select(_ => _.Trim()).ToImmutableHashSet();
    }
}