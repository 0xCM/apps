//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ClrDefs
    {
        public class TypeDef
        {
            public Identifier Namespace;

            public Identifier Name;

            public TextBlock Description;

            public ClrAccessKind Access;
        }
    }
}