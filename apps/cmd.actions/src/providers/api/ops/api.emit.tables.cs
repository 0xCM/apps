//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using static core;

    partial class ApiCmdProvider
    {
        static uint FieldCount(ReadOnlySpan<TableDef> src)
        {
            var counter = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var table = ref skip(src,i);
                counter += (uint)table.Fields.Length;
            }
            return counter;
        }

        [CmdOp("api/emit/tables")]
        Outcome EmitTableReport(CmdArgs args)
        {
            var dst = ProjectDb.Subdir("api") + FS.file("api.tables", FS.Csv);
            var tables = ApiRuntimeCatalog.TableDefs;
            var kTables = tables.Length;
            var kFields = FieldCount(tables);
            var buffer = alloc<TableDefRecord>(kFields);
            var k=0u;
            for(var i=0; i<kTables; i++)
            {
                ref readonly var table = ref skip(tables,i);
                var fields = table.Fields;
                for(var j=0; j<fields.Length; j++)
                {
                    ref readonly var field = ref skip(fields,j);
                    ref var record = ref seek(buffer,k);
                    record.Seq = k;
                    record.TableId = table.TableId;
                    record.TableType = table.TypeName;
                    record.FieldIndex = field.FieldIndex;
                    record.FieldType = field.DataType;
                    record.FieldName = field.FieldName;
                    k++;
                }
            }

            TableEmit(@readonly(buffer), TableDefRecord.RenderWidths, dst);
            return true;
        }
    }
}