//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ApiExtractRow
    {
        public const string TableId = "extract";

        public MemoryAddress Base;

        public NameOld Uri;

        public BinaryCode Encoded;
    }
}