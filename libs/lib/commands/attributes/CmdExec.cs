//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Cmd(CmdName)]
    public struct CmdExec : ICmd<CmdExec>
    {
        public const string CmdName = "exec-wf";

        /// <summary>
        /// Defines a <see cref='CmdResult'/>
        /// </summary>
        /// <param name="cmd">The completed command</param>
        /// <param name="ok">Whether the command succeeded</param>
        [MethodImpl(Inline), Op]
        public static CmdResult result(ICmd cmd, bool ok)
            => new CmdResult(cmd.CmdId, ok);

        /// <summary>
        /// Defines a <see cref='CmdResult'/>
        /// </summary>
        /// <param name="cmd">The completed command</param>
        /// <param name="ok">Whether the command succeeded</param>
        [MethodImpl(Inline), Op]
        public static CmdResult result(ICmd cmd, bool ok, dynamic payload)
            => new CmdResult(cmd.CmdId, ok, payload);

        /// <summary>
        /// Defines a <see cref='CmdResult{C}'/>
        /// </summary>
        /// <param name="cmd">The completed command</param>
        /// <param name="ok">Whether the command succeeded</param>
        /// <typeparam name="C">The command type</typeparam>
        [MethodImpl(Inline), Op]
        public static CmdResult<C> result<C>(C cmd, bool ok)
            where C : struct, ICmd<C>
                => new CmdResult<C>(cmd, ok);

        /// <summary>
        /// Defines a <see cref='CmdResult{C}'/>
        /// </summary>
        /// <param name="cmd">The completed command</param>
        /// <param name="ok">Whether the command succeeded</param>
        /// <typeparam name="C">The command type</typeparam>
        [MethodImpl(Inline), Op]
        public static CmdResult<C> result<C>(C cmd, bool ok, dynamic payload)
            where C : struct, ICmd<C>
                => new CmdResult<C>(cmd, ok, payload);

        /// <summary>
        /// Defines a <see cref='CmdResult{C,P}'/>
        /// </summary>
        /// <param name="cmd">The completed command</param>
        /// <param name="payload"></param>
        /// <param name="ok">Whether the command succeeded</param>
        /// <typeparam name="C">The command type</typeparam>
        /// <typeparam name="P">The payload type</typeparam>
        [MethodImpl(Inline), Op]
        public static CmdResult<C,P> result<C,P>(C cmd, bool ok, P payload, string msg = EmptyString)
            where C : struct, ICmd<C>
                => new CmdResult<C,P>(cmd, ok, payload, msg);

        [MethodImpl(Inline)]
        public static CmdResult<C> ok<C>(C spec)
            where C : struct, ICmd
                => new CmdResult<C>(spec, true);

        [MethodImpl(Inline)]
        public static CmdResult<C> ok<C>(C spec, string msg)
            where C : struct, ICmd
                => new CmdResult<C>(spec, true, msg);

        [MethodImpl(Inline)]
        public static CmdResult<C,P> ok<C,P>(C spec, P payload, string msg = EmptyString)
            where C : struct, ICmd
                => new CmdResult<C,P>(spec, true, payload, msg);

        [MethodImpl(Inline), Op]
        public static CmdResult fail(ICmd cmd)
            => new CmdResult(cmd.CmdId, false);

        [MethodImpl(Inline), Op]
        public static CmdResult fail(ICmd cmd, Exception e)
            => new CmdResult(cmd.CmdId, e);

        public static CmdResult<C> fail<C>(C cmd)
            where C : struct, ICmd
                => new CmdResult<C>(cmd, false);

        public static CmdResult<C> fail<C>(C cmd, Exception e)
            where C : struct, ICmd
                => new CmdResult<C>(cmd, e);

        public static CmdResult<C> fail<C>(C cmd, string message)
            where C : struct, ICmd
                => new CmdResult<C>(cmd, false, message);

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