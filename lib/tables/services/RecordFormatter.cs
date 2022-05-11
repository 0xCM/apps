//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Tables;

    using api = Tables;

    public class RecordFormatter : IRecordFormatter
    {
        class Formatter2<T> : IRecordFormatter<T>
            where T : struct
        {
            object[] CellBuffer;

            public Formatter2(RowFormatSpec spec, RowAdapter adapter)
            {
                CellBuffer = new object[spec.CellCount];
                FormatSpec = spec;
                Adapter = adapter;
            }

            public RowFormatSpec FormatSpec {get;}

            RowAdapter Adapter;

            public string Format(in T src)
            {
                adapt(src, ref Adapter);
                return format(FormatSpec, CellBuffer, Adapter.Adapted);
            }

            public string Format(in T src, RecordFormatKind kind)
                => throw new NotImplementedException();

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
        }

        public static IRecordFormatter<T> create<T>()
            where T : struct
        {
            var record = typeof(T);
            var fields = api.fields(record).Index();
            var count = fields.Length;
            var buffer = alloc<HeaderCell>(count);
            for(var i=0u; i<count; i++)
                seek(buffer, i) = new HeaderCell(fields[i].FieldIndex, fields[i].FieldName, fields[i].FieldWidth);
            var header = new RowHeader(buffer, DefaultDelimiter);
            var spec = rowspec(header, header.Cells.Select(x => x.CellFormat), 0, RecordFormatKind.Tablular);
            return new Formatter2<T>(spec, adapter(record));
        }

        // public static RecordFormatter<T> create<T>()
        //     where T : struct
        // {
        //     var record = typeof(T);
        //     var fields = api.fields(record).Index();
        //     var count = fields.Length;
        //     var buffer = alloc<HeaderCell>(count);
        //     for(var i=0u; i<count; i++)
        //         seek(buffer, i) = new HeaderCell(fields[i].FieldIndex, fields[i].FieldName, fields[i].FieldWidth);
        //     var header = new RowHeader(buffer, DefaultDelimiter);
        //     var spec = rowspec(header, header.Cells.Select(x => x.CellFormat), 0, RecordFormatKind.Tablular);
        //     return new RecordFormatter<T>(spec, adapter<T>(fields));
        // }

        public static RecordFormatter create(Type record, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = DefaultDelimiter)
        {
            var fields = api.fields(record).Index();
            var count = fields.Length;
            var buffer = alloc<HeaderCell>(count);
            for(var i=0u; i<count; i++)
                seek(buffer, i) = new HeaderCell(fields[i].FieldIndex, fields[i].FieldName, fields[i].FieldWidth);
            var header = new RowHeader(buffer, delimiter);
            var spec = rowspec(header, header.Cells.Select(x => x.CellFormat), 0, fk);
            return new RecordFormatter(record, spec, adapter(record));
        }

        RowAdapter Adapter;

        public readonly RowFormatSpec FormatSpec;

        public readonly TableId TableId;

        object[] CellBuffer;

        [MethodImpl(Inline)]
        RecordFormatter(Type record, RowFormatSpec spec, RowAdapter adapter)
        {
            TableId = Tables.identify(record);
            FormatSpec = spec;
            Adapter = adapter;
            CellBuffer = new object[FormatSpec.CellCount];
        }

        public void RenderLine<T>(in T src, ITextEmitter dst)
            where T : struct
                => dst.AppendLine(Format(src));

        public string Format<T>(in T src)
            where T : struct
        {
            adapt<T>(src, ref Adapter);
            return format(FormatSpec, CellBuffer, Adapter.Adapted);
        }

        internal static string format(in RowFormatSpec spec, object[] buffer, in DynamicRow src)
        {
            var content = src.Format(spec.Pattern,buffer);
            var pad = spec.RowPad;
            if(pad == 0)
                return content;
            else
                return content.PadRight(pad);
        }

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
        internal struct RowAdapter
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

            public readonly DynamicRow Adapted
            {
                [MethodImpl(Inline)]
                get => Row;
            }
        }

        [MethodImpl(Inline)]
        internal static ref RowAdapter adapt<T>(in T src, ref RowAdapter adapter)
            where T : struct
        {
            adapter.Source = src;
            adapter.Index++;
            load(adapter.Source, ref adapter.Row);
            return ref adapter;
        }

        internal static RowAdapter<T> adapter<T>(in ClrTableField[] fields)
            where T : struct
                => new RowAdapter<T>(fields);

        internal static RowAdapter adapter(Type src)
            => new RowAdapter(src, Tables.fields(src));

        internal static void load<T>(T src, ref DynamicRow dst)
            where T : struct
        {
            var tr = __makeref(edit(src));
            for(var i=0u; i<dst.FieldCount; i++)
                dst[i] = dst.Fields[i].Definition.GetValueDirect(tr);
        }
    }
}