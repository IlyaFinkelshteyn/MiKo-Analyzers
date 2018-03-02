﻿using System.Collections.Generic;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MiKoSolutions.Analyzers.Rules.Documentation
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class MiKo_2022_OutParamDefaultPhraseAnalyzer : ParamDocumentationAnalyzer
    {
        public const string Id = "MiKo_2022";

        public MiKo_2022_OutParamDefaultPhraseAnalyzer() : base(Id)
        {
        }

        protected override bool ShallAnalyzeParameter(IParameterSymbol parameter) => parameter.RefKind == RefKind.Out;

        protected override IEnumerable<Diagnostic> AnalyzeParameter(IParameterSymbol parameter, string comment) => AnalyzeStartingPhrase(parameter, comment, Constants.Comments.OutParameterStartingPhrase);
    }
}