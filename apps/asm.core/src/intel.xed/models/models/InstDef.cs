//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial struct XedModels
    {
        public struct InstDef : IComparable<InstDef>
        {
            public IClass Class;

            public IForm Form;

            public Category Category;

            public Extension Extension;

            public IsaKind Isa;

            public Index<AttributeKind> Attributes;

            public Index<FlagAction> Flags;

            public Index<PatternOperands> PatternOps;

            public int CompareTo(InstDef src)
            {
                var result = ((ushort)Class).CompareTo((ushort)src.Class);
                if(result == 0)
                {
                    if(PatternOps.IsNonEmpty && src.PatternOps.IsNonEmpty)
                        result = PatternOps.First.Expr.CompareTo(src.PatternOps.First.Expr);
                }
                return result;
            }
        }
    }
}