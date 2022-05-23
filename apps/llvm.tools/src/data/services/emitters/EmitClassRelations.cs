//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataEmitter
    {
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
                        LlvmDataCalcs.lineage(content, out record.Ancestors);
                        record.Parameters = parameters;
                        dst.Add(record);
                    }
                }
            }

            var collected = dst.ToArray();
            AppSvc.TableEmit(collected, LlvmPaths.Table<ClassRelations>());
            return collected;
        }
    }
}