//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct JsonDepsModel
    {
        public record struct RuntimLib
        {
            public Seq<AssetGroup> AssemblyGroups;

            public Seq<AssetGroup> NativeLibraries;

            public Seq<ResourceAssembly> ResourceAssemblies;
        }
    }
}