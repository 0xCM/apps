//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static Root;

    partial struct XedModels
    {
        public struct RuleOpInfo
        {
            public RuleOpName Name;

            public object Value;

            readonly byte Width;

            readonly bool UseWidth;

            public RuleOpInfo(RuleOpName name, ulong value)
            {
                Name = name;
                Value = value;
                Width = 64;
                UseWidth = false;
            }

// ((sbyte)value).FormatHex(zpad:false,specifier:true,uppercase:true);
            public RuleOpInfo(RuleOpName name, long value)
            {
                Name = name;
                Value = value;
                Width = 64;
                UseWidth = false;
            }

            public RuleOpInfo(RuleOpName name, long value, byte width)
            {
                Name = name;
                Value = value;
                Width = width;
                UseWidth = true;
            }

            public RuleOpInfo(RuleOpName name, uint4 value)
            {
                Name = name;
                Value = value;
                Width = 4;
                UseWidth = false;
            }

            public RuleOpInfo(RuleOpName name, RegId value)
            {
                Name = name;
                Value = value;
                Width = 16;
                UseWidth = false;
            }

            public RuleOpInfo(RuleOpName name, string value)
            {
                Name = name;
                Value = value;
                Width = 0;
                UseWidth = false;
            }

            public RuleOpInfo(RuleOpName name, ImmOp value)
            {
                Name = name;
                Value = value;
                Width = (byte)value.Width;
                UseWidth = false;
            }

            public RuleOpInfo(RuleOpName name, Disp value)
            {
                Name = name;
                Value = value;
                Width = (byte)value.Size.Code;
                UseWidth = false;
            }

            static string FormatHexInt(object src, byte width, bool signed)
                => src != null ? variant.integer(src, width, signed).FormatHex() : EmptyString;

            public string Format()
            {
                if(Value == null)
                    return EmptyString;

                var dst = EmptyString;
                var type = Value.GetType();
                var kind = type.NumericKind();
                if(UseWidth && Width != 0)
                    dst = FormatHexInt(Value, Width, kind.IsSigned());
                else
                    dst = Value.ToString();

                return dst;
            }

            public override string ToString()
                => Format();

            public static RuleOpInfo Empty => new RuleOpInfo(RuleOpName.None, EmptyString);
        }

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
                    dst.AppendFormat(", {0}={1}", "modrm",  ModRm);
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
}