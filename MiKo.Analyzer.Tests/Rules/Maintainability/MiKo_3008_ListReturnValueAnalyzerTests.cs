﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Microsoft.CodeAnalysis.Diagnostics;

using NUnit.Framework;

using TestHelper;

namespace MiKoSolutions.Analyzers.Rules.Maintainability
{
    [TestFixture]
    public sealed class MiKo_3008_ListReturnValueAnalyzerTests : CodeFixVerifier
    {
        [Test]
        public void No_issue_is_reported_for_allowed_type([ValueSource(nameof(AllowedTypes))] string returnValue) => No_issue_is_reported_for(@"
using System;
using System.Collections;
using System.Collections.Generic;

public interface TestMe
{
    public " + returnValue + @" GetSomething();
}
");

        [Test]
        public void An_issue_is_reported_for_forbidden_type([ValueSource(nameof(ForbiddenTypes))] string returnValue) => An_issue_is_reported_for(@"
using System;
using System.Collections;
using System.Collections.Generic;

public interface TestMe
{
    public " + returnValue + @" GetSomething();
}
");

        protected override string GetDiagnosticId() => MiKo_3008_ListReturnValueAnalyzer.Id;

        protected override DiagnosticAnalyzer GetObjectUnderTest() => new MiKo_3008_ListReturnValueAnalyzer();

        [ExcludeFromCodeCoverage]
        private static IEnumerable<string> AllowedTypes() => new[]
                                                                 {
                                                                     "string",
                                                                     "byte[]",
                                                                     "Byte[]",
                                                                     "int",
                                                                     "IReadOnlyCollection<string>",
                                                                     "IReadOnlyList<string>",
                                                                     "IReadOnlyDictionary<string, string>",
                                                                 };

        [ExcludeFromCodeCoverage]
        private static IEnumerable<string> ForbiddenTypes() => new[]
                                                                   {
                                                                       "ICollection<string>",
                                                                       "IList<string>",
                                                                       "List<string>",
                                                                       "IDictionary<string, string>",
                                                                       "Dictionary<string, string>",
// TODO: RKN                                                                       "Queue<string>",
// TODO: RKN                                                                       "Stack<string>",
// TODO: RKN                                                                       "HashSet<string>",
// TODO: RKN                                                                       "ArrayList",
                                                                   };
    }
}