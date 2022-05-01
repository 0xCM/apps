//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedCmdProvider
    {
        [MethodImpl(Inline)]
        public static Span<object> broadcast<T>(T src, Span<object> dst)
        {
            for(var i=0; i<dst.Length; i++)
                seek(dst,i) = src;
            return dst;
        }

        [CmdOp("xed/emit/layouts")]
        Outcome CheckLayouts(CmdArgs args)
        {
            TableEmit(LayoutCalcs.layouts(CalcPatterns()).View, InstLayout.RenderWidths, XedPaths.Table<InstLayout>());
            return true;
        }
    }
}