//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1), Record(TableId)]
    public readonly struct ShellCmd : IShellCmd<ShellCmd>
    {
        const string TableId = "cmd.shell";

        public readonly PartId Part;

        public readonly asci32 Host;

        public readonly asci32 Name;

        [MethodImpl(Inline)]
        public ShellCmd(PartId part, string host, string name)
        {
            Part = part;
            Host = host;
            Name = name;
        }
    }
}