//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct HashCode<S> : ITextual
    {
        public readonly S Source;

        public readonly Hash32 Hash;

        [MethodImpl(Inline)]
        public HashCode(S src, Hash32 hash)
        {
            Source = src;
            Hash = hash;
        }

        public string Format()
            => string.Format("{0}: {1}", Hash, Source);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator HashCode<S>((S input, uint output) src)
            => new HashCode<S>(src.input, src.output);
    }
}