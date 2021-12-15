//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;
    using static Root;

    using SQ = SymbolicQuery;

    partial class LlvmDataEmitter
    {
        static bool lineage(string content, out Lineage dst)
        {
            var m = SQ.index(content, Chars.FSlash, Chars.FSlash);
            if(m >= 0)
            {
                var chain = text.trim(text.right(content, m + 1)).Split(Chars.Space);
                if(chain.Length > 0)
                {
                    dst = Lineage.path(chain);
                    return true;
                }
            }
            dst = Lineage.Empty;
            return false;
        }

        public Index<ClassRelations> EmitClassRelations(ReadOnlySpan<TextLine> src)
        {
            const string Marker = "class ";
            var lines = list<TextLine>();
            var dst = list<ClassRelations>();
            var name = EmptyString;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var line = ref skip(src,i);
                var content = line.Content;
                var j = text.index(content, Marker);
                var parameters = EmptyString;
                if(j >= 0)
                {
                    var k = text.index(content, Chars.LBrace);
                    if(k>=0)
                    {
                        var lt = text.index(content,Chars.Lt);
                        if(lt >=0)
                        {
                            name = text.trim(text.inside(content, j + Marker.Length - 1, lt));
                            var bounds = SQ.enclosed(content,0, (Chars.Lt, Chars.Gt));
                            parameters = text.inside(content, bounds.Min - 1, bounds.Max + 1).Replace(Chars.Pipe,Chars.Caret);
                        }
                        else
                            name = text.trim(text.inside(content, j + Marker.Length - 1, k));

                        if(empty(name))
                            continue;

                        var record = new ClassRelations();
                        record.SourceLine = line.LineNumber;
                        record.Name = name;
                        lineage(content, out record.Ancestors);
                        record.Parameters = parameters;
                        dst.Add(record);
                    }
                }
            }

            var collected = dst.ToArray();
            TableEmit(@readonly(collected), ClassRelations.RenderWidths, LlvmPaths.Table<ClassRelations>());
            return collected;
        }

        public Index<DefRelations> EmitDefRelations(ReadOnlySpan<TextLine> src)
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
                        if(empty(name))
                            continue;

                        lineage(content, out var a);
                        record.Specify(line.LineNumber, name, a);
                        dst.Add(record);
                    }
                }
            }
            var collected = dst.ToArray();
            TableEmit(@readonly(collected), DefRelations.RenderWidths, LlvmPaths.Table<DefRelations>());
            return collected;
        }
    }
}