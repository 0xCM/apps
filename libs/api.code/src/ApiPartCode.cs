//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiPartCode
    {
        public ResolvedPart Resolved;

        public readonly Index<ApiHostMembers> Code;

        public ApiPartCode(ResolvedPart resolved, ApiHostMembers[] code)
        {
            Resolved = resolved;
            Code = code;
        }
    }
}