//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMemDb
    {
        MemoryFileInfo Description {get;}

        void Store(MemoryAddress @base, ReadOnlySpan<byte> src);
    }
}