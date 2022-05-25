//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using Asm;

    partial class ApiExtractor
    {
        ApiCodeExtractor CodeExtractor => Service(Wf.CodeExtractor);

        ApiHostDataset ExtractHostDatast(in ResolvedHost src, IApiPack pack)
        {
            //var code = ExtractCode(src, pack);
            var code = CodeExtractor.ExtractHostCode(src, pack, PackArchive);
            return CreateDataset(code, EmitRoutines(code));
        }
    }
}