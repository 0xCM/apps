//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using NK = NumericKind;
    using BK = ClrEnumKind;

    partial struct Enums
    {
        /// <summary>
        /// Determines the integral type refined by a parametrically-identified enum type
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        public static ClrEnumKind @base<E>()
            where E : unmanaged, Enum
             => @base(typeof(E).GetEnumUnderlyingType().NumericKind());

        /// <summary>
        /// Determines the integral type refined by a value-identified enum type
        /// </summary>
        /// <param name="value">The enum value</typeparam>
        [Op]
        public static ClrEnumKind @base(Enum value)
            => @base(value.GetType().GetEnumUnderlyingType().NumericKind());

        /// <summary>
        /// Determines the integral type refined by a specified enum type
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        [Op]
        public static ClrEnumKind @base(Type et)
            => @base(et.GetEnumUnderlyingType().NumericKind());

        [Op]
        public static ClrEnumKind @base(NumericKind src)
             => src switch{
                NK.U8 => BK.U8,
                NK.I8 => BK.I8,
                NK.U16 => BK.U16,
                NK.I16 => BK.I16,
                NK.U32 => BK.U32,
                NK.I32 => BK.I32,
                NK.I64 => BK.I64,
                NK.U64 => BK.U64,
                _ => ClrEnumKind.None,
            };
    }
}