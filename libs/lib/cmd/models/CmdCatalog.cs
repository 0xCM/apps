//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdCatalog
    {
        readonly CmdUriSeq ShellCmdSeq;

        public readonly PartId Part;

        public ref readonly CmdUriSeq ShellCommands
        {
            [MethodImpl(Inline)]
            get => ref ShellCmdSeq;
        }

        public CmdCatalog(PartId part, CmdUri[] defs)
        {
            Part = part;
            ShellCmdSeq =  defs;
        }
    }
}