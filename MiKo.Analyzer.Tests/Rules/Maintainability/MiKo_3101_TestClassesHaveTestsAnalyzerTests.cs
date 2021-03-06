﻿using Microsoft.CodeAnalysis.Diagnostics;

using NUnit.Framework;

using TestHelper;

namespace MiKoSolutions.Analyzers.Rules.Maintainability
{
    [TestFixture]
    public sealed class MiKo_3101_TestClassesHaveTestsAnalyzerTests : CodeFixVerifier
    {
        [Test]
        public void No_issue_is_reported_for_non_test_class() => No_issue_is_reported_for(@"
public class TestMe
{
}
");

        [Test, Combinatorial]
        public void No_issue_is_reported_for_test_class_with_tests(
                                                                [ValueSource(nameof(TestFixtures))] string testClassAttribute,
                                                                [ValueSource(nameof(TestsExceptSetUpTearDowns))] string testAttribute)
            => No_issue_is_reported_for(@"
[" + testClassAttribute + @"]
public class TestMe
{
    [" + testAttribute + @"]
    public void DoSomething() { }
}
");

        [Test, Combinatorial]
        public void No_issue_is_reported_for_partial_test_class_with_tests(
                                                                        [ValueSource(nameof(TestFixtures))] string testClassAttribute,
                                                                        [ValueSource(nameof(TestsExceptSetUpTearDowns))] string testAttribute)
            => No_issue_is_reported_for(@"
public partial class TestMe
{
    [" + testAttribute + @"]
    public void DoSomething() { }
}

[" + testClassAttribute + @"]
public partial class TestMe
{
    private void DoSomethingElse() { }
}
");

        [Test, Combinatorial]
        public void No_issue_is_reported_for_test_class_with_multiple_base_classes_with_tests(
                                                                                        [ValueSource(nameof(TestFixtures))] string testClassAttribute,
                                                                                        [ValueSource(nameof(TestsExceptSetUpTearDowns))] string testAttribute)
            => No_issue_is_reported_for(@"
[" + testClassAttribute + @"]
public class TestMe3 : TestMe2
{
    private void DoSomething3() { }
}

public class TestMe2 : TestMe1
{
    [" + testAttribute + @"]
    private void DoSomething2() { }
}

public class TestMe1
{
    [" + testAttribute + @"]
    private void DoSomething1() { }
}
");


        [Test]
        public void An_issue_is_reported_for_test_class_without_tests([ValueSource(nameof(TestFixtures))] string testClassAttribute) => An_issue_is_reported_for(@"
[" + testClassAttribute + @"]
public class TestMe
{
    private void DoSomethingElse() { }
}
");

        [Test]
        public void An_issue_is_reported_for_test_class_with_multiple_base_classes_without_tests([ValueSource(nameof(TestFixtures))] string testClassAttribute) => An_issue_is_reported_for(@"
[" + testClassAttribute + @"]
public class TestMe3 : TestMe2
{
    private void DoSomething3() { }
}

public class TestMe2 : TestMe1
{
    private void DoSomething2() { }
}

public class TestMe1
{
    private void DoSomething1() { }
}
");

        protected override string GetDiagnosticId() => MiKo_3101_TestClassesHaveTestsAnalyzer.Id;

        protected override DiagnosticAnalyzer GetObjectUnderTest() => new MiKo_3101_TestClassesHaveTestsAnalyzer();
    }
}