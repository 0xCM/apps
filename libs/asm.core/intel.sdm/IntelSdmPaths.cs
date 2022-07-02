//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static SdmModels;
    using static ApiGranules;

    public class IntelSdmPaths : WfSvc<IntelSdmPaths>
    {
        public IDbTargets Targets()
            => AppDb.DbOut(sdm);

        public FS.FilePath SdmTable<T>()
            where T : struct
                => AppDb.DbTable<T>(sdm);

        public IDbTargets Logs()
            => AppDb.Logs(sdm);

        public IDbSources Settings()
            => AppDb.EnvConfig();

        public FS.FilePath SigFixupConfig()
            => AppDb.EnvConfig().Path("asm.sigs.fixups", FileKind.Map);

        public FS.FilePath SigNormalConfig()
            => AppDb.EnvConfig().Path("asm.sigs.normalize", FileKind.Map);

        public FS.FilePath OcFixupConfig()
            => AppDb.EnvConfig().Path("asm.opcodes.fixups", FileKind.Map);

        public FS.FilePath SplitConfig()
            => Settings().Path(FS.file("sdm.splits", FS.Csv));

        public IDbSources Sources()
            => AppDb.DbIn(intel);

        public IDbSources Sources(string scope)
            => Sources().Sources(scope);

        public FS.FilePath SdmSrcVol(byte vol)
            => Sources().Path(FS.file(string.Format("intel-sdm-vol{0}", vol), FS.Txt));

        public FS.FilePath SdmDstVol(byte vol)
            => Targets().Path(FS.file(string.Format("intel-sdm-vol{0}-{1}", vol, "lined"), FS.Txt));

        public FS.FilePath TocImportDoc()
            => Targets().Path(FS.file("sdm.toc", FS.Txt));

        public FS.FilePath ProcessLog(string name)
            => Logs().Path(name,FileKind.Log);

        public SortedSpan<FS.FilePath> TocPaths()
            => Targets().Files().Where(f => IsTocPart(f)).Array().ToSortedSpan();

        public FS.FilePath TocImportTable()
            => AppDb.DbTable<TocEntry>(sdm);

        public FS.FilePath FormDetailPath()
            => AppDb.DbTable<SdmFormDetail>(sdm);

        public FS.FilePath CharMapTarget()
            => Targets().Path(FS.file("sdm.charmap", FS.Config));

        public FS.FilePath UnmappedCharLog()
            => Logs().Path("sdm.unmapped", FileKind.Log);

        public FS.FilePath SdmSrcPath()
            => Sources().Path(FS.file("intel-sdm", FS.Txt));

        public IDbSources CsvSources()
            => Sources().Sources("sdm.instructions");

        public FS.FilePath Tokens(string sort)
            => Targets().Path(sort,FileKind.Csv);

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