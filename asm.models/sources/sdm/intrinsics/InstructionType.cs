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
        public struct InstructionType
        {
            public const string ElementType = "type";

            public string Content;

            [MethodImpl(Inline)]
            public InstructionType(string src)
            {
                Content = src;
            }

            public string Format()
                => Content;

            public override string ToString()
                => Content;

            [MethodImpl(Inline)]
            public static implicit operator InstructionType(string src)
                => new InstructionType(src);
        }
    }
}