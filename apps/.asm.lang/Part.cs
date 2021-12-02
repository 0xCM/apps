//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.AsmLang)]
namespace Z0.Parts
{
    public sealed partial class AsmLang : Part<AsmLang>
    {
        public static PartAssets Assets = new PartAssets();

        public static IAssets AssetSet
            => Assets;

        public AsmLang()
        {
        }

        public sealed class PartAssets : Assets<PartAssets>
        {


        }
    }
}

namespace Z0
{
    [ApiHost]
    public static partial class XTend
    {

    }

}