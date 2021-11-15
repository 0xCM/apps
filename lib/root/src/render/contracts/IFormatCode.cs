//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static minicore;

    public interface IFormatCode : ITextual
    {
        FormatCodeKind Kind {get;}

        object Code {get;}

        string ITextual.Format()
            => string.Format("{0}:{1}", Code, Kind);

        string Slot
            => "{0:" +  $"{Code}" + "}";

        string Apply<T>(T src)
            => string.Format(Slot,src);
    }

    public interface IFormatCode<K,C> : IFormatCode
        where K : unmanaged
    {
        new K Kind {get;}

        FormatCodeKind IFormatCode.Kind
            => @as<K,FormatCodeKind>(Kind);

        new C Code {get;}

        object IFormatCode.Code
            => Code;
    }

    public interface IFormatCodeHost<H,K,C> : IFormatCode<K,C>
        where K : unmanaged
        where H : struct, IFormatCodeHost<H,K,C>
    {

    }
}