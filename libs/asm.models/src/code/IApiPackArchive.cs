//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    public interface IApiPackArchive : IFileArchive
    {
        IDbTargets Targets()
            => new DbTargets(Root);

        IDbTargets Tables()
            => Targets();

        IDbTargets Targets(string scope)
            => Targets().Targets(scope);

        // FS.FilePath PartCsv(PartId part)
        //     => Targets().Path(FS.file(part.Format(),  FS.Csv));

        // FS.FilePath PartHex(PartId part)
        //     => Targets().Path(FS.file(part.Format(),  FS.Hex));

        // FS.FilePath PartAsm(PartId part)
        //     => Targets().Path(FS.file(part.Format(),  FS.Asm));

        FS.FilePath HostAsm(ApiHostUri host)
            => Targets().Path(host.FileName(FS.Asm));

        // FS.FilePath HostCsv(ApiHostUri host)
        //     => Targets().Path(host.FileName(FS.Csv));

        // FS.FilePath HostHex(ApiHostUri host)
        //     => Targets().Path(host.FileName(FS.Hex));

        IDbTargets ContextRoot()
            => Targets(context);

        FS.FilePath ProcessAsmPath()
            => Targets().Path(FS.file("asm.statements", FS.Csv));

        FS.FilePath AsmCallsPath()
            => Tables().Path(FS.file("asm.calls", FS.Csv));

        FS.FilePath JmpTarget()
            => Tables().Path(FS.file("asm.jumps", FS.Csv));

        IDbTargets DetailTables()
            => Tables().Targets("asm.details");

        FS.FilePath ApiCatalogPath()
            => Tables().Path(FS.file(Z0.Tables.identify<ApiCatalogEntry>().Format(), FS.Csv));

        FS.FilePath RawHexPath(ApiHostUri host)
            => Targets().Path(FS.file(host, "extracts.raw", FS.XPack));

        FS.FilePath ParsedHexPath(ApiHostUri host)
            => Targets().Path(FS.file(host, "extracts.parsed", FS.XPack));

        FS.FilePath ParsedExtractPath(ApiHostUri host)
            => Targets().Path(ApiFiles.filename(host, FS.PCsv));
    }
}