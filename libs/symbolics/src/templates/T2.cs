//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class TextTemplates
    {
        public class TextTemplate<T0,T1> : TextTemplate<T0>
        {
            public new const byte Arity = 2;

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

            public override uint ParameterCount => Arity;

            public override Index<object> Parameters
                => new object[Arity]{Param0, Param1};
        }
    }
}