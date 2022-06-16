//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsArchives
    {
        public static Settings settings(FS.FilePath src)
        {
            var dst = Settings.Empty;
            try
            {
                dst = Settings.load(src);
            }
            catch(Exception e)
            {
                term.error(e);
            }
            return dst;
        }

        public static Settings settings(FS.FolderPath src, ProjectId project)
            => settings(src + FS.file(project.Format(), FS.Csv));

        public static Settings settings()
            => settings(Assembly.GetEntryAssembly(), FileKind.Csv);

        public static Settings settings(Assembly src, FileKind kind)
            => settings(SettingsPath(src,kind));

        static FS.FilePath SettingsPath(Assembly src, FileKind kind)
            => FS.path(src.Location).FolderPath + FS.file(string.Format("{0}.settings", src.GetSimpleName()), kind.Ext());

        public static WsArchives load()
            => load(settings());

        public static WsArchives load(Settings src)
        {
            var count = src.Count;
            var dst = alloc<WsArchive>(count);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var setting = ref src[i];
                seek(dst,i) = new WsArchive(text.trim(setting.Name), FS.dir(setting.ValueText));
            }
            return new WsArchives(dst);
        }

        public WsArchive Path(string name)
        {
            var dst = WsArchive.Empty;
            Lookup.Find(name, out dst);
            return dst;
        }

        readonly Index<WsArchive> Data;

        readonly ConstLookup<string, WsArchive> Lookup;

        WsArchives(WsArchive[] src)
        {
            Data = src;
            Lookup = src.Select(x => (x.Name,x)).ToDictionary();
        }

        public string Format()
        {
            var dst = text.emitter();
            Tables.emit(Data.View, dst);
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}