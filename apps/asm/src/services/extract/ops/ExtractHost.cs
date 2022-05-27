//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiExtractor
    {
        ApiHostDataset ExtractHost(in ResolvedHost src, IApiPack pack)
        {
            var code = CodeExtractor.ExtractHostCode(src, pack, PackArchive);
            return CreateDataset(code, EmitRoutines(code));
        }
    }
}