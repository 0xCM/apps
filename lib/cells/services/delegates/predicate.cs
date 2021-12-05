//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct CellDelegates
    {
        [MethodImpl(NotInline), Op]
        public static UnaryPredicate1 predicate(UnaryPredicate<bit> f)
            => a => f(a);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate8 predicate(UnaryPredicate<sbyte> f)
            => a => f((sbyte)a.Content);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate8 predicate(UnaryPredicate<byte> f)
            => a => f((byte)a.Content);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate16 predicate(UnaryPredicate<short> f)
            => a => f((short)a.Content);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate16 predicate(UnaryPredicate<ushort> f)
            => a => f((ushort)a.Content);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate32 predicate(UnaryPredicate<int> f)
            => a => f((int)a.Content);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate32 predicate(UnaryPredicate<uint> f)
            => a => f((uint)a.Content);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate64 predicate(UnaryPredicate<long> f)
            => a => f((long)a.Content);

        [MethodImpl(NotInline), Op]
        public static UnaryPredicate64 predicate(UnaryPredicate<ulong> f)
            => a => f(a.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate1 predicate(BinaryPredicate<bit> f)
            => (a, b) => f(a, b);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate8 predicate(BinaryPredicate<sbyte> f)
            => (a, b) => f((sbyte)a.Content, (sbyte)b.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate8 predicate(BinaryPredicate<byte> f)
            => (a, b) => f(a.Content, b.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate16 predicate(BinaryPredicate<short> f)
            => (a, b) => f((short)a.Content, (short)b.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate16 predicate(BinaryPredicate<ushort> f)
            => (a, b) => f(a.Content, b.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate32 predicate(BinaryPredicate<int> f)
            => (a, b) => f((int)a.Content, (int)a.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate32 predicate(BinaryPredicate<uint> f)
            => (a, b) => f(a.Content, b.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate64 predicate(BinaryPredicate<long> f)
            => (a, b) => f((long)a.Content, (long)b.Content);

        [MethodImpl(NotInline), Op]
        public static BinaryPredicate64 predicate(BinaryPredicate<ulong> f)
            => (a, b) => f(a.Content, b.Content);
    }
}