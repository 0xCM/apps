//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
        /// Designates a bitvector type
        /// </summary>
        public static Label BV => "bv";

        /// <summary>
        /// Designates a component bitvector type
        /// </summary>
        public static Label V => "v";

        /// <summary>
        /// Designates a type of content width 1
        /// </summary>
        public static Label Bit => "bit";

        public static Label U0 => "u0";

        /// <summary>
        /// Designates an type of content width 1
        /// </summary>
        public static Label U1 => "u1";

        /// <summary>
        /// Designates an unsigned integral type of content width 2
        /// </summary>
        public static Label U2 => "u2";

        /// <summary>
        /// Designates an unsigned integral type of content width 3
        /// </summary>
        public static Label U3 => "u3";

        /// <summary>
        /// Designates an unsigned integral type of content width 4
        /// </summary>
        public static Label U4 => "u4";

        /// <summary>
        /// Designates an unsigned integral type of content width 5
        /// </summary>
        public static Label U5 => "u5";

        /// <summary>
        /// Designates an unsigned integral type of content width 6
        /// </summary>
        public static Label U6 => "u6";

        /// <summary>
        /// Designates an unsigned integral type of content width 7
        /// </summary>
        public static Label U7 => "u7";

        /// <summary>
        /// Designates an unsigned integral type of content width 8
        /// </summary>
        public static Label U8 => "u8";

        /// <summary>
        /// Designates an unsigned integral type of content width 16
        /// </summary>
        public static Label U16 => "u16";

        /// <summary>
        /// Designates an unsigned integral type of content width 32
        /// </summary>
        public static Label U32 => "u32";

        /// <summary>
        /// Designates an unsigned integral type of content width 64
        /// </summary>
        public static Label U64 => "u64";

        /// <summary>
        /// Designates an unsigned integral type of content width 128
        /// </summary>
        public static Label U128 => "u128";

        public static Label U256 => "u256";

        public static Label U512 => "u512";

        public static string Un(uint n) => string.Format("u{0}",n);

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

        public static string In(uint n) => string.Format("i{0}",n);

        public static string Seq(IType type) => string.Format("seq<{0}>", type);

        public static string Seq(IType type, uint n) => string.Format("seq<{0}:{1}>", type, n);

        public static Label C8 => "c8";

        public static Label C16 => "c16";

        public static Label C32 => "c32";

        public static Label F16 => "f16";

        public static Label F32 => "f32";

        public static Label F64 => "f64";

        public static Label BV1 => "bv1";

        public static Label BV2 => "bv2";

        public static Label BV3 => "bv3";

        public static Label BV4 => "bv4";

        public static Label BV5 => "bv5";

        public static Label BV6 => "bv6";

        public static Label BV7 => "bv7";

        public static Label BV8 => "bv8";

        public static Label BV16 => "bv16";

        public static Label BV32 => "bv32";

        public static Label BV64 => "bv64";

        public static Label BV128 => "bv128";

        public static Label BV256 => "bv256";

        public static Label BV512 => "bv512";

        /// <summary>
        /// Defines a bitvector type of content width n
        /// </summary>
        /// <param name="n">The bitvector width</param>
        public static string BVn(uint n) => string.Format("bv{0}", n);

        /// <summary>
        /// Defines a 1-component vector type over a specified cell type
        /// </summary>
        /// <param name="cells">The cell type</param>
        public static string V1(IScalarType cells) => string.Format("v1<{0}>", cells);

        /// <summary>
        /// Defines a 2-component vector type over a specified cell type
        /// </summary>
        /// <param name="cells">The cell type</param>
        public static string V2(IScalarType cells) => string.Format("v2<{0}>", cells);

        /// <summary>
        /// Defines a 3-component vector type over a specified cell type
        /// </summary>
        /// <param name="cells">The cell type</param>
        public static string V3(IScalarType cells) => string.Format("v3<{0}>", cells);

        /// <summary>
        /// Defines a 4-component vector type over a specified cell type
        /// </summary>
        /// <param name="cells">The cell type</param>
        public static string V4(IScalarType cells) => string.Format("v4<{0}>", cells);

        /// <summary>
        /// Defines a 5-component vector type over a specified cell type
        /// </summary>
        /// <param name="cells">The cell type</param>
        public static string V5(IScalarType cells) => string.Format("v5<{0}>", cells);

        /// <summary>
        /// Defines a 6-component vector type over a specified cell type
        /// </summary>
        /// <param name="cells">The cell type</param>
        public static string V6(IScalarType cells) => string.Format("v6<{0}>", cells);

        /// <summary>
        /// Defines a 7-component vector type over a specified cell type
        /// </summary>
        /// <param name="cells">The cell type</param>
        public static string V7(IScalarType cells) => string.Format("v7<{0}>", cells);

        /// <summary>
        /// Defines an 8-component vector type over a specified cell type
        /// </summary>
        /// <param name="cells">The cell type</param>
        public static string V8(IScalarType cells) => string.Format("v8<{0}>", cells);

        /// <summary>
        /// Defines a 9-component vector type over a specified cell type
        /// </summary>
        /// <param name="cells">The cell type</param>
        public static string V9(IScalarType cells) => string.Format("v9<{0}>", cells);

        /// <summary>
        /// Defines a 10-component vector type over a specified cell type
        /// </summary>
        /// <param name="cells">The cell type</param>
        public static string V10(IScalarType cells) => string.Format("v10<{0}>", cells);

        public static string V11(IScalarType cells) => string.Format("v11<{0}>", cells);

        public static string V12(IScalarType cells) => string.Format("v12<{0}>", cells);

        public static string V16(IScalarType cells) => string.Format("v16<{0}>", cells);

        public static string V32(IScalarType cells) => string.Format("v32<{0}>", cells);

        public static string V64(IScalarType cells) => string.Format("v64<{0}>", cells);

        /// <summary>
        /// Defines an n-component vector over a specified cell type
        /// </summary>
        /// <param name="cells">The cell type</param>
        /// <param name="n">The number of vector components</param>
        public static string Vn(IScalarType cells, uint n) => string.Format("v{0}<{1}>", n, cells);

        public static string VNx1(IScalarType cells, uint n) => string.Format("v{0}x1<{1}>", n, cells);

        public static string VNx8(IScalarType cells, uint n) => string.Format("v{0}x8<{1}>", n, cells);

        public static string VNx16(IScalarType cells, uint n) => string.Format("v{0}x16<{1}>", n, cells);

        public static string VNx32(IScalarType cells, uint n) => string.Format("v{0}x32<{1}>", n, cells);

        public static string VNxM(IScalarType cells, uint n, uint m) => string.Format("v{0}x{1}<{2}>", n, m, cells);
    }
}