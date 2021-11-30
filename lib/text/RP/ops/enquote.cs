//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RP
    {
        [Op]
        public static string enquote(string src)
        {
            if(!string.IsNullOrWhiteSpace(src))
                return string.Concat(Chars.Quote, src, Chars.Quote);
            else
                return EmptyString;
        }
    }
}