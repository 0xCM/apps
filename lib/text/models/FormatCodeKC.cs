//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = FormatCodes;

    public readonly struct FormatCode<K,C> : IFormatCodeHost<FormatCode<K,C>,K,C>
        where K : unmanaged
    {
        public readonly K Kind {get;}

        public readonly C Code {get;}

        [MethodImpl(Inline)]
        public FormatCode(K k, C c)
        {
            Kind = k;
            Code = c;
        }

        public string Slot
        {
            [MethodImpl(Inline)]
            get => api.slot(this);
        }

        [MethodImpl(Inline)]
        public string Apply<T>(T src)
            => api.apply(this, src);

        [MethodImpl(Inline)]
        public static implicit operator FormatCode<K,C>((K kind, C code) src)
            => new FormatCode<K,C>(src.kind, src.code);
    }
}