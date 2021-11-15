//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    public interface IBlock
    {
        IComponent Owner {get;}

        uint Key {get;}
    }
}