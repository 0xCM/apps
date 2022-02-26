//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial struct XedModels
    {
        public struct RuleOperand
        {
            public RuleOpName Name;

            public object Value;

            public readonly byte Width;

            readonly bool UseWidth;

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, Hex64 value)
            {
                Name = name;
                Value = value;
                Width = 64;
                UseWidth = false;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, long value)
            {
                Name = name;
                Value = value;
                Width = 64;
                UseWidth = false;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, long value, byte width)
            {
                Name = name;
                Value = value;
                Width = width;
                UseWidth = true;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, uint4 value)
            {
                Name = name;
                Value = value;
                Width = 4;
                UseWidth = false;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, XedRegId value)
            {
                Name = name;
                Value = value;
                Width = 16;
                UseWidth = false;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, string value)
            {
                Name = name;
                Value = value;
                Width = 0;
                UseWidth = false;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, Imm value)
            {
                Name = name;
                Value = value;
                Width = (byte)value.Width;
                UseWidth = false;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, Disp value)
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

            public static RuleOperand Empty => new RuleOperand(RuleOpName.None, 0, 0);
        }
    }
}