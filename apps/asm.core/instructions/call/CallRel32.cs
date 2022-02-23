//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public readonly struct CallRel32 : IAsmRelInst<Disp32>
    {
        [MethodImpl(Inline), Op]
        public static bool test(ReadOnlySpan<byte> encoding)
            => encoding.Length >= CallRel32.InstSize && core.first(encoding) == CallRel32.OpCode;

        [MethodImpl(Inline), Op]
        public static CallRel32 define(Rip rip, Disp32 disp)
            => new CallRel32(rip, AsmRel32.target(rip,disp));

        [MethodImpl(Inline), Op]
        public static byte encode(Rip src, MemoryAddress dst, ref byte hex)
        {
            const byte Size = 5;
            seek(hex, 0) = CallRel32.OpCode;
            i32(seek(hex, 1)) = AsmRel32.disp(src, dst);
            return CallRel32.InstSize;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode encode(Rip rip, MemoryAddress dst)
        {
            var encoded = AsmHexCode.Empty;
            var bytes = encoded.Bytes;
            seek(bytes,15) = encode(rip, dst, ref first(bytes));
            return encoded;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode encode(CallRel32 spec)
        {
            var encoding = AsmHexCode.Empty;
            var buffer = encoding.Bytes;
            seek(buffer,0) = CallRel32.OpCode;
            @as<Disp32>(seek(buffer,1)) = AsmRel32.disp(spec.Rip, spec.TargetAddress);
            seek(buffer,15) = CallRel32.InstSize;
            return encoding;
        }

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
            get => encode(this);
        }

        public AsmMnemonic Mnemonic
        {
            [MethodImpl(Inline)]
            get => "call";
        }

        LocatedSymbol IAsmRelInst.Source
            => Source;

        LocatedSymbol IAsmRelInst.Target
            => Target;

        public string Format()
            => string.Format("call:{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();
    }
}