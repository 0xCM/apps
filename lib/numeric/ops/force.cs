//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct Numeric
    {
        /// <summary>
        /// Unconditionally converts the source values to values of parametric numeric type
        /// </summary>
        /// <param name="src">The source values</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline)]
        public static T[] force<S,T>(S[] src, T[] dst)
            where T : unmanaged
            where S : unmanaged
        {
            var input = span(src);
            var count = input.Length;
            var target = span(dst);
            for(var i=0; i<count; i++)
                seek(target,(uint)i) = force<S,T>(skip(input,(uint)i));
            return dst;
        }

        /// <summary>
        /// Unconditionally converts the source values to values of parametric numeric type
        /// </summary>
        /// <param name="src">The source values</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline)]
        public static T[] force<S,T>(S[] src)
            where T : unmanaged
            where S : unmanaged
        {
            var input = span(src);
            var count = input.Length;
            var buffer = alloc<T>(count);
            var dst = buffer.ToSpan();
            for(var i=0; i<count; i++)
                seek(dst,(uint)i) = force<S,T>(skip(input,(uint)i));
            return buffer;
        }

        /// <summary>
        /// Unconditionally converts the source value to a value of parametric numeric type
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(sbyte src)
            => convert8i_u<T>(src);

        /// <summary>
        /// Unconditionally converts the source value to a value of parametric numeric type
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(byte src)
            => convert8u_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion ushort -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(ushort src)
            => convert16u_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion short -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(short src)
            => convert16i_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion int -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(int src)
            => convert32i_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion uint -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(uint src)
            => convert32u_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion long -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(long src)
            => convert64i_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion ulong -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(ulong src)
            => convert64u_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion float -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(float src)
            => convert32f_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion double -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(double src)
            => convert64f_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion char -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(char src)
            => convert16c_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion S -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static T force<S,T>(S src)
            => force_u<S,T>(src);

        [MethodImpl(Inline)]
        static T force_u<S,T>(S src)
        {
            if(typeof(S) == typeof(byte))
                return force<T>(uint8(src));
            else if(typeof(S) == typeof(ushort))
                return force<T>(uint16(src));
            else if(typeof(S) == typeof(uint))
                return force<T>(uint32(src));
            else if(typeof(S) == typeof(ulong))
                return force<T>(uint64(src));
            else
                return force_i<S,T>(src);
        }

        [MethodImpl(Inline)]
        static T force_i<S,T>(S src)
        {
            if(typeof(S) == typeof(sbyte))
                return force<T>(int8(src));
            else if(typeof(S) == typeof(short))
                return force<T>(int16(src));
            else if(typeof(S) == typeof(int))
                return force<T>(int32(src));
            else if(typeof(S) == typeof(long))
                return force<T>(int64(src));
            else
                return force_x<S,T>(src);
        }

        [MethodImpl(Inline)]
        static T force_x<S,T>(S src)
        {
            if(typeof(S) == typeof(float))
                return force<T>(float32(src));
            else if(typeof(S) == typeof(double))
                return force<T>(float64(src));
            else if(typeof(S) == typeof(char))
                return force<T>(c16(src));
            else
                return no<S,T>();
        }
    }
}