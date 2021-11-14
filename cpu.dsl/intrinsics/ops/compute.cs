//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    using K = IntrinsicKind;

    partial struct Intrinsics
    {
        partial class Checks
        {
            void Compute(IntrinsicKind kind)
            {
                switch(kind)
                {
                    case K._mm256_cvtepi16_epi8:
                    break;

                    case K.mm256_min_epu8:
                    {
                        var block0 = Cells<byte>(n0);
                        Random.Fill(block0);
                        var block1 = Cells<byte>(n1);
                        Random.Fill(block1);
                        var left = recover<m256i<byte>>(block0);
                        var right = recover<m256i<byte>>(block1);
                        var count = left.Length;
                        for(var i=0; i<count; i++)
                        {
                            var input = new mm256_min_epu8(skip(left,i), skip(right,i));
                            var output = Specs.calc(input);
                            var expr = string.Format("{0}(\r\n  {1}, \r\n  {2}) -> \r\n  {3}", input.Kind, input.A, input.B, output);
                            Write(expr);
                        }
                    }
                    break;

                    case K.mm_packus_epi16:
                    {
                        var block0 = Cells<short>(n0);
                        Random.Fill(block0);
                        var block1 = Cells<short>(n1);
                        Random.Fill(block1);
                        var left = recover<m128i<short>>(block0);
                        var right = recover<m128i<short>>(block1);
                        var count = left.Length;
                        for(var i=0; i<count; i++)
                        {
                            var input = new mm_packus_epi16(skip(left,i), skip(right,i));
                            var output = Specs.calc(input);
                            var expr = string.Format("{0}(\r\n  {1}, \r\n  {2}) -> \r\n  {3}", input.Kind, input.A, input.B, output);
                            var y = eq(vpack.vpackus(input.A, input.B), output).Format();
                            Write(y);
                        }
                    }
                    break;

                    case K.mm_min_epi8:
                    {
                        var block0 = Cells<sbyte>(n0);
                        Random.Fill(block0);
                        var block1 = Cells<sbyte>(n1);
                        Random.Fill(block1);
                        var left = recover<m128i<sbyte>>(block0);
                        var right = recover<m128i<sbyte>>(block1);
                        var count = left.Length;
                        for(var i=0; i<count; i++)
                        {
                            var input = new mm_min_epi8(skip(left,i), skip(right,i));
                            var output = Specs.calc(input);
                            var expr = string.Format("{0}(\r\n  {1}, \r\n  {2}) -> \r\n  {3}", input.Kind, input.A, input.B, output);
                            Write(expr);
                        }
                    }
                    break;

                    default:
                    break;
                }
            }
        }
    }
}