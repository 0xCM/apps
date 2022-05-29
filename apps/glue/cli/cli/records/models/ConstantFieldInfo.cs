//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ConstantFieldInfo : IRecord<ConstantFieldInfo>
    {
        public const string TableId = "cli.metadata.constfield";

        public Count Sequence;

        public CliToken ParentId;

        public string Source;

        public ConstantTypeCode DataType;

        public BinaryCode Content;
    }
}