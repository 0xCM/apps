//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TypeSpecifier
    {
        public readonly Label Pattern;

        [MethodImpl(Inline)]
        public TypeSpecifier(string src)
        {
            Pattern = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator TypeSpecifier(string src)
            => new TypeSpecifier(src);
    }
}