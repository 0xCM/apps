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
            var objects = Schema.Objects;
            var render = Render;
            dst.AppendLine(TypeTable.header());
            var count = objects.ObjectCount(ObjectKind.TypeTable);
            for(var i=0; i<count; i++)
                dst.Append(objects.TypeTable(i).Format());
            FileEmit(dst.Emit(), count, TargetPath("typetables", FileKind.Csv), TextEncodingKind.Asci);
        }
    }
}