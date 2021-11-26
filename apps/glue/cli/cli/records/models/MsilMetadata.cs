//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MsilMetadata : IRecord<MsilMetadata>
    {
        public const string TableId = "image.msil";

        public const byte FieldCount = 8;

        public FS.FileName ImageName;

        public CliToken Token;

        public Address32 MethodRva;

        public ByteSize BodySize;

        public ByteSize MaxStack;

        public bool LocalInit;

        public ClrMemberName MethodName;

        public BinaryCode Code;
    }
}