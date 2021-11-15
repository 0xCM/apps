//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    partial class text
    {
        [Op]
        public static bool member(string src, ISet<string> set, bool partial = true)
        {
            if(partial)
            {
                foreach(var item in set)
                {
                    if(src.Contains(item))
                        return true;
                }
                return false;
            }
            else
                return set.Contains(src);
        }
    }
}