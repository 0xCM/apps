//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public sealed class FieldLookup : PairedLookup<FieldKind,FieldInfo>
        {
            static FieldInfo[] fields = typeof(RuleState).DeclaredInstanceFields().Tagged<RuleOperandAttribute>();

            static Dictionary<FieldKind,FieldInfo> kinds = fields.Select(f => (f.Tag<RuleOperandAttribute>().Require().Kind,f)).ToDictionary();

            public FieldLookup()
                : base(kinds)
            {

            }
        }
    }
}