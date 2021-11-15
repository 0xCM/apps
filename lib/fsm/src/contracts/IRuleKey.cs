//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRuleKey : IHashed
    {
        new int Hash {get;}

        uint IHashed.Hash => (uint)Hash;
    }

    public interface IRuleKey<E,S> : IRuleKey
    {
        /// <summary>
        /// The triggering event
        /// </summary>
        E Trigger {get;}
    
        /// <summary>
        /// The source state
        /// </summary>
        S Source {get;}
    }
}