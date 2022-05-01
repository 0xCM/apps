//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CodeRepoLink
    {
        public string Http {get;}

        public CodeRepoLink(string http)
        {
            Http = http;
        }

        public static implicit operator CodeRepoLink(string src)
            => new CodeRepoLink(src);
    }
}