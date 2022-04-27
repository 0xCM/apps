//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedDb;
    using static core;

    partial class XedCmdProvider
    {
        XedDb XedDb => Service(Wf.XedDb);

        [CmdOp("xed/emit/schema")]
        Outcome EmitSchema(CmdArgs args)
        {
            var formatter = Tables.formatter<TypeTable>();
            Write(formatter.FormatHeader());

            var dst = text.emitter();
            var objects = XedDb.Schema.Objects;
            var render = XedDb.Render;

            dst.AppendLine(TypeTable.header());
            var count = objects.ObjectCount(ObjectKind.TypeTable);
            for(var i=0; i<count; i++)
            {
                ref readonly var table = ref objects.TypeTable(i);
                dst.Append(table.Format());
            }
            FileEmit(dst.Emit(), count, XedDb.TargetPath("typetables", FileKind.Csv), TextEncodingKind.Asci);

            return true;
        }

    }
}