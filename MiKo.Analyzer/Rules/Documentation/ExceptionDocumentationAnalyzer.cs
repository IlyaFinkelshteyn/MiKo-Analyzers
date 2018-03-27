﻿using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MiKoSolutions.Analyzers.Rules.Documentation
{
    public abstract class ExceptionDocumentationAnalyzer : DocumentationAnalyzer
    {
        protected ExceptionDocumentationAnalyzer(string diagnosticId, Type exceptionType) : this(diagnosticId, exceptionType.FullName)
        {
        }

        protected ExceptionDocumentationAnalyzer(string diagnosticId, string exceptionTypeFullName) : base(diagnosticId, (SymbolKind)(-1)) => m_exceptionTypeFullName = exceptionTypeFullName;

        protected override void InitializeCore(AnalysisContext context) => InitializeCore(context, SymbolKind.Method, SymbolKind.Property);

        protected override IEnumerable<Diagnostic> AnalyzeMethod(IMethodSymbol symbol, string commentXml) => AnalyzeExceptionComment(symbol, commentXml);

        protected override IEnumerable<Diagnostic> AnalyzeProperty(IPropertySymbol symbol, string commentXml) => AnalyzeExceptionComment(symbol, commentXml);

        protected virtual IEnumerable<Diagnostic> AnalyzeException(ISymbol symbol, string exceptionComment) => Enumerable.Empty<Diagnostic>();

        protected IEnumerable<Diagnostic> AnalyzeExceptionComment(ISymbol symbol, string commentXml)
        {
            if (commentXml.IsNullOrWhiteSpace()) return Enumerable.Empty<Diagnostic>();

            var comment = GetExceptionComment(m_exceptionTypeFullName, commentXml);
            return AnalyzeException(symbol, comment);
        }

        protected string ExceptionPhrase => string.Format(Constants.Comments.ExceptionPhrase, m_exceptionTypeFullName.GetNameOnlyPart());

        private readonly string m_exceptionTypeFullName;
    }
}