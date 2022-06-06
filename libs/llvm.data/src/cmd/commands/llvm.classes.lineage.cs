//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/lineage")]
        Outcome QueryClassLineage(CmdArgs args)
        {
            Query.FileEmit("llvm/classes/lineage", DataProvider.ClassLineage().Values);
            return true;
        }

        [CmdOp("llvm/emit/lineage-summary")]
        Outcome EmitLineageSummary(CmdArgs args)
        {
            var result = Outcome.Success;
            var defrel = DataProvider.DefRelations();
            var classrel = DataProvider.ClassRelations();
            var dst =  AppDb.Targets("llvm/logs").Path("llvm.lineage", FileKind.Txt);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();

            iter(classrel, r => {
                if(r.Ancestors.IsNonEmpty)
                    writer.WriteLine(string.Format("{0} -> {1}", r.Name, r.Ancestors));
                else
                    writer.WriteLine(r.Name);
            });

            iter(defrel, r => {
                if(r.Ancestors.IsNonEmpty)
                    writer.WriteLine(string.Format("{0} -> {1}", r.Name, r.Ancestors));
                else
                    writer.WriteLine(r.Name);
            });

            iter(LlvmRelations.CalcEqClasses(classrel), c => Write(c.Format()));

            EmittedFile(emitting, classrel.Length + defrel.Length);

            return result;
        }
    }
}