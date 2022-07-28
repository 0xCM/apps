//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public sealed class Roslyn : WfSvc<Roslyn>
    {
        [Op]
        public CaCompilation<CSharpCompilation> Compilation(string name, params MetadataReference[] refs)
            => CSharpCompilation.Create(name, references: refs);
    }
}