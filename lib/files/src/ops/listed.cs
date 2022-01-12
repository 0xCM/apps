//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        public static ItemList<string> listed(FS.FilePath src, char delimiter = Chars.Comma)
        {
            var items = core.items(src.ReadText().SplitClean(delimiter).Select(x => x.Trim()).Where(text.nonempty).ToReadOnlySpan());
            var name = src.FileName.WithoutExtension.Format();
            return new ItemList<string>(items);
        }
    }
}