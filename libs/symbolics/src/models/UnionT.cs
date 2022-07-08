//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Refs;

    [StructLayout(LayoutKind.Explicit)]
    public struct Union<T0,T1,T2,T3,T4>
    {
        [FieldOffset(0)]
        T0 F0;

        [FieldOffset(0)]
        T1 F1;

        [FieldOffset(0)]
        T2 F2;

        [FieldOffset(0)]
        T3 F3;

        [FieldOffset(0)]
        T4 F4;

        [MethodImpl(Inline)]
        public void Set<T>(in T src)
        {
            if(typeof(T) == typeof(T0))
                F0 = @as<T,T0>(src);
            else if(typeof(T) == typeof(T1))
                F1 = @as<T,T1>(src);
            else if(typeof(T) == typeof(T2))
                F2 = @as<T,T2>(src);
            else if(typeof(T) == typeof(T3))
                F3 = @as<T,T3>(src);
            else if(typeof(T) == typeof(T4))
                F4 = @as<T,T4>(src);

        }

        [MethodImpl(Inline)]
        public bool Get<T>(out T dst)
        {
            var matched = true;
            if(typeof(T) == typeof(T0))
                dst = @as<T0,T>(F0);
            else if(typeof(T) == typeof(T1))
                dst = @as<T1,T>(F1);
            else if(typeof(T) == typeof(T2))
                dst = @as<T2,T>(F2);
            else if(typeof(T) == typeof(T3))
                dst = @as<T3,T>(F3);
            else if(typeof(T) == typeof(T4))
                dst = @as<T4,T>(F4);
            else
            {
                dst = default;
                matched = false;
            }
            return matched;
        }
    }
}