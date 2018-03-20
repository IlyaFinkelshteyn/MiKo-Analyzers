﻿using System.Collections.Generic;

using Microsoft.CodeAnalysis.Diagnostics;

using NUnit.Framework;

using TestHelper;

namespace MiKoSolutions.Analyzers.Rules.Naming
{
    [TestFixture]
    public sealed class MiKo_1105_MockNamingAnalyzerTests : CodeFixVerifier
    {
        [Test]
        public void No_issue_is_reported_for_empty_class() => No_issue_is_reported_for(@"
public class TestMe
{
}
");

        [Test]
        public void No_issue_is_reported_for_correctly_named_field() => No_issue_is_reported_for(@"
public class TestMe
{
    private int _something;
}
");

        [Test]
        public void An_issue_is_reported_for_incorrectly_named_field([ValueSource(nameof(WrongNames))] string name) => An_issue_is_reported_for(@"
public class TestMe
{
    private int _" + name + @";
}
");

        [Test]
        public void No_issue_is_reported_for_correctly_named_variable() => No_issue_is_reported_for(@"
public class TestMe
{
    public void DoSomething()
    {
        int i = 0;
    }
}
");

        [Test]
        public void An_issue_is_reported_for_incorrectly_named_variable([ValueSource(nameof(WrongNames))] string name) => An_issue_is_reported_for(@"
public class TestMe
{
    public void DoSomething()
    {
        int " + name + @" = 0;
    }
}
");

        [Test]
        public void An_issue_is_reported_for_incorrectly_named_variable_on_mukti_variable_declaration([ValueSource(nameof(WrongNames))] string name) => An_issue_is_reported_for(@"
public class TestMe
{
    public void DoSomething()
    {
        int i = 0, " + name + @" = 0;
    }
}
");

        protected override string GetDiagnosticId() => MiKo_1105_MockNamingAnalyzer.Id;

        protected override DiagnosticAnalyzer GetObjectUnderTest() => new MiKo_1105_MockNamingAnalyzer();

        private static IEnumerable<string> WrongNames() => new[]
                                                               {
                                                                   "somethingMock",
                                                                   "mock",
                                                                   "MockManager",
                                                                   "somethingStub",
                                                                   "stub",
                                                                   "StubManager",
                                                               };
    }
}