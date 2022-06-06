//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    public partial class LlvmDataEmitter : AppService<LlvmDataEmitter>
    {
        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);

        LlvmDataProvider DataProvider => Service(Wf.LlvmDataProvider);

        LlvmDataCalcs DataCalcs => Service(Wf.LlvmDataCalcs);

        AppSvcOps AppSvc => Service(Wf.AppSvc);

        public LlvmQuery Query => Service(() => LlvmQuery.create(Wf));

        public void Emit(string id, Index<LlvmTestLogEntry> src)
            => AppSvc.TableEmit(src, LlvmPaths.LogTargets().Table<LlvmTestLogEntry>("llvm.tests.logs." + id + ".detail"));

        public void Emit(ReadOnlySpan<LlvmInstDef> src)
            => AppSvc.TableEmit(src, LlvmPaths.Table<LlvmInstDef>());

        public void Emit(ReadOnlySpan<AsmMnemonicRow> src)
            => AppSvc.TableEmit(src, LlvmPaths.Table("llvm.asm.mnemonics"));

        public void Emit(ReadOnlySpan<LlvmAsmInstPattern> src)
            => AppSvc.TableEmit(src, LlvmPaths.Table<LlvmAsmInstPattern>());

        public void Emit(ReadOnlySpan<LlvmAsmVariation> src)
            => AppSvc.TableEmit(src, LlvmPaths.Table<LlvmAsmVariation>());

        public void Emit(RegIdentifiers src)
        {
            var dst = LlvmPaths.Table("llvm.asm.RegId");
            var list = new LlvmList(dst, src.Values.Select(x => new LlvmListItem(x.Id, x.RegName.Format())));
            EmitList(list, dst);
        }

        public void Emit(ReadOnlySpan<LlvmAsmPattern> src)
            => AppSvc.TableEmit(src, LlvmPaths.Table<LlvmAsmPattern>());

        public void Emit(AsmIdentifiers src)
        {
            var values = src.Values;
            var items = values.Select(x => new LlvmListItem(x.Id, x.Instruction.Format()));
            var dst = LlvmPaths.Table("llvm.asm.AsmId");
            EmitList(new LlvmList(dst, items), dst);
        }

        public void Emit(ReadOnlySpan<LlvmAsmOpCode> src)
            => AppSvc.TableEmit(src, LlvmPaths.Table<LlvmAsmOpCode>());
    }
}