//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct OpN<T0> { }

    public readonly struct OpN<T0,T1> { }

    public readonly struct OpN<T0,T1,T2> { }

    public readonly struct OpN<T0,T1,T2,T3>
    {
        readonly Type @null;

        readonly Type t0;

        readonly Type t1;

        readonly Type t2;

        readonly Type t3;

        [MethodImpl(Inline)]
        internal OpN(int i)
        {
            @null = typeof(void);
            t0 = typeof(T0);
            t1 = typeof(T1);
            t2 = typeof(T2);
            t3 = typeof(T3);
        }

        [MethodImpl(Inline)]
        public Type type<T>()
        {
            if(typeof(T) == typeof(T0))
                return t0;
            else if(typeof(T) == typeof(T1))
                return t1;
            else if(typeof(T) == typeof(T2))
                return t2;
            else if(typeof(T) == typeof(T3))
                return t3;
            else
                return @null;
        }
    }

    public readonly struct OpN<T0,T1,T2,T3,T4>
    {
        readonly Type @null;

        readonly Type t0;

        readonly Type t1;

        readonly Type t2;

        readonly Type t3;

        readonly Type t4;


        [MethodImpl(Inline)]
        internal OpN(int i)
        {
            @null = typeof(void);
            t0 = typeof(T0);
            t1 = typeof(T1);
            t2 = typeof(T2);
            t3 = typeof(T3);
            t4 = typeof(T4);
        }

        [MethodImpl(Inline)]
        public Type match<T>()
        {
            if(typeof(T) == typeof(T0))
                return t0;
            else if(typeof(T) == typeof(T1))
                return t1;
            else if(typeof(T) == typeof(T2))
                return t2;
            else if(typeof(T) == typeof(T3))
                return t3;
            else if(typeof(T) == typeof(T4))
                return t4;
            else
                return @null;
        }
    }

    /// <summary>
    /// Identifies a sextet of parametric types
    /// </summary>
    public readonly struct OpN<T0,T1,T2,T3,T4,T5>
    {
        readonly Type @null;

        readonly Type t0;

        readonly Type t1;

        readonly Type t2;

        readonly Type t3;

        readonly Type t4;

        readonly Type t5;

        [MethodImpl(Inline)]
        internal OpN(int i)
        {
            @null = typeof(void);
            t0 = typeof(T0);
            t1 = typeof(T1);
            t2 = typeof(T2);
            t3 = typeof(T3);
            t4 = typeof(T4);
            t5 = typeof(T5);
        }

        [MethodImpl(Inline)]
        public Type match<T>()
        {
            if(typeof(T) == typeof(T0))
                return t0;
            else if(typeof(T) == typeof(T1))
                return t1;
            else if(typeof(T) == typeof(T2))
                return t2;
            else if(typeof(T) == typeof(T3))
                return t3;
            else if(typeof(T) == typeof(T4))
                return t4;
            else if(typeof(T) == typeof(T5))
                return t5;
            else
                return @null;
        }
     }

    /// <summary>
    /// Identifies a septet of parametric types
    /// </summary>
    public readonly struct OpN<T0,T1,T2,T3,T4,T5,T6>
    {
        readonly Type @null;

        readonly Type t0;

        readonly Type t1;

        readonly Type t2;

        readonly Type t3;

        readonly Type t4;

        readonly Type t5;

        readonly Type t6;

        [MethodImpl(Inline)]
        internal OpN(int i)
        {
            @null = typeof(void);
            t0 = typeof(T0);
            t1 = typeof(T1);
            t2 = typeof(T2);
            t3 = typeof(T3);
            t4 = typeof(T4);
            t5 = typeof(T5);
            t6 = typeof(T6);
        }

        [MethodImpl(Inline)]
        public Type match<T>()
        {
            if(typeof(T) == typeof(T0))
                return t0;
            else if(typeof(T) == typeof(T1))
                return t1;
            else if(typeof(T) == typeof(T2))
                return t2;
            else if(typeof(T) == typeof(T3))
                return t3;
            else if(typeof(T) == typeof(T4))
                return t4;
            else if(typeof(T) == typeof(T5))
                return t5;
            else if(typeof(T) == typeof(T6))
                return t6;
            else
                return @null;
        }
    }

    /// <summary>
    /// Identifies an octet of parametric types
    /// </summary>
    public readonly struct OpN<T0,T1,T2,T3,T4,T5,T6,T7>
    {
        readonly Type @null;

        readonly Type t0;

        readonly Type t1;

        readonly Type t2;

        readonly Type t3;

        readonly Type t4;

        readonly Type t5;

        readonly Type t6;

        readonly Type t7;

        [MethodImpl(Inline)]
        internal OpN(int i)
        {
            @null = typeof(void);
            t0 = typeof(T0);
            t1 = typeof(T1);
            t2 = typeof(T2);
            t3 = typeof(T3);
            t4 = typeof(T4);
            t5 = typeof(T5);
            t6 = typeof(T6);
            t7 = typeof(T7);
        }

        [MethodImpl(Inline)]
        public Type match<T>()
        {
            if(typeof(T) == typeof(T0))
                return t0;
            else if(typeof(T) == typeof(T1))
                return t1;
            else if(typeof(T) == typeof(T2))
                return t2;
            else if(typeof(T) == typeof(T3))
                return t3;
            else if(typeof(T) == typeof(T4))
                return t4;
            else if(typeof(T) == typeof(T5))
                return t5;
            else if(typeof(T) == typeof(T6))
                return t6;
            else if(typeof(T) == typeof(T7))
                return t7;
            else
                return @null;
        }
    }

    public readonly struct OpN<T0,T1,T2,T3,T4,T5,T6,T7,T8>
    {
        readonly Type @null;

        readonly Type t0;

        readonly Type t1;

        readonly Type t2;

        readonly Type t3;

        readonly Type t4;

        readonly Type t5;

        readonly Type t6;

        readonly Type t7;

        readonly Type t8;

        [MethodImpl(Inline)]
        internal OpN(int i)
        {
            @null = typeof(void);
            t0 = typeof(T0);
            t1 = typeof(T1);
            t2 = typeof(T2);
            t3 = typeof(T3);
            t4 = typeof(T4);
            t5 = typeof(T5);
            t6 = typeof(T6);
            t7 = typeof(T7);
            t8 = typeof(T8);
        }

        [MethodImpl(Inline)]
        public Type match<T>()
        {
            if(typeof(T) == typeof(T0))
                return t0;
            else if(typeof(T) == typeof(T1))
                return t1;
            else if(typeof(T) == typeof(T2))
                return t2;
            else if(typeof(T) == typeof(T3))
                return t3;
            else if(typeof(T) == typeof(T4))
                return t4;
            else if(typeof(T) == typeof(T5))
                return t5;
            else if(typeof(T) == typeof(T6))
                return t6;
            else if(typeof(T) == typeof(T7))
                return t7;
            else if(typeof(T) == typeof(T8))
                return t8;
            else
                return @null;
        }
    }

    public readonly struct OpN<T0,T1,T2,T3,T4,T5,T6,T7,T8,T9>
    {
        readonly Type @null;

        readonly Type t0;

        readonly Type t1;

        readonly Type t2;

        readonly Type t3;

        readonly Type t4;

        readonly Type t5;

        readonly Type t6;

        readonly Type t7;

        readonly Type t8;

        readonly Type t9;

        [MethodImpl(Inline)]
        internal OpN(int i)
        {
            @null = typeof(void);
            t0 = typeof(T0);
            t1 = typeof(T1);
            t2 = typeof(T2);
            t3 = typeof(T3);
            t4 = typeof(T4);
            t5 = typeof(T5);
            t6 = typeof(T6);
            t7 = typeof(T7);
            t8 = typeof(T8);
            t9 = typeof(T9);
        }

        [MethodImpl(Inline)]
        public Type match<T>()
        {
            if(typeof(T) == typeof(T0))
                return t0;
            else if(typeof(T) == typeof(T1))
                return t1;
            else if(typeof(T) == typeof(T2))
                return t2;
            else if(typeof(T) == typeof(T3))
                return t3;
            else if(typeof(T) == typeof(T4))
                return t4;
            else if(typeof(T) == typeof(T5))
                return t5;
            else if(typeof(T) == typeof(T6))
                return t6;
            else if(typeof(T) == typeof(T7))
                return t7;
            else if(typeof(T) == typeof(T8))
                return t8;
            else if(typeof(T) == typeof(T9))
                return t9;
            else
                return @null;
        }
    }
}