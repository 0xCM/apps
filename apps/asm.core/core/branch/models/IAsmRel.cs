//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmRel : ITextual
    {
        AsmMnemonic Mnemonic {get;}

        NativeSize RelSize {get;}

        LocatedSymbol Source {get;}

        LocatedSymbol Target {get;}

        AsmHexCode Encoding {get;}

        MemoryAddress SourceAddress
            => Source.Location;

        MemoryAddress TargetAddress
            => Target.Location;
    }

    public interface IAsmRel<T> : IAsmRel
        where T : unmanaged, IDisplacement
    {
        T Disp {get;}

        NativeSize IAsmRel.RelSize
            => Sizes.native(core.width<T>());
    }

}