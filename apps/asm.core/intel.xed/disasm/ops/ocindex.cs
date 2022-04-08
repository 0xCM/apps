//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedDisasm
    {
        public static OpCodeIndex? ocindex(byte code)
        {
            var kind = XedPatterns.basemap(code);
            if(kind != null)
                return XedPatterns.ocindex(kind.Value);
            else
                return null;
        }
    }
}