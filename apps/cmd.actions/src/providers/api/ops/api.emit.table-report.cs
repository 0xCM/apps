//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCmdProvider
    {
        const string EmitApiTables = "api/emit/tables";

        [CmdOp(EmitApiTables)]
        Outcome EmitTableReport(CmdArgs args)
        {
            var dst = ProjectDb.Subdir("api") + FS.file("api.tables", FS.Csv);
            EmitTableReport(dst);
            return true;
        }

        void EmitTableReport(FS.FilePath dst)
        {
            using var writer = dst.Writer();
            var emitting = EmittingFile(dst);
            var tables = Tables.reflected(ApiRuntimeCatalog.Components);
            var count = tables.Length;
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    writer.WriteLine();

                var table = skip(tables,i);
                writer.WriteLine(string.Format("{0,-8} | {1,-42} | {2}", i, table.Id.Identifier, table.Id.Identity));
                writer.WriteLine(RP.PageBreak80);

                var fields = @readonly(table.Fields);
                for(var j=0; j<fields.Length; j++)
                {
                    ref readonly var field = ref skip(fields,j);
                    writer.WriteLine(string.Format("{0,-8} | {1,-42} | {2}", field.FieldIndex, field.Name, field.DataType));
                }
            }

            EmittedFile(emitting, count);
        }
    }
}