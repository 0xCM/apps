//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial struct XedModels
    {
        public sealed class FieldKinds : PairedLookup<XedOpKind,FieldInfo>
        {
            public ConstLookup<XedOpKind,object> Values(in OpState src)
            {
                var dst = dict<XedOpKind,object>();
                var fields = RightValues;
                foreach(var f in fields)
                    dst.Add(this[f], f.GetValue(src));
                return dst;
            }

            static FieldInfo[] fields = typeof(OpState).DeclaredInstanceFields().Tagged<OperandKindAttribute>();

            static Dictionary<XedOpKind,FieldInfo> kinds = fields.Select(f => (f.Tag<OperandKindAttribute>().Require().Kind,f)).ToDictionary();

            public FieldKinds()
                : base(kinds)
            {

            }
        }
    }
}