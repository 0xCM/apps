// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [MethodImpl(Inline), Op]
        public static Hash32 hash(Type src)
            => alg.hash.calc(src);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(uint x, uint y)
            => alg.hash.combine(x,y);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(sbyte x, sbyte y)
            => alg.hash.combine(x,y);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(byte x, byte y)
            => alg.hash.combine(x,y);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(short x, short y)
            => alg.hash.combine(x,y);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(ushort x, ushort y)
            => alg.hash.combine(x,y);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(int x, int y)
            => alg.hash.combine(x,y);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(ulong x, ulong y)
            => alg.hash.combine(x,y);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(long x, long y)
            => alg.hash.combine(x,y);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(float x, float y)
            => alg.hash.combine(x,y);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(double x, double y)
            => alg.hash.combine(x,y);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(decimal x, decimal y)
            => alg.hash.combine(x,y);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(sbyte x, sbyte y, sbyte z)
             => alg.hash.combine(x,y,z);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(byte x, byte y, byte z)
             => alg.hash.combine(x,y,z);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(ushort x, ushort y, ushort z)
             => alg.hash.combine(x,y,z);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(short x, short y, short z)
             => alg.hash.combine(x,y,z);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(uint x, uint y, uint z)
             => alg.hash.combine(x,y,z);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(int x, int y, int z)
             => alg.hash.combine(x,y,z);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(ulong x, ulong y, ulong z)
             => alg.hash.combine(x,y,z);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(long x, long y, long z)
             => alg.hash.combine(x,y,z);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(char x, char y, char z)
             => alg.hash.combine(x,y,z);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hash32 hash<T>(T src)
            => alg.ghash.calc(src);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(ReadOnlySpan<byte> src)
            => alg.hash.marvin(src);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(ReadOnlySpan<char> src)
            => alg.hash.marvin(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hash32 hash<T>(ReadOnlySpan<T> src)
            =>  alg.ghash.calc(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hash32 hash<T>(T x, T y)
            => alg.ghash.combine(x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hash32 hash<T>(T x, T y, T z)
            => alg.ghash.calc(x,y,z,z);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hash64 hash64<X,Y>(X x, Y y)
            => alg.ghash.calc64(x,y);

        [MethodImpl(Inline)]
        public static Hash64 hash64(Type x, Type y)
            => alg.hash.combine(x,y);

        [MethodImpl(Inline)]
        public static Hash64 hash64(Type x, Type y, Type z)
             => alg.hash.combine(x,y,z);
    }
}