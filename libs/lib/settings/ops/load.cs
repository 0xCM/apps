//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Arrays;
    using static Algs;

    partial class Settings
    {
        public static SettingLookup load(FS.FilePath src, char sep)
        {
            var dst = list<Setting>();
            var line = AsciLineCover.Empty;
            var quoted = new Fence<AsciCode>(AsciCode.SQuote, AsciCode.SQuote);
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
                        var name = Asci.format(SQ.left(content,i));
                        var value = Asci.format(SQ.right(content,i));
                        dst.Add(new Setting(name, value));
                    }
                }
            }
            return new SettingLookup(dst.ToArray());
        }
    }
}