//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct XedModels
    {
        public sealed class FieldKinds : PairedLookup<FieldKind,FieldInfo>
        {
            static FieldInfo[] fields = typeof(OpState).DeclaredInstanceFields().Tagged<OperandKindAttribute>();

            static Dictionary<FieldKind,FieldInfo> kinds = fields.Select(f => (f.Tag<OperandKindAttribute>().Require().Kind,f)).ToDictionary();

            public FieldKinds()
                : base(kinds)
            {

            }
        }
    }
}