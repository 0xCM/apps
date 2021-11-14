//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;
    using static DocSplitSpec;

    public readonly struct DocSplitSpecs
    {
        public static DocSplitSpecs Service => default;

        public Outcome Load(FS.FilePath src, out RecordSet<DocSplitSpec> dst)
        {
            dst = RecordSet<DocSplitSpec>.Empty;

            var outcome = TextGrids.load(src, out var doc);
            if(outcome.Fail)
                return outcome;

            var header = doc.Header;
            if(doc.Header.CellCount != FieldCount)
                outcome = (false, nameof(FieldCount));

            if(outcome.Fail)
                return outcome;

            var rows = doc.Rows;
            var count = rows.Length;
            dst = alloc<DocSplitSpec>(count);
            var records = dst.Edit;
            for(var i=0; i<count; i++)
            {
                outcome = Load(skip(rows,i), out seek(records,i));
                if(outcome.Fail)
                    break;
            }
            return outcome;
        }

        public Outcome Load(in TextRow src, out DocSplitSpec dst)
        {
            var outcome = Outcome.Success;
            dst = default;
            var count = src.CellCount;
            if(count != FieldCount)
                outcome = (false, nameof(FieldCount));
            if(!outcome)
                return outcome;

            var cells = src.Cells;
            var i=0;
            outcome += DataParser.parse(skip(cells,i++), out dst.DocId);
            outcome += DataParser.parse(skip(cells,i++), out dst.Unit);
            outcome += DataParser.parse(skip(cells,i++), out dst.FirstLine);
            outcome += DataParser.parse(skip(cells,i++), out dst.LastLine);
            return outcome;
        }
    }
}