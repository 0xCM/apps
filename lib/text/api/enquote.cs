//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    partial class text
    {
        [Op]
        public static string enquote(string src)
            => nonempty(src) ? string.Concat(Chars.Quote, src, Chars.Quote) : EmptyString;
   }
}