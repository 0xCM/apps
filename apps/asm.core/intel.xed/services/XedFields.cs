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
        const string xed = nameof(xed);

        public sealed class SymbolicFields : TokenSet<SymbolicFields>
        {
            public override string Name
                => "xed.field.domains";

            public override Type[] Types()
                => EffectiveFieldTypes.Where(t => t.IsEnum);
        }

        static readonly Index<FieldKind,RuleFieldSpec> _Specs;

        public static Index<FieldKind,RuleFieldSpec> Specs => _Specs;

        public static FieldKind kind(string src)
        {
            var i = text.index(src, Chars.Eq);
            var j = text.index(src, Chars.LBracket);
            var k = text.index(src, "!=");
            var result = FieldKind.INVALID;

            if(j>0)
            {
                var field = text.left(src, j);
                if(XedParsers.parse(field, out result))
                    return result;
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), field));
            }
            else if(k>0)
            {
                var field = text.left(src,k);
                if(XedParsers.parse(field, out result))
                    return result;
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), field));
            }
            else if(i > 0)
            {
                var field = text.left(src,i);
                if(XedParsers.parse(field, out result))
                    return result;
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), field));

            }
            if(XedParsers.parse(src, out result))
                return result;

            return result;
        }

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

        static Index<FieldKind,Type> EffectiveFieldTypes;

        static Index<FieldKind,RuleFieldSpec> specs()
        {
            var kinds = Symbols.index<FieldKind>().Kinds;
            var count = kinds.Length;
            var src = typeof(RuleState).InstanceFields().Tagged<RuleFieldAttribute>();
            var fields = src.Map(f => (f.Tag<RuleFieldAttribute>().Require().Kind, f)).ToDictionary();
            var dst = alloc<RuleFieldSpec>(count);
            var total = z16;
            var types = alloc<Type>(count);

            for(var i=z16; i<count; i++)
            {
                ref var record = ref seek(dst,i);
                ref readonly var kind = ref skip(kinds,i);
                ref var type = ref seek(types,i);
                if(fields.TryGetValue(kind, out var field))
                {
                    var tag = field.Tag<RuleFieldAttribute>().Require();
                    var dw = datawidth(field.FieldType);
                    type = tag.EffectiveType;
                    total = (ushort)(total + (dw/8));
                    record.Index = (ushort)kind;
                    record.FieldName = field.Name;
                    record.FieldWidth = tag.Width;
                    record.DataWidth = dw;
                    record.TotalSize = total;
                    record.FieldKind = tag.Kind;
                    record.DeclaredType = field.FieldType.DisplayName();
                    record.EffectiveType = type.DisplayName();
                    record.Description = tag.Description;
                }
                else
                {
                    record.FieldName = nameof(FieldKind.INVALID);
                    record.FieldKind = FieldKind.INVALID;
                    type = typeof(void);
                }
            }

            EffectiveFieldTypes = types;
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