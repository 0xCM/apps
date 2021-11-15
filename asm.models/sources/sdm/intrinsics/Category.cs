//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class IntelIntrinsicModels
    {
        public struct Category : ITextual
        {
            public const string ElementName = "category";

            public string Content;

            [MethodImpl(Inline)]
            public Category(string src)
            {
                Content = src;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => nonempty(Content);
            }

            public string Format()
                => Content;

            public override string ToString()
                => Content;

            [MethodImpl(Inline)]
            public static implicit operator Category(string src)
                => new Category(src);

            [MethodImpl(Inline)]
            public static implicit operator string(Category src)
                => src.Content;
        }
    }
}