//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Cmd
    {
        public static ReadOnlySpan<CmdOption> options(FS.FilePath src)
        {
            var dst = list<CmdOption>();
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                if(line.IsNonEmpty)
                {
                    ref readonly var content = ref line.Content;
                    if(parse(content, out var option))
                        dst.Add(option);
                }
            }
            return dst.ViewDeposited();
        }

        [Parser]
        public static Outcome parse(string src, out CmdOption dst)
        {
            const char Delimiter = Chars.Colon;

            dst = CmdOption.Empty;
            if(empty(src))
                return (false,RP.Empty);
            var i = text.index(src, Delimiter);
            if(i>0)
                dst = new CmdOption(text.left(src,i).Trim(), text.right(src,i).Trim());
            else
                dst = new CmdOption(src.Trim());
            return true;
        }
    }
}