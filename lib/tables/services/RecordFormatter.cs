//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Tables;

    using api = Tables;

    public struct RecordFormatter : IRecordFormatter
    {
        public static RecordFormatter<T> create<T>()
            where T : struct
        {
            var record = typeof(T);
            var fields = api.fields(record).Index();
            var count = fields.Length;
            var buffer = alloc<HeaderCell>(count);
            for(var i=0u; i<count; i++)
                seek(buffer, i) = new HeaderCell(fields[i].FieldIndex, fields[i].FieldName, fields[i].FieldWidth);
            var header = new RowHeader(buffer, DefaultDelimiter);
            return new RecordFormatter<T>(rowspec(header, header.Cells.Select(x => x.CellFormat), 0, RecordFormatKind.Tablular), adapter<T>(fields));
        }

        public static RecordFormatter create(Type record, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = DefaultDelimiter)
        {
            var fields = api.fields(record).Index();
            var count = fields.Length;
            var buffer = alloc<HeaderCell>(count);
            for(var i=0u; i<count; i++)
                seek(buffer, i) = new HeaderCell(fields[i].FieldIndex, fields[i].FieldName, fields[i].FieldWidth);
            var header = new RowHeader(buffer, delimiter);
            return new RecordFormatter(record, rowspec(header, header.Cells.Select(x => x.CellFormat), 0, fk), adapter(record));
        }

        RowAdapter Adapter;

        public readonly RowFormatSpec FormatSpec;

        public readonly TableId TableId;

        [MethodImpl(Inline)]
        RecordFormatter(Type record, RowFormatSpec spec, RowAdapter adapter)
        {
            TableId = Tables.identify(record);
            FormatSpec = spec;
            Adapter = adapter;
        }

        public void RenderLine<T>(in T src, ITextEmitter dst)
            where T : struct
                => dst.AppendLine(Format(src));

        public string Format<T>(in T src)
            where T : struct
        {
            adapt<T>(src, ref Adapter);
            return format(FormatSpec, Adapter.Adapted);
            //return format(ref this, src);
        }

        // static string format<T>(ref RecordFormatter formatter, in T src)
        //     where T : struct
        // {
        //     adapt<T>(src, ref formatter.Adapter);
        //     return format(formatter.FormatSpec, formatter.Adapter.Adapted);
        // }

        public string FormatHeader()
        {
            if(FormatSpec.FormatKind == RecordFormatKind.Tablular)
                return FormatSpec.Header.Format();
            else
            {
                Errors.Throw("Unsupported");
                return EmptyString;
            }
        }

        RowFormatSpec IRecordFormatter.FormatSpec
            => FormatSpec;

        TableId IRecordFormatter.TableId
            => TableId;

        /// <summary>
        /// Defines a row over a specified record type
        /// </summary>
        /// <typeparam name="T">The record type</typeparam>
        struct RowAdapter
        {
            internal uint Index;

            internal dynamic Source;

            internal DynamicRow Row;

            public readonly Type RowType;

            [MethodImpl(Inline)]
            internal RowAdapter(Type type, ClrRecordFields fields)
            {
                RowType = type;
                Source = type;
                Index = 0;
                Row = api.dynarow(fields);
            }

            public readonly ClrRecordFields Fields
            {
                [MethodImpl(Inline)]
                get => Row.Fields;
            }

            [MethodImpl(Inline)]
            public RowAdapter Adapt<T>(in T src)
                where T : struct
                    => adapt<T>(src, ref this);

            public readonly DynamicRow Adapted
            {
                [MethodImpl(Inline)]
                get => Row;
            }

            public readonly Span<dynamic> Cells
            {
                [MethodImpl(Inline)]
                get => Row.Cells;
            }

            public readonly uint ColumnCount
            {
                [MethodImpl(Inline)]
                get => Fields.Count;
            }
        }

        [MethodImpl(Inline)]
        static ref RowAdapter adapt<T>(in T src, ref RowAdapter adapter)
            where T : struct
        {
            adapter.Source = src;
            adapter.Index++;
            load(adapter.Source, ref adapter.Row);
            return ref adapter;
        }

        static RowAdapter<T> adapter<T>(in ClrTableField[] fields)
            where T : struct
                => new RowAdapter<T>(fields);

        static RowAdapter adapter(Type src)
            => new RowAdapter(src, Tables.fields(src));

        static string format(in RowFormatSpec spec, in DynamicRow src)
        {
            var content = string.Format(spec.Pattern, src.Cells);
            var pad = spec.RowPad;
            if(pad == 0)
                return content;
            else
                return content.PadRight(pad);
        }

        static void load<T>(T src, ref DynamicRow dst)
            where T : struct
        {
            var tr = __makeref(edit(src));
            for(var i=0u; i<dst.FieldCount; i++)
                dst[i] = dst.Fields[i].Definition.GetValueDirect(tr);
        }
    }
}