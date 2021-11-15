//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct HashCode<S> : ITextual
    {
        public S Source {get;}

        public uint Hash {get;}

        [MethodImpl(Inline)]
        public HashCode(S src, uint hash)
        {
            Source = src;
            Hash = hash;
        }

        public string Format()
            => string.Format("{0}: {1}", Hash.FormatHex(specifier:false), Source);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator HashCode<S>((S input, uint output) src)
            => new HashCode<S>(src.input, src.output);
    }
}