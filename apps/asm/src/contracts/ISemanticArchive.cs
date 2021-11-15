//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface ISemanticArchive : IFileArchive
    {
        FS.FolderPath SemanticDir(PartId part);

        FS.FilePath SemanticPath(ApiHostUri host);
    }

    public interface ISemanticArchive<H> : ISemanticArchive
        where H : struct, ISemanticArchive<H>
    {

    }
}