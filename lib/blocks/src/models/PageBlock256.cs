//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
    public struct PageBlock256 : IPageBlock<PageBlock256>
    {
        public const uint SZ = PageCount*PageSize;

        public const uint PageCount = 256;

        PageBlock64 Block0;

        PageBlock64 Block1;

        PageBlock64 Block2;

        PageBlock64 Block3;
    }
}