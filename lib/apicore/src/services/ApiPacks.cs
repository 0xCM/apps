//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public sealed class ApiPacks : AppService<ApiPacks>
    {
        public IApiPack Create(Timestamp ts)
            => new ApiPack(ApiExtractSettings.init(Db.CapturePackRoot(), ts));

        public IApiPack Create(ApiExtractSettings settings)
            => new ApiPack(settings);

        public IApiPack Create()
            => Create(core.now());

        public FS.FolderPath PackRoot
            => Db.CapturePackRoot();

        public IApiPack Create(FS.FolderPath root)
            => new ApiPack(ApiExtractSettings.init(root));

        public IApiPack Current()
            => Archives.Last();

        public ApiPackArchive Archive()
            => ApiPackArchive.create(Archives.Last().Root);

        public ApiPackArchive Archive(FS.FolderPath root)
            => ApiPackArchive.create(root);

        public ApiPackArchives Archives
            => ApiPackArchives.create(PackRoot);

        public void CreateLink(Timestamp ts)
        {
            var outcome = Archives.Link(ts);
            if(Check(outcome, out var data))
                Wf.Status(string.Format("Created symlink {0} -> {1}", data.Source, data.Target));
        }

        public Index<IApiPack> List()
            => PackRoot.SubDirs(false).Select(x => (IApiPack)(Create(x)));
    }
}