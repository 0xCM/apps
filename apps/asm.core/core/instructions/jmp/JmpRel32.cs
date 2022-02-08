//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct JmpRel32 : IAsmRel<Disp32>
    {
        [MethodImpl(Inline), Op]
        public static JmpRel32 jmp(Rip src, MemoryAddress dst)
            => new JmpRel32(src, dst);

        [MethodImpl(Inline), Op]
        public static JmpRel32 jmp(LocatedSymbol src, LocatedSymbol dst)
            => new JmpRel32(src, dst);

        [MethodImpl(Inline), Op]
        public static bool test(ReadOnlySpan<byte> encoding)
            => encoding.Length >= InstSize && core.first(encoding) == OpCode;

        public const byte OpCode = 0xE9;

        public const byte InstSize = 5;

        public readonly LocatedSymbol Source;

        public readonly LocatedSymbol Target;

        [MethodImpl(Inline)]
        public JmpRel32(LocatedSymbol src, LocatedSymbol dst)
        {
            Source = src;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public JmpRel32(Rip src, LocatedSymbol dst)
        {
            Source = src.Address - InstSize;
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
            get => AsmRel32.disp(Rip, TargetAddress);
        }

        public Rip Rip
        {
            [MethodImpl(Inline)]
            get => (Source.Location, InstSize);
        }

        public AsmHexCode Encoding
        {
            [MethodImpl(Inline)]
            get => asm.jmp32(this);
        }

        public AsmMnemonic Mnemonic
        {
            [MethodImpl(Inline)]
            get => "jmp";
        }

        LocatedSymbol IAsmRel.Source
            => Source;

        LocatedSymbol IAsmRel.Target
            => Target;

        public string Format()
            => string.Format("jmp32:{0} [{1}] -> {2} -> {3}", Source, Disp, Target, Encoding);

        public override string ToString()
            => Format();
    }
}