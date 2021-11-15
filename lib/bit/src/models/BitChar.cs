//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = BitChars;

    public readonly struct BitChar : IEquatable<BitChar>
    {
        public BitCharKind Kind {get;}

        [MethodImpl(Inline)]
        public BitChar(BitCharKind kind)
        {
            Kind = kind;
        }

        [MethodImpl(Inline)]
        public bool Equals(BitChar src)
            => (byte)Kind == (byte)src.Kind;

        public override bool Equals(object src)
            => src is BitChar c && Equals(c);

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (byte)Kind;
        }

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BitChar(BitCharKind src)
            => new BitChar(src);

        [MethodImpl(Inline)]
        public static implicit operator BitChar(bit src)
            => api.from(src);

        [MethodImpl(Inline)]
        public static implicit operator BitCharKind(BitChar src)
            => src.Kind;

        [MethodImpl(Inline)]
        public static implicit operator char(BitChar src)
            => api.render(src);

        [MethodImpl(Inline)]
        public static bool operator ==(BitChar a, BitChar b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(BitChar a, BitChar b)
            => !a.Equals(b);
    }
}