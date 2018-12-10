﻿using Microsoft.CodeAnalysis.Diagnostics;

using NUnit.Framework;

using TestHelper;

namespace MiKoSolutions.Analyzers.Rules.Maintainability
{
    [TestFixture]
    public sealed class MiKo_3051_DependencyPropertyRegisterNameAnalyzerTests : CodeFixVerifier
    {
        [Test]
        public void No_issue_is_reported_for_non_DependencyProperty_field() => No_issue_is_reported_for(@"
using System.Windows;

namespace Bla
{
    public class TestMe
    {
        private int m_field = 5;
    }
}
");

        [Test]
        public void No_issue_is_reported_for_DependencyProperty_field_that_is_not_registered() => No_issue_is_reported_for(@"
using System.Windows;

namespace Bla
{
    public class TestMe
    {
        private DependencyProperty m_fieldProperty;
    }
}
");

        [Test]
        public void No_issue_is_reported_for_DependencyProperty_field_that_is_registered_with_nameof() => No_issue_is_reported_for(@"
using System.Windows;

namespace Bla
{
    public class TestMe
    {
        public int MyField { get; set; }
        
        private static readonly DependencyProperty m_fieldProperty = DependencyProperty.Register(nameof(MyField), typeof(int), typeof(TestMe), new PropertyMetadata(default(int)));
    }
}
");

        [Test]
        public void An_issue_is_reported_for_DependencyProperty_field_that_is_registered_with_StringLiteral() => An_issue_is_reported_for(@"
using System.Windows;

namespace Bla
{
    public class TestMe
    {
        public int MyField { get; set; }
        
        private static readonly DependencyProperty m_fieldProperty = DependencyProperty.Register(""MyField"", typeof(int), typeof(TestMe), new PropertyMetadata(default(int)));
    }
}
");

        protected override string GetDiagnosticId() => MiKo_3051_DependencyPropertyRegisterNameAnalyzer.Id;

        protected override DiagnosticAnalyzer GetObjectUnderTest() => new MiKo_3051_DependencyPropertyRegisterNameAnalyzer();
    }
}