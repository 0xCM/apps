//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiExtractor
    {
        ApiHostDataset ExtractHost(in ResolvedHost src, IApiPack dst)
        {
            var code = CodeExtractor.ExtractHostCode(src, dst, PackArchive);
            return CreateDataset(code, EmitRoutines(code));
        }
    }
}