//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    partial class text
    {
        public static int hash(string src)
            => (src ?? EmptyString).GetHashCode();
    }
}