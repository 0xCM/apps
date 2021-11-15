//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    public abstract class Component<B> : IComponent
        where B : IBlock
    {
        readonly Index<B> _Blocks;

        protected Component(B[] blocks)
        {
            _Blocks = blocks;
        }
    }
}