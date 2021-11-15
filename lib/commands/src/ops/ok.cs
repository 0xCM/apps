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
    }
}