﻿
using Microsoft.CodeAnalysis.Diagnostics;

using NUnit.Framework;

using TestHelper;

namespace MiKoSolutions.Analyzers.Rules.Naming
{
    [TestFixture]
    public sealed class MiKo_1101_TestClassesSuffixAnalyzerTests : CodeFixVerifier
    {
        [Test]
        public void No_issue_is_reported_for_non_test_class() => No_issue_is_reported_for(@"
public class TestMe
{
}
");

        [TestCaseSource(nameof(TestFixtures))]
        public void No_issue_is_reported_for_test_class_with_correct_suffix(string testClassAttribute) => No_issue_is_reported_for(@"
[" + testClassAttribute + @"]
public class TestMeTests
{
    public void DoSomething() { }
}
");

        [TestCaseSource(nameof(TestFixtures))]
        public void An_issue_is_reported_for_test_class_with_wrong_suffix(string testClassAttribute) => An_issue_is_reported_for(@"
[" + testClassAttribute + @"]
public class TestMe
{
    private void DoSomething() { }
}
");

        protected override string GetDiagnosticId() => MiKo_1101_TestClassesSuffixAnalyzer.Id;

        protected override DiagnosticAnalyzer GetObjectUnderTest() => new MiKo_1101_TestClassesSuffixAnalyzer();
    }
}