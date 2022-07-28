//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    [ApiHost]
    public sealed class ApiPacks : WfSvc<ApiPacks>
    {
        public IApiPack Current()
            => ApiPack.discover().Last;

        Arrow<FS.FolderPath,FS.FolderPath> Link(Timestamp ts)
        {
            var capture = AppDb.Capture();
            var src = capture.Root + FS.folder(current);
            var dst = ApiPack.discover().Last.Root;
            FS.symlink(src,dst,true).Require();
            Status($"symlink:{src} -> {dst}");
            return (src,dst);
        }

        public Arrow<FS.FolderPath,FS.FolderPath> Link(IApiPack dst)
            => Link(dst.Timestamp);
    }
}