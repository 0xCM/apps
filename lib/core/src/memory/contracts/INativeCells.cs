
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface INativeCells : IDisposable
    {
        MemoryAddress BaseAddress {get;}

        uint CellCount {get;}
    }
}