//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using Asm;

    [ApiComplete]
    public class AsmHexWriter
    {
        [MethodImpl(Inline)]
        public static AsmHexWriter create()
            => new AsmHexWriter();

        AsmHexCode Dst;

        uint Offset;

        [MethodImpl(Inline)]
        public AsmHexWriter()
        {
            Dst = AsmHexCode.Empty;
            Offset = 0;
        }

        [MethodImpl(Inline)]
        public AsmHexWriter Clear()
        {
            Dst = AsmHexCode.Empty;
            Offset = 0;
            return this;
        }

        public ref readonly AsmHexCode Target
        {
            [MethodImpl(Inline)]
            get => ref Dst;
        }

        [MethodImpl(Inline)]
        public ref readonly AsmHexCode Write<T>(in T src)
            where T : unmanaged
        {
            var size = (byte)core.size<T>();
            Dst.Size = (byte)(Dst.Size + size);
            cell<T>(Dst.Bytes, Offset) = src;
            Offset += size;
            return ref Target;
        }

        [MethodImpl(Inline)]
        public ref readonly AsmHexCode Write<A,B>(in A a, in B b)
            where A : unmanaged
            where B : unmanaged
        {
            Write(a);
            Write(b);
            return ref Target;
        }

        [MethodImpl(Inline)]
        public ref readonly AsmHexCode Write<A,B,C>(in A a, in B b, in C c)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
        {
            Write(a);
            Write(b);
            Write(c);
            return ref Target;
        }

        [MethodImpl(Inline)]
        public ref readonly AsmHexCode Write<A,B,C,D>(in A a, in B b, in C c, in D d)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
            where D : unmanaged
        {
            Write(a);
            Write(b);
            Write(c);
            Write(d);
            return ref Target;
        }
    }
}