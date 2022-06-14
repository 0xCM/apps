//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextTemplates
    {
        public class TextTemplate<T0,T1,T2,T3,T4> : TextTemplate<T0,T1,T2,T3>
        {
            public new const byte Arity = 5;

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

            public override uint ParameterCount => Arity;

            public override Index<object> Parameters
                => new object[Arity]{Param0, Param1, Param2, Param3, Param4};
        }
    }
}