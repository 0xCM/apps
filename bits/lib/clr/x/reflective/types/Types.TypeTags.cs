//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using System;

    partial class ClrQuery
    {
        public static Pairings<Type,A> TypeTags<A>(this Type[] src)
            where A : Attribute
                => src.Tagged<A>().Select(t => core.paired(t,t.Tag<A>().Require()));
    }
}