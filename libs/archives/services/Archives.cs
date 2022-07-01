//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Archives : AppService<Archives>
    {
        public static IDbArchive archive(FS.FolderPath root)
            => new DbArchive(root);
    }
}