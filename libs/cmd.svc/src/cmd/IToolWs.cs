//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    public interface IToolWs
    {
        FS.FolderPath Home  {get;}

        SettingLookup Settings {get;}
            
        IDbArchive Docs()
            => new DbArchive(Home + FS.folder(docs));
            
        FS.FilePath ConfigScript(string name, FileKind kind)
            => Home + FS.file(name,kind);

        FS.FilePath Script(string name, FileKind kind)
            => Home + FS.folder(scripts) + FS.file(name,kind);

        FS.FilePath Script(FS.FileName file)
            => Home + FS.folder(scripts) + file;
    }
}