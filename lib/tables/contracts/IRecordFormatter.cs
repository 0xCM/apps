//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRecordFormatter
    {
        TableId TableId {get;}

        RowFormatSpec FormatSpec {get;}

        string FormatHeader();

        string Format<T>(in T src)
            where T : struct;

        void RenderLine<T>(in T src, ITextEmitter dst)
            where T : struct
                => dst.AppendLine(Format(src));
    }

    public interface IRecordFormatter<T> : IRecordFormatter
        where T : struct
    {
        string Format(in T src);

        string IRecordFormatter.Format<X>(in X src)
            => throw new NotSupportedException();

        string Format(in T src, RecordFormatKind kind);

        TableId IRecordFormatter.TableId
            => TableId.identify(typeof(T));

        string FormatKvp(in T src)
            => Format(src, RecordFormatKind.KeyValuePairs);
    }
}