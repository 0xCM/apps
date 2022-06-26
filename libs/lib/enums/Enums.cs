//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    using PK = PrimalKind;

    [ApiHost]
    public readonly partial struct Enums
    {
        [MethodImpl(Inline)]
        public static ClrEnumAdapter<E> @enum<E>()
            where E : unmanaged, Enum
                => default;

        /// <summary>
        /// Constructs a arbitrarily deduplicated value-to-member index
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="V">The numeric value type</typeparam>
        public static IDictionary<V,E> dictionary<E,V>()
            where E : unmanaged, Enum
            where V : unmanaged
        {
            var pairs = Enums.details<E,V>();
            var index = new Dictionary<V,E>();
            foreach(var pair in pairs)
                index.TryAdd(pair.PrimalValue, pair.LiteralValue);
            return index;
        }

        [Op]
        public static ulong @ulong(PrimalKind kind, object src)
            => kind switch {
                PK.U8 => (ulong)(byte)src,
                PK.I8 => (ulong)(sbyte)src,
                PK.U16 => (ulong)(ushort)src,
                PK.I16 => (ulong)(short)src,
                PK.U32 => (ulong)(uint)src,
                PK.I32 => (ulong)(int)src,
                PK.I64 => (ulong)(long)src,
                PK.U64 => (ulong)src,
                _ => 0ul,
            };
    }
}