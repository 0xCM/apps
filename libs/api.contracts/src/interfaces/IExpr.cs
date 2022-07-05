//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IExpr : IExpr2
    {
        ulong Kind => 0;

        bool INullity.IsEmpty
            => false;

       string IExpr2.Format()
            => string.Empty;
    }
}