//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection;

    public interface IApiAssets : IAppService
    {
        Index<ResEmission> EmitAssetContent();

        Index<ResEmission> EmitEmbedded(Assembly src, FS.FolderPath root, utf8 match = default,  bool clear = true);

        ResEmission Emit(in Asset src, FS.FolderPath root);
    }
}