//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial struct Symbols
    {
        public static TokenSet tokens(Type[] src)
        {
            var dst = new TokenSet();
            dst.WithTypes(src);
            return dst;
        }

        public static TokenSet tokens(string name, Type[] src)
        {
            var dst = new TokenSet(name);
            dst.WithTypes(src);
            return dst;
        }
    }
}