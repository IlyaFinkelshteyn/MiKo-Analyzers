﻿using Microsoft.CodeAnalysis.Diagnostics;

using NUnit.Framework;

using TestHelper;

namespace MiKoSolutions.Analyzers.Rules.Documentation
{
    [TestFixture]
    public sealed class MiKo_2043_DelegateSummaryAnalyzerTests : CodeFixVerifier
    {
        [Test]
        public void No_issue_is_reported_for_undocumented_class() => No_issue_is_reported_for(@"
using System;

public class TestMe
{
}
");

        [Test]
        public void No_issue_is_reported_for_documented_class() => No_issue_is_reported_for(@"
using System;

/// <summary>
/// Some documentation.
/// </summary>
public class TestMe
{
}
");

        [Test]
        public void No_issue_is_reported_for_undocumented_delegate() => No_issue_is_reported_for(@"
using System;

public delegate void TestMe();

");

        [Test]
        public void No_issue_is_reported_for_correctly_documented_delegate() => No_issue_is_reported_for(@"
using System;

/// <summary>
/// Encapsulates a method that does something.
/// </summary>
public delegate void TestMe();

");

        [Test]
        public void An_issue_is_reported_for_incorrectly_documented_delegate() => An_issue_is_reported_for(@"
using System;

/// <summary>
/// My delegate.
/// </summary>
public delegate void TestMe();

");

        protected override string GetDiagnosticId() => MiKo_2043_DelegateSummaryAnalyzer.Id;

        protected override DiagnosticAnalyzer GetObjectUnderTest() => new MiKo_2043_DelegateSummaryAnalyzer();
    }
}