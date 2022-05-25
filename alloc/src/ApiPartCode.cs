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

        public readonly ApiPackArchive Archive;

        public ApiPartCode(ResolvedPart resolved, ApiHostCode[] code, ApiPackArchive archive)
        {
            Resolved = resolved;
            Code = code;
            Archive = archive;
        }
    }
}