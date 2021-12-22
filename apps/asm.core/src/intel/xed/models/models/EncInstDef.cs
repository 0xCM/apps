//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    partial struct XedModels
    {
        public struct EncInstDef
        {
            public IClass Class;

            public IForm Form;

            public Category Category;

            public Extension Extension;

            public IsaKind Isa;

            public DelimitedIndex<AttributeKind> Attributes;

            public DelimitedIndex<FlagAction> FlagActions;

            public Index<PatternOperands> PatternOps;
        }
    }
}