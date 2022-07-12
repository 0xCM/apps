//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdCatalog
    {
        readonly ReadOnlySeq<ShellCmdDef> ShellCmdSeq;

        public readonly asci32 Host;

        public readonly PartId Part;

        public ref readonly ReadOnlySeq<ShellCmdDef> ShellCommands
        {
            [MethodImpl(Inline)]
            get => ref ShellCmdSeq;
        }

        public CmdCatalog(PartId part, asci32 host, ShellCmdDef[] defs)
        {
            Part = part;
            Host = host;
            ShellCmdSeq =  defs;
        }
    }
}