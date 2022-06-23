//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ShellCmdDef : CmdDef<ShellCmdDef>
    {
        public override CmdKind CmdKind
            => CmdKind.ShellCmd;

        public asci32 CmdName {get;}

        public readonly CmdActionKind Kind;

        public readonly object Host;

        public readonly MethodInfo Method;

        [MethodImpl(Inline)]
        public ShellCmdDef(asci32 name, CmdActionKind kind, MethodInfo method, object host)
        {
            CmdName = name;
            Kind = kind;
            Host = host;
            Method = method;
        }
    }
}