//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    partial class text
    {
        public static string embrace<T>(T src)
            => $"{Chars.LBrace}{src}{Chars.RBrace}";
    }
}