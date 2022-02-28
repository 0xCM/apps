//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public sealed class FieldKinds : PairedLookup<FieldKind,FieldInfo>
        {
            static FieldInfo[] fields = typeof(RuleState).DeclaredInstanceFields().Tagged<RuleOperandAttribute>();

            static Dictionary<FieldKind,FieldInfo> kinds = fields.Select(f => (f.Tag<RuleOperandAttribute>().Require().Kind,f)).ToDictionary();

            public FieldKinds()
                : base(kinds)
            {

            }
        }
    }
}