﻿using System;

// ReSharper disable AssignNullToNotNullAttribute
namespace MiKoSolutions.Analyzers
{
    internal static class TypeNames
    {
        internal static readonly string CancellationToken = string.Intern(typeof(System.Threading.CancellationToken).FullName);
        internal static readonly string CancellationTokenSource = string.Intern(typeof(System.Threading.CancellationTokenSource).FullName);

        internal static readonly string Delegate = string.Intern(typeof(Delegate).FullName);

        internal static readonly string ArgumentException = string.Intern(typeof(ArgumentException).FullName);
        internal static readonly string ArgumentNullException = string.Intern(typeof(ArgumentNullException).FullName);
        internal static readonly string ArgumentOutOfRangeException = string.Intern(typeof(ArgumentOutOfRangeException).FullName);

        internal static readonly string InvalidOperationException = string.Intern(typeof(InvalidOperationException).FullName);
        internal static readonly string NotImplementedException = string.Intern(typeof(NotImplementedException).FullName);
        internal static readonly string NotSupportedException = string.Intern(typeof(NotSupportedException).FullName);

        internal const string InvalidEnumArgumentException = "System.ComponentModel." + nameof(InvalidEnumArgumentException);
    }
}