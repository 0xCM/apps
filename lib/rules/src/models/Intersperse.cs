//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        /// <summary>
        /// Specifies that the terms of an input sequence are interspersed by a distinguished element
        /// </summary>
        public readonly struct Intersperse
        {
            public dynamic Element {get;}

            [MethodImpl(Inline)]
            public Intersperse(dynamic insert)
            {
                Element = insert;
            }
        }

        /// <summary>
        /// Specifies that the terms of an input sequence are interspersed by a distinguished element
        /// </summary>
        public readonly struct Intersperse<T>
        {
            public T Element {get;}

            [MethodImpl(Inline)]
            public Intersperse(T insert)
            {
                Element = insert;
            }

            public static implicit operator Intersperse(Intersperse<T> src)
                => new Intersperse(src.Element);
        }
    }
}