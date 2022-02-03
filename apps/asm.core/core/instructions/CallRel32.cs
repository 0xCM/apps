//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct CallRel32 : IAsmRel<Disp32>
    {
        [MethodImpl(Inline), Op]
        public static CallRel32 call(Rip rip, Disp32 disp)
            => new CallRel32(rip, AsmRel32.target(rip,disp));

        [MethodImpl(Inline), Op]
        public static bool test(ReadOnlySpan<byte> encoding)
            => encoding.Length >= InstSize && core.first(encoding) == OpCode;

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

        [MethodImpl(Inline)]
        public CallRel32(Rip src, LocatedSymbol dst)
        {
            Source = src.Address - InstSize;
            Target = dst;
        }

        public Rip Rip
        {
            [MethodImpl(Inline)]
            get => (Source.Location, InstSize);
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
            get => AsmRel32.disp(Rip, TargetAddress);
        }

        public AsmHexCode Encoding
        {
            [MethodImpl(Inline)]
            get => AsmBytes.call32(this);
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