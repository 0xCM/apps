//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules.FieldKind;
    using static XedRules;
    using static core;

    [ApiHost]
    public partial class XedFields
    {
        static readonly Index<FieldKind,RuleFieldSpec> _Specs;

        public static Index<FieldKind,RuleFieldSpec> Specs => _Specs;

        [Op]
        public static bool ispos(FieldKind field)
        {
            var result = false;
            switch(field)
            {
                case POS_NOMINAL_OPCODE:
                case POS_MODRM:
                case POS_SIB:
                case POS_IMM:
                case POS_IMM1:
                case POS_DISP:
                    result = true;
                break;
            }
            return result;
        }

        static Index<FieldKind,RuleFieldSpec> specs()
        {
            var kinds = Symbols.index<FieldKind>().Kinds;
            var count = kinds.Length;
            var src = typeof(RuleState).InstanceFields().Tagged<RuleFieldAttribute>();
            var fields = src.Map(f => (f.Tag<RuleFieldAttribute>().Require().Kind, f)).ToDictionary();
            var dst = alloc<RuleFieldSpec>(count);
            var total = z16;

            for(var i=z16; i<count; i++)
            {
                ref var record = ref seek(dst,i);
                ref readonly var kind = ref skip(kinds,i);
                if(fields.TryGetValue(kind, out var field))
                {
                    var tag = field.Tag<RuleFieldAttribute>().Require();
                    var dw = datawidth(field.FieldType);
                    total = (ushort)(total + (dw/8));
                    record.Index = (ushort)kind;
                    record.FieldName = field.Name;
                    record.FieldWidth = tag.Width;
                    record.DataWidth = dw;
                    record.TotalSize = total;
                    record.FieldKind = tag.Kind;
                    record.DeclaredType = typename(field.FieldType);
                    record.EffectiveType = typename(tag.EffectiveType);
                    record.Description = tag.Description;
                }
                else
                {
                    record.FieldName = nameof(FieldKind.INVALID);
                    record.FieldKind = FieldKind.INVALID;
                }
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

        static XedFields()
        {
            _Specs = specs();
        }
    }
}