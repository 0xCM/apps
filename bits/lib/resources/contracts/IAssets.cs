//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    public interface IAssets
    {
        Assembly DataSource {get;}

        ReadOnlySpan<Asset> Descriptors {get;}

        ref readonly Asset Asset(ResourceName id);
    }
}