//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Settings
    {
        public static Settings config(FS.FilePath src, char sep = Chars.Colon)
        {
            var dst = list<Setting>();
            var line = AsciLineCover.Empty;
            using var reader = src.AsciLineReader();
            while(reader.Next(out line))
            {
                var content = line.Codes;
                var length = content.Length;
                if(length != 0)
                {
                    if(SQ.hash(first(content)))
                        continue;

                    var i = SQ.index(content, sep);
                    if(i > 0)
                    {
                        var name = text.format(SQ.left(content,i));
                        var value = text.format(SQ.right(content,i));
                        dst.Add(new Setting(name,value));
                    }
                }
            }
            return new Settings(dst.ToArray());
        }
    }
}