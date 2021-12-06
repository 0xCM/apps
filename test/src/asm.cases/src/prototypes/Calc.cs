//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    partial struct Prototypes
    {
        [Free]
        public interface ICalc<T>
            where T : unmanaged
        {
            T Add(T a, T b);

            T Sub(T a, T b);

            T Mul(T a, T b);

            T Mod(T a, T b);
        }

        [Free]
        public interface ICalc8
        {
            byte Add(byte a, byte b);

            byte Sub(byte a, byte b);

            byte Mul(byte a, byte b);

            byte Mod(byte a, byte b);

        }

        [Free]
        public interface ICalc16 : ICalc<ushort>
        {

        }

        [Free]
        public interface ICalc32 : ICalc<uint>
        {

        }

        [Free]
        public interface ICalc64
        {
            ulong Add(ulong a, ulong b);

            ulong Sub(ulong a, ulong b);

            ulong Mul(ulong a, ulong b);

            ulong Mod(ulong a, ulong b);
        }

        [ApiHost(prototypes + calc8)]
        public readonly struct Calc8 : ICalc8
        {
            [Op]
            public byte Add(byte a, byte b)
                => math.add(a,b);

            [Op]
            public byte Mod(byte a, byte b)
                => math.mod(a,b);

            [Op]
            public byte Mul(byte a, byte b)
                => math.mul(a,b);

            [Op]
            public byte Sub(byte a, byte b)
                => math.sub(a,b);
        }

        [ApiHost(prototypes + calc64)]
        public readonly struct Calc64 : ICalc64
        {
            [Op]
            public ulong Add(ulong a, ulong b)
                => math.add(a,b);

            [Op]
            public ulong Mod(ulong a, ulong b)
                => math.mod(a,b);

            [Op]
            public ulong Mul(ulong a, ulong b)
                => math.mul(a,b);

            [Op]
            public ulong Sub(ulong a, ulong b)
                => math.sub(a,b);
        }
    }
}