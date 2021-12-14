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
        public static uint csharp(StringTableSyntax syntax, ReadOnlySpan<ListItem<string>> entries, StreamWriter dst)
        {
            dst.WriteLine(string.Format("namespace {0}", syntax.TableNs));
            dst.WriteLine(Open());
            dst.WriteLine(string.Format("    using {0};", "System"));
            dst.WriteLine();
            dst.WriteLine(string.Format("    using static {0};", "core"));
            dst.WriteLine();
            dst.WriteLine(create(syntax, entries).Format(4));
            dst.WriteLine(Close());
            return (uint)entries.Length;
        }
    }
}