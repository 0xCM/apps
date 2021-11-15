//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Parts
{
    partial class AsmCore
    {
        public static PartAssets Assets = new PartAssets();

        public static IAssets AssetSet
            => Assets;

        public sealed class PartAssets : Assets<PartAssets>
        {


        }
    }
}