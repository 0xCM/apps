//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool Contains<T>(this Index<T> src, T match)
            where T : IEquatable<T>
        {
            var result = false;
            for(var i=0; i<src.Count; i++)
            {
                result = src[i].Equals(match);
                if(result)
                    break;
            }
            return result;
        }
    }
}