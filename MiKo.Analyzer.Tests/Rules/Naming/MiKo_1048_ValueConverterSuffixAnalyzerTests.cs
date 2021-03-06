﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Microsoft.CodeAnalysis.Diagnostics;

using NUnit.Framework;

using TestHelper;

namespace MiKoSolutions.Analyzers.Rules.Naming
{
    [TestFixture]
    public sealed class MiKo_1048_ValueConverterSuffixAnalyzerTests : CodeFixVerifier
    {
        [Test]
        public void No_issue_is_reported_for_non_converter_class() => No_issue_is_reported_for(@"
using System;

public class TestMe
{
}
");

        [Test]
        public void No_issue_is_reported_for_correctly_named_converter_class([ValueSource(nameof(ConverterInterfaces))] string interfaceName) => No_issue_is_reported_for(@"
using System;
using System.Windows.Data;

public class TestMeConverter : " + interfaceName + @"
{
}
");

        [Test]
        public void An_issue_is_reported_for_incorrectly_named_converter_class([ValueSource(nameof(ConverterInterfaces))] string interfaceName) => An_issue_is_reported_for(@"
using System;
using System.Windows.Data;

public class TestMe : " + interfaceName + @"
{
}
");

        protected override string GetDiagnosticId() => MiKo_1048_ValueConverterSuffixAnalyzer.Id;

        protected override DiagnosticAnalyzer GetObjectUnderTest() => new MiKo_1048_ValueConverterSuffixAnalyzer();

        [ExcludeFromCodeCoverage]
        private static IEnumerable<string> ConverterInterfaces() => new[]
                                                               {
                                                                   "IValueConverter",
                                                                   "IMultiValueConverter",
                                                                   "System.Windows.Data.IValueConverter",
                                                                   "System.Windows.Data.IMultiValueConverter",
                                                               };
    }
}