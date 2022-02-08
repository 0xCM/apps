//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRecords;

    partial struct XedModels
    {
        public sealed class FieldKinds : PairedLookup<XedOpKind,FieldInfo>
        {
            static FieldInfo[] fields = typeof(OpState).DeclaredInstanceFields().Tagged<OperandKindAttribute>();

            static Dictionary<XedOpKind,FieldInfo> kinds = fields.Select(f => (f.Tag<OperandKindAttribute>().Require().Kind,f)).ToDictionary();

            public FieldKinds()
                : base(kinds)
            {

            }
        }
    }
}