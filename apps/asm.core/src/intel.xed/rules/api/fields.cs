//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using Asm;

    partial class XedRules
    {
        public static Index<RuleFieldSpec> fields()
        {
            var src = typeof(RuleState).InstanceFields().Tagged<RuleFieldAttribute>();
            var dst = alloc<RuleFieldSpec>(src.Length);

            var total = z16;
            for(var i=z16; i<src.Length; i++)
            {
                ref readonly var field = ref skip(src,i);
                var tag = field.Tag<RuleFieldAttribute>().Require();
                ref var record = ref seek(dst,i);
                var dw = datawidth(field.FieldType);
                total = (ushort)(total + (dw/8));
                record.Pos = i;
                record.Name = field.Name;
                record.Type = typename(field.FieldType);
                record.FieldWidth = tag.Width;
                record.DataWidth = dw;
                record.TotalSize = total;
                record.Kind = tag.Kind;
            }
            return dst;
        }

        static string typename(Type src)
        {
            var dst = src.DisplayName();
            if(src.IsEnum)
                dst = string.Format("enum<{0}>", src.Name);
            else if(src == typeof(ByteBlock14))
                dst = string.Format("block<{0}>", 14);
            return dst;

        }

        static ushort datawidth(Type src)
        {
            var result = z16;
            if(src.IsEnum)
                result = (ushort)NativeSizes.convert(PrimalBits.width(Enums.@base(src))).Width;
            else if(src == typeof(bit) || src == typeof(byte) || src == typeof(Hex8) || src == typeof(imm8) || src == typeof(uint4))
                result = 8;
            else if(src == typeof(ushort))
                result = 16;
            else if(src == typeof(Disp))
                result = 72;
            else if(src == typeof(Disp64) || src == typeof(imm64))
                result = 64;
            else if(src == typeof(ByteBlock16))
                result = 128;
            else if(src == typeof(Imm))
                result = 72;
            else if(src == typeof(ByteBlock14))
                result = 14*8;
            return result;
        }
    }
}