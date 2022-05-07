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
        public static RowAdapter adapter(Type src)
            => new RowAdapter(src, Tables.fields(src));

        public static RowAdapter<T> adapter<T>(in ClrTableField[] fields)
            where T : struct
                => new RowAdapter<T>(fields);

        [MethodImpl(Inline)]
        public static ref RowAdapter adapt<T>(in T src, ref RowAdapter adapter)
            where T : struct
        {
            adapter.Source = src;
            adapter.Index++;
            load(adapter.Source, ref adapter.Row);
            return ref adapter;
        }

        [Op]
        public static void load<T>(T src, ref DynamicRow dst)
            where T : struct
        {
            var tr = __makeref(edit(src));
            for(var i=0u; i<dst.FieldCount; i++)
                dst[i] = dst.Fields[i].Definition.GetValueDirect(tr);
        }

        public static Func<dynamic,string> Fx(Type src)
        {
            string fx(dynamic input)
                => create(src).Format(input);
            return fx;
        }

        public static RecordFormatter<T> create<T>(RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = DefaultDelimiter)
            where T : struct
        {
            var record = typeof(T);
            var fields = api.fields(record).Index();
            var count = fields.Length;
            var buffer = alloc<HeaderCell>(count);
            for(var i=0u; i<count; i++)
                seek(buffer, i) = new HeaderCell(fields[i].FieldIndex, fields[i].FieldName, fields[i].FieldWidth);
            var header = new RowHeader(buffer, delimiter);
            return new RecordFormatter<T>(rowspec(header, header.Cells.Select(x => x.CellFormat), 0, fk), adapter<T>(fields));
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

        public static string format<T>(ref RecordFormatter formatter, in T src)
            where T : struct
        {
            adapt<T>(src, ref formatter.Adapter);
            return format(formatter.FormatSpec, formatter.Adapter.Adapted);
        }

        public static string format(in RowFormatSpec rowspec, in DynamicRow src)
        {
            var content = string.Format(rowspec.Pattern, src.Cells);
            var pad = rowspec.RowPad;
            if(pad == 0)
                return content;
            else
                return content.PadRight(pad);
        }

        public readonly RowFormatSpec FormatSpec;

        internal RowAdapter Adapter;

        readonly ITextBuffer Buffer;

        public Type RecordType {get;}

        public TableId TableId {get;}

        [MethodImpl(Inline)]
        internal RecordFormatter(Type record, RowFormatSpec spec, RowAdapter adapter)
        {
            RecordType = record;
            TableId = Tables.identify(record);
            FormatSpec = spec;
            Adapter = adapter;
            Buffer = text.buffer();
        }

        RowFormatSpec IRecordFormatter.FormatSpec
            => FormatSpec;

        public string Format<T>(in T src)
            where T : struct
                => FormatRecord(src, FormatSpec.FormatKind);

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

        string FormatRecord<T>(in T src, RecordFormatKind fk)
            where T : struct
        {
            adapt(src, ref Adapter);
            if(fk == RecordFormatKind.Tablular)
                return format(FormatSpec, Adapter.Adapted);
            else
            {
                Errors.Throw("Unsupported");
                return EmptyString;
            }
        }

        public string Format(dynamic src)
        {
            throw new NotImplementedException();
        }

        public string Format(dynamic src, RecordFormatKind kind)
        {
            throw new NotImplementedException();
        }
    }
}