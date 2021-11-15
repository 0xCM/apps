//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Hash8 : IHashCode<byte,byte>
    {
        public byte Value {get;}

        [MethodImpl(Inline)]
        public Hash8(byte value)
            => Value = value;

        public byte Primitive
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public string Format()
            => Value.ToString("X");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash8(byte src)
            => new Hash8(src);

        [MethodImpl(Inline)]
        public static implicit operator Hash<byte,byte>(Hash8 src)
            => new Hash<byte,byte>(src.Value);
    }
}