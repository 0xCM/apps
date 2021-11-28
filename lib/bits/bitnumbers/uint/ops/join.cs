//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using T = Z0;

    partial struct BitNumbers
    {
        /// <summary>
        /// Produces a <see cref='T.uint3'/> value by concatentating operand-supplied bits
        /// </summary>
        /// <param name="a">Source bit 0</param>
        /// <param name="b">Source bit 1</param>
        /// <param name="b">Source bit 2</param>
        [MethodImpl(Inline), Op]
        public static uint3 join(uint1 a, uint1 b, uint1 c)
            => wrap3((uint)a | ((uint)b << 1)  | ((uint)c << 2));

        /// <summary>
        /// Produces a <see cref='T.uint2'/> value by concatentating operand-supplied bits
        /// </summary>
        /// <param name="a">Source bit 0</param>
        /// <param name="b">Source bit 1</param>
        [MethodImpl(Inline), Op]
        public static uint2 join(uint1 a, uint1 b)
            => wrap2((uint)a | ((uint)b << 1));

        /// <summary>
        /// Produces a <see cref='T.eight'/> value by contcatenating the operand-suppled bits
        /// </summary>
        /// <param name="a">Source bit 0</param>
        /// <param name="b">Source bits 1-7</param>
        [MethodImpl(Inline), Op]
        public static eight join(uint1 a, uint7 b)
            => movzx(a, w8) | (movzx(b, w8) << 1);

        /// <summary>
        /// Produces a <see cref='T.uint4'/> value by contcatenating the operand-suppled bits
        /// </summary>
        /// <param name="a">Source bits 0-1</param>
        /// <param name="b">Source bits 2-3</param>
        [MethodImpl(Inline), Op]
        public static uint4 join(uint2 a, uint2 b)
            => movzx(a, w4) | (movzx(b, w4) << 2);

        /// <summary>
        /// (a,b) -> [bbaa]
        /// </summary>
        /// <param name="a">Source bits 0-1</param>
        /// <param name="b">Source bits 2-3</param>
        /// <param name="c">Source bits 4-5</param>
        /// <param name="d">Source bits 6-7</param>
        [MethodImpl(Inline), Op]
        public static uint6 join(uint2 a, uint2 b, uint2 c)
            => movzx(a,w6) | (movzx(b,w6) << 2) | (movzx(b,w6) << 4);

        /// <summary>
        /// (a,b,c,d) -> [dd cc bb aa]
        /// </summary>
        /// <param name="a">Source bits 0-1</param>
        /// <param name="b">Source bits 2-3</param>
        /// <param name="c">Source bits 4-5</param>
        /// <param name="d">Source bits 6-7</param>
        [MethodImpl(Inline), Op]
        public static eight join(uint2 a, uint2 b, uint2 c, uint2 d)
            => movzx(a, w8) | (movzx(b, w8) << 2) | (movzx(c, w8) << 4) | (movzx(d, w8) << 6);

        /// <summary>
        /// Produces a <see cref='eight'/> value by contcatenating the operand-suppled bits
        /// </summary>
        /// <param name="a">The lo bits</param>
        /// <param name="b">The hi bits</param>
        [MethodImpl(Inline), Op]
        public static eight join(uint2 a, uint6 b)
            => movzx(a, w8) | (movxz(b, w8) << 2);

        /// <summary>
        /// Produces a <see cref='eight'/> value by contcatenating the operand-suppled bits
        /// </summary>
        /// <param name="a">The lo bits</param>
        /// <param name="b">The hi bits</param>
        [MethodImpl(Inline), Op]
        public static eight join(uint3 a, uint6 b)
            => movzx(a, w8) | (movxz(b, w8) << 3);

        /// <summary>
        /// Produces a <see cref='eight'/> value by contcatenating the operand-suppled bits
        /// </summary>
        /// <param name="a">Source bits 0-2</param>
        /// <param name="b">Source bits 3-5</param>
        /// <param name="c">Source bits 6-7</param>
        [MethodImpl(Inline), Op]
        public static eight join(uint3 a, uint3 b, uint2 c)
            => movzx(a, w8) | (movzx(b, w8) << 3) | (movzx(c, w8) << 6);

        /// <summary>
        /// Produces a <see cref='eight'/> value by contcatenating the operand-suppled bits
        /// </summary>
        /// <param name="lo">The lo bits</param>
        /// <param name="hi">The hi bits</param>
        [MethodImpl(Inline), Op]
        public static eight join(uint4 lo, uint4 hi)
            => movzx(lo, w8) | (movzx(hi, w8) << 4);

        /// <summary>
        /// Creates a <see cref='T.uint4'/> by concatenating operand-supplied bits
        /// </summary>
        /// <param name="a">Bit 0</param>
        /// <param name="b">Bit 1</param>
        /// <param name="c">Bit 2</param>
        /// <param name="d">Bit 3</param>
        [MethodImpl(Inline), Op]
        public static uint4 join(bit a, bit b, bit c, bit d)
             => wrap4(Bytes.or(
                 Bytes.sll((byte)a, 0),
                 Bytes.sll((byte)b, 1),
                 Bytes.sll((byte)c, 2),
                 Bytes.sll((byte)d, 3)
                 ));

        /// <summary>
        /// Creates a <see cref='T.uint5'/> by concatenating operand-supplied bits
        /// </summary>
        /// <param name="a">Bit 0</param>
        /// <param name="b">Bit 1</param>
        /// <param name="c">Bit 2</param>
        /// <param name="d">Bit 3</param>
        /// <param name="e">Bit 4</param>
        [MethodImpl(Inline), Op]
        public static uint5 join(bit a, bit b, bit c, bit d, bit e)
             => wrap5(Bytes.or(
                 Bytes.sll((byte)a, 0),
                 Bytes.sll((byte)b, 1),
                 Bytes.sll((byte)c, 2),
                 Bytes.sll((byte)d, 3),
                 Bytes.sll((byte)e, 4)
                 ));

        /// <summary>
        /// Produces a <see cref='eight'/> value by contcatenating the operand-suppled bits
        /// </summary>
        /// <param name="lo">The lo bits</param>
        /// <param name="hi">The hi bits</param>
        [MethodImpl(Inline), Op]
        public static eight join(uint5 lo, uint3 hi)
            => movzx(lo, w8) | (movzx(hi, w8) << 5);

        /// <summary>
        /// Produces a <see cref='eight'/> value by contcatenating the operand-suppled bits
        /// </summary>
        /// <param name="lo">The lo bits</param>
        /// <param name="hi">The hi bits</param>
        [MethodImpl(Inline), Op]
        public static eight join(uint6 lo, uint2 hi)
            => movxz(lo, w8) | (movzx(hi, w8) << 6);

        /// <summary>
        /// Produces a <see cref='eight'/> value by contcatenating the operand-suppled bits
        /// </summary>
        /// <param name="lo">The lo bits</param>
        /// <param name="hi">The hi bits</param>
        [MethodImpl(Inline), Op]
        public static eight join(uint7 lo, uint1 hi)
            => movzx(lo, w8) | (movzx(hi,w8) << 7);
    }
}