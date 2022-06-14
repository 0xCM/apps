
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISymbolHash : IAllocation<SymHash>
    {
        bool HashSymbol(string src);
    }
}