﻿using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MiKoSolutions.Analyzers.Rules.Naming
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class MiKo_1001_EventArgsParameterAnalyzer : NamingAnalyzer
    {
        public const string Id = "MiKo_1001";

        public MiKo_1001_EventArgsParameterAnalyzer() : base(Id)
        {
        }

        protected override IEnumerable<Diagnostic> AnalyzeMethod(IMethodSymbol method)
        {
            if (method.IsOverride) return Enumerable.Empty<Diagnostic>();

            // ignore the method as it is handled by EventHandlingMethodParametersAnalyzer
            if (method.IsEventHandler()) return Enumerable.Empty<Diagnostic>();

            // ignore the setter as the name there has to be 'value'
            if (method.MethodKind == MethodKind.PropertySet) return Enumerable.Empty<Diagnostic>();

            var parameters = method.Parameters.Where(_ => _.Type.IsEventArgs()).ToList();
            switch (parameters.Count)
            {
                case 0: return Enumerable.Empty<Diagnostic>();
                case 1:
                    {
                        var expected = method.Name != nameof(Equals) ? "e" : "other";

                        var parameter = parameters[0];
                        return parameter.Name != expected
                                   ? new[] { ReportIssue(parameter, expected) }
                                   : Enumerable.Empty<Diagnostic>();
                    }

                default:
                    {
                        var i = 0;
                        var diagnostics = new List<Diagnostic>(parameters.Count);
                        foreach (var parameter in parameters)
                        {
                            var parameterName = parameter.Name;

                            var expected = "e" + (++i);
                            if (parameterName != expected)
                            {
                                diagnostics.Add(ReportIssue(parameter, expected));
                            }
                        }

                        return diagnostics;
                    }
            }
        }
    }
}