//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;

    partial struct XedModels
    {
        public sealed class FieldKinds : PairedLookup<OpKind,FieldInfo>
        {
            static FieldInfo[] fields = typeof(OpState).DeclaredInstanceFields().Tagged<OperandKindAttribute>();

            static Dictionary<OpKind,FieldInfo> kinds = fields.Select(f => (f.Tag<OperandKindAttribute>().Require().Kind,f)).ToDictionary();

            public FieldKinds()
                : base(kinds)
            {

            }
        }
    }
}