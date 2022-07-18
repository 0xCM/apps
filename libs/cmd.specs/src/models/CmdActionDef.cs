//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct CmdActionDef
    {
        public Name ActionName;

        public Seq<Name> OpNames;

        public Seq<TextBlock> OpDescriptions;

    }
}