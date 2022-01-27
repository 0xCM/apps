//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Generic;

    public class Productions : ConstLookup<string, Index<string>>
    {

        public Productions(Dictionary<string, Index<string>> src)
            : base(src)
        {

        }

        public static implicit operator Productions(Dictionary<string,Index<string>> src)
            => new Productions(src);
    }
}