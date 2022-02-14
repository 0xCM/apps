//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PatternCell<T> : IDataPattern<T>
        where T : unmanaged
    {
        public MatchKind MatchKind {get;}

        public T Content {get;}

        [MethodImpl(Inline)]
        public PatternCell(MatchKind kind, T state)
        {
            Content = state;
            MatchKind = kind;
        }

        [MethodImpl(Inline)]
        public static implicit operator PatternCell<T>(T src)
            => new PatternCell<T>(MatchKind.Enabled, src);
    }
}