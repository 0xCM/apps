//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextTemplates
    {
        public class TextTemplate<T0,T1,T2,T3> : TextTemplate<T0,T1,T2>
        {
            public new const byte Arity = 4;

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

            public override uint ParameterCount => Arity;

            public override Index<object> Parameters
                => new object[Arity]{Param0, Param1, Param2, Param3};
        }
    }
}