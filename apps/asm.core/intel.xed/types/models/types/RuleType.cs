//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDataTypes
    {
        [StructLayout(StructLayout,Pack=1)]
        public readonly struct RuleType : IDataType<RuleType>
        {
            public const TypeKind Kind = TypeKind.Rule;

            public readonly RuleName Rule;

            public readonly TypeKey DataType;

            [MethodImpl(Inline)]
            public RuleType(RuleName seg, TypeKey type)
            {
                Rule = seg;
                DataType = type;
            }

            TypeKind IDataType.Kind
                => Kind;

            asci32 IDataType.Name
                => nameof(RuleName);
        }
    }
}