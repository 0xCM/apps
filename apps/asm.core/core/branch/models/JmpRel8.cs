//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct JmpRel8 : IAsmRel<Disp8>
    {
        public const byte OpCode = 0xEB;

        public const byte InstSize = 2;

        public readonly LocatedSymbol Source;

        public readonly LocatedSymbol Target;

        [MethodImpl(Inline)]
        public JmpRel8(LocatedSymbol src, LocatedSymbol dst)
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

        public Disp8 Disp
        {
            [MethodImpl(Inline)]
            get => AsmRel8.disp(SourceAddress, TargetAddress);
        }

        public AsmHexCode Encoding
        {
            [MethodImpl(Inline)]
            get => AsmRel8.encode(this);
        }

        public AsmMnemonic Mnemonic
        {
            [MethodImpl(Inline)]
            get => AsmMnemonicNames.jmp;
        }

        LocatedSymbol IAsmRel.Source
            => Source;

        LocatedSymbol IAsmRel.Target
            => Target;

        public string Format()
            => string.Format("jmp8:{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();
    }
}