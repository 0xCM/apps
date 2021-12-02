//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmData
    {
        public static AsmDataSources Assets = new AsmDataSources();

        public static IAssets AssetSet
            => Assets;

        public sealed class AsmDataSources : Assets<AsmDataSources>
        {
            public Asset StanfordAsmCatalog() => Asset("stanford-asm-catalog.csv");
        }
    }
}