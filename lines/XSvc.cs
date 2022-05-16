//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    partial class XTend
    {
        [Op]
        public static AsciLineReader AsciLineReader(this FS.FilePath src)
            => new AsciLineReader(src.AsciReader());

        [Op]
        public static UnicodeLineReader UnicodeLineReader(this FS.FilePath src)
            => new UnicodeLineReader(src.UnicodeReader());
    }

    public static class XSvc
    {

    }
}