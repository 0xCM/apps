//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public class LlvmImportObserver
    {
        public virtual void EtlStarted()
        {
        }

        public virtual void ToolHelpEmitted(Index<ToolHelpDoc> src)
        {
        }

        public virtual void AsmIdDefsEmitted(LlvmList src)
        {
        }

        public virtual void RegIdDefsEmitted(LlvmList src)
        {
        }

        public virtual void SourceRecordsSelected(Index<TextLine> src)
        {
        }

        public virtual void ClassRelationsEmitted(Index<ClassRelations> src)
        {
        }

        public virtual void DefRelationsEmitted(Index<DefRelations> src)
        {
        }

        public virtual void DefMapEmitted(LineMap<Identifier> src)
        {
        }

        public virtual void DefFieldsEmitted(Index<RecordField> src)
        {
        }

        public virtual void ClassMapEmitted(LineMap<Identifier> src)
        {
        }

        public virtual void ClassFieldsEmitted(Index<RecordField> src)
        {
        }

        public virtual void EntitiesSelected(Index<LlvmEntity> src)
        {
        }

        public virtual void ListsEmitted(Index<LlvmList> src)
        {
        }

        public virtual void ChildRelationsEmitted(Index<ChildRelation> src)
        {
        }

        public virtual void AsmVariationsEmitted(Index<LlvmAsmVariation> src)
        {
        }

        public virtual void InstDefsEmitted(Index<LlvmInstDef> src)
        {
        }

        public virtual void InstPatternsEmitted(Index<LlvmInstPattern> src)
        {
        }

        public virtual void EtlCompleted()
        {
        }
    }
}