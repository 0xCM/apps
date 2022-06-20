//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class TextTemplates
    {
        public class TextTemplate<T0,T1,T2> : TextTemplate<T0,T1>
        {
            public new const byte Arity = 3;

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

            public override uint ParameterCount => Arity;

            public override Index<object> Parameters
                => array<object>(Param0, Param1, Param2);
        }

    }
}