//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static SdmModels;

    partial struct SdmOps
    {
        public static int index(ReadOnlySpan<char> src, string marker)
        {
            var index = src.IndexOf(marker);
            if(index > ContentMarkers.TableNumber.Length)
                return NotFound;
            else
                return index;
        }
    }
}