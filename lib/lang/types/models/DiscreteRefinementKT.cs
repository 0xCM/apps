//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class DiscreteRefinement<K,R> : RefinementType<K,R>
        where K : unmanaged
        where R : unmanaged
    {

        protected DiscreteRefinement(Identifier name, K kind)
            : base(name,kind)
        {


        }
    }


    // public abstract class DiscreteLiteralRefinement<K,R> : DiscreteRefinement<K,R>
    //     where K : unmanaged
    //     where R : unmanaged, ILiteralType<R>
    // {
    //     protected DiscreteLiteralRefinement(Identifier name, K kind)
    //         : base(name,kind)
    //     {


    //     }
    // }
}