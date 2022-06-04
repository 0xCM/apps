//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ResSeg
    {
        public readonly Identifier Name;

        public readonly MemorySeg Segment;

        [MethodImpl(Inline)]
        public ResSeg(Identifier name, in MemorySeg segment)
        {
            Name = name;
            Segment = segment;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format("{0}[{1}:{2}]", Name, Segment.BaseAddress, Segment.Length);

        public override string ToString()
            => Format();
    }
}