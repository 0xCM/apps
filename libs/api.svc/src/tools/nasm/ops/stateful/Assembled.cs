//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Z0.Asm;

    using static core;

    partial class Nasm
    {
        public ref AssembledAsm Assembled(in NasmEncoding src, out AssembledAsm dst)
        {
            dst.Bitstring = FormatBitstring(src.Encoded);
            dst.Id = EncodingId.from(src.Offset, src.Encoded);
            dst.IP = src.Offset;
            dst.Encoded = src.Encoded;
            AsmExpr.parse(src.SourceText, out dst.Asm);
            dst.SourceLine = src.LineNumber;
            return ref dst;
        }

        public Index<AssembledAsm> Assembled(ReadOnlySpan<NasmCodeBlock> blocks)
        {
            var dst = list<AssembledAsm>();
            var count = blocks.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                var code = block.Code.View;
                for(var j=0; j<code.Length; j++)
                    dst.Add(Assembled(skip(code,j), out var a));
            }
            return dst.ToArray();
        }
    }
}