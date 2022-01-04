//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using Asm;

    using static core;

    public class AsmCodeAllocation : Allocation<AsmCode>
    {
        public static AsmCodeAllocation create(ReadOnlySpan<AsmStatementEncoding> src)
        {
            var indices = dict<AsmHexCode,uint>();
            var statements = dict<uint,string>();
            var count = src.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var record = ref skip(src,i);
                var asm = record.Asm.Format();

                if(indices.TryAdd(record.Encoding, i))
                    statements[i] = asm;
                else
                {
                    var i0 = indices[record.Encoding];
                    if(statements[i0].Length > asm.Length)
                        statements[i0] = asm;
                }
            }

            var length = gcalc.sum(map(statements.Values, v => (uint)v.Length));
            var allocator = SourceAllocator.create(length);
            var ucount = indices.Count;
            var dst = alloc<AsmCode>(ucount);
            var j=0u;
            foreach(var key in indices.Keys)
            {
                var index = indices[key];
                var asm = statements[index];
                allocator.Allocate(asm, out var source);
                seek(dst,j++) = new AsmCode(source,key);
            }
            return new AsmCodeAllocation(dst.Sort(), allocator);
        }

        internal AsmCodeAllocation(AsmCode[] data, IStringAllocator allocator)
            : base(data,allocator)
        {

        }
    }
}