//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IExprScope
    {
        Label Parent {get;}

        Label Name {get;}

        bool IsRoot
            => Parent.Length == 0;
    }
}