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

    partial class AsmCmdService
    {
        [CmdOp(".gen-bit-seq")]
        Outcome GenBitSeq(CmdArgs args)
        {
            const byte CellWidth = 8;
            const uint CellCount = 512;
            Span<char> buffer = stackalloc char[CellWidth];
            var dst = Ws.Gen().Root + FS.file("bitseq", FS.Cs);
            var flow = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            writer.WriteLine("    public readonly struct GeneratedBits");
            writer.WriteLine("    {");
            writer.Write(string.Format("        public static ReadOnlySpan<byte> SequencedBits = new byte[{0}]", CellCount));
            writer.Write("{");
            for(var i=0; i<CellCount; i++)
            {
                byte b = (byte)i;
                var data = text.format(render(b, CellWidth, buffer));
                writer.Write(string.Format("0b{0}, ", data));
            }
            writer.WriteLine("};");
            writer.WriteLine("    }");
            EmittedFile(flow, CellCount);
            return true;
        }

        [MethodImpl(Inline), Op]
        static Span<char> render(byte src, byte width, Span<char> dst)
        {
            for(var j=0; j<width; j++)
                seek(dst, j) = @char(@bool(bit.test(src, (byte)j)));
            dst.Reverse();
            return dst;
        }
    }
}