//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static PrimalBits;

    partial struct Clr
    {
        /// <summary>
        /// Determines the numeric sign, if any, of the represented primitive
        /// </summary>
        /// <param name="f">The literal's bitfield</param>
        [MethodImpl(Inline), Op]
        public static PolarityKind sign(PrimalKind f)
            => (PolarityKind)PrimalBits.select(f, Field.Sign);
    }
}