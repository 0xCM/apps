//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public sealed class ApiPacks : WfSvc<ApiPacks>
    {
        public IApiPack Current()
            => AppDb.apipacks().Last;

        public Arrow<FS.FolderPath,FS.FolderPath> Link(Timestamp ts)
        {
            var src = AppDb.apipacks().Last;
            var link = src.Root + FS.folder(ApiGranules.current);
            var target = src.Root + FS.folder(ts);
            FS.symlink(link, target, true).Require();
            Status(string.Format("Created symlink {0} -> {1}", link, target));
            return new Arrow<FS.FolderPath,FS.FolderPath>(link, target);
        }
    }
}