﻿using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MiKoSolutions.Analyzers.Rules.Naming
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class MiKo_1012_FireMethodsAnalyzer : NamingAnalyzer
    {
        public const string Id = "MiKo_1012";

        public MiKo_1012_FireMethodsAnalyzer() : base(Id)
        {
        }

        protected override IEnumerable<Diagnostic> AnalyzeMethod(IMethodSymbol method)
        {
            var methodName = method.Name;
            var forbidden = methodName.ContainsAny("Fire", "_fire") && !methodName.ContainsAny("Firewall", "_firewall");
            return forbidden
                       ? new[] { ReportIssue(method, methodName.Replace("Fire", "Raise").Replace("_fire", "_raise")) }
                       : Enumerable.Empty<Diagnostic>();
        }
    }
}