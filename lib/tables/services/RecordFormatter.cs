//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Tables;
    using static RecordFormatter;

    using api = RecordFormatters;

    public class RecordFormatters
    {
        public static IRecordFormatter<T> create<T>(ushort rowpad, RecordFormatKind fk, string delimiter = DefaultDelimiter)
            where T : struct
        {
            var record = typeof(T);
            var fields = Tables.fields(record).Index();
            var count = fields.Length;
            var buffer = alloc<HeaderCell>(count);
            for(var i=0u; i<count; i++)
                seek(buffer, i) = new HeaderCell(fields[i].FieldIndex, fields[i].FieldName, fields[i].FieldWidth);
            var header = new RowHeader(buffer, DefaultDelimiter);
            var spec = rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
            return new Formatter2<T>(spec, api.adapter(record));
        }

        public static RecordFormatter create(Type record, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = DefaultDelimiter)
        {
            var fields = Tables.fields(record).Index();
            var count = fields.Length;
            var buffer = alloc<HeaderCell>(count);
            for(var i=0u; i<count; i++)
                seek(buffer, i) = new HeaderCell(fields[i].FieldIndex, fields[i].FieldName, fields[i].FieldWidth);
            var header = new RowHeader(buffer, delimiter);
            var spec = rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
            return new RecordFormatter(record, spec, api.adapter(record));
        }

        internal static RowAdapter adapter(Type src)
            => new RowAdapter(src, Tables.fields(src));

        [MethodImpl(Inline)]
        internal static ref RowAdapter adapt<T>(in T src, ref RowAdapter adapter)
            where T : struct
        {
            adapter.Source = src;
            adapter.Index++;
            load(adapter.Source, ref adapter.Row);
            return ref adapter;
        }

        internal static void load<T>(T src, ref DynamicRow dst)
            where T : struct
        {
            var tr = __makeref(edit(src));
            for(var i=0u; i<dst.FieldCount; i++)
                dst[i] = dst.Fields[i].Definition.GetValueDirect(tr);
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

    }

    public class RecordFormatter : IRecordFormatter
    {
        internal class Formatter2<T> : IRecordFormatter<T>
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
                api.adapt(src, ref Adapter);
                return api.format(FormatSpec, CellBuffer, Adapter.Adapted);
            }

            public string FormatHeader()
            {
                if(FormatSpec.FormatKind == RecordFormatKind.Tablular)
                    return FormatSpec.Header.Format();
                else
                    return string.Format(Tables.KvpPattern(FormatSpec), "Name", "Value");
            }
        }

        // public static IRecordFormatter<T> create<T>(ushort rowpad, RecordFormatKind fk, string delimiter = DefaultDelimiter)
        //     where T : struct
        // {
        //     var record = typeof(T);
        //     var fields = Tables.fields(record).Index();
        //     var count = fields.Length;
        //     var buffer = alloc<HeaderCell>(count);
        //     for(var i=0u; i<count; i++)
        //         seek(buffer, i) = new HeaderCell(fields[i].FieldIndex, fields[i].FieldName, fields[i].FieldWidth);
        //     var header = new RowHeader(buffer, DefaultDelimiter);
        //     var spec = rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
        //     return new Formatter2<T>(spec, api.adapter(record));
        // }

        // public static RecordFormatter create(Type record, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular, string delimiter = DefaultDelimiter)
        // {
        //     var fields = Tables.fields(record).Index();
        //     var count = fields.Length;
        //     var buffer = alloc<HeaderCell>(count);
        //     for(var i=0u; i<count; i++)
        //         seek(buffer, i) = new HeaderCell(fields[i].FieldIndex, fields[i].FieldName, fields[i].FieldWidth);
        //     var header = new RowHeader(buffer, delimiter);
        //     var spec = rowspec(header, header.Cells.Select(x => x.CellFormat), rowpad, fk);
        //     return new RecordFormatter(record, spec, api.adapter(record));
        // }

        RowAdapter Adapter;

        public readonly RowFormatSpec FormatSpec;

        public readonly TableId TableId;

        object[] CellBuffer;

        [MethodImpl(Inline)]
        internal RecordFormatter(Type record, RowFormatSpec spec, RowAdapter adapter)
        {
            TableId = Tables.identify(record);
            FormatSpec = spec;
            Adapter = adapter;
            CellBuffer = new object[FormatSpec.CellCount];
        }

        public string Format<T>(in T src)
            where T : struct
        {
            api.adapt<T>(src, ref Adapter);
            return api.format(FormatSpec, CellBuffer, Adapter.Adapted);
        }

        // [MethodImpl(Inline)]
        // internal static ref RowAdapter adapt<T>(in T src, ref RowAdapter adapter)
        //     where T : struct
        // {
        //     adapter.Source = src;
        //     adapter.Index++;
        //     api.load(adapter.Source, ref adapter.Row);
        //     return ref adapter;
        // }

        // internal static RowAdapter adapter(Type src)
        //     => new RowAdapter(src, Tables.fields(src));

        // internal static void load<T>(T src, ref DynamicRow dst)
        //     where T : struct
        // {
        //     var tr = __makeref(edit(src));
        //     for(var i=0u; i<dst.FieldCount; i++)
        //         dst[i] = dst.Fields[i].Definition.GetValueDirect(tr);
        // }

        // internal static string format(in RowFormatSpec spec, object[] buffer, in DynamicRow src)
        // {
        //     var content = src.Format(spec.Pattern,buffer);
        //     var pad = spec.RowPad;
        //     if(pad == 0)
        //         return content;
        //     else
        //         return content.PadRight(pad);
        // }

        public string FormatHeader()
        {
            if(FormatSpec.FormatKind == RecordFormatKind.Tablular)
                return FormatSpec.Header.Format();
            else
                return string.Format(Tables.KvpPattern(FormatSpec), "Name", "Value");
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
                Row = Tables.dynarow(fields);
            }

            public readonly DynamicRow Adapted
            {
                [MethodImpl(Inline)]
                get => Row;
            }
        }
    }
}