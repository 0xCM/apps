//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public abstract class RecordPipe<H,T> : AppService<H>
        where H : RecordPipe<H,T>, new()
        where T : struct, IRecord<T>
    {
        protected RecordPipe()
        {
            FieldDelimiter = Chars.Pipe;
            TableId = Tables.identify<T>();
            Fields = Tables.fields<T>();
            FieldCount = Fields.Count;
            Formatter = Tables.formatter<T>();
        }

        protected char FieldDelimiter {get;}

        protected RecordFields Fields {get;}

        protected TableId TableId {get;}

        protected uint FieldCount {get;}

        protected IRecordFormatter<T> Formatter {get;}

        public static T NewRecord() => new T();

        public string Format(in T src)
            => Formatter.Format(src);

        public string FormatHeader()
            => Formatter.FormatHeader();

        protected ReadOnlySpan<string> Cells(string src)
            => src.SplitClean(FieldDelimiter);

        protected static MsgPattern<TableId,Count,Count> FieldCountMismatch
            => "The {0} row had {1} fields while {2} were expected";
    }
}