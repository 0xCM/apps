//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiComplete]
    public ref struct AsmHexWriter
    {
        [MethodImpl(Inline)]
        public static AsmHexWriter create(Span<byte> buffer)
            => new AsmHexWriter(buffer);

        readonly Span<byte> Data;

        uint Position;

        byte Counter;

        [MethodImpl(Inline)]
        public AsmHexWriter(Span<byte> src)
        {
            Data = src;
            Position = 0;
            Counter = 0;
        }

        [MethodImpl(Inline)]
        public AsmHexWriter Clear()
        {
            Counter = 0;
            Data.Clear();
            return this;
        }

        public byte BytesWritten
        {
            [MethodImpl(Inline)]
            get => (byte)Position;
        }

        [MethodImpl(Inline)]
        public byte Write<T>(in T src)
            where T : unmanaged
        {
            cell<T>(Data, Position) = src;
            Position += size<T>();
            return (byte)size<T>();
        }

        [MethodImpl(Inline)]
        public byte Write<A,B>(in A a, in B b)
            where A : unmanaged
            where B : unmanaged
        {
            var size = Write(a);
            size += Write(b);
            return size;
        }

        [MethodImpl(Inline)]
        public byte Write<A,B,C>(in A a, in B b, in C c)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
        {
            var size = Write(a);
            size += Write(b);
            size += Write(c);
            return size;
        }

        [MethodImpl(Inline)]
        public byte Write<A,B,C,D>(in A a, in B b, in C c, in D d)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
            where D : unmanaged
        {
            var size = Write(a);
            size += Write(b);
            size += Write(c);
            size += Write(d);
            return size;
        }
    }
}