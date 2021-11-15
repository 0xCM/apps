//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    partial class text
    {
        /// <summary>
        /// Extracts text that is enclosed between left and right boundaries, i.e. {left}{content}{right} => {content}
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="left">The left boundary</param>
        /// <param name="right">The right boundary</param>
        [Op]
        public static string unfence(string src, Fence<string> fence)
        {
            (var i0, var i1) = indices(src, fence);
            if(i0 != NotFound && i1 != NotFound && (i0 < i1))
            {
                var start = i0 + fence.Left.Length;
                var length = i1 - start;
                return slice(src, start, length);
            }

            return EmptyString;
        }

        /// <summary>
        /// Extracts text that is enclosed between left and right boundaries, i.e. {left}{content}{right} => {content}
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="left">The left boundary</param>
        /// <param name="right">The right boundary</param>
        [Op]
        public static bool unfence(string src, Fence<char> fence, out string dst)
        {
            dst = EmptyString;
            if(!blank(src))
            {
                if(fenced(src, fence, out var location))
                {
                    dst = segment(src, location.Left + 1,  location.Right - 1);
                    return true;
                }
            }
            return false;
        }
    }
}