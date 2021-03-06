﻿using Microsoft.CodeAnalysis.Diagnostics;

using NUnit.Framework;

using TestHelper;

namespace MiKoSolutions.Analyzers.Rules.Maintainability
{
    [TestFixture]
    public sealed class MiKo_3050_DependencyPropertyPublicStaticReadOnlyFieldAnalyzerTests : CodeFixVerifier
    {
        [Test]
        public void No_issue_is_reported_for_non_DependencyProperty_field() => No_issue_is_reported_for(@"
using System.Windows;

namespace Bla
{
    public class TestMe
    {
        private int m_field;
    }
}
");

        [Test]
        public void No_issue_is_reported_for_public_static_readonly_DependencyProperty_field() => No_issue_is_reported_for(@"
using System.Windows;

namespace Bla
{
    public class TestMe
    {
        public static readonly DependencyProperty m_fieldProperty;
    }
}
");

        [Test]
        public void An_issue_is_reported_for_non_public_static_readonly_DependencyProperty_field([Values("protected", "internal", "protected internal", "private", "")] string visibility)
            => An_issue_is_reported_for(@"
using System.Windows;

namespace Bla
{
    public class TestMe
    {
        " + visibility + @" static readonly DependencyProperty m_fieldProperty;
    }
}
");

        [Test]
        public void An_issue_is_reported_for_static_only_DependencyProperty_field() => An_issue_is_reported_for(@"
using System.Windows;

namespace Bla
{
    public class TestMe
    {
        public static DependencyProperty m_fieldProperty;
    }
}
");

        [Test]
        public void An_issue_is_reported_for_readonly_only_DependencyProperty_field() => An_issue_is_reported_for(@"
using System.Windows;

namespace Bla
{
    public class TestMe
    {
        public readonly DependencyProperty m_fieldProperty;
    }
}
");

        [Test]
        public void An_issue_is_reported_for_non_static_non_readonly_DependencyProperty_field() => An_issue_is_reported_for(@"
using System.Windows;

namespace Bla
{
    public class TestMe
    {
        public DependencyProperty m_fieldProperty;
    }
}
");

        protected override string GetDiagnosticId() => MiKo_3050_DependencyPropertyPublicStaticReadOnlyFieldAnalyzer.Id;

        protected override DiagnosticAnalyzer GetObjectUnderTest() => new MiKo_3050_DependencyPropertyPublicStaticReadOnlyFieldAnalyzer();
    }
}