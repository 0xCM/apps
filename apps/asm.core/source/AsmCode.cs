//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct AsmCode
    {
        public readonly SourceText Source;

        public readonly MemoryAddress Location;

        public readonly AsmHexRef AsmHex;

        [MethodImpl(Inline)]
        public AsmCode(MemoryAddress loc, SourceText asm, AsmHexRef code)
        {
            Location = loc;
            Source = asm;
            AsmHex = code;
        }

        public string ToAsmString()
        {
            const string RenderPattern = "{0,-80} {1} {2}";
            var dst = text.buffer();
            var marker = (char)AsmCommentMarker.Hash;
            if(AsmInlineComment.parse(Source.Cells, out var comment))
            {
                marker = (char)comment.Marker;
                var prior = comment.Content;
                var asm = text.trim(text.left(Source.Format(), marker));
                dst.AppendFormat(RenderPattern, asm, marker, string.Format("{0,-42} | {1}", AsmHex.Format(), prior));
            }
            else
                dst.AppendFormat(RenderPattern, Source, marker, AsmHex.Format());

            return dst.Emit();
        }

        public string Format()
        {
            var dst = text.buffer();
            dst.AppendFormat("{0,-8}", Location.Format(4));
            dst.AppendFormat("{0,-80}", Source);
            dst.AppendFormat("# {0}", AsmHex.Format());
            return dst.Emit();
        }


        public override string ToString()
            => Format();
    }
}