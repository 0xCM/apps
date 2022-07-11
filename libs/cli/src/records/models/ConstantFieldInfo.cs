//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ConstantFieldInfo
    {
        const string TableId = "fields.const";

        [Render(8)]
        public uint Seq;

        [Render(16)]
        public CliToken ParentId;

        [Render(32)]
        public string Source;

        [Render(16)]
        public ConstantTypeCode DataType;

        [Render(1)]
        public BinaryCode Content;
    }
}