//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IExpr : ITextual, INullity
    {
        ulong Kind => 0;

        bool INullity.IsEmpty
            => false;

       string ITextual.Format()
            => string.Empty;
    }
}