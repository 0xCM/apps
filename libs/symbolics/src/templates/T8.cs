//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class TextTemplates
    {
        public class TextTemplate<T0,T1,T2,T3,T4,T5,T6,T7> : TextTemplate<T0,T1,T2,T3,T4,T5,T6>
        {
            public new const byte Arity = 8;

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

            public override uint ParameterCount => Arity;

            public override Index<object> Parameters
                => new object[Arity]{Param0, Param1, Param2, Param3, Param4, Param5, Param6, Param7};
        }
    }
}