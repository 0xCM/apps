//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
    public struct PageBlock128 : IPageBlock<PageBlock128>
    {
        public const uint SZ = PageCount*PageSize;

        public const uint PageCount = 128;

        PageBlock32 Block0;

        PageBlock32 Block1;

        PageBlock32 Block2;

        PageBlock32 Block3;
    }
}