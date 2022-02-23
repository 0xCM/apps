//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmBlockSegment : IAsmEncodingRecord
    {
        Identifier BlockName {get;}

        MemoryAddress BlockAddress {get;}
    }
}