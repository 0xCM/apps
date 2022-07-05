//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ImageMemory
    {
        public static PEReader pe(Stream src)
            => new PEReader(src);
    }
}