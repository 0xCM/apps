//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Pow2x32;

    [Flags]
    public enum DataFormatCode : uint
    {
        None,

        Bin = P2ᐞ00,

        Dec = P2ᐞ01,

        Hex = P2ᐞ02,

        Signed = P2ᐞ03,

        Spec = P2ᐞ04,

        Lower = P2ᐞ05,

        Upper = P2ᐞ06,

        Asci = P2ᐞ07,

        Utf8 = P2ᐞ08,

        Unicode = P2ᐞ09,

        [Symbol("b1", "Specifield a binary sequence of length 1")]
        B1 = Bin | D1,

        [Symbol("b2", "Specifield a binary sequence of length 2")]
        B2 = Bin | D2,

        [Symbol("b3", "Specifield a binary sequence of length 3")]
        B3 = Bin | D3,

        [Symbol("b4", "Specifield a binary sequence of length 4")]
        B4 = Bin | D4,

        [Symbol("b5", "Specifield a binary sequence of length 5")]
        B5 = Bin | D5,

        [Symbol("b6", "Specifield a binary sequence of length 6")]
        B6 = Bin | D6,

        [Symbol("b7", "Specifield a binary sequence of length 7")]
        B7 = Bin | D7,

        [Symbol("b8", "Specifield a binary sequence of length 8")]
        B8 = Bin | D8,

        [Symbol("b1", "Specifield a binary sequence of length 1 preceded by a '0b' specifier")]
        B1s = Bin | Spec | D1,

        [Symbol("b2", "Specifield a binary sequence of length 2 preceded by a '0b' specifier")]
        B2s = Bin | Spec | D2,

        [Symbol("b3", "Specifield a binary sequence of length 3 preceded by a '0b' specifier")]
        B3s = Bin | Spec | D3,

        [Symbol("b4", "Specifield a binary sequence of length 4 preceded by a '0b' specifier")]
        B4s = Bin | Spec | D4,

        [Symbol("b5", "Specifield a binary sequence of length 5 preceded by a '0b' specifier")]
        B5s = Bin | Spec | D5,

        [Symbol("b6", "Specifield a binary sequence of length 6 preceded by a '0b' specifier")]
        B6s = Bin | Spec | D6,

        [Symbol("b7", "Specifield a binary sequence of length 7 preceded by a '0b' specifier")]
        B7s = Bin | Spec | D7,

        [Symbol("b8", "Specifield a binary sequence of length 8 preceded by a '0b' specifier")]
        B8s = Bin | Spec | D5,

        [Symbol("u2", "Secifies an unsigned numeric value rendered  in base 10 with 2 fixed digits")]
        U2 = Dec | D2,

        [Symbol("u3", "Secifies an unsigned numeric value rendered in base 10 with 3 fixed digits")]
        U3 = Dec | D3,

        [Symbol("u4", "Secifies an unsigned numeric value rendered in base 10 with 4 fixed digits")]
        U4 = Dec | D4,

        [Symbol("u5", "Secifies an unsigned numeric value rendered in base 10 with 5 fixed digits")]
        U5 = Dec | D5,

        [Symbol("u6", "Secifies an unsigned numeric value rendered in base 10 with 6 fixed digits")]
        U6 = Dec | D6,

        [Symbol("u7", "Secifies an unsigned numeric value rendered in base 10 with 7 fixed digits")]
        U7 = Dec | D7,

        [Symbol("u8", "Secifies an unsigned numeric value rendered in base 10 with 8 fixed digits")]
        U8 = Dec | D8,

        [Symbol("u9", "Secifies an unsigned numeric value rendered in base 10 with 9 fixed digits")]
        U9 = Dec | D9,

        [Symbol("i2", "Secifies a signed numeric value rendered  in base 10 with 2 fixed digits")]
        I2 = Dec | Signed | D2,

        [Symbol("i3", "Secifies a signed numeric value rendered in base 10 with 3 fixed digits")]
        I3 = Dec | Signed | D3,

        [Symbol("i4", "Secifies a signed numeric value rendered in base 10 with 4 fixed digits")]
        I4 = Dec | Signed | D4,

        [Symbol("i5", "Secifies a signed numeric value rendered in base 10 with 5 fixed digits")]
        I5 = Dec | Signed | D5,

        [Symbol("i6", "Secifies a signed numeric value rendered in base 10 with 6 fixed digits")]
        I6 = Dec | Signed | D6,

        [Symbol("i7", "Secifies a signed numeric value rendered in base 10 with 7 fixed digits")]
        I7 = Dec | Signed | D7,

        [Symbol("i8", "Secifies a signed numeric value rendered in base 10 with 8 fixed digits")]
        I8 = Dec | Signed | D8,

        [Symbol("i9", "Secifies a signed numeric value rendered in base 10 with 9 fixed digits")]
        I9 = Dec | Signed | D9,

        [Symbol("x1", "Secifies a numeric value rendered in base 16 with 1 fixed digit using lowercase letters")]
        x1 = Hex | Lower | D1,

        [Symbol("x2", "Secifies a numeric value rendered in base 16 with 2 fixed digits using lowercase letters")]
        x2 = Hex | Lower | D2,

        [Symbol("x3", "Secifies a numeric value rendered in base 16 with 3 fixed digits using lowercase letters")]
        x3 = Hex | Lower | D3,

        [Symbol("x4", "Secifies a numeric value rendered in base 16 with 4 fixed digits using lowercase letters")]
        x4 = Hex | Lower | D4,

        [Symbol("x5", "Secifies a numeric value rendered in base 16 with 5 fixed digits using lowercase letters")]
        x5 = Hex | Lower | D5,

        [Symbol("x6", "Secifies a numeric value rendered in base 16 with 6 fixed digits using lowercase letters")]
        x6 = Hex | Lower | D6,

        [Symbol("x7", "Secifies a numeric value rendered in base 16 with 7 fixed digits using lowercase letters")]
        x7 = Hex | Lower | D7,

        [Symbol("x8", "Secifies a numeric value rendered in base 16 with 8 fixed digits using lowercase letters")]
        x8 = Hex | Lower | D8,

        [Symbol("x9", "Secifies a numeric value rendered in base 16 with 9 fixed digits using lowercase letters")]
        x9 = Hex | Lower | D9,

        [Symbol("x10", "Secifies a numeric value rendered in base 16 with 10 fixed digits using lowercase letters")]
        x10 = Hex | Lower | D10,

        [Symbol("x11", "Secifies a numeric value rendered in base 16 with 11 fixed digits using lowercase letters")]
        x11 = Hex | Lower | D11,

        [Symbol("x12", "Secifies a numeric value rendered in base 16 with 12 fixed digits using lowercase letters")]
        x12 = Hex | Lower | D12,

        [Symbol("x13", "Secifies a numeric value rendered in base 16 with 13 fixed digits using lowercase letters")]
        x13 = Hex | Lower | D13,

        [Symbol("x14", "Secifies a numeric value rendered in base 16 with 14 fixed digits using lowercase letters")]
        x14 = Hex | Lower | D14,

        [Symbol("x15", "Secifies a numeric value rendered in base 16 with 15 fixed digits using lowercase letters")]
        x15 = Hex | Lower | D15,

        [Symbol("x16", "Secifies a numeric value rendered in base 16 with 16 fixed digits using lowercase letters")]
        x16 = Hex |  Lower | D2,

        [Symbol("x1s", "Secifies a numeric value rendered in base 16 with 1 fixed digit using lowercase letters preceded by a '0x' specifier")]
        x1s = Hex | Lower | Spec | D1,

        [Symbol("x2s", "Secifies a numeric value rendered in base 16 with 2 fixed digits using lowercase letters preceded by a '0x' specifier")]
        x2s = Hex | Lower | Spec | D2,

        [Symbol("x3s", "Secifies a numeric value rendered in base 16 with 3 fixed digits using lowercase letters preceded by a '0x' specifier")]
        x3s = Hex | Lower | Spec | D3,

        [Symbol("x4s", "Secifies a numeric value rendered in base 16 with 4 fixed digits using lowercase letters preceded by a '0x' specifier")]
        x4s = Hex | Lower | Spec | D4,

        [Symbol("x5s", "Secifies a numeric value rendered in base 16 with 5 fixed digits using lowercase letters preceded by a '0x' specifier")]
        x5s = Hex | Lower | Spec | D6,

        [Symbol("x6s", "Secifies a numeric value rendered in base 16 with 6 fixed digits using lowercase letters preceded by a '0x' specifier")]
        x6s = Hex | Lower | Spec | D6,

        [Symbol("x7s", "Secifies a numeric value rendered in base 16 with 7 fixed digits using lowercase letters preceded by a '0x' specifier")]
        x7s = Hex | Lower | Spec | D7,

        [Symbol("x8s", "Secifies a numeric value rendered in base 16 with 8 fixed digits using lowercase letters preceded by a '0x' specifier")]
        x8s = Hex | Lower | Spec | D8,

        [Symbol("x9s", "Secifies a numeric value rendered in base 16 with 9 fixed digits using lowercase letters preceded by a '0x' specifier")]
        x9s = Hex | Lower | Spec | D9,

        [Symbol("x10s", "Secifies a numeric value rendered in base 16 with 10 fixed digits using lowercase letters preceded by a '0x' specifier")]
        x10s = Hex | Lower | Spec | D10,

        [Symbol("x11s", "Secifies a numeric value rendered in base 16 with 11 fixed digits using lowercase letters preceded by a '0x' specifier")]
        x11s = Hex | Lower | Spec | D11,

        [Symbol("x12s", "Secifies a numeric value rendered in base 16 with 12 fixed digits using lowercase letters preceded by a '0x' specifier")]
        x12s = Hex | Lower | Spec | D12,

        [Symbol("x13s", "Secifies a numeric value rendered in base 16 with 13 fixed digits using lowercase letters preceded by a '0x' specifier")]
        x13s = Hex | Lower | Spec | D13,

        [Symbol("x14s", "Secifies a numeric value rendered in base 16 with 14 fixed digits using lowercase letters preceded by a '0x' specifier")]
        x14s = Hex | Lower | Spec | D14,

        [Symbol("x15s", "Secifies a numeric value rendered in base 16 with 15 fixed digits using lowercase letters preceded by a '0x' specifier")]
        x15s = Hex | Lower | Spec | D15,

        [Symbol("x16s", "Secifies a numeric value rendered in base 16 with 16 fixed digits using lowercase letters preceded by a '0x' specifier")]
        x16s = Hex | Lower | Spec | D16,

        [Symbol("X1", "Secifies a numeric value rendered in base 16 with 1 fixed digit using lowercase letters")]
        X1 = Hex | Upper | D1,

        [Symbol("X2", "Secifies a numeric value rendered in base 16 with 2 fixed digits using lowercase letters")]
        X2 = Hex | Upper | D2,

        [Symbol("X3", "Secifies a numeric value rendered in base 16 with 3 fixed digits using lowercase letters")]
        X3 = Hex | Upper | D3,

        [Symbol("X4", "Secifies a numeric value rendered in base 16 with 4 fixed digits using lowercase letters")]
        X4 = Hex | Upper | D4,

        [Symbol("X5", "Secifies a numeric value rendered in base 16 with 5 fixed digits using lowercase letters")]
        X5 = Hex | Upper | D5,

        [Symbol("X6", "Secifies a numeric value rendered in base 16 with 6 fixed digits using lowercase letters")]
        X6 = Hex | Upper | D6,

        [Symbol("X7", "Secifies a numeric value rendered in base 16 with 7 fixed digits using lowercase letters")]
        X7 = Hex | Upper | D7,

        [Symbol("X8", "Secifies a numeric value rendered in base 16 with 8 fixed digits using lowercase letters")]
        X8 = Hex | Upper | D8,

        [Symbol("X9", "Secifies a numeric value rendered in base 16 with 9 fixed digits using lowercase letters")]
        X9 = Hex | Upper | D9,

        [Symbol("X10", "Secifies a numeric value rendered in base 16 with 10 fixed digits using lowercase letters")]
        X10 = Hex | Upper | D10,

        [Symbol("X11", "Secifies a numeric value rendered in base 16 with 11 fixed digits using lowercase letters")]
        X11 = Hex | Upper | D11,

        [Symbol("X12", "Secifies a numeric value rendered in base 16 with 12 fixed digits using lowercase letters")]
        X12 = Hex | Upper | D12,

        [Symbol("X13", "Secifies a numeric value rendered in base 16 with 13 fixed digits using lowercase letters")]
        X13 = Hex | Upper | D13,

        [Symbol("X14", "Secifies a numeric value rendered in base 16 with 14 fixed digits using lowercase letters")]
        X14 = Hex | Upper | D14,

        [Symbol("X15", "Secifies a numeric value rendered in base 16 with 15 fixed digits using lowercase letters")]
        X15 = Hex | Upper | D15,

        [Symbol("X16", "Secifies a numeric value rendered in base 16 with 16 fixed digits using lowercase letters")]
        X16 = Hex | Upper | D16,

        [Symbol("X1s", "Secifies a numeric value rendered in base 16 with 1 fixed digit using lowercase letters preceded by a '0x' specifier")]
        X1s = Hex | Upper | Spec | D1,

        [Symbol("X2s", "Secifies a numeric value rendered in base 16 with 2 fixed digits using lowercase letters preceded by a '0x' specifier")]
        X2s = Hex | Upper | Spec | D2,

        [Symbol("X3s", "Secifies a numeric value rendered in base 16 with 3 fixed digits using lowercase letters preceded by a '0x' specifier")]
        X3s = Hex | Upper | Spec | D3,

        [Symbol("X4s", "Secifies a numeric value rendered in base 16 with 4 fixed digits using lowercase letters preceded by a '0x' specifier")]
        X4s = Hex | Upper | Spec | D4,

        [Symbol("X5s", "Secifies a numeric value rendered in base 16 with 5 fixed digits using lowercase letters preceded by a '0x' specifier")]
        X5s = Hex | Upper | Spec | D5,

        [Symbol("X6s", "Secifies a numeric value rendered in base 16 with 6 fixed digits using lowercase letters preceded by a '0x' specifier")]
        X6s = Hex | Upper | Spec | D6,

        [Symbol("X7s", "Secifies a numeric value rendered in base 16 with 7 fixed digits using lowercase letters preceded by a '0x' specifier")]
        X7s = Hex | Upper | Spec | D7,

        [Symbol("X8s", "Secifies a numeric value rendered in base 16 with 8 fixed digits using lowercase letters preceded by a '0x' specifier")]
        X8s = Hex | Upper | Spec | D8,

        [Symbol("X9s", "Secifies a numeric value rendered in base 16 with 9 fixed digits using lowercase letters preceded by a '0x' specifier")]
        X9s = Hex | Upper | Spec | D9,

        [Symbol("X10s", "Secifies a numeric value rendered in base 16 with 10 fixed digits using lowercase letters preceded by a '0x' specifier")]
        X10s = Hex | Upper | Spec | D10,

        [Symbol("X11s", "Secifies a numeric value rendered in base 16 with 11 fixed digits using lowercase letters preceded by a '0x' specifier")]
        X11s = Hex | Upper | Spec | D11,

        [Symbol("X12s", "Secifies a numeric value rendered in base 16 with 12 fixed digits using lowercase letters preceded by a '0x' specifier")]
        X12s = Hex | Upper | Spec | D12,

        [Symbol("X13s", "Secifies a numeric value rendered in base 16 with 13 fixed digits using lowercase letters preceded by a '0x' specifier")]
        X13s = Hex | Upper | Spec | D13,

        [Symbol("X14s", "Secifies a numeric value rendered in base 16 with 14 fixed digits using lowercase letters preceded by a '0x' specifier")]
        X14s = Hex | Upper | Spec | D14,

        [Symbol("X15s", "Secifies a numeric value rendered in base 16 with 15 fixed digits using lowercase letters preceded by a '0x' specifier")]
        X15s = Hex | Upper | Spec | D15,

        [Symbol("X16s", "Secifies a numeric value rendered in base 16 with 16 fixed digits using lowercase letters preceded by a '0x' specifier")]
        X16s = Hex | Upper | Spec | D16,


        D1 = 1 << 16,

        D2 = 2 << 16,

        D3 = 3 << 16,

        D4 = 4 << 16,

        D5 = 5 << 16,

        D6 = 6 << 16,

        D7 = 7 << 16,

        D8 = 8 << 16,

        D9 = 9 << 16,

        D10 = 10 << 16,

        D11 = 11 << 16,

        D12 = 12 << 16,

        D13 = 13 << 16,

        D14 = 14 << 16,

        D15 = 15 << 16,

        D16 = 16 << 16,

    }
 }