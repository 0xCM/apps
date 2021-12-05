//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiComplete]
    public readonly struct CanonicalType
    {
        public static Label None => nameof(None);

        /// <summary>
        /// Designates an unsigned integral type
        /// </summary>
        public static Label U => "u";

        /// <summary>
        /// Designates a signed integral type
        /// </summary>
        public static Label I => "i";

        /// <summary>
        /// Designates a character type
        /// </summary>
        public static Label C => "c";

        /// <summary>
        /// Designates a floating-point type
        /// </summary>
        public static Label F => "f";

        /// <summary>
        /// Designates a type of content width 1
        /// </summary>
        public static Label Bit => "bit";

        public static Label U0 => "u0";

        public static Label U1 => "u1";

        public static Label U2 => "u2";

        public static Label U3 => "u3";

        public static Label U4 => "u4";

        public static Label U5 => "u5";

        public static Label U6 => "u6";

        public static Label U7 => "u7";

        public static Label U8 => "u8";

        public static Label U16 => "u16";

        public static Label U32 => "u32";

        public static Label U64 => "u64";

        public static Label U128 => "u128";

        public static Label U256 => "u256";

        public static Label U512 => "u512";

        public static text15 UN(uint n) => string.Format("u{0}",n);

        public static Label I0 => "i0";

        public static Label I1 => "i1";

        public static Label I2 => "i2";

        public static Label I3 => "i3";

        public static Label I4 => "i4";

        public static Label I5 => "i5";

        public static Label I6 => "i6";

        public static Label I7 => "i7";

        public static Label I8 => "i8";

        public static Label I16 => "i16";

        public static Label I32 => "i32";

        public static Label I64 => "i64";

        public static Label I128 => "i128";

        public static Label I256 => "i256";

        public static Label I512 => "i512";

        public static text15 IN(uint n) => string.Format("i{0}",n);

        public static text15 Seq(string type) => string.Format("seq<{0}>", type);

        public static text15 Seq(string type, uint n) => string.Format("seq<{0}:{1}>", type, n);

        public static Label C8 => "c8";

        public static Label C16 => "c16";

        public static Label C32 => "c32";

        public static Label F16 => "f16";

        public static Label F32 => "f32";

        public static Label F64 => "f64";


        // V0 => nameof(None);

        // V1 => nameof(None);

        // V2 => nameof(None);

        // V3 => nameof(None);

        // V4 => nameof(None);

        // V5 => nameof(None);

        // V6 => nameof(None);

        // V7 => nameof(None);

        // V8 => nameof(None);

        // V9 => nameof(None);

        // V10 => nameof(None);

        // V11 => nameof(None);

        // V12 => nameof(None);

        // V16 => nameof(None);

        // V32 => nameof(None);

        // V64 => nameof(None);

        // VN => nameof(None);

        // VNx1 => nameof(None);

        // VNx8 => nameof(None);

        // VNx16 => nameof(None);

        // VNx32 => nameof(None);

        // VNx64 => nameof(None);

        // VNx128 => nameof(None);

        // VNx256 => nameof(None);
    }
}