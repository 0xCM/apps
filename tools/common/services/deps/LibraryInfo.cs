//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct JsonDepsModel
    {
        public struct LibraryInfo
        {
            public string Type;

            public string Name;

            public string Version;

            public string Hash;

            public Index<LibraryDependency> Dependencies;

            public bool Serviceable;

            public FS.FilePath Path;

            public string HashPath;

            public string RuntimeStoreManifestName;

            public Index<string> Assemblies;

            public Index<FS.FilePath> ReferencePaths;
        }
    }
}