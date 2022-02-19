//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static XedRecords;

    [Record(TableId)]
    public struct IntelIntrinsic
    {
        public const string TableId = "intel.intrinsics";

        public const byte FieldCount = 7;

        public string Name;

        public DelimitedIndex<string> CpuId;

        public DelimitedIndex<string> Types;

        public string Category;

        public string Signature;

        public string Instruction;

        public IFormType IForm;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{42,32,32,32,120,56,120};
    }
}