//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct TextTemplates
    {
   public static TextTemplate template(string pattern, object[] parameters)
            => new TextTemplate(pattern, parameters);

        public static TextTemplate<T0> template<T0>(string pattern, T0 p0)
        {
            var t = new TextTemplate<T0>(pattern);
            t.Param0 = p0;
            return t;
        }

        public static TextTemplate<T0,T1> template<T0,T1>(string pattern, T0 p0, T1 p1)
        {
            var t = new TextTemplate<T0,T1>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            return t;
        }

        public static TextTemplate<T0,T1,T2> template<T0,T1,T2>(string pattern, T0 p0, T1 p1, T2 p2)
        {
            var t = new TextTemplate<T0,T1,T2>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            return t;
        }

        public static TextTemplate<T0,T1,T2,T3> template<T0,T1,T2,T3>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3)
        {
            var t = new TextTemplate<T0,T1,T2,T3>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            return t;
        }

        public static TextTemplate<T0,T1,T2,T3,T4> template<T0,T1,T2,T3,T4>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4)
        {
            var t = new TextTemplate<T0,T1,T2,T3,T4>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            return t;
        }

        public static TextTemplate<T0,T1,T2,T3,T4,T5> template<T0,T1,T2,T3,T4,T5>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
        {
            var t = new TextTemplate<T0,T1,T2,T3,T4,T5>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            t.Param5 = p5;
            return t;
        }

        public static TextTemplate<T0,T1,T2,T3,T4,T5,T6> template<T0,T1,T2,T3,T4,T5,T6>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
        {
            var t = new TextTemplate<T0,T1,T2,T3,T4,T5,T6>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            t.Param5 = p5;
            t.Param6 = p6;
            return t;
        }

        public static TextTemplate<T0,T1,T2,T3,T4,T5,T6,T7> template<T0,T1,T2,T3,T4,T5,T6,T7>(string pattern, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
        {
            var t = new TextTemplate<T0,T1,T2,T3,T4,T5,T6,T7>(pattern);
            t.Param0 = p0;
            t.Param1 = p1;
            t.Param2 = p2;
            t.Param3 = p3;
            t.Param4 = p4;
            t.Param5 = p5;
            t.Param6 = p6;
            t.Param7 = p7;
            return t;
        }

    }

    public class TextTemplate : ITextTemplate
    {
        public TextBlock Pattern {get;}

        public virtual Index<object> Parameters {get;}

        public virtual uint ParameterCount {get;}

        public TextTemplate(string src)
        {
            Pattern = src ?? EmptyString;
            Parameters = sys.empty<object>();
            ParameterCount = 0;
        }

        public TextTemplate(string src, object[] parameters)
        {
            Pattern = src ?? EmptyString;
            Parameters = parameters;
            ParameterCount = (uint)parameters.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Pattern.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Pattern.IsNonEmpty;
        }

        public string Format()
            => Parameters.IsNonEmpty ? string.Format(Pattern, Parameters) : Pattern;

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

        public override Index<object> Parameters
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

        public override Index<object> Parameters
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

        public override Index<object> Parameters
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

        public override Index<object> Parameters
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

        public override Index<object> Parameters
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

        public override Index<object> Parameters
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

        public override Index<object> Parameters
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

        public override Index<object> Parameters
            => array<object>(Param0, Param1, Param2, Param3, Param4, Param5, Param6, Param7);
    }
}