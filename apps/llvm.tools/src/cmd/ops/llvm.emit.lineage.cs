//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static Root;
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/lineage")]
        Outcome EmitLineageSummary(CmdArgs args)
        {
            var result = Outcome.Success;
            var defrel = DataProvider.SelectDefRelations();
            var classrel = DataProvider.SelectClassRelations();

            var dst = Data.Log("llvm.lineage");
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

            iter(LlvmRelations.equivalance(classrel), c => Write(c.Format()));

            EmittedFile(emitting, classrel.Length + defrel.Length);

            return result;
        }
    }
}