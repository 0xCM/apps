//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static XedModels;

    [Record(TableId)]
    public struct IntelIntrinsic : IComparable<IntelIntrinsic>
    {
        const string TableId = "intel.intrinsics";

        [Render(64)]
        public InstForm Form;

        [Render(42)]
        public string Name;

        [Render(56)]
        public string Instruction;

        [Render(32)]
        public DelimitedIndex<string> CpuId;

        [Render(32)]
        public DelimitedIndex<string> Types;

        [Render(32)]
        public string Category;

        [Render(1)]
        public string Signature;

        public int CompareTo(IntelIntrinsic src)
        {
            var result = Form.CompareTo(src.Form);
            if(result == 0)
                result = Name.CompareTo(src.Name);
            return result;
        }
    }
}