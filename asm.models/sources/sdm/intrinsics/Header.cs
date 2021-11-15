//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class IntelIntrinsicModels
    {
        public struct Header : ITextual
        {
            public const string ElementName = "header";

            public string Content;

            [MethodImpl(Inline)]
            public Header(string src)
            {
                Content = src;
            }

            public string Format()
                => Content;

            public override string ToString()
                => Content;

            [MethodImpl(Inline)]
            public static implicit operator Header(string src)
                => new Header(src);
        }
    }
}