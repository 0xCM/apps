//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    [ApiHost]
    public sealed class ApiPacks : WfSvc<ApiPacks>
    {
        static Timestamp ts;

        public static IApiPack create(Timestamp ts, string label = EmptyString)
            => new ApiPack(AppDb.Service.Capture().Targets(ts.Format()).Root, ts, label);

        public static IApiPack create(string label = EmptyString)
            => new ApiPack(AppDb.Service.Capture().Targets(ts.Format()).Root, ts, label);

        static ApiPacks()
        {
            ts = core.now();
        }

        public static bool timestamp(FS.FolderPath src, out Timestamp dst)
        {
            dst = default;
            var fmt = src.Format(PathSeparator.FS);
            var idx = fmt.LastIndexOf(Chars.FSlash);
            if(idx == NotFound)
                return false;
            return Time.parse(fmt.RightOfIndex(idx), out dst);
        }

        public Index<LineCount> CountLines()
        {
            var pack = Current();
            var files = pack.Files(FS.Csv).View;
            var counting = Running(string.Format("Counting lines in {0} files from {1}", files.Length, pack.Root));
            var counts = AsciLines.count(files);
            core.iter(counts, c => Row(c.Format()));
            Ran(counting, string.Format("Counted lines in {0} files", files.Length));
            return counts;
        }

        public static bool parse(FS.FolderPath src, out ApiPack dst)
        {
            dst = default;
            var fmt = src.Format(PathSeparator.FS);
            var idx = fmt.LastIndexOf(Chars.FSlash);
            if(idx == NotFound)
                return false;
            var result =Time.parse(fmt.RightOfIndex(idx), out var ts);
            if(result)
                dst = new ApiPack(src,ts);
            else
                dst = new ApiPack(FS.FolderPath.Empty, Timestamp.Zero);
            return result;
        }


        public IApiPack Create(FS.FolderPath root)
        {
            parse(root, out var pack);
            return pack;
        }

        FS.FolderPath PackRoot
            => Env.CapturePacks;

        public IApiPack Current()
            => Packs().Last;

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
    }
}