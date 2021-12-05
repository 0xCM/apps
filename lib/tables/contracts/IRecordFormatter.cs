//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IRecordFormatter
    {
        string Format(ValueType src);

        string Format(ValueType src, RecordFormatKind kind);

        Type RecordType {get;}

        TableId TableId {get;}

        RowFormatSpec FormatSpec {get;}

        string FormatHeader();
    }

    public interface IRecordFormatter<T> : IRecordFormatter
        where T : struct
    {
        string Format(in T src);

        string Format(in T src, RecordFormatKind kind);

        TableId IRecordFormatter.TableId
            => TableId.identify(typeof(T));

        string FormatKvp(in T src)
            => Format(src, RecordFormatKind.KeyValuePairs);

        string IRecordFormatter.Format(ValueType src)
            => Format((T)src);

        string IRecordFormatter.Format(ValueType src, RecordFormatKind kind)
            => Format((T)src, kind);

        Type IRecordFormatter.RecordType
            => typeof(T);
    }
}