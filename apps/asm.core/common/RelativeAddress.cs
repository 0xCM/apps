//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct RelativeAddress
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static RelativeAddress define(MemoryAddress @base, MemoryAddress offset)
            => new RelativeAddress(@base, offset);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RelativeAddress<T> define<T>(MemoryAddress @base, T offset)
            where T : unmanaged, IAddress
                    => new RelativeAddress<T>(@base, offset);

        public readonly MemoryAddress Base;

        public readonly MemoryAddress Offset;

        [MethodImpl(Inline)]
        public RelativeAddress(MemoryAddress @base, MemoryAddress offset)
        {
            Base = @base;
            Offset = offset;
        }

        public bool IsEmpty
        {
             [MethodImpl(Inline)]
             get => Base == 0 && Offset == 0;
        }

        public bool IsNonEmpty
        {
             [MethodImpl(Inline)]
             get => !IsEmpty;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format("[{0x}:{1x}]", (ulong)Base, (ulong)Offset);

        [MethodImpl(Inline)]
        public bool Equals(RelativeAddress src)
            => Base == src.Base && Offset == src.Offset;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Offset.GetHashCode();

        public override bool Equals(object src)
            => src is RelativeAddress l && Equals(l);

        [MethodImpl(Inline)]
        public static RelativeAddress operator+(RelativeAddress x, byte y)
            => new RelativeAddress(x.Base, x.Offset + y);

        [MethodImpl(Inline)]
        public static RelativeAddress operator+(RelativeAddress x, ushort y)
            => new RelativeAddress(x.Base, x.Offset + y);

        [MethodImpl(Inline)]
        public static RelativeAddress operator+(RelativeAddress x, uint y)
            => new RelativeAddress(x.Base, x.Offset + y);

        [MethodImpl(Inline)]
        public static RelativeAddress operator-(RelativeAddress x, byte y)
            => new RelativeAddress(x.Base, x.Offset - y);

        [MethodImpl(Inline)]
        public static RelativeAddress operator-(RelativeAddress x, ushort y)
            => new RelativeAddress(x.Base, x.Offset - y);

        [MethodImpl(Inline)]
        public static RelativeAddress operator-(RelativeAddress x, uint y)
            => new RelativeAddress(x.Base, x.Offset - y);

        [MethodImpl(Inline)]
        public static bool operator==(RelativeAddress x, RelativeAddress y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator!=(RelativeAddress x, RelativeAddress y)
            => !x.Equals(y);

        public static RelativeAddress Empty
            => default;
    }
}