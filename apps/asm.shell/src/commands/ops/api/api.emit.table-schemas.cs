//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static Root;

    partial class AsmCmdService
    {
        [CmdOp("api/emit/table-schemas")]
        Outcome TableSchemas(CmdArgs args)
        {
            var catalog = ApiRuntimeLoader.catalog();
            var schemas = Tables.schemas(catalog.Components);
            var count = schemas.Count;
            var dst = Ws.Project("db").Subdir("api") + FS.file("api.tables.schema");
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<count; i++)
            {
                ref readonly var schema = ref schemas[i];
                var fields = schema.Fields;
                var fcount = fields.Length;
                writer.WriteLine(string.Format("table {0} {{", schema.Id));
                for(var j=0; j<fcount; j++)
                {
                    ref readonly var field = ref skip(fields,j);
                    writer.WriteLine(string.Format("  {0}",field.Format()));
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