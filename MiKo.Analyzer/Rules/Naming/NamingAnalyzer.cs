﻿using System;
using System.Collections.Concurrent;

using Microsoft.CodeAnalysis;

namespace MiKoSolutions.Analyzers.Rules.Naming
{
    public abstract class NamingAnalyzer : Analyzer
    {
        private static readonly ConcurrentDictionary<string, string> PluralNames = new ConcurrentDictionary<string, string>();

        protected NamingAnalyzer(string diagnosticId, SymbolKind kind = SymbolKind.Method, bool isEnabledByDefault = true) : base(nameof(Naming), diagnosticId, kind, isEnabledByDefault)
        {
        }

        protected Diagnostic AnalyzeCollectionSuffix(ISymbol symbol) => AnalyzeSuffix(symbol, "List")
                                                                     ?? AnalyzeSuffix(symbol, "Dictionary")
                                                                     ?? AnalyzeSuffix(symbol, "Collection")
                                                                     ?? AnalyzeSuffix(symbol, "Array")
                                                                     ?? AnalyzeSuffix(symbol, "HashSet");

        protected Diagnostic AnalyzeSuffix(ISymbol symbol, string suffix, StringComparison comparison = StringComparison.Ordinal)
        {
            var symbolName = symbol.Name;
            if (!symbolName.EndsWith(suffix, comparison)) return null;
            if (symbolName == "blackList" || symbolName == "whiteList") return null;

            var betterName = PluralNames.GetOrAdd(symbolName, _ => GetPluralName(symbolName, suffix, comparison));
            return ReportIssue(symbol, betterName);
        }

        private static string GetPluralName(string symbolName, string suffix, StringComparison comparison)
        {
            var name = symbolName.Substring(0, symbolName.Length - suffix.Length);
            if (name.EndsWith("y", comparison)) return name.Substring(0, name.Length - 1) + "ies";
            if (name.EndsWith("ss", comparison)) return name + "es";
            if (name.EndsWith("ed", comparison)) return name;
            if (name.EndsWith("child", comparison)) return name + "ren";
            if (name.EndsWith("children", comparison)) return name;
            if (name.EndsWith("complete", comparison)) return "all";
            if (name.EndsWith("Data", comparison)) return name;
            if (name.EndsWith("Datas", comparison)) return name.Substring(0, name.Length - 1);
            if (name.EndsWith("nformation", comparison)) return name;
            if (name.EndsWith("nformations", comparison)) return name.Substring(0, name.Length - 1);

            var pluralName = name;
            if (symbolName.IsEntityMarker())
                pluralName = name.Substring(0, name.Length - 5);
            else if (name.EndsWith("ToConvert", comparison))
                pluralName = name.Substring(0, name.Length - "ToConvert".Length);

            return pluralName.EndsWith("s", comparison) ? pluralName : pluralName + "s";
        }
    }
}