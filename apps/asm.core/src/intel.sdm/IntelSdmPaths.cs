//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static SdmModels;

    public class IntelSdmPaths : AppService<IntelSdmPaths>
    {
        protected override IProjectWs Project()
            => Ws.Project("db/sources/intel");

        public FS.FolderPath Targets()
            => ProjectDb.Subdir("sdm");

        public FS.FolderPath Logs()
            => ProjectDb.Subdir("logs") + FS.folder("sdm");

        public FS.FolderPath Settings()
            => ProjectDb.Settings();

        public FS.FilePath SigProductions()
            => Targets() + FS.file("sdm.sigs.productions", FS.ext("map"));

        public FS.FilePath SigDecompRules()
            => ProjectDb.Settings("asm.sigs.decomp", FS.ext("map"));

        public FS.FilePath SigFixupRules()
            => ProjectDb.Settings("asm.sigs.fixups", FS.ext("map"));

        public FS.FilePath SigExpansionRules()
            => ProjectDb.Settings("asm.sigs.expansions", FS.ext("map"));

        public FS.FilePath SigDecompTable()
            => ProjectDb.TablePath<AsmSigOpCode>("sdm", "decomposed");

        public FS.FilePath SigDuplicateTable()
            => ProjectDb.TablePath<AsmSigOpCode>("sdm", "duplicates");

        public FS.FilePath SigNormalRules()
            => ProjectDb.Settings("asm.sigs.normalize", FS.ext("map"));

        public FS.FilePath OcFixupRules()
            => ProjectDb.Settings("asm.opcodes.fixups", FS.ext("map"));

        public FS.FolderPath Sources()
            => Project().Home();

        public FS.FolderPath Sources(string name)
            => Sources() + FS.folder(name);

        public FS.FilePath SdmSrcPath(byte vol)
            => Sources() + SdmSrcFile(vol);

        public FS.FilePath SdmDstPath(byte vol)
            => Targets() + FS.file(string.Format("intel-sdm-vol{0}-{1}", vol, "lined"), FS.Txt);

        public FS.FilePath TocImportDoc()
            => Targets() + FS.file("sdm.toc", FS.Txt);

        public FS.FilePath ProcessLog(string name)
            => Logs() + FS.file(name, FS.Log);

        public SortedSpan<FS.FilePath> TocPaths()
            => Targets().AllFiles.Where(f => IsTocPart(f)).Array().ToSortedSpan();

        public FS.FilePath TocImportTable()
            => Targets() + FS.file(TableId.identify<TocEntry>().Format(), FS.Csv);

        public FS.FolderPath Imports()
            => Project().Subdir("imports");

        public FS.FilePath ImportPath(string id, FS.FileExt ext)
            => Targets() + FS.file(id,ext);

        public FS.FilePath CharMapPath()
            => Settings() + FS.file("sdm.charmap", FS.Config);

        public FS.FilePath UnmappedCharLog()
            => Logs() + FS.file("sdm.unmapped", FS.Log);

        public FS.FilePath SplitSpecs()
            => Settings() + FS.file("sdm.splits", FS.Csv);

        public FS.FileName SdmSrcFile(byte vol)
            => FS.file(string.Format("intel-sdm-vol{0}", vol), FS.Txt);

        public FS.FilePath SdmSrcPath()
            => Sources() + FS.file("intel-sdm", FS.Txt);

        public FS.FolderPath CsvSources()
            => Sources() + FS.folder("sdm.instructions");

        public FS.FilePath ImportTable<T>()
            where T : struct
                => Targets() + Tables.filename<T>();

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