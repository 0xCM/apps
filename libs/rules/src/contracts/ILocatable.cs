//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILocatable : IExpr
    {
        dynamic Location {get;}

        bool INullity.IsEmpty
            => Location == null;
    }
}