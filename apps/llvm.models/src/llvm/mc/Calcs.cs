//-----------------------------------------------------------------------------
// Copyright   :  (c) LLVM Project
// License     :  Apache-2.0 WITH LLVM-exceptions
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using SQ = SymbolicQuery;

    [ApiHost("llvm.mc")]
    public readonly partial struct MC
    {
        [MethodImpl(NotInline), Op]
        public static Calcs calcs()
            => new Calcs(Symbols.index<AsmId>(), Data.AsmStrs, Data.OpInfo0, Data.OpInfo1);

        [Op]
        public static Index<OpCodeSpec> opcodes()
        {
            var calcs = MC.calcs();
            var count = calcs.AsmCount;
            var buffer = alloc<OpCodeSpec>(count);
            ref var dst = ref first(buffer);
            var ids = calcs.AsmId();
            for(ushort i=0; i<count; i++)
            {
                ref readonly var id = ref skip(ids,i);
                ref readonly var sym = ref calcs.Sym(id);
                var opcode = calcs.OpCode(id);
                ref var record = ref seek(dst,i);
                record.Id = id;
                record.Index = i;
                record.Mnemonic = calcs.Monic(id);
                record.OpCodeValue = opcode;
                record.OpCodeBytes = Hex.hexchars(opcode, LowerCase);
            }

            Array.Sort(buffer);
            return buffer;
        }

        [ApiHost("llvm.mc.calcs")]
        public readonly ref struct Calcs
        {
            readonly ReadOnlySpan<AsmId> _AsmId;

            readonly ReadOnlySpan<Sym> _AsmIdSym;

            readonly ReadOnlySpan<char> AsmStrs;

            readonly ReadOnlySpan<uint> OpInfo0;

            readonly ReadOnlySpan<uint> OpInfo1;

            [MethodImpl(Inline)]
            internal Calcs(Symbols<AsmId> asmid, ReadOnlySpan<char> strs, ReadOnlySpan<uint> a, ReadOnlySpan<uint> b)
            {
                _AsmId = asmid.Kinds;
                _AsmIdSym = asmid.Untyped().Storage;
                AsmStrs = strs;
                OpInfo0 = a;
                OpInfo1 = b;
                Require.equal(OpInfo0.Length, OpInfo1.Length);
            }

            public uint CharCount
            {
                [MethodImpl(Inline), Op]
                get => (uint)AsmStrs.Length;
            }

            public uint AsmCount
            {
                [MethodImpl(Inline), Op]
                get => (uint)OpInfo0.Length;
            }

            public uint OpInfoHiCount
            {
                [MethodImpl(Inline), Op]
                get => (uint)OpInfo1.Length;
            }

            [MethodImpl(Inline), Op]
            ReadOnlySpan<char> Monic(uint id)
            {
                var opcode = OpCode(id);
                var i = offset(opcode);
                var n = AsmLength(i);
                if(n != 0)
                    return slice(AsmStrs, i, n);
                else
                    return default;
            }

            [MethodImpl(Inline), Op]
            public string Monic(AsmId id)
                => text.format(Monic(index(id))).Replace(Chars.Tab, Chars.Space).Trim();

            [MethodImpl(Inline), Op]
            public ReadOnlySpan<AsmId> AsmId()
                => _AsmId;

            [MethodImpl(Inline), Op]
            public ref readonly Sym Sym(AsmId id)
                => ref skip(_AsmIdSym, u32(id));

            [MethodImpl(Inline), Op]
            public ulong OpCode(uint id)
            {
                ulong Bits = 0;
                Bits |= (ulong)skip(OpInfo0, id) << 0;
                Bits |= (ulong)skip(OpInfo1, id) << 32;
                return Bits;
            }

            [MethodImpl(Inline), Op]
            public Hex64 OpCode(AsmId id)
                => OpCode(u32(id));

            [MethodImpl(Inline)]
            static uint index(AsmId id)
                => u32(id);

            [MethodImpl(Inline), Op]
            public static uint offset(ulong bits)
                => (uint)((bits & 16383ul)-1);

            [MethodImpl(Inline), Op]
            uint AsmLength(uint offset)
            {
                var count = (uint)AsmStrs.Length;
                var n = z32;
                for(var i=offset; i<count; i++)
                {
                    ref readonly var c = ref skip(AsmStrs,i);
                    if(SQ.nil(c))
                        break;
                    else
                        n++;
                }
                return n;
            }
        }
    }
}