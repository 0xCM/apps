//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ClrDefs
    {
        public abstract class Member
        {
            public Identifier Name;

            public TextBlock Description;

            public ClrAccessKind Access;

            public ClrModifierKind Modifiers;
        }
    }
}