//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;
    using System;

    using Z0.Lang;

    using static Root;
    using static core;

    public struct Dfa26State
    {
        public byte Depth;

        public Token26 Token;
    }

    [ApiHost]
    public readonly partial struct Dfa
    {
        const NumericKind Closure = UnsignedInts;

        static ReadOnlySpan<char> AsciLo => new char[]{'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

        public static TableDfa<Hex5Seq,AsciLetterLoSym> recognizer(string src)
        {
            const AsciLetterLoSym Min = AsciLetterLoSym.a;
            const AsciLetterLoSym Max = AsciLetterLoSym.z;

            var states = Dfa.states<Hex5Seq>();
            var alphabet = lang.alphabet<AsciLetterLoSym>("asci-lo");
            var length = src.Length;
            if(length > 16)
                @throw(string.Format("Strings of length {0} > {1} are not accepted", length, Hex4.Max));

            var dim = new GridDim(32,32);
            var cells = alloc<Hex5>(dim.M*dim.N);
            var g = new Grid<Hex5>(dim, alloc<Hex5>(dim.M*dim.N));
            var chars = core.span(src);

            var col = Hex5.Zero;
            for(var row=0; row<length; row++)
            {
                ref readonly var c = ref skip(chars,row);
                ref readonly var s = ref @as<char,AsciLetterLoSym>(c);
                if(s >= Min && s <= Max)
                    g[row,col] = (byte)((ushort)s - (ushort)Min);
                else
                    @throw("Only lowercase asci characters are supported");
            }

            return default;
        }
    }
}