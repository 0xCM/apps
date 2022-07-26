//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;

    public interface IToolWs
    {
        FS.FolderPath Home  {get;}

        FS.FilePath Script(string name, FileKind kind)
            => Home + FS.folder(scripts) + FS.file(name,kind);

        FS.FilePath Script(FS.FileName file)
            => Home + FS.folder(scripts) + file;
    }
}