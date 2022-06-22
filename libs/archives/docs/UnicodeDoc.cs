//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static DocModels;

    public sealed class UnicodeDoc : Doc<char>
    {
        public UnicodeDoc(char[] src)
            : base(src)
        {
            //LineCount = Lines.count(src);
        }

    }
}