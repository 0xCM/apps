//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

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

            public Index<FlagAction> FlagActions;

            public Index<PatternOperands> PatternOps;

            public int CompareTo(InstDef src)
            {
                var result = ((ushort)Class).CompareTo((ushort)src.Class);
                if(result == 0)
                {
                    if(PatternOps.IsNonEmpty && src.PatternOps.IsNonEmpty)
                        result = PatternOps.First.Pattern.CompareTo(src.PatternOps.First.Pattern);
                }
                return result;
            }
        }
    }
}