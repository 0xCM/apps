//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ShellCmdDef : ICmdDef
    {
        public readonly Name CmdName;

        public readonly CmdActionKind Kind;

        public readonly object Host;

        public readonly MethodInfo Method;

        public readonly CmdUri Uri;

        [MethodImpl(Inline)]
        public ShellCmdDef(Name name, CmdActionKind kind, MethodInfo method, object host)
        {
            CmdName = name;
            Kind = kind;
            Host = Require.notnull(host);
            Method = Require.notnull(method);
            Uri = CmdUri.define(host.GetType().Assembly.PartName().Format(), host.GetType().DisplayName(), CmdName);
        }

        ref readonly CmdUri ICmdDef.Uri
            => ref Uri;

        public string Format()
            => Uri.Format();

        public override string ToString()
            => Format();
    }
}