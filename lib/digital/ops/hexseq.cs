//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Digital
    {
        /// <summary>
        /// Returns a readonly symbol span covering each <see cref='Hex2Seq'/> member
        /// </summary>
        /// <param name="n">The sequence length selector</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<SymVal<Hex2Seq,byte,N2>> hexseq(N2 n)
            => Bytes.cells<SymVal<Hex2Seq,byte,N2>>(n4);

        /// <summary>
        /// Returns a readonly symbol span covering each <see cref='Hex3Seq'/> member
        /// </summary>
        /// <param name="n">The sequence length selector</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<SymVal<Hex3Seq,byte,N3>> hexseq(N3 n)
            => Bytes.cells<SymVal<Hex3Seq,byte,N3>>(n8);

        /// <summary>
        /// Returns a readonly symbol span covering each <see cref='Hex4Seq'/> member
        /// </summary>
        /// <param name="n">The sequence length selector</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<SymVal<Hex4Seq,byte,N4>> hexseq(N4 n)
            => Bytes.cells<SymVal<Hex4Seq,byte,N4>>(n16);

        /// <summary>
        /// Creates a store covering each <see cref='Hex5Seq'/> member
        /// </summary>
        /// <param name="n">The sequence length selector</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<SymVal<Hex5Seq,byte,N5>> hexseq(N5 n)
            => Bytes.cells<SymVal<Hex5Seq,byte,N5>>(n32);
    }
}