//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct SeqPattern<T> : IDataPattern
        where T : unmanaged
    {
        public MatchKind MatchKind {get;}

        readonly Index<T> Data;

        [MethodImpl(Inline)]
        public SeqPattern(T[] src)
        {
            MatchKind = MatchKind.Enabled;
            Data = src;
        }

        public static implicit operator SeqPattern<T>(T[] src)
            => new SeqPattern<T>(src);
    }

    public struct TextPattern
    {

    }

}