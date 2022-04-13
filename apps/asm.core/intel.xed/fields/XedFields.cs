//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    [ApiHost]
    public partial class XedFields
    {
        const string xed = nameof(xed);

        public sealed class EffectiveFields : TokenSet<EffectiveFields>
        {
            public override string Name
                => "xed.field.domains";

            public override Type[] Types()
                => EffectiveFieldTypes.Where(t => t.IsEnum);
        }

        static Index<FieldKind,ReflectedField> _Reflected;

        static Index<FieldKind,FieldSpec> _Specs;

        public static ref readonly Index<FieldKind,FieldSpec> Specs
        {
            [MethodImpl(Inline)]
            get => ref _Specs;
        }

        public static Index<FieldKind,ReflectedField> Reflected => _Reflected;

        static Index<FieldKind,Type> EffectiveFieldTypes;

        static XedFields()
        {
            init();
        }
    }
}