//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/tables/schemas")]
        Outcome EmitTableSchemas(CmdArgs args)
        {
            var schemas = Tables.schemas(ApiRuntimeCatalog.Components);
            var count = schemas.Count;
            var dst = ProjectDb.Api() + FS.file("api.tables.schema");
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<count; i++)
            {
                ref readonly var schema = ref schemas[i];
                var fields = schema.Fields;
                var fcount = fields.Length;
                writer.WriteLine(string.Format("table {0} {{", schema.TableId));
                for(var j=0; j<fcount; j++)
                {
                    ref readonly var field = ref skip(fields,j);
                    writer.WriteLine(string.Format("  {0}", field.Format()));
                }
                writer.WriteLine("}");
                if(i != count - 1)
                    writer.WriteLine();
            }

            EmittedFile(emitting,count);
            return true;
        }
    }
}
