//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static MemDb;
    using Asm;
    partial class AsmCoreCmd
    {
        [CmdOp("xed/db/check")]
        Outcome CheckXedDb(CmdArgs args)
        {
            var formatter = RecordFormatter.create(typeof(TypeTableRow));
            var rows = Rules.CalcTypeTables().SelectMany(x => x.Rows).Sort().Resequence();
            AppSvc.TableEmit(rows, XedPaths.DbTable<TypeTableRow>());
            CheckRender();
            return true;
        }

        [MethodImpl(Inline)]
        static ulong key(Type type, ushort selector)
        {
            var token = (uint)type.MetadataToken;
            var part = type.Assembly.Id();
            return (ulong)token | ((ulong)part << 32) | ((ulong)selector << 38);
        }

        void CheckRender()
        {
            var k0 = key(typeof(num4),z16);
            var points = Rules.CalcPoints();
            var f2 = Tables.formatter<Coordinate>();
            for(var i=0; i<points.Count; i++)
            {
                ref readonly var point = ref points[i];
                Write(f2.Format(point));
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
            FileEmit(lDst.Emit(), linear.Count, AppDb.Logs().Scoped(scope).Path($"{scope}.linear.{suffix}", FileKind.Csv));
            FileEmit(rDst.Emit(), m, AppDb.Logs().Scoped(scope).Path($"{scope}.rows.{suffix}", FileKind.Txt), TextEncodingKind.Asci);
            FileEmit(cDst.Emit(), m, AppDb.Logs().Scoped(scope).Path($"{scope}.cols.{suffix}", FileKind.Txt), TextEncodingKind.Asci);
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