//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp(".bitfields")]
        Outcome EmitBitfield(CmdArgs args)
        {
            var result = Outcome.Success;
            var syms = Symbols.index<Bf1>();
            var dst = LlvmData.Subdir("bitfields");
            var model = Wf.Bitfields().EmitBitfield(syms, nameof(Bf1), dst);
            return result;
        }

        public enum Bf1 : uint
        {
            Field0 = 3,

            Field1 = 7,

            Field2 = 1,

            Field3 = 2,
        }
    }
}