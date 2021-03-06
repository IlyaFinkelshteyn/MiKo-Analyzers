﻿using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;

namespace MiKoSolutions.Analyzers.Rules.Documentation
{
    public abstract class ParamDocumentationAnalyzer : DocumentationAnalyzer
    {
        protected ParamDocumentationAnalyzer(string diagnosticId) : base(diagnosticId, SymbolKind.Method)
        {
        }

        protected sealed override IEnumerable<Diagnostic> AnalyzeMethod(IMethodSymbol symbol, string commentXml) => AnalyzeParameters(symbol, commentXml);

        protected virtual bool ShallAnalyzeParameter(IParameterSymbol parameter) => true;

        protected virtual IEnumerable<Diagnostic> AnalyzeParameter(IParameterSymbol parameter, string comment) => Enumerable.Empty<Diagnostic>();

        protected IEnumerable<Diagnostic> AnalyzeParameters(IMethodSymbol symbol, string commentXml)
        {
            if (commentXml.IsNullOrWhiteSpace()) return Enumerable.Empty<Diagnostic>();

            List<Diagnostic> results = null;
            foreach (var parameter in symbol.Parameters.Where(ShallAnalyzeParameter))
            {
                var comment = GetParameterComment(parameter, commentXml);
                if (comment is null) continue;
                if (comment.EqualsAny(StringComparison.Ordinal, Constants.Comments.UnusedPhrase)) continue;

                AnalyzeParameters(parameter, comment, ref results);
            }

            return results ?? Enumerable.Empty<Diagnostic>();
        }

        private void AnalyzeParameters(IParameterSymbol parameter, string comment, ref List<Diagnostic> results)
        {
            var findings = AnalyzeParameter(parameter, comment);
            if (findings.Any())
            {
                if (results == null) results = new List<Diagnostic>();
                results.AddRange(findings);
            }
        }

        protected IEnumerable<Diagnostic> AnalyzeStartingPhrase(IParameterSymbol parameter, string comment, string[] phrase) => comment.StartsWithAny(StringComparison.Ordinal, phrase)
                                                                                                                                ? Enumerable.Empty<Diagnostic>()
                                                                                                                                : new[] { ReportIssue(parameter, parameter.Name, phrase.HumanizedConcatenated()) };
    }
}