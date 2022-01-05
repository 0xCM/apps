//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct EncodingOffsets
    {
        public static EncodingOffsets init()
        {
            var dst = new EncodingOffsets();
            dst.OpCode = -1;
            dst.ModRm = -1;
            dst.Sib = -1;
            dst.Imm0 = -1;
            dst.Disp = -1;
            return dst;
        }

        public sbyte OpCode;

        public sbyte ModRm;

        public sbyte Sib;

        public sbyte Imm0;

        public sbyte Disp;

        public string Format()
        {
            var dst = text.buffer();
            dst.Append(Chars.LBrace);
            dst.AppendFormat("{0}={1}", "opcode", OpCode);
            if(ModRm > 0)
                dst.AppendFormat(", {0}={1}", "modrm", ModRm);
            if(Sib > 0)
                dst.AppendFormat(", {0}={1}", "sib",  Sib);
            if(Disp > 0)
                dst.AppendFormat(", {0}={1}", "disp", Disp);
            if(Imm0 > 0)
                dst.AppendFormat(", {0}={1}", "imm0", Imm0);
            dst.Append(Chars.RBrace);
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}