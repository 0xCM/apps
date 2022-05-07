//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static MemDb;

    partial class XedDb
    {
        public void EmitTypeTables()
        {
            var dst = text.emitter();
            var objects = Services.Objects;
            dst.AppendLine(Render.TypeTableHeader());
            var count = objects.ObjectCount(ObjectKind.TypeTable);
            for(var i=0; i<count; i++)
                dst.Append(Render.Format(objects.TypeTable(i)));
            FileEmit(dst.Emit(), count, Paths.DbTarget("typetables", FileKind.Csv), TextEncodingKind.Asci);
        }
    }
}