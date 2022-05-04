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

        static FieldDefs _Defs;

        static Type[] EffectiveFieldTypes;

        [MethodImpl(Inline)]
        public static ref readonly FieldDef field(FieldKind kind)
            => ref _Defs[kind];

        public static ref readonly FieldDefs Defs
        {
            [MethodImpl(Inline)]
            get => ref _Defs;
        }

        static XedFields()
        {
            _Defs = CalcFieldDefs();
            EffectiveFieldTypes = CalcEffectiveTypes();
        }
    }
}