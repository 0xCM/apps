//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAssets
    {
        Assembly DataSource {get;}

        ReadOnlySpan<Asset> Data {get;}

        ref readonly Asset Asset(ResourceName id);
    }
}