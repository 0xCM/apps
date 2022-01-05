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

        public static AsmCodeAllocation create(ReadOnlySpan<IAsmStatementEncoding> src)
        {
            var indices = dict<AsmHexCode,uint>();
            var statements = dict<uint,AsmExprOffset>();
            var count = src.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var record = ref skip(src,i);
                include(record, i, indices, statements);
            }

            return allocation(indices,statements);
        }

        public static AsmCodeAllocation create(ReadOnlySpan<AsmStatementEncoding> src)
        {
            var count = src.Length;
            var boxed = alloc<IAsmStatementEncoding>(count);
            for(var i=0; i<count; i++)
                seek(boxed,i) = skip(src,i);
            return create(boxed);

            // var indices = dict<AsmHexCode,uint>();
            // var statements = dict<uint,string>();
            // var count = src.Length;
            // for(var i=0u; i<count; i++)
            // {
            //     ref readonly var record = ref skip(src,i);
            //     var asm = record.Asm.Format();

            //     if(indices.TryAdd(record.Encoding, i))
            //         statements[i] = asm;
            //     else
            //     {
            //         var i0 = indices[record.Encoding];
            //         if(statements[i0].Length > asm.Length)
            //             statements[i0] = asm;
            //     }
            // }

            // var length = gcalc.sum(map(statements.Values, v => (uint)v.Length));
            // var allocator = SourceAllocator.create(length);
            // var ucount = indices.Count;
            // var dst = alloc<AsmCode>(ucount);
            // var j=0u;
            // foreach(var key in indices.Keys)
            // {
            //     var index = indices[key];
            //     var asm = statements[index];
            //     allocator.Allocate(asm, out var source);
            //     seek(dst,j++) = new AsmCode(0,source,key);
            // }
            // return new AsmCodeAllocation(dst.Sort(), allocator);
        }

        internal AsmCodeAllocation(AsmCode[] data, IStringAllocator allocator)
            : base(data,allocator)
        {

        }
    }
}