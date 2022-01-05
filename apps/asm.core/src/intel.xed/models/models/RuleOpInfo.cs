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

            public readonly byte Width;

            readonly bool UseWidth;

            public RuleOpInfo(RuleOpName name, ulong value)
            {
                Name = name;
                Value = value;
                Width = 64;
                UseWidth = false;
            }

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

            public RuleOpInfo(RuleOpName name, XedRegId value)
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
    }
}