//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    partial class ApiQuery
    {
        public static ApiMembers members(Index<ApiMember> src)
        {
            if(src.Length != 0)
            {
                Array.Sort(src.Storage);
                return new ApiMembers(src.First.BaseAddress, src);
            }
            else
                return ApiMembers.Empty;
        }

        public static ApiMembers members(MemoryAddress @base, Index<ApiMember> src)
        {
            if(src.Length != 0)
                return new ApiMembers(@base, src.Sort());
            else
                return ApiMembers.Empty;
        }
    }
}