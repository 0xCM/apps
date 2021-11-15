//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using LK = LiteralKind;

    [ApiHost]
    public readonly struct LiteralKinds
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<LiteralKind> kinds()
            => Kinds;

        /// <summary>
        /// Returns the <see cref='LiteralKind'/> classification of a parametrically-identified primitive
        /// </summary>
        /// <typeparam name="T">The type to classify</typeparam>
        [MethodImpl(Inline)]
        public static LiteralKind kind<T>()
        {
            if(typeof(T) == typeof(string))
                return LK.String;
            else if(typeof(T) == typeof(char))
                return LK.C16;
            else if(typeof(T) == typeof(bool))
                return LK.U1;
            else
                return numeric<T>();
        }

        /// <summary>
        /// Returns the <see cref='LiteralKind'/> classification of a parametrically-identified numeric primitive
        /// </summary>
        /// <typeparam name="T">The type to classify</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static LiteralKind numeric<T>()
            => numeric_u<T>();

        [MethodImpl(Inline)]
        static LiteralKind numeric_u<T>()
        {
            if(typeof(T) == typeof(byte))
                return LK.U8;
            else if(typeof(T) == typeof(ushort))
                return LK.U16;
            else if(typeof(T) == typeof(uint))
                return LK.U32;
            else if(typeof(T) == typeof(ulong))
                return LK.U64;
            else
                return numeric_i<T>();
        }

        [MethodImpl(Inline)]
        static LiteralKind numeric_i<T>()
        {
            if(typeof(T) == typeof(sbyte))
                return LK.I8;
            else if(typeof(T) == typeof(short))
                return LK.I16;
            else if(typeof(T) == typeof(int))
                return LK.I32;
            else if(typeof(T) == typeof(long))
                return LK.I64;
            return numeric_f<T>();
        }

        [MethodImpl(Inline)]
        static LiteralKind numeric_f<T>()
        {
            if(typeof(T) == typeof(float))
                return LK.I8;
            else if(typeof(T) == typeof(double))
                return LK.I16;
            else if(typeof(T) == typeof(decimal))
                return LK.I32;
            else
                return LiteralKind.None;
        }

        static ReadOnlySpan<LiteralKind> Kinds => new LiteralKind[]{
            LK.None,
            LK.U1,
            LK.U8,
            LK.U16,
            LK.U32,
            LK.U64,
            LK.I8,
            LK.I16,
            LK.I32,
            LK.I64,
            LK.F32,
            LK.F64,
            LK.F128,
            LK.C16,
            LK.String,
        };
    }
}