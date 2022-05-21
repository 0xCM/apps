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
        public readonly record struct RuleType : IDataType<RuleType>
        {
            public readonly RuleName Rule;

            public readonly TypeKey DataType;

            [MethodImpl(Inline)]
            public RuleType(RuleName seg, TypeKey type)
            {
                Rule = seg;
                DataType = type;
            }

            public DataSize Size
                => throw new NotImplementedException();

            asci64 IDataType.Name
                => nameof(RuleName);
        }
    }
}