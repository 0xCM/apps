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

        static readonly Index<FieldKind,ReflectedField> _Specs;

        public static Index<FieldKind,ReflectedField> Specs => _Specs;

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

        static Index<FieldKind,ReflectedField> specs()
        {
            var kinds = Symbols.index<FieldKind>().Kinds;
            var count = kinds.Length;
            var src = typeof(RuleState).InstanceFields().Tagged<RuleFieldAttribute>();
            var fields = src.Map(f => (f.Tag<RuleFieldAttribute>().Require().Kind, f)).ToDictionary();
            var dst = alloc<ReflectedField>(count - 1);
            var total = z16;
            var types = alloc<Type>(count - 1);

            var k=0u;
            for(var i=1; i<count; i++,k++)
            {
                ref readonly var kind = ref skip(kinds,i);

                ref var record = ref seek(dst,k);
                ref var type = ref seek(types,k);
                if(fields.TryGetValue(kind, out var field))
                {
                    var tag = field.Tag<RuleFieldAttribute>().Require();
                    var dw = datawidth(field.FieldType);
                    type = tag.EffectiveType;
                    total = (ushort)(total + (dw/8));
                    record.Index = (ushort)kind;
                    record.EffectiveWidth = tag.Width;
                    record.FieldWidth = dw;
                    record.TotalSize = total;
                    record.Field = tag.Kind;
                    record.FieldType = new(kind,field.FieldType.DisplayName());
                    record.EffectiveType = new(kind,type.DisplayName());
                    record.Description = tag.Description;
                }
                else
                {
                    Errors.Throw($"{kind} is invalid");
                }
            }

            EffectiveFieldTypes = types;
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