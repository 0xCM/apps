//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class StringTableGen : AppService<StringTableGen>
    {
        public Outcome Generate(StringTableSpec spec, FS.FolderPath outdir)
        {
            var result = Outcome.Success;
            var syntax = spec.Syntax;
            var csdst = outdir + FS.file(syntax.TableName.Format(), FS.Cs);
            var rowdst = outdir + FS.file(syntax.TableName.Format(), FS.Csv);
            var emitting = EmittingFile(csdst);
            using var cswriter = csdst.Writer();
            var cscount = StringTables.csharp(syntax, spec.Entries, cswriter);
            EmittedFile(emitting, cscount);
            var buffer = alloc<StringTableRow>(spec.Entries.Length);
            StringTables.rows(spec, buffer);
            TableEmit(@readonly(buffer), StringTableRow.RenderWidths, rowdst);
            return result;
        }
    }
}