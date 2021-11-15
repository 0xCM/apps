//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection.Emit;

    using static Root;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [ApiHost]
    public readonly partial struct CellDelegates
    {
        const NumericKind Closure = Integers;

        [MethodImpl(Inline)]
        public static CellDelegate define(OpIdentity id, MemoryAddress src, DynamicMethod enclosure, Delegate dynop)
            => CellDelegate.define(id, src, enclosure, dynop);

        [MethodImpl(Inline)]
        public static CellDelegate define(Identifier id, MemoryAddress src, DynamicMethod enclosure, Delegate dynop)
            => CellDelegate.define(id, src, enclosure, dynop);

        [Free]
        public delegate bit Emitter1();

        [Free]
        public delegate Cell8 Emitter8();

        [Free]
        public delegate Cell16 Emitter16();

        [Free]
        public delegate Cell32 Emitter32();

        [Free]
        public delegate Cell64 Emitter64();

        [Free]
        public delegate Cell128 Emitter128();

        [Free]
        public delegate Cell256 Emitter256();

        [Free]
        public delegate Cell512 Emitter512();

        [Free]
        public delegate bit UnaryOp1(bit a);

        [Free]
        public delegate Cell8 UnaryOp8(Cell8 a);

        [Free]
        public delegate Cell16 UnaryOp16(Cell16 a);

        [Free]
        public delegate Cell32 UnaryOp32(Cell32 a);

        [Free]
        public delegate Cell64 UnaryOp64(Cell64 a);

        [Free]
        public delegate Cell128 UnaryOp128(Cell128 a);

        [Free]
        public delegate Cell256 UnaryOp256(Cell256 a);

        [Free]
        public delegate Cell512 UnaryOp512(Cell512 a);

        [Free]
        public delegate bit BinaryOp1(bit a, bit b);

        [Free]
        public delegate Cell8 BinaryOp8(Cell8 a, Cell8 b);

        [Free]
        public delegate Cell32 BinaryOp32(Cell32 a, Cell32 b);

        [Free]
        public delegate Cell16 BinaryOp16(Cell16 a, Cell16 b);

        [Free]
        public delegate Cell64 BinaryOp64(Cell64 a, Cell64 b);

        [Free]
        public delegate Cell128 BinaryOp128(Cell128 a, Cell128 b);

        [Free]
        public delegate Cell256 BinaryOp256(Cell256 a, Cell256 b);

        [Free]
        public delegate Cell512 BinaryOp512(Cell512 a, Cell512 b);

        [Free]
        public delegate bit BinaryPredicate1(bit a, bit b);

        [Free]
        public delegate bit BinaryPredicate<T>(T a, T b);

        [Free]
        public delegate bit UnaryPredicate1(bit a);

        [Free]
        public delegate bit UnaryPredicate8(Cell8 a);

        [Free]
        public delegate bit UnaryPredicate16(Cell16 a);

        [Free]
        public delegate bit UnaryPredicate32(Cell32 a);

        [Free]
        public delegate bit UnaryPredicate64(Cell64 a);

        [Free]
        public delegate bit UnaryPredicate128(Cell128 a);

        [Free]
        public delegate bit UnaryPredicate256(Cell256 a);

        [Free]
        public delegate bit UnaryPredicate512(Cell512 a);

        [Free]
        public delegate bit BinaryPredicate8(Cell8 a, Cell8 b);

        [Free]
        public delegate bit BinaryPredicate16(Cell16 a, Cell16 b);

        [Free]
        public delegate bit BinaryPredicate32(Cell32 a, Cell32 b);

        [Free]
        public delegate bit BinaryPredicate64(Cell64 a, Cell64 b);

        [Free]
        public delegate Bit32 BinaryPredicate128(Cell128 a, Cell128 b);

        [Free]
        public delegate Bit32 BinaryPredicate256(Cell256 a, Cell256 b);

        [Free]
        public delegate Bit32 BinaryPredicate512(Cell512 a, Cell512 b);
    }
}