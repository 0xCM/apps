//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct AsmCode
    {
        public readonly SourceText Asm;

        public readonly MemoryAddress IP;

        public readonly AsmHexRef Encoded;

        [MethodImpl(Inline)]
        public AsmCode(SourceText asm, MemoryAddress loc, AsmHexRef code)
        {
            IP = loc;
            Asm = asm;
            Encoded = code;
        }

        public string ToAsmString()
        {
            const string RenderPattern = "{0,-80} {1} {2}";
            var dst = text.buffer();
            var marker = (char)AsmCommentMarker.Hash;
            if(AsmParser.comment(Asm.Cells, out var comment))
            {
                marker = (char)comment.Marker;
                var prior = comment.Content;
                var asm = text.trim(text.left(Asm.Format(), marker));
                dst.AppendFormat(RenderPattern, asm, marker, string.Format("{0,-42} | {1}", Encoded.Format(), prior));
            }
            else
                dst.AppendFormat(RenderPattern, Asm, marker, Encoded.Format());

            return dst.Emit();
        }

        public string Format()
        {
            var dst = text.buffer();
            dst.AppendFormat("{0,-8}", IP);
            dst.AppendFormat("{0,-80}", Asm);
            dst.AppendFormat("# {0}", Encoded.Format());
            return dst.Emit();
        }


        public override string ToString()
            => Format();

        public static AsmCode Empty => default;
    }
}