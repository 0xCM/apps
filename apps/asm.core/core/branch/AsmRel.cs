//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    using static core;

    [ApiHost]
    public readonly struct AsmRel
    {
        const byte Rel32InstSize = 5;

        const byte Rel8InstSize = 2;

        public const byte JmpRel8OpCode = 0xEB;

        public const byte JmpRel32OpCode = 0xE9;

        public const byte CallRel32OpCode = 0xE8;

        [MethodImpl(Inline), Op]
        public static bool isRel32Jmp(ReadOnlySpan<byte> encoding)
            => encoding.Length >= Rel32InstSize && first(encoding) == JmpRel32OpCode;

        [MethodImpl(Inline), Op]
        public static bool isRel32Call(ReadOnlySpan<byte> encoding)
            => encoding.Length >= Rel32InstSize && first(encoding) == CallRel32OpCode;

        [MethodImpl(Inline), Op]
        public static bool isRel8Jmp(ReadOnlySpan<byte> encoding)
            => encoding.Length >= Rel8InstSize && first(encoding) == JmpRel8OpCode;

        [MethodImpl(Inline), Op]
        public static Disp8 rel8dx(ReadOnlySpan<byte> encoding)
            => skip(encoding,1);

        [MethodImpl(Inline), Op]
        public static byte rel8dx(MemoryAddress ip, MemoryAddress target)
        {
            var rip = ip + Rel8InstSize;
            var dx = (byte)(rip - target);
            return dx;
        }

        [MethodImpl(Inline), Op]
        public static Address8 rel8target(MemoryAddress ip, ReadOnlySpan<byte> encoding)
        {
            var rip = ip + Rel8InstSize;
            var dx = rel8dx(encoding);
            return (byte)(rip + dx);
        }

        [MethodImpl(Inline), Op]
        public static Address8 rel8offset(MemoryAddress block, MemoryAddress ip, ReadOnlySpan<byte> encoding)
            => (Address8)(rel8target(ip, encoding) - block);

        [MethodImpl(Inline), Op]
        public static Address32 rel32dx(ReadOnlySpan<byte> encoding)
            => first(recover<uint>(slice(encoding,1, 4)));

        [MethodImpl(Inline), Op]
        public static Disp32 rel32dx(MemoryAddress ip, MemoryAddress target)
        {
            var rip = ip + Rel32InstSize;
            var dx = (long)rip - (long)target;
            return (Disp32)dx;
        }

        [MethodImpl(Inline), Op]
        public static Address32 rel32target(MemoryAddress ip, ReadOnlySpan<byte> encoding)
        {
            var rip = ip + Rel32InstSize;
            var dx = rel32dx(encoding);
            return (Address32)(rip + dx);
        }

        [MethodImpl(Inline), Op]
        public static Address32 rel32offset(MemoryAddress block, MemoryAddress ip, ReadOnlySpan<byte> encoding)
            => (Address32)(rel32target(ip,encoding) - block);


        [MethodImpl(Inline), Op]
        public static AsmHexCode encodeRel8Jmp(MemoryAddress ip, MemoryAddress target)
        {
            var encoding = AsmHexCode.Empty;
            var dst = encoding.Bytes;
            seek(dst,0) = JmpRel8OpCode;
            seek(dst,1) = rel8dx(ip,target);
            return encoding;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode encodeRel32Jmp(MemoryAddress ip, MemoryAddress target)
        {
            var encoding = AsmHexCode.Empty;
            var dst = encoding.Bytes;
            seek(dst,0) = JmpRel32OpCode;
            @as<Disp32>(seek(dst,1)) = rel32dx(ip,target);
            return encoding;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode encodeRel32Call(MemoryAddress ip, MemoryAddress target)
        {
            var encoding = AsmHexCode.Empty;
            var dst = encoding.Bytes;
            seek(dst,0) = CallRel32OpCode;
            @as<Disp32>(seek(dst,1)) = rel32dx(ip,target);
            return encoding;
        }

        [Op]
        public static string describe(in AsmDetailRow row)
        {
            var encoded = row.Encoded.Bytes;
            var ip = row.IP;
            var @base = row.BlockAddress;

            if(row.Mnemonic.Format(MnemonicCase.Lowercase) == "jmp")
            {
                if(isRel8Jmp(encoded))
                    return string.Format("jmp(rel8,{0},{1}) -> {2}",
                        rel8dx(encoded),
                        rel8offset(@base, ip, encoded),
                        rel8target(ip, encoded)
                        );
                else if(isRel32Jmp(encoded))
                    return string.Format("jmp(rel32,{0},{1}) -> {2}",
                        rel32dx(encoded).FormatMinimal(),
                        rel32offset(@base, ip, encoded).FormatMinimal(),
                        rel32target(ip, encoded)
                        );

            }
            else if(row.Mnemonic.Format(MnemonicCase.Lowercase) == "call")
            {
                if(isRel32Call(encoded))
                {
                    return string.Format("call(rel32,{0},{1}) -> {2}",
                        rel32dx(encoded).FormatMinimal(),
                        rel32offset(@base, ip, encoded).FormatMinimal(),
                        rel32target(ip, encoded)
                        );
                }
            }
            return EmptyString;
        }

    }
}