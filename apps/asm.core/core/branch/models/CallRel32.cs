//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct CallRel32 : IAsmRel<Disp32>
    {
        public const byte OpCode = 0xE8;

        public const byte InstSize = 5;

        public readonly LocatedSymbol Source;

        public readonly LocatedSymbol Target;

        [MethodImpl(Inline)]
        public CallRel32(LocatedSymbol src, LocatedSymbol dst)
        {
            Source = src;
            Target = dst;
        }

        public MemoryAddress SourceAddress
        {
            [MethodImpl(Inline)]
            get => Source.Location;
        }

        public MemoryAddress TargetAddress
        {
            [MethodImpl(Inline)]
            get => Target.Location;
        }

        public Disp32 Disp
        {
            [MethodImpl(Inline)]
            get => AsmRel32.disp(SourceAddress, TargetAddress);
        }

        public AsmHexCode Encoding
        {
            [MethodImpl(Inline)]
            get => AsmRel32.encode(this);
        }

        public AsmMnemonic Mnemonic
        {
            [MethodImpl(Inline)]
            get => AsmMnemonicNames.call;
        }

        LocatedSymbol IAsmRel.Source
            => Source;

        LocatedSymbol IAsmRel.Target
            => Target;

        public string Format()
            => string.Format("call:{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();
    }
}