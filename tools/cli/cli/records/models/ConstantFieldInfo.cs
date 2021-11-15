//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;
    using System.Reflection.Metadata;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ConstantFieldInfo : IRecord<ConstantFieldInfo>
    {
        public const string TableId = "image.constants";

        public Count Sequence;

        public CliToken ParentId;

        public string Source;

        public ConstantTypeCode DataType;

        public BinaryCode Content;
    }
}