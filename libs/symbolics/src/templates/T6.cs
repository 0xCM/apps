//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextTemplates
    {
        public class TextTemplate<T0,T1,T2,T3,T4,T5> : TextTemplate<T0,T1,T2,T3,T4>
        {
            public new const byte Arity = 6;

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

            public override uint ParameterCount => Arity;

            public override Index<object> Parameters
                => new object[Arity]{Param0, Param1, Param2, Param3, Param4, Param5};
        }
    }
}