//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    [ApiHost]
    public sealed class ApiPacks : AppService<ApiPacks>
    {
        ApiCodeFiles ApiFiles => Wf.ApiCodeFiles();

        public IApiPack Create(ApiExtractSettings settings)
            => new ApiPack(ApiFiles, settings);

        public IApiPack Create(FS.FolderPath root)
            => Create(ApiExtractSettings.init(root));

        FS.FolderPath PackRoot
            => Env.CapturePacks;

        public IApiPack Current()
            => Packs().Last;


        IApiPack Pack(FS.FolderPath dir)
            => new ApiPack(ApiFiles, ApiExtractSettings.init(dir));

        public void CreateLink(Timestamp ts)
        {
            var outcome = Link(ts);
            if(Check(outcome, out var data))
                Wf.Status(string.Format("Created symlink {0} -> {1}", data.Source, data.Target));
        }

        public Outcome<Arrow<FS.FolderPath,FS.FolderPath>> Link(Timestamp ts)
        {
            var link = PackRoot + FS.folder(current);
            var target = PackRoot + FS.folder(ts);
            var outcome = FS.symlink(link, target, true);
            if(outcome.Ok)
                return new Arrow<FS.FolderPath,FS.FolderPath>(link, target);
            else
                return outcome;
        }

        public Index<IApiPack> Packs()
            => PackRoot.SubDirs(false).Select(x => (IApiPack)(Create(x)));

        public Index<IApiPack> List()
            => PackRoot.SubDirs(false).Select(x => (IApiPack)(Create(x)));
    }
}