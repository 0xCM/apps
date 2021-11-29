//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ClrDefs
    {
        public class LiteralProvider : TypeDef
        {
            public Index<LiteralField> Fields;

            public LiteralProvider(Identifier ns, Identifier name, LiteralField[] fields, TextBlock desc)
            {
                Namespace = ns;
                Name = name;
                Description = desc;
                Fields = fields;
                Access = ClrAccessKind.Public;
            }
        }
    }
}