//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;
    using static Root;

    public class RecordGen : AppService<RecordGen>
    {
        public void Emit(uint margin, TableDef spec, ITextBuffer dst)
        {
            dst.IndentLine(margin, "[Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]");
            dst.IndentLineFormat(margin, "public struct {0}", spec.TypeName);
            dst.IndentLine(margin, Chars.LBrace);
            margin += 4;
            dst.IndentLineFormat(margin,"public const string TableId = \"{0}\";", spec.TableId);

            var fields = spec.Fields;
            var count = fields.Length;
            for(var i=0; i<count; i++)
            {
                dst.AppendLine();
                ref readonly var field = ref skip(fields,i);
                dst.IndentLineFormat(margin,"public {0} {1};", field.DataType.Format(), field.FieldName);
            }

            margin -= 4;
            dst.IndentLine(margin, Chars.RBrace);
        }
    }
}
