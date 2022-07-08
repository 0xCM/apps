//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Refs;

    partial struct Numeric
    {
        [MethodImpl(Inline)]
        static T convert16i_u<T>(short src)
        {
            if(typeof(T) == typeof(byte))
                return generic<T>((byte)src);
            else if(typeof(T) == typeof(ushort))
                return generic<T>((ushort)src);
            else if(typeof(T) == typeof(uint))
                return generic<T>((uint)src);
            else if(typeof(T) == typeof(ulong))
                return generic<T>((ulong)src);
            else
                return convert16i_i<T>(src);
        }

        [MethodImpl(Inline)]
        static T convert16i_i<T>(short src)
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>((sbyte)src);
            else if(typeof(T) == typeof(short))
                return generic<T>((short)src);
            else if(typeof(T) == typeof(int))
                return generic<T>((int)src);
            else if(typeof(T) == typeof(long))
                return generic<T>((long)src);
            else
                return convert16i_x<T>(src);
        }

        [MethodImpl(Inline)]
        static T convert16i_x<T>(short src)
        {
            if(typeof(T) == typeof(float))
                return generic<T>((float)src);
            else if(typeof(T) == typeof(double))
                return generic<T>(ScalarCast.float64(src));
            else if(typeof(T) == typeof(char))
                return generic<T>((char)src);
            else
                throw no<T>();
        }
    }
}