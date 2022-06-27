//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public abstract class Actor<A> : IActor<A>
        where A : Actor<A>,new()
    {
        public string Name {get;}

        static A _Instance = new();

        public static ref readonly A Instance
        {
            [MethodImpl(Inline)]
            get => ref _Instance;
        }

        protected Actor(string name)
        {
            Name = name;
        }
    }
}