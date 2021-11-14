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
        public static Outcome load(FS.FilePath src, out HostAsmRecord[] dst)
        {
            var result = TextGrids.load(src, out var doc);
            dst = sys.empty<HostAsmRecord>();
            if(result.Fail)
                return result;

            dst = alloc<HostAsmRecord>(doc.RowCount);
            return AsmParser.row(doc,dst);
        }

        public static Outcome<uint> load(FS.FilePath src, Span<ProcessAsmRecord> dst)
        {
            var counter = 1u;
            var i = 0u;
            var max = dst.Length;
            using var reader = src.AsciReader();
            var header = reader.ReadLine();
            var line = reader.ReadLine();
            var result = Outcome.Success;
            while(line != null && result.Ok)
            {
                result = AsmParser.row(counter++, line, out seek(dst,i));
                if(result.Fail)
                    return result;
                else
                    i++;

                line = reader.ReadLine();
            }
            return i;
        }
    }
}