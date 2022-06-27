//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Actor<A> : IActor<A>
        where A : Actor<A>,new()
    {
        public string Name {get;}

        public static A Instance = new();

        protected Actor(string name)
        {
            Name = name;
        }
    }
}