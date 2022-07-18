//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiPackArchive : IFileArchive
    {
        IDbTargets Tables()
            => new DbTargets(Root);

        FS.FilePath ProcessAsmPath()
            => Tables().Path(FS.file("asm.statements", FS.Csv));

        FS.FilePath AsmCallsPath()
            => Tables().Path(FS.file("asm.calls", FS.Csv));

        FS.FilePath JmpTarget()
            => Tables().Path(FS.file("asm.jumps", FS.Csv));

        IDbTargets DetailTables()
            => Tables().Targets("asm.details");
    }
}