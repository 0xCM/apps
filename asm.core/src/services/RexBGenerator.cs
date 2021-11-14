//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static AsmRegCodes;
    using static AsmOpCodeTokens;

    /// <summary>
    /// Generates <see cref='RexB'/> tables
    /// </summary>
    public sealed class RexBGenerator : Service<RexBGenerator>
    {
        // RexBBits:[Index[00000] | Token[000]]
        public static RexB rexb(RexBToken token, RegIndexCode r)
            => new RexB(token,r);

        Symbols<RexBToken> _Tokens;

        [MethodImpl(Inline)]
        static RexBToken rb()
            => RexBToken.rb;

        [MethodImpl(Inline)]
        static RexBToken rw()
            => RexBToken.rw;

        [MethodImpl(Inline)]
        static RexBToken rd()
            => RexBToken.rd;

        [MethodImpl(Inline)]
        static RexBToken ro()
            => RexBToken.ro;

        public RexBGenerator()
        {
            _Tokens = Symbols.index<RexBToken>();
        }

        ReadOnlySpan<RexBToken> Tokens
        {
            [MethodImpl(Inline)]
            get => _Tokens.Kinds;
        }

        public ReadOnlySpan<RexB> Generate()
        {
            var dst = span<RexB>(256);
            var i=0u;
            var counter = 0u;
            counter += IncludeGp8(ref i, dst);
            counter += IncludeGp16(ref i, dst);
            counter += IncludeGp32(ref i, dst);
            counter += IncludeGp64(ref i, dst);
            return slice(dst,0,counter);
        }

        byte IncludeGp8(ref uint i, Span<RexB> dst)
        {
            const byte RegCount = 16;
            var i0 = i;
            var j = z8;
            var regs = Gp8Regs().Kinds;
            for(j=0; j<RegCount; j++)
            {
                if(j>=4)
                    seek(dst,i++) = rexb(rb(), (RegIndexCode)skip(regs,j));
            }

            return (byte)(i - i0);
        }

        byte IncludeGp16(ref uint i, Span<RexB> dst)
        {
            const byte RegCount = 16;
            var i0 = i;
            var regs = Gp16Regs().Kinds;
            var j = z8;
            for(j=0; j<RegCount; j++)
            {
                if(j>=8)
                    seek(dst,i++) = rexb(rw(), (RegIndexCode)skip(regs,j));
            }

            return (byte)(i - i0);
        }

        byte IncludeGp32(ref uint i, Span<RexB> dst)
        {
            const byte RegCount = 16;
            var i0 = i;
            var j = z8;
            var regs = Gp32Regs().Kinds;
            for(j=0; j<RegCount; j++)
            {
                if(j>=8)
                    seek(dst,i++) = rexb(rd(), (RegIndexCode)skip(regs,j));
            }
            return (byte)(i - i0);
        }

        byte IncludeGp64(ref uint i, Span<RexB> dst)
        {
            const byte RegCount = 16;
            var i0 = i;
            var j = z8;
            var regs = Gp64Regs().Kinds;
            for(j=0; j<RegCount; j++)
            {
                if(j >=8)
                    seek(dst,i++) = rexb(ro(), (RegIndexCode)skip(regs,j));
            }
            return (byte)(i - i0);
        }
    }
}