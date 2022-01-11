//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct PatternCell<T> : IDataPattern<T>
        where T : unmanaged
    {
        public MatchKind MatchKind {get;}

        public T State {get;}

        [MethodImpl(Inline)]
        public PatternCell(MatchKind kind, T state)
        {
            State = state;
            MatchKind = kind;
        }

        [MethodImpl(Inline)]
        public static implicit operator PatternCell<T>(T src)
            => new PatternCell<T>(MatchKind.Enabled, src);
    }
}