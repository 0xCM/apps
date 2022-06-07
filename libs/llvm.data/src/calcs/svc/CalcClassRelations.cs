//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataCalcs
    {
        public Index<ClassRelations> CalcClassRelations(ReadOnlySpan<TextLine> src)
        {
            var dst = list<ClassRelations>();
            var record = ClassRelations.Empty;
            for(var i=0; i<src.Length; i++)
            {
                if(parse(skip(src,i), out record))
                    dst.Add(record);
           }

            return dst.ToArray();
        }

        static bool parse(in TextLine src, out ClassRelations dst)
        {
            const string Marker = "class ";
            dst = ClassRelations.Empty;
            var content = src.Content;
            var j = text.index(content, Marker);
            var parameters = EmptyString;
            var name = EmptyString;
            var result = false;
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

                    if(nonempty(name))
                    {                            
                        dst = new ClassRelations();
                        dst.SourceLine = src.LineNumber;
                        dst.Name = name;
                        Lineage.parse(content, out dst.Ancestors);
                        dst.Parameters = parameters;
                        result = true;
                    }
                }
            }
            
            return result;
        }
    }
}