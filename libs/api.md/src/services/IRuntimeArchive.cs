//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FS;

    public interface IRuntimeArchive : IFileArchive
    {
        /// <summary>
        /// All runtime-related files in the archive
        /// </summary>
        FS.Files IFileArchive.Files()
             => Root.Files(false, Exe, Dll, Pdb, Json, Xml).Where(x => !x.Name.Contains("System.Private.CoreLib"));

        FS.Files ExeFiles
            => Files().Where(x => x.Is(Exe));

        FS.Files XmlFiles
            => Files().Where(x => x.Is(Xml));

        FS.Files DllFiles
            => Files().Where(x => x.Is(Dll));
    }
}