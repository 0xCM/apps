//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITextVarKind
    {
        bool IsFenced {get;}

        Fence<char> Fence {get;}

        string Prefix {get;}

        bool IsPrefixed {get;}
    }
}