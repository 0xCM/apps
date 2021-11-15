//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    public readonly struct ToolFlows
    {
        /// <summary>
        /// Determines the first target from an input sequence, if any, with a specified extension match
        /// </summary>
        /// <param name="src">The input sequence</param>
        /// <param name="ext">The extension to match</param>
        /// <param name="dst">The match, if any</param>
        /// <returns>True if found; false otherwise</returns>
        public static bool target(ReadOnlySpan<ToolFlow> src, FS.FileExt ext, out ToolFlow dst)
        {
            var result = false;
            dst = ToolFlow.Empty;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var flow = ref skip(src,i);
                if(flow.Target.Is(ext))
                {
                    dst = flow;
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}