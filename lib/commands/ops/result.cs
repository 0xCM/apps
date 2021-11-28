//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Cmd
    {
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
    }
}