//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Free]
    public interface IStringAllocProvider
    {
        Label Label(string src);

        StringRef String(string src);

        SourceText Source(string src);
    }

    [Free]
    public interface ISymAllocProvider
    {
        LocatedSymbol Symbol(MemoryAddress location, string name);

        LocatedSymbol Symbol(SymAddress location, string name);
    }

    [Free]
    public interface IMemAllocProvider
    {
        MemorySeg Memory(ByteSize size);

        MemorySeg Page();
    }

    [Free]
    public interface IHexAllocProvider
    {
        AsmHexRef AsmEncoding(ByteSize size);

        AsmHexRef AsmEncoding(ReadOnlySpan<byte> src);
    }

    [Free]
    public interface IAllocProvider : IStringAllocProvider, ISymAllocProvider, IMemAllocProvider, IHexAllocProvider
    {

    }
}