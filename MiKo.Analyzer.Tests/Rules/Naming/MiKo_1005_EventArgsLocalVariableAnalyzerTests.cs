﻿using Microsoft.CodeAnalysis.Diagnostics;

using NUnit.Framework;

using TestHelper;

namespace MiKoSolutions.Analyzers.Rules.Naming
{
    [TestFixture]
    public sealed class MiKo_1005_EventArgsLocalVariableAnalyzerTests : CodeFixVerifier
    {
        [Test]
        public void No_issue_is_reported_for_empty_method() => No_issue_is_reported_for(@"
using System;

public class TestMe
{
    public void DoSomething()
    {
    }
}
");

        [Test]
        public void No_issue_is_reported_for_method_with_non_EventArgs_variable() => No_issue_is_reported_for(@"
using System;

public class TestMe
{
    public void DoSomething()
    {
        int i = 0;
    }
}
");

        [Test]
        public void No_issue_is_reported_for_method_with_EventArgs_variable_with_correct_name() => No_issue_is_reported_for(@"
using System;

public class TestMe
{
    public void DoSomething()
    {
        EventArgs e = EventArgs.Empty;
    }
}
");
        [Test]
        public void No_issue_is_reported_for_method_with_var_EventArgs_variable_with_correct_name() => No_issue_is_reported_for(@"
using System;

public class TestMe
{
    public void DoSomething()
    {
        var e = EventArgs.Empty;
    }
}
");

        [Test]
        public void An_issue_is_reported_for_method_with_EventArgs_variable_with_incorrect_name() => An_issue_is_reported_for(@"
using System;

public class TestMe
{
    public void DoSomething()
    {
        EventArgs eventArgs = EventArgs.Empty;
    }
}
");
        [Test]
        public void An_issue_is_reported_for_method_with_var_EventArgs_variable_with_incorrect_name() => An_issue_is_reported_for(@"
using System;

public class TestMe
{
    public void DoSomething()
    {
        var eventArgs = EventArgs.Empty;
    }
}
");

        protected override string GetDiagnosticId() => MiKo_1005_EventArgsLocalVariableAnalyzer.Id;

        protected override DiagnosticAnalyzer GetObjectUnderTest() => new MiKo_1005_EventArgsLocalVariableAnalyzer();
    }
}