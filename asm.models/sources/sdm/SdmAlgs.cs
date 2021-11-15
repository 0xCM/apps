//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly partial struct SdmAlgs
    {
        [MethodImpl(Inline)]
        public static string format(in Comment src)
            => string.Format("(* {0} *)", src.Content);

        [MethodImpl(Inline)]
        public static Comment comment(string src)
            => new Comment(src);

        public readonly struct Comparison
        {
            readonly uint Data;

            [MethodImpl(Inline)]
            internal Comparison(uint data)
            {
                Data = data;
            }
        }

        public readonly struct Comment
        {
            public string Content {get;}

            [MethodImpl(Inline)]
            public Comment(string src)
            {
                Content = src;
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();
        }
    }
}