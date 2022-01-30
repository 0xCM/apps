//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public readonly struct AsmRecords
    {
        [MethodImpl(Inline), Op]
        public static AsmDisassembly disassembly(MemoryAddress offset, AsmExpr statement)
            => new AsmDisassembly(offset, statement);

        [Op]
        public static AsmDisassembly disassembly(MemoryAddress offset, AsmExpr statement, AsmHexCode code)
            => new AsmDisassembly(offset, statement, code, code);

        public static HexVector32 offsets(ReadOnlySpan<ProcessAsmRecord> src)
        {
            var count = src.Length;
            var buffer = alloc<Hex32>(count);
            offsets(src, buffer);
            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static uint offsets(ReadOnlySpan<ProcessAsmRecord> src, Span<Hex32> dst)
        {
            var count = (uint)src.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i).GlobalOffset;
            return count;
        }
    }
}