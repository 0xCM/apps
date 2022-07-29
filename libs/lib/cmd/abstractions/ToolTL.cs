//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Tool<T,L> : ITool<L>
        where T : Tool<T,L>, new()
        where L : IExpr
    {
        public Name Name {get;}

        public abstract L Location {get;}

        protected Tool(Name name)
        {
            Name = name;
        }
    
        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }
       public string Format()
            => Location.Format();

        
        public override string ToString()
            => Format();
    }
}