//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct JsonDepsModel
    {
        public struct RuntimeLibraryInfo
        {
            public Index<AssetGroupInfo> AssemblyGroups;

            public Index<AssetGroupInfo> NativeLibraries;

            public Index<ResourceAssembly> ResourceAssemblies;

            public void Render(ITextBuffer dst)
            {
                core.iter(AssemblyGroups, x => x.Render(dst));
                core.iter(NativeLibraries, x => x.Render(dst));
            }
        }
    }
}