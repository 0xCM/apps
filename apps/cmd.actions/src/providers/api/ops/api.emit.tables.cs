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
                var table = skip(tables,i);
                var fields = @readonly(table.Fields);
                for(var j=0; j<fields.Length; j++)
                {
                    ref readonly var field = ref skip(fields,j);
                    var spec = field.DataType.Spec();
                    writer.WriteLine(string.Format("{0,-24} | {1,-48} | {2,-8} | {3,-42} | {4}", table.Type.DisplayName(), table.Id.Identifier, field.FieldIndex, field.FieldName, spec));
                }
            }

            EmittedFile(emitting, count);
        }
    }
}