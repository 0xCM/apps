//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Collections.Concurrent;

    using static core;
    using static AppMsg;

    using R = HostAsmRecord;

    partial struct AsmParser
    {
        public static Outcome<uint> row(in TextGrid doc, Span<R> dst)
        {
            var counter = 0u;
            if(doc.Header.Labels.Length != R.FieldCount)
                return (false, AppMsg.FieldCountMismatch.Format(R.FieldCount, doc.Header.Labels.Length));

            var count = (uint)min(doc.RowCount, dst.Length);
            var rows = doc.RowData.View;
            for(var i=0; i<count; i++)
            {
                var result = row(skip(rows, i), out seek(dst, i));
                if(result.Fail)
                    return result;
            }
            return count;
        }

        public static Outcome<uint> rows(in TextGrid src, Span<SdmOpCodeDetail> dst)
        {
            var cells = src.Header.Labels.Count;
            if(cells != SdmOpCodeDetail.FieldCount)
                return (false, FieldCountMismatch.Format(SdmOpCodeDetail.FieldCount, cells));
            return rows(src.Rows, dst);
        }

        [Op]
        public static Outcome<uint> rows(ReadOnlySpan<TextRow> src, Span<SdmOpCodeDetail> dst)
        {
            var counter = 0u;
            var result = Outcome.Success;
            var count = min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
            {
                result = row(skip(src,i), out seek(dst, i));
                if(result.Fail)
                      warn(result.Message);
            }
            return (true,counter);
        }

        public static Index<Outcome<uint>> rows(ReadOnlySpan<TextGrid> src, ConcurrentBag<R> dst)
        {
            var results = bag<Outcome<uint>>();
            iter(src, doc => {
                results.Add(rows(doc, dst));
            }, true);
            return results.ToArray();
        }

        public static Outcome<uint> rows(in TextGrid doc, ConcurrentBag<R> dst)
        {
            var counter = 0u;
            if(doc.Header.Labels.Length != R.FieldCount)
                return (false, FieldCountMismatch.Format(R.FieldCount, doc.Header.Labels.Length));

            var count = doc.RowCount;
            var rows = doc.RowData.View;
            for(var i=0; i<count; i++)
            {
                var result = row(skip(rows,i), out R statement);
                if(result)
                {
                    dst.Add(statement);
                    counter++;
                }
                else
                    return result;
            }
            return counter;
        }
    }
}