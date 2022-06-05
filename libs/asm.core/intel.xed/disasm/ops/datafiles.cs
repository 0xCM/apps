//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public static Index<DataFile> datafiles(WsContext context, bool pll = true)
        {
            var src = sources(context);
            var dst = bag<DataFile>();
            iter(src, file => dst.Add(datafile(context,file)), pll);
            return dst.Index().Sort();
        }
    }
}