//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ApiCodeDescriptor : IRecord<ApiCodeDescriptor>
    {
        public const string TableId = "apicode";

        public ApiPartKind Part;

        public Name Host;

        public MemoryAddress Base;

        public ByteSize Size;

        public OpUri Uri;

        public BinaryCode Encoded;
    }
}