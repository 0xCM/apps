//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static CsPatterns;

    partial class StringTables
    {
        public static uint csharp(StringTableSyntax syntax, ItemList<string> entries, StreamWriter dst)
        {
            dst.WriteLine(string.Format("namespace {0}", syntax.TableNs));
            dst.WriteLine(Open());
            dst.WriteLine(string.Format("    using {0};", "System"));
            dst.WriteLine();
            dst.WriteLine(string.Format("    using static {0};", "core"));
            dst.WriteLine();
            dst.WriteLine(format(4, define(syntax, entries)));
            dst.WriteLine(Close());
            return (uint)entries.Length;
        }

        public static uint csharp(StringTableSyntax syntax, ReadOnlySpan<string> values, StreamWriter dst)
        {
            dst.WriteLine(string.Format("namespace {0}", syntax.TableNs));
            dst.WriteLine(Open());
            dst.WriteLine(string.Format("    using {0};", "System"));
            dst.WriteLine();
            dst.WriteLine(string.Format("    using static {0};", "core"));
            dst.WriteLine();
            dst.WriteLine(format(4, define(syntax, values)));
            dst.WriteLine(Close());
            return (uint)values.Length;
        }
    }
}