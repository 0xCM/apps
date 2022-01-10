//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct HexFileStats
    {
        public uint RowCount;

        public Hex32 RowSize;

        public Hex32 TotalSize;

        public FS.FilePath Path;
    }
}