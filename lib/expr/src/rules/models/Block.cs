//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    public abstract class Block : IBlock
    {
        public IComponent Owner {get;}

        public uint Key {get;}

        protected Block(IComponent owner, uint key)
        {
            Owner = owner;
            Key = key;
        }
    }
}