//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;
    [ApiHost]
    public sealed class ApiPacks : WfSvc<ApiPacks>
    {
        public IApiPack Current()
            => AppDb.apipacks().Last;

        Arrow<FS.FolderPath,FS.FolderPath> Link(Timestamp ts)
        {
            var capture = AppDb.Capture();
            var src = capture.Root + FS.folder(current);
            var dst = AppDb.apipacks().Last.Root;
            FS.symlink(src,dst,true).Require();
            Status($"symlink:{src} -> {dst}");
            return (src,dst);

            // var src = AppDb.apipacks().Last;
            // var link = src.Root + FS.folder(current);
            // var dst = capture.Root + FS.folder(current);
            // FS.symlink(link, dst, true).Require();
            // Status(string.Format("Created symlink {0} -> {1}", link, dst));
            // return new Arrow<FS.FolderPath,FS.FolderPath>(link, dst);
        }

        public Arrow<FS.FolderPath,FS.FolderPath> Link(IApiPack dst)
            => Link(dst.Timestamp);
    }
}