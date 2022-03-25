//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a bit sequence representation compatible with both llvm and SMTLib 'FixedSizeBitVectors' theory
    /// </summary>
    public struct bits<T>
        where T : unmanaged
    {
        public const string Identifier = "bits<{0}>";

        const char DefaultSep = Chars.Comma;

        public T Packed;

        public uint N;

        public string TypeName
            => string.Format(Identifier, N);

        [MethodImpl(Inline)]
        public bits(uint n, T src)
        {
            N = n;
            Packed = src;
        }

        [MethodImpl(Inline)]
        public bits(T src)
        {
            N = core.width<T>();
            Packed = src;
        }

        public bit this[uint pos]
        {
            [MethodImpl(Inline)]
            get => bit.test(Packed, pos);
            [MethodImpl(Inline)]
            set => Packed = core.@as<ulong,T>(bit.set(core.@as<T,ulong>(Packed),(byte)pos,value));
        }

        public string Format(RenderFence fence, char sep = (char)0)
        {
            var dst = text.buffer();
            BitRender.render(N, fence, sep, Packed, dst);
            return dst.Emit();
        }

        public string Format()
        {
            var dst = text.buffer();
            BitRender.render(N, RenderFence.Embraced, DefaultSep, Packed, dst);
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public S Convert<S>()
            where S : unmanaged
                => core.@as<T,S>(Packed);

        [MethodImpl(Inline)]
        public static implicit operator bits<T>((uint n, T value) src)
            => new bits<T>(src.n, src.value);

        [MethodImpl(Inline)]
        public static implicit operator bits<T>(T src)
            => new bits<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(bits<T> src)
            => src.Packed;
    }
}