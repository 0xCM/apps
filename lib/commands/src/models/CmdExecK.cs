//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdExec<K>
        where K : unmanaged
    {
        public K Kind {get;}

        public CmdExec Enclosed {get;}

        [MethodImpl(Inline)]
        public CmdExec(K kind, CmdExec cmd)
        {
            Kind = kind;
            Enclosed = cmd;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdExec(CmdExec<K> src)
            => src.Enclosed;

        [MethodImpl(Inline)]
        public static implicit operator K(CmdExec<K> src)
            => src.Kind;

        [MethodImpl(Inline)]
        public static implicit operator CmdExec<K>((K kind, CmdExec cmd) src)
            => new CmdExec<K>(src.kind, src.cmd);
    }

}