//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FileKinder
    {

        public static FileKind kind(FS.FilePath src)
        {
            var name = src.FileName.Format().ToLower();
            var kind = FileKind.None;
            foreach(var expr in Data)
            {
                if(name.EndsWith(expr.Key))
                {
                    kind = expr.Value;
                    break;
                }
            }
            return kind;
        }

        static FileKinder()
        {
            Data = Symbols.index<FileKind>().View.Map(s => ("." + s.Expr.Format().ToLower(), s.Kind)).ToSortedDictionary(TextLengthComparer.create(true));
        }

        static SortedDictionary<string,FileKind> Data;
    }
}