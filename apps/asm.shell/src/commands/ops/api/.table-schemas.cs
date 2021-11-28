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
        [CmdOp(".table-schemas")]
        Outcome TableSchemas(CmdArgs args)
        {
            var catalog = ApiRuntimeLoader.catalog();
            var schemas = Tables.schemas(catalog.Components);
            var count = schemas.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var schema = ref schemas[i];
                var fields = schema.Fields;
                var fcount = fields.Length;
                Write(string.Format("table {0} {{", schema.Id));
                for(var j=0; j<fcount; j++)
                {
                    ref readonly var field = ref skip(fields,j);
                    Write(string.Format("  {0}",field.Format()));
                }
                Write("}");
                Write(EmptyString);
            }

            return true;
        }
    }
}