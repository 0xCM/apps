//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Hash16 : IHashCode<ushort,ushort>
    {
        public ushort Value {get;}

        [MethodImpl(Inline)]
        public Hash16(ushort value)
            => Value = value;

        public ushort Primitive
        {
            [MethodImpl(Inline)]
           get => Value;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString("X");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash16(ushort src)
            => new Hash16(src);
    }
}