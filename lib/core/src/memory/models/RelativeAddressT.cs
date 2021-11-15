//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct RelativeAddress<T> : ITextual, INullity
        where T : unmanaged
    {
        public MemoryAddress Base {get;}

        public T Offset {get;}

        [MethodImpl(Inline)]
        internal RelativeAddress(MemoryAddress @base, T offset)
        {
            Base = @base;
            Offset = offset;
        }

        public DataWidth Grain
        {
            [MethodImpl(Inline)]
            get => core.width<T>();
        }

        public bool IsEmpty
        {
             [MethodImpl(Inline)]
             get => Offset.Equals(default);
        }

        public bool IsNonEmpty
        {
             [MethodImpl(Inline)]
             get => !Offset.Equals(default);
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Offset);
        }

        [MethodImpl(Inline)]
        public string Format()
            => RelativeAddress.format(this);

        public bool Equals(RelativeAddress<T> src)
            => Offset.Equals(src.Offset);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is RelativeAddress l && Equals(l);

        [MethodImpl(Inline)]
        public static bool operator==(RelativeAddress<T> x, RelativeAddress<T> y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator!=(RelativeAddress<T> x, RelativeAddress<T> y)
            => !x.Equals(y);

        public static RelativeAddress<T> Empty
            => default;
    }
}