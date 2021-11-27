//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
    public struct PageBlock16x4 : IPageBlock<PageBlock16x4>
    {
        public const uint SZ = PageCount*PageSize;

        public const uint PageCount = 64;

        PageBlock16 Block0;

        PageBlock16 Block1;

        PageBlock16 Block2;

        PageBlock16 Block3;
    }
}