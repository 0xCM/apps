//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    public interface ICilPaths : IEnvPaths
    {
        FS.Files CilDataPaths()
            => CilDataRoot().Files(FS.Csv);


    }
}