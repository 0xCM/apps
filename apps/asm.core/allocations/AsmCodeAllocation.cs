//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using Asm;

    using static core;

    public class AsmCodeAllocation : Allocation<AsmCode>
    {
        public static AsmCodeAllocation allocate(ReadOnlySpan<IAsmStatementEncoding> src)
        {
            var count = src.Length;
            var indices = dict<AsmHexCode,uint>();
            var statements = dict<uint,AsmExprOffset>();
            for(var i=0u; i<count; i++)
            {
                ref readonly var record = ref skip(src,i);
                include(record, i, indices, statements);
            }

            return allocation(indices,statements);
        }

        static void include(IAsmStatementEncoding src, uint i, Dictionary<AsmHexCode,uint> indices, Dictionary<uint,AsmExprOffset> statements)
        {
            var asm = src.Asm.Format();
            var encoding = src.Encoding;
            if(indices.TryAdd(src.Encoding, i))
                statements[i] = (src.Asm,src.Offset);
            else
            {
                var i0 = indices[encoding];
                if(statements[i0].Asm.Content.Length > asm.Length)
                    statements[i0] = (src.Asm,src.Offset);
            }
        }

        static SourceAllocator allocater(Dictionary<uint,AsmExprOffset> src)
        {
            var length = gcalc.sum(map(src.Values, v => (uint)v.Asm.Data.Length));
            return SourceAllocator.create(length);
        }

        static AsmCodeAllocation allocation(Dictionary<AsmHexCode,uint> indices, Dictionary<uint,AsmExprOffset> statements)
        {
            var alloc = allocater(statements);
            var ucount = indices.Count;
            var dst = core.alloc<AsmCode>(ucount);
            var j=0u;
            foreach(var key in indices.Keys)
            {
                var index = indices[key];
                var asm = statements[index];
                alloc.Allocate(asm.Asm.Data, out var source);
                seek(dst,j++) = new AsmCode(asm.Offset,source,key);
            }
            return new AsmCodeAllocation(dst.Sort(), alloc);
        }

        internal AsmCodeAllocation(AsmCode[] data, IStringAllocator allocator)
            : base(data,allocator)
        {

        }
    }
}