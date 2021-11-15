//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct bit
    {
        public static void render<T>(in bits<T> src, ITextBuffer dst)
            where T : unmanaged
        {
            dst.Append(Chars.LBrace);
            var n = src.N;
            var data = @readonly(bytes(src.Packed));
            var count = data.Length;
            var k=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var b = ref skip(data,i);
                for(byte j=0; j<8 && k<n; j++, k++)
                {
                    dst.Append(bit.test(b,j).ToChar());
                    if(k < n-1)
                    {
                        dst.Append(Chars.Comma);
                        dst.Append(Chars.Space);
                    }
                }
            }

            dst.Append(Chars.RBrace);
        }

        public static uint render<T>(in bits<T> src, Span<char> dst)
            where T : unmanaged
        {
            var m=0u;
            var k=0;
            var n = src.N;
            seek(dst,m++) = Chars.LBrace;
            var data = @readonly(bytes(src.Packed));
            for(var i=0; i<data.Length; i++)
            {
                ref readonly var b = ref skip(data,i);
                for(byte j=0; j<8 && k<n; j++, k++)
                {
                    seek(dst, m++) = bit.test(b, j);
                    if(k < n-1)
                    {
                        seek(dst, m++) = Chars.Comma;
                        seek(dst, m++) = Chars.Space;
                    }
                }
            }

            seek(dst,m++) = Chars.RBrace;
            return m;
        }

        public static string format<T>(in bits<T> src)
            where T : unmanaged
        {
            var dst = text.buffer();
            render(src,dst);
            return dst.Emit();
        }
    }
}