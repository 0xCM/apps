//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    public partial class LlvmDataEmitter : AppService<LlvmDataEmitter>
    {
        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);

        LlvmDataProvider DataProvider => Service(Wf.LlvmDataProvider);

        LlvmDataCalcs DataCalcs => Service(Wf.LlvmDataCalcs);


        public void EmitInstPatterns(ReadOnlySpan<LlvmInstPattern> src)
            => TableEmit(src, LlvmInstPattern.RenderWidths, LlvmPaths.Table<LlvmInstPattern>());

        public void EmitAsmVariations(ReadOnlySpan<LlvmAsmVariation> src)
            => TableEmit(src, LlvmPaths.Table<LlvmAsmVariation>());

        public void EmitRegIdentifiers(RegIdentifiers src)
        {
            var dst = LlvmPaths.Table("llvm.asm.RegId");
            var list = new LlvmList(dst, src.Values.Select(x => new LlvmListItem(x.Id, x.RegName.Format())).ToArray());
            EmitList(list, dst);
        }

        public void EmitAsmIdentifiers(AsmIdentifiers src)
        {
            var values = src.Values;
            var items = values.Select(x => new LlvmListItem(x.Id, x.Instruction.Format())).ToArray();
            var dst = LlvmPaths.Table("llvm.asm.AsmId");
            EmitList(new LlvmList(dst, items), dst);
        }

        public void EmitOpCodes(ReadOnlySpan<LlvmAsmOpCode> src)
            => TableEmit(src, LlvmPaths.Table<LlvmAsmOpCode>());
    }
}