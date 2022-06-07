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

        public void Emit(Index<ClassRelations> src)
            => AppSvc.TableEmit(src, LlvmPaths.Table<ClassRelations>());

        public void Emit(Index<DefRelations> src)
            => AppSvc.TableEmit(src, LlvmPaths.Table<DefRelations>());

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
            var dst = LlvmPaths.Table(RegIdentifier.TableId);
            var list = new LlvmList(dst, src.Values.Select(x => new LlvmListItem(x.Id, x.Name.Format())));
            EmitList(list, dst);
        }

        public void Emit(AsmIdentifiers src)
        {
            var items = src.Values.Select(x => new LlvmListItem(x.Id, x.Name.Format()));
            var dst = LlvmPaths.Table(AsmIdentifier.TableId);
            EmitList(new LlvmList(dst, items), dst);
        }

        public void Emit(ReadOnlySpan<LlvmAsmOpCode> src)
            => AppSvc.TableEmit(src, LlvmPaths.Table<LlvmAsmOpCode>());
    }
}