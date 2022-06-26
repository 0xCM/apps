//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Archives : WfSvc<Archives>
    {
        public static IDbArchive archive(FS.FolderPath root)
            => new DbArchive(root);

        public static IDbArchive jobs(FS.FolderPath root)
            => new DbArchive(root);
    }
}