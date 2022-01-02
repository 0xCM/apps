//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [DataType("hash<w:64>")]
    public readonly struct Hash64 : IHashCode<ulong,ulong>
    {
        public ulong Value {get;}

        [MethodImpl(Inline)]
        public Hash64(ulong value)
            => Value = value;

        public ulong Primitive
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public string Format()
            => Value.FormatHex(zpad:true, specifier:true, uppercase:true);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash64(ulong src)
            => new Hash64(src);
    }
}