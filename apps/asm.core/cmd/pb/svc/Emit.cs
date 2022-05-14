//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class PolyBits
    {
        public void EmitPatterns(string name, ReadOnlySpan<BitPattern> src)
        {
            var dst = text.emitter();
            for(var i=0u; i<src.Length; i++)
                describe(skip(src,i), i, dst);
            AppSvc.FileEmit(dst.Emit(), 12, AppDb.Targets("polybits").Path(name, FileKind.Txt));
        }
    }
}