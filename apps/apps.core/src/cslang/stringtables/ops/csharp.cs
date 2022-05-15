//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CsPatterns;

    partial class StringTables
    {
        public static uint csharp(in StringTableSyntax syntax, ItemList<string> src, ITextEmitter dst)
        {
            dst.WriteLine(string.Format("namespace {0}", syntax.TableNs));
            dst.WriteLine(Open());
            dst.WriteLine(string.Format("    using {0};", "System"));
            dst.WriteLine();
            dst.WriteLine(string.Format("    using static {0};", "core"));
            dst.WriteLine();
            dst.WriteLine(format(4, define(syntax, src)));
            dst.WriteLine(Close());
            return (uint)src.Length;
        }

        public static uint csharp(in StringTableSyntax syntax, ReadOnlySpan<string> src, ITextEmitter dst)
        {
            dst.WriteLine(string.Format("namespace {0}", syntax.TableNs));
            dst.WriteLine(Open());
            dst.WriteLine(string.Format("    using {0};", "System"));
            dst.WriteLine();
            dst.WriteLine(string.Format("    using static {0};", "core"));
            dst.WriteLine();
            dst.WriteLine(format(4, define(syntax, src)));
            dst.WriteLine(Close());
            return (uint)src.Length;
        }
    }
}