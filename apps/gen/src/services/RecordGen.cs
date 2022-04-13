//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class RecordGen : AppService<RecordGen>
    {
        public void Emit(uint margin, TableDef spec, ITextBuffer dst)
        {
            dst.IndentLine(margin, "[Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]");
            dst.IndentLineFormat(margin, "public struct {0}", spec.TypeName);
            dst.IndentLine(margin, Chars.LBrace);
            margin += 4;
            dst.IndentLineFormat(margin,"public const string TableId = \"{0}\";", spec.TableId);

            ref readonly var fields = ref spec.Fields;
            for(var i=0; i<fields.Count; i++)
            {
                dst.AppendLine();
                ref readonly var field = ref fields[i];
                dst.IndentLineFormat(margin,"public {0} {1};", field.DataType, field.FieldName);
            }

            margin -= 4;
            dst.IndentLine(margin, Chars.RBrace);
        }
    }
}
