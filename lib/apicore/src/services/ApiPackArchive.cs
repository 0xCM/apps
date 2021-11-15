//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Diagnostics;

    using static Root;
    using static EnvFolders;
    using static core;

    public readonly struct ApiPackArchive : IFileArchive
    {
        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public static ApiPackArchive create(FS.FolderPath root)
            => new ApiPackArchive(root);

        [MethodImpl(Inline)]
        public ApiPackArchive(FS.FolderPath root)
        {
            Root = root;
        }

        IFileArchive This => this;

        public FS.FolderPath RootDir()
            => Root;

        public FS.FolderPath CaptureTables()
            => Root + FS.folder(tables);

        public FS.FolderPath PartDir(PartId part)
            => Root + FS.folder(part);

        public FS.FolderPath HostAsm()
            => CaptureTables() + FS.folder("asm.statements");

        public FS.FolderPath HostAsm(PartId part)
            => HostAsm() + FS.folder(part.Format());

        public FS.FilePath ApiCatalog()
            => Root + FS.folder(tables) + FS.file(TableId.identify<ApiCatalogEntry>().Format(),FS.Csv);

        public FS.Files HostAsmDocs()
            => HostAsm().Files(FS.Asm, true);

        public FS.Files HostAsmTables()
            => HostAsm().Files(FS.Csv, true);

        public Index<AsmCsvPaths> HostAsmCsv()
        {
            var asm = HostAsmDocs().View;
            var csv = HostAsmTables().View;
            var count = csv.Length;
            Require.equal(count, asm.Length);
            var buffer = alloc<AsmCsvPaths>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst,i) = (skip(asm,i),skip(csv,i));
            return buffer;
        }

        public FS.FilePath ProcessAsmPath()
            => RootDir() + FS.file("asm.statements", FS.Csv);

        public FS.FilePath HostAsmTable(ApiHostUri host)
            => HostAsm(host.Part) + FS.file(host.HostName, FS.Csv);

        public FS.FilePath Thumbprints()
            => RootDir() + FS.file("thumbprints", FS.Asm);

        public FS.FolderPath Dumps()
            => RootDir() + FS.folder(dumps);

        public FS.FolderPath Dumps(string id)
            => Dumps() + FS.folder(id);

        public FS.FileName ProcDumpFile(Process process, Timestamp ts)
            => FS.file(ProcDumpIdentity.create(process,ts).Format(), FS.Dmp);

        public FS.FilePath ProcDumpPath(Process process, Timestamp ts)
            => Dumps() + ProcDumpFile(process, ts);

        public FS.FolderPath CaptureRoot()
            => Root + FS.folder(capture);

        public FS.FolderPath AsmCaptureRoot()
            => CaptureRoot() + FS.folder(asm);

        public FS.FolderPath CodeGenRoot()
            => Root + FS.folder("codegen");

        public FS.FolderPath CodeGenDir(string id)
            => CodeGenRoot() + FS.folder(id);

        public FS.FolderPath AsmPartCapture(PartId part)
            => AsmCaptureRoot() + FS.folder(part);

        public FS.Files AsmCapturePaths(PartId id)
            => AsmPartCapture(id).Files(FS.Asm);

        public FS.FolderPath HexPackRoot()
            => CaptureRoot() + FS.folder(extracts);

        public FS.FilePath RawHexPath(ApiHostUri host)
            => HexPackRoot() + FS.file(host, "extracts.raw", FS.XPack);

        public FS.FilePath ParsedHexPath(ApiHostUri host)
            => HexPackRoot() + FS.file(host, "extracts.parsed", FS.XPack);

        public FS.Files HexPackPaths(bool parsed)
            => parsed ?  HexPackRoot().Files(FS.ext("parsed") + FS.XPack) : HexPackRoot().Files(FS.ext("raw") + FS.XPack);

        public FS.FilePath AsmSrcPath(ApiHostUri host)
            => AsmPartCapture(host.Part) + FS.file(host, FS.Asm);

        public FS.FolderPath ContextRoot()
            => CaptureRoot() + FS.folder(context);

        public FS.FolderPath TableDir()
            => RootDir() + FS.folder("tables");

        public FS.FilePath AsmCallsPath()
            => TableDir() + FS.file("asm.calls", FS.Csv);

        public FS.FilePath JmpTarget()
            => TableDir() + FS.file("asm.jumps", FS.Csv);

        public FS.FilePath TablePath<T>()
            where T : struct
                => TableDir() + FS.file(TableId.identify<T>().Format(), FS.Csv);
        public FS.FilePath TablePath(string id)
            => TableDir() + FS.file(id, FS.Csv);

        public FS.FolderPath DetailTables()
            => TableDir() + FS.folder("asm.details");

        public FS.FilePath ApiCatalogPath()
            => TableDir() + FS.file(TableId.identify<ApiCatalogEntry>().Format(), FS.Csv);

        // public FS.FilePath ApiCatalogPath(Timestamp ts)
        //     => ContextRoot() + FS.file(string.Format("{0}.{1}", TableId.identify<ApiCatalogEntry>(), ts.Format()), FS.Csv);
    }
}