//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct CmdSchema
    {
        public Name Workspace;

        public Name Group;

        public Name Name;

        public TextBlock Description;

        public ConstLookup<Name,CmdActionDef> Actions;

        public CmdUri Uri
            => CmdUri.define(Workspace,Group,Name);
    }
}