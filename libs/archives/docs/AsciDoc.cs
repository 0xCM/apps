//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static DocModels;

    public sealed class AsciDoc : Doc<AsciSymbol>
    {
        public AsciDoc(AsciSymbol[] src)
            : base(src)
        {

        }
    }
}