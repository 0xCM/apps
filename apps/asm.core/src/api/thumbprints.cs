//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct asm
    {
        public static Outcome thumbprints(FS.FilePath src, out AsmThumbprint[] dst)
        {
            var buffer = list<AsmThumbprint>();
            var result = Outcome.Success;
            dst = sys.empty<AsmThumbprint>();
            using var reader = src.Utf8Reader();
            while(!reader.EndOfStream)
            {
                var data = reader.ReadLine();
                var statement = AsmExpr.parse(data.LeftOfFirst(Chars.Semicolon));
                result = AsmParser.thumbprint(data, out var thumbprint);
                if(result.Fail)
                    break;
                else
                    buffer.Add(thumbprint);
            }
            if(result)
                dst = buffer.ToArray();
            return result;
        }

        public static SortedSpan<AsmThumbprint> thumbprints(ReadOnlySpan<HostAsmRecord> src)
        {
            var distinct = hashset<AsmThumbprint>();
            iter(src, s => distinct.Add(asm.thumbprint(s)));
            return distinct.Array().ToSortedSpan();
        }
    }
}