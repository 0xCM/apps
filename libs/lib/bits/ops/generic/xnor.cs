//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Numeric;

    using BL = math;

    partial class gbits
    {
        [MethodImpl(Inline), Xnor, Closures(Integers)]
        public static T xnor<T>(T a, T b)
            where T : unmanaged
                => xnor_u(a,b);

        [MethodImpl(Inline)]
        static T xnor_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<T>(BL.xnor(force<T,uint>(a), force<T,uint>(b)));
            else if(typeof(T) == typeof(ushort))
                return force<T>(BL.xnor(force<T,uint>(a), force<T,uint>(b)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(BL.xnor(uint32(a), uint32(b)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(BL.xnor(uint64(a), uint64(b)));
            else
                return xnor_i(a,b);
        }

        [MethodImpl(Inline)]
        static T xnor_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return force<T>(BL.xnor(force<T,int>(a), force<T,int>(b)));
            else if(typeof(T) == typeof(short))
                return force<T>(BL.xnor(force<T,int>(a), force<T,int>(b)));
            else if(typeof(T) == typeof(int))
                return generic<T>(BL.xnor(int32(a), int32(b)));
            else if(typeof(T) == typeof(long))
                return generic<T>(BL.xnor(int64(a), int64(b)));
            else
                throw no<T>();
        }
    }
}