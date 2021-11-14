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

    partial class AsmSpecs
    {
        /// <summary>
        /// Populates the target with the encoding for <see cref='AsmInstructions.Int3'/>
        /// </summary>
        /// <param name="dst">The data target</param>
        [MethodImpl(Inline), Op]
        public static byte int3(Span<byte> dst)
        {
            seek(dst,int3());
            return 1;
        }

        /// <summary>
        /// Produces the encoding for <see cref='AsmInstructions.Int3'/>
        /// </summary>
        [MethodImpl(Inline), Op]
        public static byte int3()
            => 0xCC;

        /// <summary>
        /// Tests whether the source operand is the encoding for <see cref='AsmInstructions.Int3'/>
        /// </summary>
        /// <param name="dst">The data source</param>
        [MethodImpl(Inline), Op]
        public static bit int3(byte src)
            => src == int3();
    }
}