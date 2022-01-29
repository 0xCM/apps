//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Generic;

    public class Productions
    {
        ConstLookup<string, Index<string>> Data;

        public Productions(Dictionary<string, Index<string>> src)
        {
            Data = src;
        }

        public Index<string> this[string left]
        {
            get => Data[left];
        }

        public bool Find(string src, out Index<string> dst)
            => Data.Find(src, out dst);

        public static implicit operator Productions(Dictionary<string,Index<string>> src)
            => new Productions(src);
    }
}