//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static CsPatterns;

    partial class StringTables
    {
        public static uint csharp2(StringTableSpec spec, StreamWriter dst)
        {
            dst.WriteLine(string.Format("namespace {0}", spec.Namespace));
            dst.WriteLine(Open());
            dst.WriteLine(string.Format("    using {0};", "System"));
            dst.WriteLine();
            dst.WriteLine(string.Format("    using static {0};", "core"));
            dst.WriteLine();
            dst.WriteLine(create(spec, spec.Entries).Format(4));
            dst.WriteLine(Close());
            return (uint)spec.Entries.Length;
        }
    }
}