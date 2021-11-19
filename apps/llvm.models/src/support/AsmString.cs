//-----------------------------------------------------------------------------
// Copyright   :  (c) LLVM Project
// License     :  Apache-2.0 WITH LLVM-exceptions
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmString
    {
        readonly string Content;

        [MethodImpl(Inline)]
        public AsmString(string src)
        {
            Content = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator AsmString(string src)
            => new AsmString(src);
    }
}