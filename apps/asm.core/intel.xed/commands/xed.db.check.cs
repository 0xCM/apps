//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static MemDb;

    partial class XedCmdProvider
    {
        [CmdOp("xed/db/check")]
        Outcome CheckXedDb(CmdArgs args)
        {
            CheckLocatedFields();

            var formatter = RecordFormatter.create(typeof(TypeTableRow));
            var types = XedDb.Views.TypeTables;

            Write(formatter.FormatHeader());
            for(var i=0; i<types.Count; i++)
            {
                ref readonly var type = ref types[i];
                ref readonly var rows = ref type.Rows;
                for(var j=0; j<rows.Count; j++)
                {
                    ref readonly var row = ref rows[j];
                    Write(formatter.Format(row));
                }
            }


            return true;
        }

        void CheckLocatedFields()
        {
            var located = XedDb.CalcLocatedFields(CalcRuleCells());
            for(var i=0; i<located.Count; i++)
            {
                ref readonly var f0 = ref located[i];
                var a = LocatedField.pack(f0);
                Require.equal(f0,LocatedField.unpack(a));
            }
        }
        void CheckMemDb(Dim2<uint> shape)
        {
            var r = shape.I;
            var c = shape.J;
            var m = (uint)(r*c);
            var grid = MemDb.grid<byte>(shape);
            ref readonly var rows = ref grid.Rows;
            for(var i=0u; i<r; i++)
            {
                for(var j=0u; j<c; j++)
                    rows[i,j] = (byte)math.mod((i*c + j), r) ;
            }

            var cols = rows.Columns();
            var rDst = text.emitter();
            var cDst = text.emitter();

            for(var i=0u; i<r; i++)
            {
                for(var j=0u; j<c; j++)
                {
                    rDst.AppendFormat("{0:X2} | ", rows[i,j]);
                    cDst.AppendFormat("{0:X2} | ", cols[i,j]);
                }

                rDst.AppendLine();
                cDst.AppendLine();
            }

            var linear = Points.multilinear(shape);
            var lDst = text.emitter();
            Points.render(linear, lDst);

            var scope = "memdb";
            var suffix = $"{r}x{c}";
            FileEmit(lDst.Emit(), linear.Count, AppDb.Log(scope, $"{scope}.linear.{suffix}", FileKind.Csv));
            FileEmit(rDst.Emit(), m, AppDb.Log(scope, $"{scope}.rows.{suffix}", FileKind.Txt), TextEncodingKind.Asci);
            FileEmit(cDst.Emit(), m, AppDb.Log(scope, $"{scope}.cols.{suffix}", FileKind.Txt), TextEncodingKind.Asci);
        }

        [CmdOp("memdb/check")]
        Outcome CheckMemDb(CmdArgs args)
        {
            CheckMemDb((32,32));
            CheckMemDb((12,12));
            CheckMemDb((8,8));
            CheckMemDb((256,256));
           return true;
        }
    }
}