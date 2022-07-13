//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    public class DumpArchive : AppService<DumpArchive>, IDumpArchive
    {
        public static IDumpArchive Service => new DumpArchive();

        public DumpArchive()
        {
            Root = AppDb.Service.Archives().Sources(dumps).Root;
        }

        public FS.FolderPath Root {get;}
    }
}