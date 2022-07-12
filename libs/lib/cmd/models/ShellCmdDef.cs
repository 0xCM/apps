//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ShellCmdDef : CmdDef<ShellCmdDef>
    {
        public readonly asci32 CmdName;

        public readonly CmdActionKind Kind;

        public readonly object Host;

        public readonly MethodInfo Method;

        public readonly CmdUri Uri;

        [MethodImpl(Inline)]
        public ShellCmdDef(asci32 name, CmdActionKind kind, MethodInfo method, object host)
        {
            CmdName = name;
            Kind = kind;
            Host = Require.notnull(host);
            Method = Require.notnull(method);
            Uri = CmdUri.define(host.GetType().Assembly.PartName(), host.GetType().DisplayName(), CmdName);
        }

        public string Format()
            => Uri.Format();

        public override string ToString()
            => Format();
    }
}