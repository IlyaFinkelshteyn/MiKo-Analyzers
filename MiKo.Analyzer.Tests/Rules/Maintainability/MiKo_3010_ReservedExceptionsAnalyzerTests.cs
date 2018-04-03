﻿using System;
using System.Collections.Generic;

using System.Runtime.InteropServices;

using Microsoft.CodeAnalysis.Diagnostics;

using NUnit.Framework;

using TestHelper;

namespace MiKoSolutions.Analyzers.Rules.Maintainability
{
    [TestFixture]
    public sealed class MiKo_3010_ReservedExceptionsAnalyzerTests : CodeFixVerifier
    {
        [Test]
        public void No_issue_is_reported_for_normal_created_object([Values(nameof(Object), nameof(Int32), nameof(ArgumentException))] string type) => No_issue_is_reported_for(@"
using System;
using System.Runtime.InteropServices;

public class TestMe
{
    public void DoSomething()
    {
        var x = new " + type + @"();
    }
}
");
        [Test]
        public void An_issue_is_reported_for_forbidden_object([ValueSource(nameof(ForbiddenExceptions))] string type) => An_issue_is_reported_for(@"
using System;
using System.Runtime.InteropServices;

public class TestMe
{
    public void DoSomething()
    {
        var x = new " + type + @"();
    }
}
");

        private static IEnumerable<string> ForbiddenExceptions() => new HashSet<string>(new[]
                                                                                            {
                                                                                                nameof(Exception),
                                                                                                nameof(AccessViolationException),
                                                                                                nameof(IndexOutOfRangeException),
                                                                                                nameof(ExecutionEngineException),
                                                                                                nameof(NullReferenceException),
                                                                                                nameof(OutOfMemoryException),
                                                                                                nameof(StackOverflowException),
                                                                                                nameof(COMException),
                                                                                                nameof(SEHException),
                                                                                                "System.Exception",
                                                                                                "System.AccessViolationException",
                                                                                                "System.IndexOutOfRangeException",
                                                                                                "System.ExecutionEngineException",
                                                                                                "System.NullReferenceException",
                                                                                                "System.OutOfMemoryException",
                                                                                                "System.StackOverflowException",
                                                                                                "System.Runtime.InteropServices.COMException",
                                                                                                "System.Runtime.InteropServices.SEHException",
                                                                                            });

        protected override string GetDiagnosticId() => MiKo_3010_ReservedExceptionsAnalyzer.Id;

        protected override DiagnosticAnalyzer GetObjectUnderTest() => new MiKo_3010_ReservedExceptionsAnalyzer();
    }
}