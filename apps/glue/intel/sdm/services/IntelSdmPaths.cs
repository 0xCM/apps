//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static SdmModels;

    public class IntelSdmPaths : AppService<IntelSdmPaths>
    {
        IProjectWs Project()
            => Ws.Project("db/sources/intel");

        public FS.FolderPath Targets()
            => Ws.Project("db").Subdir("sdm");

        public FS.FolderPath Sources()
            => Project().Home();

        public FS.FolderPath Sources(string name)
            => Sources() + FS.folder(name);

        public FS.FilePath SdmSrcPath(byte vol)
            => Sources() + SdmSrcFile(vol);

        public FS.FilePath SdmDstPath(byte vol)
            => Targets() + FS.file(string.Format("intel-sdm-vol{0}-{1}", vol, "lined"), FS.Txt);

        public FS.FilePath TocImportPath()
            => Targets() + FS.file("sdm.toc", FS.Txt);

        public FS.FilePath ProcessLog(string name)
            => LogDir() + FS.file(name, FS.Log);

        public SortedSpan<FS.FilePath> TocPaths()
            => Targets().AllFiles.Where(f => IsTocPart(f)).Array().ToSortedSpan();

        public FS.FilePath TocEntryTable()
            => Targets() + FS.file(TableId.identify<TocEntry>().Format(), FS.Csv);

        public FS.FolderPath LogDir()
            => Project().Out() + FS.folder("intel.sdm.logs");

        public FS.FolderPath Imports()
            => Project().Subdir("imports");

        public FS.FilePath ImportPath(string id, FS.FileExt ext)
            => Targets() + FS.file(id,ext);

        public FS.FolderPath SettingsDir()
            => Project().Subdir("settings");

        public FS.FilePath CharMapPath()
            => SettingsDir() + FS.file("sdm.charmap", FS.Config);

        public FS.FilePath UnmappedCharLog()
            => LogDir() + FS.file("unmapped", FS.Log);

        public FS.FilePath SplitSpecs()
            => SettingsDir() + FS.file("sdm.splits", FS.Csv);

        public FS.FileName SdmSrcFile(byte vol)
            => FS.file(string.Format("intel-sdm-vol{0}", vol), FS.Txt);

        public FS.FilePath SdmSrcPath()
            => Sources() + FS.file("intel-sdm", FS.Txt);

        public FS.FilePath ImportTable<T>()
            where T : struct
                => Targets() + Tables.filename<T>();

        public FS.FolderPath StringTables()
            => Wf.EnvPaths.ZRoot() + FS.folder("gen/src");

        static bool IsTocPart(FS.FilePath src)
        {
            var f = src.FileName.Format();
            if(src.Ext == FS.Txt)
            {
                var name = src.WithoutExtension.Format();
                if(name.Contains("toc") && name.EndsWithDigit())
                    return true;
            }
            return false;
        }
    }
}