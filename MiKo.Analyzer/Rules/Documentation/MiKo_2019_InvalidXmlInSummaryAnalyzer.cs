﻿using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MiKoSolutions.Analyzers.Rules.Documentation
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class MiKo_2019_InvalidXmlInSummaryAnalyzer : SummaryDocumentationAnalyzer
    {
        public const string Id = "MiKo_2019";

        private const StringComparison Comparison = StringComparison.OrdinalIgnoreCase;

        public MiKo_2019_InvalidXmlInSummaryAnalyzer() : base(Id, (SymbolKind)(-1))
        {
        }

        public override void Initialize(AnalysisContext context)
        {
            Initialize(context, SymbolKind.Event);
            Initialize(context, SymbolKind.Field);
            Initialize(context, SymbolKind.Method);
            Initialize(context, SymbolKind.NamedType);
            Initialize(context, SymbolKind.Property);
        }

        protected override IEnumerable<Diagnostic> AnalyzeSummary(ISymbol symbol, IEnumerable<string> summaries)
        {
            List<Diagnostic> findings = null;

            foreach (var phrase in summaries.SelectMany(_ => Constants.Comments.InvalidSummaryCrefPhrases.Where(__ => _.Contains(__, Comparison))))
            {
                if (findings == null) findings = new List<Diagnostic>();
                findings.Add(ReportIssue(symbol, phrase + "/>"));
            }

            return findings ?? Enumerable.Empty<Diagnostic>();
        }
    }
}