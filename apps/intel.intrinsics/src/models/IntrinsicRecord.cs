//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static IntrinsicsDoc;

    partial class IntelIntrinsics
    {
        [Record(TableId)]
        public struct IntrinsicRecord : IComparable<IntrinsicRecord>, ISequential<IntrinsicRecord>
        {
            const string TableId = "intel.intrinsics";

            [Render(8)]
            public uint Key;

            [Render(8)]
            public ushort FormId;

            [Render(64)]
            public InstForm InstForm;

            [Render(42)]
            public string Name;

            [Render(56)]
            public Instruction Instruction;

            [Render(32)]
            public DelimitedIndex<CpuId> CpuId;

            [Render(32)]
            public DelimitedIndex<InstructionType> Types;

            [Render(32)]
            public string Category;

            [Render(1)]
            public string Signature;

            uint ISequential.Seq
            {
                get => Key;
                set => Key = value;
            }

            public int CompareTo(IntrinsicRecord src)
            {
                var result = InstForm.CompareTo(src.InstForm);
                if(result == 0)
                    result = Name.CompareTo(src.Name);
                return result;
            }
        }
    }
}