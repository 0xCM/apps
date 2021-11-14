//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Runtime.Intrinsics;

    using static core;

    public sealed class t_classify : t_inx<t_classify>
    {
        static string FormatList(IEnumerable<NumericKind> src, char? sep = null)
            => src.Select(k => k.ToString()).Join(sep ?? Chars.Comma);

        static string FormatList(IEnumerable<Type> src, char? sep = null)
            => src.Select(k => k.DisplayName()).Join(sep ?? Chars.Comma);

        public void classify_numeric()
        {
            var fkExpect = hashset(NumericKind.F32, NumericKind.F64);
            var fkActual = NumericKind.Floats.DistinctKinds();
            Claim.seteq(fkExpect,fkActual);

            var ftExpect = hashset(typeof(float), typeof(double));
            var ftActual = NumericKind.Floats.DistinctTypes();
            Claim.seteq(ftExpect,ftActual);

            var ukExpect = hashset(NumericKind.U8, NumericKind.U16, NumericKind.U32, NumericKind.U64);
            var ukActual = NumericKind.UnsignedInts.DistinctKinds();
            Claim.seteq(ukExpect,ukActual);

            var utExpect = hashset(typeof(byte), typeof(ushort), typeof(uint), typeof(ulong));
            var utActual = NumericKind.UnsignedInts.DistinctTypes();
            Claim.seteq(utExpect,utActual);

            var skExpect = hashset(NumericKind.I8, NumericKind.I16, NumericKind.I32, NumericKind.I64);
            var skActual = NumericKind.SignedInts.DistinctKinds();
            Claim.seteq(skExpect,skActual);

            var stExpect = hashset(typeof(sbyte), typeof(short), typeof(int), typeof(long));
            var stActual = NumericKind.SignedInts.DistinctTypes();
            Claim.seteq(stExpect,stActual);
        }

        public void classify_numeric_width()
        {
            Claim.eq(NativeTypeWidth.W8, NumericKind.U8.TypeWidth());
            Claim.eq(NativeTypeWidth.W8, NumericKind.I8.TypeWidth());
            Claim.eq(NativeTypeWidth.W16, NumericKind.U16.TypeWidth());
            Claim.eq(NativeTypeWidth.W16, NumericKind.I16.TypeWidth());
            Claim.eq(NativeTypeWidth.W32, NumericKind.U32.TypeWidth());
            Claim.eq(NativeTypeWidth.W32, NumericKind.I32.TypeWidth());
            Claim.eq(NativeTypeWidth.W32, NumericKind.F32.TypeWidth());
            Claim.eq(NativeTypeWidth.W64, NumericKind.I64.TypeWidth());
            Claim.eq(NativeTypeWidth.W64, NumericKind.U64.TypeWidth());
            Claim.eq(NativeTypeWidth.W64, NumericKind.F64.TypeWidth());
        }

        public void check_numeric_identity()
        {
            Claim.eq(ScalarKind.U8, NumericKind.U8.ApiKind());
            Claim.eq(ScalarKind.I8, NumericKind.I8.ApiKind());
            Claim.eq(ScalarKind.U16, NumericKind.U16.ApiKind());
            Claim.eq(ScalarKind.I16, NumericKind.I16.ApiKind());
            Claim.eq(ScalarKind.U32, NumericKind.U32.ApiKind());
            Claim.eq(ScalarKind.I32, NumericKind.I32.ApiKind());
            Claim.eq(ScalarKind.U64, NumericKind.U64.ApiKind());
            Claim.eq(ScalarKind.I64, NumericKind.I64.ApiKind());
            Claim.eq(ScalarKind.F32, NumericKind.F32.ApiKind());
            Claim.eq(ScalarKind.F64, NumericKind.F64.ApiKind());
        }

        public void classify_block_segment_16()
        {
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock16<byte>)), NumericKind.U8);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock16<sbyte>)), NumericKind.I8);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock16<ushort>)), NumericKind.U16);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock16<short>)), NumericKind.I16);
        }

        public void classify_block_segment_64()
        {
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock64<byte>)), NumericKind.U8);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock64<sbyte>)), NumericKind.I8);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock64<ushort>)), NumericKind.U16);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock64<short>)), NumericKind.I16);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock64<uint>)), NumericKind.U32);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock64<int>)), NumericKind.I32);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock64<ulong>)), NumericKind.U64);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock64<long>)), NumericKind.I64);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock64<float>)), NumericKind.F32);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock64<double>)), NumericKind.F64);
        }

        public void classify_block_segment_128()
        {
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock128<byte>)), NumericKind.U8);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock128<sbyte>)), NumericKind.I8);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock128<ushort>)), NumericKind.U16);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock128<short>)), NumericKind.I16);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock128<uint>)), NumericKind.U32);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock128<int>)), NumericKind.I32);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock128<ulong>)), NumericKind.U64);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock128<long>)), NumericKind.I64);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock128<float>)), NumericKind.F32);
            Claim.eq(NativeSegKinds.segment(typeof(SpanBlock128<double>)), NumericKind.F64);
        }

        public void classify_block_width()
        {
            Claim.eq(NativeTypeWidth.W16, NativeSegKinds.width(typeof(SpanBlock16<byte>)));
            Claim.eq(NativeTypeWidth.W32, NativeSegKinds.width(typeof(SpanBlock32<byte>)));
            Claim.eq(NativeTypeWidth.W64, NativeSegKinds.width(typeof(SpanBlock64<byte>)));
            Claim.eq(NativeTypeWidth.W128, NativeSegKinds.width(typeof(SpanBlock128<byte>)));
            Claim.eq(NativeTypeWidth.W256, NativeSegKinds.width(typeof(SpanBlock256<byte>)));
            Claim.eq(NativeTypeWidth.W512, NativeSegKinds.width(typeof(SpanBlock512<byte>)));

            Claim.eq(NativeTypeWidth.W16, NativeSegKinds.width(typeof(SpanBlock16<>)));
            Claim.eq(NativeTypeWidth.W32, NativeSegKinds.width(typeof(SpanBlock32<>)));
            Claim.eq(NativeTypeWidth.W64, NativeSegKinds.width(typeof(SpanBlock64<>)));
            Claim.eq(NativeTypeWidth.W128, NativeSegKinds.width(typeof(SpanBlock128<>)));
            Claim.eq(NativeTypeWidth.W256, NativeSegKinds.width(typeof(SpanBlock256<>)));
            Claim.eq(NativeTypeWidth.W512, NativeSegKinds.width(typeof(SpanBlock512<>)));
        }

        static bool blocked(Type t)
            => t.IsSegmented();

        public void test_generic_blocks()
        {
            Claim.require(blocked(typeof(SpanBlock16<>)));
            Claim.require(blocked(typeof(SpanBlock32<>)));
            Claim.require(blocked(typeof(SpanBlock64<>)));
            Claim.require(blocked(typeof(SpanBlock128<>)));
            Claim.require(blocked(typeof(SpanBlock256<>)));
            Claim.require(blocked(typeof(SpanBlock512<>)));
        }

        public void test_block_16()
        {
            Claim.require(blocked(typeof(SpanBlock16<byte>)));
            Claim.require(blocked(typeof(SpanBlock16<sbyte>)));
            Claim.require(blocked(typeof(SpanBlock16<ushort>)));
            Claim.require(blocked(typeof(SpanBlock16<short>)));
        }

        public void test_block_32()
        {
            Claim.require(blocked(typeof(SpanBlock32<byte>)));
            Claim.require(blocked(typeof(SpanBlock32<sbyte>)));
            Claim.require(blocked(typeof(SpanBlock32<ushort>)));
            Claim.require(blocked(typeof(SpanBlock32<short>)));
            Claim.require(blocked(typeof(SpanBlock32<int>)));
            Claim.require(blocked(typeof(SpanBlock32<uint>)));
            Claim.require(blocked(typeof(SpanBlock32<float>)));
        }

        public void test_block_64()
        {
            Claim.require(blocked(typeof(SpanBlock64<byte>)));
            Claim.require(blocked(typeof(SpanBlock64<sbyte>)));
            Claim.require(blocked(typeof(SpanBlock64<ushort>)));
            Claim.require(blocked(typeof(SpanBlock64<short>)));
            Claim.require(blocked(typeof(SpanBlock64<int>)));
            Claim.require(blocked(typeof(SpanBlock64<uint>)));
            Claim.require(blocked(typeof(SpanBlock64<long>)));
            Claim.require(blocked(typeof(SpanBlock64<ulong>)));
            Claim.require(blocked(typeof(SpanBlock64<float>)));
            Claim.require(blocked(typeof(SpanBlock64<double>)));
        }

        public void test_block_128()
        {
            Claim.require(blocked(typeof(SpanBlock128<byte>)));
            Claim.require(blocked(typeof(SpanBlock128<sbyte>)));
            Claim.require(blocked(typeof(SpanBlock128<ushort>)));
            Claim.require(blocked(typeof(SpanBlock128<short>)));
            Claim.require(blocked(typeof(SpanBlock128<int>)));
            Claim.require(blocked(typeof(SpanBlock128<uint>)));
            Claim.require(blocked(typeof(SpanBlock128<long>)));
            Claim.require(blocked(typeof(SpanBlock128<ulong>)));
            Claim.require(blocked(typeof(SpanBlock128<float>)));
            Claim.require(blocked(typeof(SpanBlock128<double>)));
        }

        public void classify_block_16()
        {
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock16<byte>)), NativeSegKind.Seg16x8u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock16<sbyte>)), NativeSegKind.Seg16x8i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock16<ushort>)), NativeSegKind.Seg16x16u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock16<short>)), NativeSegKind.Seg16x16i);
        }

        void classify_block_32()
        {
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock32<byte>)), NativeSegKind.Seg32x8u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock32<sbyte>)), NativeSegKind.Seg32x8i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock32<ushort>)), NativeSegKind.Seg32x16u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock32<short>)), NativeSegKind.Seg32x16i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock32<uint>)), NativeSegKind.Seg32x32u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock32<int>)), NativeSegKind.Seg32x32i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock32<float>)), NativeSegKind.Seg32x32f);
        }

        void classify_block_64()
        {
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock64<byte>)), NativeSegKind.Seg64x8u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock64<sbyte>)), NativeSegKind.Seg64x8i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock64<ushort>)), NativeSegKind.Seg64x16u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock64<short>)), NativeSegKind.Seg64x16i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock64<uint>)), NativeSegKind.Seg64x32u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock64<int>)), NativeSegKind.Seg64x32i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock64<ulong>)), NativeSegKind.Seg64x64u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock64<long>)), NativeSegKind.Seg64x64i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock64<float>)), NativeSegKind.Seg64x32f);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock64<double>)), NativeSegKind.Seg64x64f);
        }

        void classify_block_128()
        {
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock128<byte>)), NativeSegKind.Seg128x8u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock128<sbyte>)), NativeSegKind.Seg128x8i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock128<ushort>)), NativeSegKind.Seg128x16u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock128<short>)), NativeSegKind.Seg128x16i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock128<uint>)), NativeSegKind.Seg128x32u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock128<int>)), NativeSegKind.Seg128x32i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock128<ulong>)), NativeSegKind.Seg128x64u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock128<long>)), NativeSegKind.Seg128x64i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock128<float>)), NativeSegKind.Seg128x32f);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock128<double>)), NativeSegKind.Seg128x64f);

        }

        void classify_block_256()
        {
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock256<byte>)), NativeSegKind.Seg256x8u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock256<sbyte>)), NativeSegKind.Seg256x8i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock256<ushort>)), NativeSegKind.Seg256x16u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock256<short>)), NativeSegKind.Seg256x16i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock256<uint>)), NativeSegKind.Seg256x32u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock256<int>)), NativeSegKind.Seg256x32i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock256<ulong>)), NativeSegKind.Seg256x64u);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock256<long>)), NativeSegKind.Seg256x64i);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock256<float>)), NativeSegKind.Seg256x32f);
            Claim.eq(NativeSegKinds.kind(typeof(SpanBlock256<double>)), NativeSegKind.Seg256x64f);
        }

        public void classify_vector()
        {
            Claim.eq(VK.kind(typeof(Vector128<byte>)), NativeVectorKind.v128x8u);
            Claim.eq(VK.kind(typeof(Vector128<sbyte>)), NativeVectorKind.v128x8i);
            Claim.eq(VK.kind(typeof(Vector128<ushort>)), NativeVectorKind.v128x16u);
            Claim.eq(VK.kind(typeof(Vector128<short>)), NativeVectorKind.v128x16i);
            Claim.eq(VK.kind(typeof(Vector128<uint>)), NativeVectorKind.v128x32u);
            Claim.eq(VK.kind(typeof(Vector128<int>)), NativeVectorKind.v128x32i);
            Claim.eq(VK.kind(typeof(Vector128<ulong>)), NativeVectorKind.v128x64u);
            Claim.eq(VK.kind(typeof(Vector128<long>)), NativeVectorKind.v128x64i);
            Claim.eq(VK.kind(typeof(Vector128<float>)), NativeVectorKind.v128x32f);
            Claim.eq(VK.kind(typeof(Vector128<double>)), NativeVectorKind.v128x64f);

            Claim.eq(VK.kind(typeof(Vector256<byte>)), NativeVectorKind.v256x8u);
            Claim.eq(VK.kind(typeof(Vector256<sbyte>)), NativeVectorKind.v256x8i);
            Claim.eq(VK.kind(typeof(Vector256<ushort>)), NativeVectorKind.v256x16u);
            Claim.eq(VK.kind(typeof(Vector256<short>)), NativeVectorKind.v256x16i);
            Claim.eq(VK.kind(typeof(Vector256<uint>)), NativeVectorKind.v256x32u);
            Claim.eq(VK.kind(typeof(Vector256<int>)), NativeVectorKind.v256x32i);
            Claim.eq(VK.kind(typeof(Vector256<ulong>)), NativeVectorKind.v256x64u);
            Claim.eq(VK.kind(typeof(Vector256<long>)), NativeVectorKind.v256x64i);
            Claim.eq(VK.kind(typeof(Vector256<float>)), NativeVectorKind.v256x32f);
            Claim.eq(VK.kind(typeof(Vector256<double>)), NativeVectorKind.v256x64f);
        }

        public void classify_vector_type()
        {
            Claim.eq(VK.kind(typeof(Vector128<sbyte>)), NativeVectorKind.v128x8i);
            Claim.eq(VK.kind(typeof(Vector128<byte>)), NativeVectorKind.v128x8u);

            Claim.eq(VK.kind(typeof(Vector128<short>)), NativeVectorKind.v128x16i);
            Claim.eq(VK.kind(typeof(Vector128<ushort>)), NativeVectorKind.v128x16u);

            Claim.eq(VK.kind(typeof(Vector128<int>)), NativeVectorKind.v128x32i);
            Claim.eq(VK.kind(typeof(Vector128<uint>)), NativeVectorKind.v128x32u);
            Claim.eq(VK.kind(typeof(Vector128<float>)), NativeVectorKind.v128x32f);

            Claim.eq(VK.kind(typeof(Vector128<ulong>)), NativeVectorKind.v128x64u);
            Claim.eq(VK.kind(typeof(Vector128<long>)), NativeVectorKind.v128x64i);
            Claim.eq(VK.kind(typeof(Vector128<double>)), NativeVectorKind.v128x64f);

            Claim.eq(VK.kind(typeof(Vector256<sbyte>)), NativeVectorKind.v256x8i);
            Claim.eq(VK.kind(typeof(Vector256<byte>)), NativeVectorKind.v256x8u);

            Claim.eq(VK.kind(typeof(Vector256<short>)), NativeVectorKind.v256x16i);
            Claim.eq(VK.kind(typeof(Vector256<ushort>)), NativeVectorKind.v256x16u);

            Claim.eq(VK.kind(typeof(Vector256<int>)), NativeVectorKind.v256x32i);
            Claim.eq(VK.kind(typeof(Vector256<uint>)), NativeVectorKind.v256x32u);
            Claim.eq(VK.kind(typeof(Vector256<float>)), NativeVectorKind.v256x32f);

            Claim.eq(VK.kind(typeof(Vector256<ulong>)), NativeVectorKind.v256x64u);
            Claim.eq(VK.kind(typeof(Vector256<long>)), NativeVectorKind.v256x64i);
            Claim.eq(VK.kind(typeof(Vector256<double>)), NativeVectorKind.v256x64f);
        }
    }
}