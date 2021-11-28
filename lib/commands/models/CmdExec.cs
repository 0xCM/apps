//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [Cmd(CmdName)]
    public struct CmdExec : ICmd<CmdExec>
    {
        public const string CmdName = "exec-wf";

        public Name WorkflowName;

        [MethodImpl(Inline)]
        public CmdExec(Name name)
            => WorkflowName = name;

        [MethodImpl(Inline)]
        public bool Equals(CmdExec src)
            => WorkflowName.Equals(src.WorkflowName);

        public override int GetHashCode()
            => WorkflowName.GetHashCode();

        public override bool Equals(object src)
            => src is CmdExec c && Equals(c);

        [MethodImpl(Inline)]
        public static implicit operator CmdExec(string name)
            => new CmdExec(name);

        [MethodImpl(Inline)]
        public static implicit operator CmdExec(Name name)
            => new CmdExec(name);

        public static bool operator ==(CmdExec a, CmdExec b)
            => a.Equals(b);

        public static bool operator !=(CmdExec a, CmdExec b)
            => !a.Equals(b);

        public static CmdExec Empty => new CmdExec(Name.Empty);
    }
}