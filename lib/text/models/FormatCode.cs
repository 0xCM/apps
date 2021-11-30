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

    public readonly struct FormatCode : IFormatCodeHost<FormatCode<FormatCodeKind,char>,FormatCodeKind,char>
    {
        public readonly FormatCodeKind Kind {get;}

        public readonly char Code {get;}

        [MethodImpl(Inline)]
        public FormatCode(FormatCodeKind k, char c)
        {
            Kind = k;
            Code = c;
        }

        [MethodImpl(Inline)]
        public string Apply<T>(T src)
            => api.apply(this, src);

        [MethodImpl(Inline)]
        public static implicit operator FormatCode((FormatCodeKind kind, char code) src)
            => new FormatCode(src.kind, src.code);

        [MethodImpl(Inline)]
        public static implicit operator FormatCode(FormatCode<char> src)
            => new FormatCode(src.Kind, src.Code);
    }
}