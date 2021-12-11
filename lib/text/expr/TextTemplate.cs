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

    public class TextTemplate : ITextTemplate
    {
        public TextBlock Pattern {get;}

        public virtual object[] Parameters {get;}

        public virtual uint ParameterCount {get;}

        public TextTemplate(string src)
        {
            Pattern = src ?? EmptyString;
        }

        public TextTemplate(string src, object[] parameters)
        {
            Pattern = src ?? EmptyString;
            Parameters = parameters;
            ParameterCount = (uint)parameters.Length;
        }

        public string Format()
            => string.Format(Pattern, Parameters);

        public override string ToString()
            => Format();
    }

    public class TextTemplate<T0> : TextTemplate
    {
        public TextTemplate(string src)
            : base(src)
        {

        }

        public T0 Param0;

        public T0 this[N0 n]
        {
            [MethodImpl(Inline)]
            get => Param0;
            [MethodImpl(Inline)]
            set => Param0 = value;
        }

        public override object[] Parameters
            => array<object>(Param0);

        public override uint ParameterCount => 1;
    }

    public class TextTemplate<T0,T1> : TextTemplate<T0>
    {
        public TextTemplate(string src)
            : base(src)
        {

        }

        public T1 Param1;

        public T1 this[N1 n]
        {
            [MethodImpl(Inline)]
            get => Param1;
            [MethodImpl(Inline)]
            set => Param1 = value;
        }

        public override uint ParameterCount => 2;

        public override object[] Parameters
            => array<object>(Param0, Param1);
    }

    public class TextTemplate<T0,T1,T2> : TextTemplate<T0,T1>
    {
        public TextTemplate(string src)
            : base(src)
        {

        }

        public T2 Param2;

        public T2 this[N2 n]
        {
            [MethodImpl(Inline)]
            get => Param2;
            [MethodImpl(Inline)]
            set => Param2 = value;
        }

        public override uint ParameterCount => 3;

        public override object[] Parameters
            => array<object>(Param0, Param1, Param2);
    }

    public class TextTemplate<T0,T1,T2,T3> : TextTemplate<T0,T1,T2>
    {
        public TextTemplate(string src)
            : base(src)
        {

        }

        public T3 this[N3 n]
        {
            [MethodImpl(Inline)]
            get => Param3;
            [MethodImpl(Inline)]
            set => Param3 = value;
        }

        public T3 Param3;

        public override uint ParameterCount => 4;

        public override object[] Parameters
            => array<object>(Param0, Param1, Param2, Param3);
    }

    public class TextTemplate<T0,T1,T2,T3,T4> : TextTemplate<T0,T1,T2,T3>
    {
        public TextTemplate(string src)
            : base(src)
        {

        }

        public T4 Param4;

        public T4 this[N4 n]
        {
            [MethodImpl(Inline)]
            get => Param4;
            [MethodImpl(Inline)]
            set => Param4 = value;
        }

        public override uint ParameterCount => 5;

        public override object[] Parameters
            => array<object>(Param0, Param1, Param2, Param3, Param4);
    }

    public class TextTemplate<T0,T1,T2,T3,T4,T5> : TextTemplate<T0,T1,T2,T3,T4>
    {
        public TextTemplate(string src)
            : base(src)
        {

        }

        public T5 Param5;

        public T5 this[N5 n]
        {
            [MethodImpl(Inline)]
            get => Param5;
            [MethodImpl(Inline)]
            set => Param5 = value;
        }

        public override uint ParameterCount => 6;

        public override object[] Parameters
            => array<object>(Param0, Param1, Param2, Param3, Param4, Param5);
    }


    public class TextTemplate<T0,T1,T2,T3,T4,T5,T6> : TextTemplate<T0,T1,T2,T3,T4,T5>
    {
        public TextTemplate(string src)
            : base(src)
        {

        }

        public T6 Param6;

        public T6 this[N6 n]
        {
            [MethodImpl(Inline)]
            get => Param6;
            [MethodImpl(Inline)]
            set => Param6 = value;
        }

        public override uint ParameterCount => 7;

        public override object[] Parameters
            => array<object>(Param0, Param1, Param2, Param3, Param4, Param5, Param6);
    }


    public class TextTemplate<T0,T1,T2,T3,T4,T5,T6,T7> : TextTemplate<T0,T1,T2,T3,T4,T5,T6>
    {
        public TextTemplate(string src)
            : base(src)
        {

        }

        public T7 Param7;

        public T7 this[N7 n]
        {
            [MethodImpl(Inline)]
            get => Param7;
            [MethodImpl(Inline)]
            set => Param7 = value;
        }

        public override uint ParameterCount => 8;

        public override object[] Parameters
            => array<object>(Param0, Param1, Param2, Param3, Param4, Param5, Param6, Param7);
    }
}