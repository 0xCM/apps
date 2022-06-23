//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Threading.Tasks;

    [ApiHost]
    public static partial class XCalc
    {
        /// <summary>
        /// Retrieves, at most, one cell's worth of bits defined by an inclusive bit index range
        /// </summary>
        /// <param name="i0">The linear index of the first bit</param>
        /// <param name="i1">The linear index of the last bit</param>
        [MethodImpl(Inline)]
        public static T BitSeg<T>(this SpanBlock256<T> src, uint i0, uint i1)
            where T : unmanaged
                => gbits.seg(src.Storage, i0, i1);

    }
}