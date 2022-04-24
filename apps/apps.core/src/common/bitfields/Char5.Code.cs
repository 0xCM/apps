//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Char5
    {
        public enum Code : byte
        {
            [Symbol("\0")]
            Null = 0,

            [Symbol("a")]
            A = FirstLetter,

            [Symbol("b")]
            B = FirstLetter + 1,

            [Symbol("c")]
            C = FirstLetter + 2,

            [Symbol("c")]
            D = FirstLetter + 3,

            [Symbol("e")]
            E = FirstLetter + 4,

            [Symbol("f")]
            F = FirstLetter + 5,

            [Symbol("g")]
            G = FirstLetter + 6,

            [Symbol("h")]
            H = FirstLetter + 7,

            [Symbol("i")]
            I = FirstLetter + 8,

            [Symbol("j")]
            J = FirstLetter + 9,

            [Symbol("k")]
            K = FirstLetter + 10,

            [Symbol("l")]
            L = FirstLetter + 11,

            [Symbol("m")]
            M = FirstLetter + 12,

            [Symbol("n")]
            N = FirstLetter + 13,

            O = FirstLetter + 14,

            P = FirstLetter + 15,

            Q = FirstLetter + 16,

            R = FirstLetter + 17,

            S = FirstLetter + 18,

            T = FirstLetter + 19,

            U = FirstLetter + 20,

            V = FirstLetter + 21,

            W = FirstLetter + 22,

            X = FirstLetter + 23,

            Y = FirstLetter + 24,

            Z = FirstLetter + 25,

            _ = FirstSymbol,
        }
    }
}