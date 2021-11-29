//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Numeric
    {
        /// <summary>
        /// Ones all bits each and every ... one
        /// </summary>
        /// <param name="t">A primal type representative</param>
        /// <typeparam name="T">The primal source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T ones<T>()
            where T : unmanaged
                => ones_u<T>();

        [MethodImpl(Inline)]
        static T ones_u<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<T>(Ones8u);
            else if(typeof(T) == typeof(ushort))
                return force<T>(Ones16u);
            else if(typeof(T) == typeof(uint))
                return force<T>(Ones32u);
            else if(typeof(T) == typeof(ulong))
                return force<T>(Ones64u);
            else
                return ones_i<T>();
        }

        [MethodImpl(Inline)]
        static T ones_i<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return force<T>(Ones8i);
            else if(typeof(T) == typeof(short))
                return force<T>(Ones16i);
            else if(typeof(T) == typeof(int))
                return force<T>(Ones32i);
            else if(typeof(T) == typeof(long))
                return force<T>(Ones64i);
            else
                 return ones_f<T>();
       }

        [MethodImpl(Inline)]
        static T ones_f<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return force<T>((float)Ones32u);
            else if(typeof(T) == typeof(double))
                return force<T>((double)Ones64u);
            else
                 throw no<T>();
       }

        const byte Ones8u = byte.MaxValue;

        const sbyte Ones8i = -1;

        const ushort Ones16u = ushort.MaxValue;

        const short Ones16i = -1;

        const uint Ones32u = uint.MaxValue;

        const int Ones32i = -1;

        const ulong Ones64u = ulong.MaxValue;

        const long Ones64i = -1;
    }
}