//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class StringTableGen : AppService<StringTableGen>
    {
        public Outcome Emit(StringTableSyntax syntax, ItemList<string> items, FS.FolderPath outdir)
        {
            var result = Outcome.Success;
            EmitTableCode(syntax,items, outdir + FS.file(syntax.TableName.Format(), FS.Cs));
            EmitTableData(items, outdir + FS.file(syntax.TableName.Format(), FS.Csv));
            return result;
        }

        void EmitTableCode(StringTableSyntax src, ItemList<string> items, FS.FilePath dst)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            StringTables.csharp(src, items, writer);
            EmittedFile(emitting,1);
        }

        void EmitTableData(ItemList<string> items, FS.FilePath dst)
        {
            var buffer = alloc<StringTableRow>(items.Length);
            StringTables.rows(items, buffer);
            TableEmit(@readonly(buffer), StringTableRow.RenderWidths, dst);
        }
    }
}