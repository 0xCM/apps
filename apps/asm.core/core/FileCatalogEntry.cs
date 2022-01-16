//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct FileCatalogEntry
    {
        public const string TableId = "files.catalog";

        public uint Id;

        public FS.FilePath Path;
    }
}