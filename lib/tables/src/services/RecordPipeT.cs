// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using System;
//     using System.Runtime.CompilerServices;

//     using static Root;
//     using static core;

//     public abstract class RecordPipe<T>
//         where T : struct
//     {
//         protected RecordPipe()
//         {
//             FieldDelimiter = Chars.Pipe;
//             TableId = Tables.identify<T>();
//             Fields = Tables.fields<T>();
//             FieldCount = Fields.Count;
//             Formatter = Tables.formatter<T>();
//             Parser = Tables.parser<T>(ParseRow, FieldDelimiter);
//         }

//         protected char FieldDelimiter {get;}

//         protected RecordFields Fields {get;}

//         protected TableId TableId {get;}

//         protected uint FieldCount {get;}

//         protected IRecordFormatter<T> Formatter {get;}

//         protected IRecordParser<T> Parser {get;}

//         public static T NewRecord() => new T();

//         [MethodImpl(Inline)]
//         protected ref readonly string NextCell(ReadOnlySpan<string> src, ref uint i)
//             => ref skip(src, i++);

//         protected virtual Outcome ParseRow(TextLine src, out T dst)
//         {
//             dst = default;
//             return false;
//         }

//         public string Format(in T src)
//             => Formatter.Format(src);

//         public string FormatHeader()
//             => Formatter.FormatHeader();

//         protected ReadOnlySpan<string> Cells(string src)
//             => src.SplitClean(FieldDelimiter);

//         protected static MsgPattern<TableId,Count,Count> FieldCountMismatch
//             => "The {0} row had {1} fields while {2} were expected";
//     }
// }