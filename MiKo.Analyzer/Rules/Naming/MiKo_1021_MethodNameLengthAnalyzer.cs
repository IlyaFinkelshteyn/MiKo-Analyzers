﻿using System.Collections.Generic;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MiKoSolutions.Analyzers.Rules.Naming
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class MiKo_1021_MethodNameLengthAnalyzer : NamingLengthAnalyzer
    {
        public const string Id = "MiKo_1021";

        public MiKo_1021_MethodNameLengthAnalyzer() : base(Id, SymbolKind.Method, Constants.MaxNamingLengths.Methods)
        {
        }

        protected override bool ShallAnalyze(IMethodSymbol method) => base.ShallAnalyze(method) && !method.IsSpecialAccessor() && !method.IsTestMethod();

        protected override IEnumerable<Diagnostic> AnalyzeName(IMethodSymbol symbol) => Analyze(symbol);
    }
}