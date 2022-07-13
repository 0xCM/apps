//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ITableId : ITextual
    {
        Identifier Identifier {get;}
        string ITextual.Format()
            => Identifier.Format();
    }
}