//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct JsonDepsModel
    {
        public record struct RuntimeLibraryInfo
        {
            public Seq<AssetGroupInfo> AssemblyGroups;

            public Seq<AssetGroupInfo> NativeLibraries;

            public Seq<ResourceAssembly> ResourceAssemblies;
        }
    }
}