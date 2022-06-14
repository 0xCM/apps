//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class TextTemplates
    {
        public class TextTemplate<T0> : TextTemplate
        {
            public const byte Arity = 1;

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

            public override uint ParameterCount => Arity;

            public override Index<object> Parameters
                => new object[Arity]{Param0};
        }
    }
}