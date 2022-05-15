//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class PolyBits
    {
        static void render(ReadOnlySpan<BfSegModel> src, ITextEmitter dst, bool header = true)
        {
            var formatter = Tables.formatter<BfSegModel>();
            if(header)
                dst.AppendLine(formatter.FormatHeader());
            for(var i=0; i<src.Length; i++)
                dst.AppendLine(formatter.Format(skip(src,i)));
        }
    }
}