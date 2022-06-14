//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiPartCode
    {
        public ResolvedPart Resolved;

        public readonly Index<ApiHostCode> Code;

        public readonly IApiPack Archive;

        public ApiPartCode(ResolvedPart resolved, ApiHostCode[] code, IApiPack archive)
        {
            Resolved = resolved;
            Code = code;
            Archive = archive;
        }
    }
}