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

        static ReflectedFields _ReflectedByPos;

        static ReflectedFields _ReflectedByIndex;

        static Index<FieldKind,Type> EffectiveFieldTypes;

        static FieldLookup _FieldLookup;

        [MethodImpl(Inline)]
        public static ref readonly ReflectedField field(FieldKind kind)
            => ref ByPosition[kind];

        public static ref readonly ReflectedFields ByPosition
        {
            [MethodImpl(Inline)]
            get => ref _ReflectedByPos;
        }

        static XedFields()
        {
            TypeInit();
        }
    }
}