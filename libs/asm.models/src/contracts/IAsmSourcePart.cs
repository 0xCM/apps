//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAsmSourcePart : ITextual
    {
        AsmCellKind PartKind {get;}
    }
}