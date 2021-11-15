//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ApiExtractRow : IRecord<ApiExtractRow>
    {
        public const string TableId = "extract";

        public MemoryAddress Base;

        public Name Uri;

        public BinaryCode Encoded;
    }
}