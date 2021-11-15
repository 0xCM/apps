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

    public readonly struct FormatCode<C> : IFormatCodeHost<FormatCode<FormatCodeKind,C>,FormatCodeKind,C>
    {
        public readonly FormatCodeKind Kind {get;}

        public readonly C Code {get;}

        [MethodImpl(Inline)]
        public FormatCode(FormatCodeKind k, C code)
        {
            Kind = k;
            Code = code;
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
        public static implicit operator FormatCode<C>((FormatCodeKind kind, C code) src)
            => new FormatCode<C>(src.kind, src.code);

        [MethodImpl(Inline)]
        public static implicit operator FormatCode<C>(FormatCode<FormatCodeKind,C> src)
            => new FormatCode<C>(src.Kind, src.Code);
    }
}