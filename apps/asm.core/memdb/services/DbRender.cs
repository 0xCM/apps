//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class MemDb
    {
        public class DbRender
        {
            string combined()
            {
                var s0 = z16;
                var s1 = z16;
                var left = Schema.TypeTableColumns(ref s0);
                var right = TypeTableRow.Columns(ref s1);
                var joined = resequence(left,right);
                var names = joined.Select(x => x.ColName.Format());
                var widths = joined.Select(x => x.RenderWidth);
                var pattern = joined.Select(x => RP.slot((byte)x.Pos, (sbyte)-x.RenderWidth)).Concat(" | ");
                return pattern;
            }

            public string TypeTableHeader()
            {
                var s0 = z16;
                var s1 = z16;
                var left = Schema.TypeTableColumns(ref s0);
                var right = TypeTableRow.Columns(ref s1);
                var joined = resequence(left,right);
                var names = joined.Select(x => x.ColName.Format());
                var widths = joined.Select(x => x.RenderWidth);
                return string.Format(combined(), names.Storage);
            }

            public string Format(in TypeTable src)
            {
                var pattern = combined();
                var dst = text.emitter();
                var left = Tables.dynarow(Tables.fields(typeof(TypeTable)));
                left.Update(src);
                var right = Tables.dynarow(Tables.fields(typeof(TypeTableRow)));

                for(var j=0; j<src.Rows.Count; j++)
                {
                    right.Update(src.Rows[j]);

                    var cells =  (left.Cells.Index() + right.Cells.Index()).Storage;
                    dst.AppendLineFormat(pattern, cells);
                }

                return dst.Emit();
            }

            Index<ObjectKind,string> Patterns;

            Index<ObjectKind,string> Headers;

            [MethodImpl(Inline)]
            public ref readonly string Pattern(ObjectKind kind)
                => ref Patterns[kind];

            [MethodImpl(Inline)]
            public ref readonly string Header(ObjectKind kind)
                => ref Headers[kind];

            DbSchema _Schema;

            ref readonly DbSchema Schema
            {
                [MethodImpl(Inline)]
                get => ref _Schema;
            }

            internal DbRender(DbSchema schema)
            {
                _Schema = schema;
                const byte Count = DbObjects.ObjTypeCount;
                var kinds = schema.ObjKinds;

                Patterns = alloc<string>(Count);
                broadcast(EmptyString, Patterns);

                Patterns[ObjectKind.None] = EmptyString;

                Headers = alloc<string>(Count);
                broadcast(EmptyString, Headers);

                for(var i=1; i<kinds.Count; i++)
                {
                    ref readonly var kind = ref kinds[i];
                    ref readonly var cols = ref schema.Cols(kind);
                    switch(kind)
                    {
                        case ObjectKind.TypeTable:
                            Patterns[kind] = cols.Select(x => RP.slot((byte)x.Pos, (sbyte)-x.RenderWidth)).Concat(" | ");
                        break;
                        case ObjectKind.TypeTableRow:
                            Patterns[kind] = cols.Select(x => RP.slot((byte)x.Pos, (sbyte)-x.RenderWidth)).Concat(" | ");
                        break;
                    }
                }
            }
        }
    }
}