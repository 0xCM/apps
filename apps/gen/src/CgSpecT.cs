//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct CgSpec<T>
    {
        public @string TargetNs;

        public Index<string> Usings;

        public T Content;

        public CgSpec(@string ns, string[] usings, T content)
        {
            TargetNs = ns;
            Usings = usings;
            Content = content;
        }
    }
}