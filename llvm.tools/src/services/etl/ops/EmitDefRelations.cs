//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using records;

    using static Root;
    using static core;

    partial class LlvmRecordEtl
    {
        ReadOnlySpan<DefRelations> EmitDefRelations(ReadOnlySpan<TextLine> src)
        {
            const string Marker = "def ";
            var dst = list<DefRelations>();
            var name = EmptyString;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var line = ref skip(src,i);
                var content = line.Content;
                var j = text.index(content, Marker);
                if(j >= 0)
                {
                    var k = text.index(content, Chars.LBrace);
                    if(k>=0)
                    {
                        var record = new DefRelations();
                        name = text.trim(text.inside(content, j + Marker.Length - 1, k));
                        if(empty(name) || text.member(name, ClassExclusions))
                            continue;

                        etl.lineage(content, out var a);
                        record.Specify(line.LineNumber, name, a);
                        dst.Add(record);
                    }
                }
            }
            var collected = dst.ViewDeposited();
            TableEmit(collected, DefRelations.RenderWidths, LlvmPaths.Table<DefRelations>());
            return collected;
        }
    }
}