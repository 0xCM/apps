//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Threading.Tasks;

    using static Root;
    using static core;

    partial class XTend
    {
        public static Task Continue<T>(this Task<T> src, Action<T> @continue)
            where T : struct, ICmd
                => src.ContinueWith(t => @continue(t.Result));
    }
}