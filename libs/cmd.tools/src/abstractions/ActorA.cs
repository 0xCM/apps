//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public abstract class Actor<A> : IActor
        where A : Actor<A>,new()
    {
        public Name<asci64> Name {get;}

        static A _Instance = new();

        public static ref readonly A Instance
        {
            [MethodImpl(Inline)]
            get => ref _Instance;
        }

        protected Actor(Name<asci64> name)
        {
            Name = name;
        }
    }
}