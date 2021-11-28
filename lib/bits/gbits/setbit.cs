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

    partial class gbits
    {
        [MethodImpl(Inline)]
        public static T setbit<T,I>(T src, I index, bit state)
            where T : unmanaged
            where I : unmanaged
                => setbit<T>(src, u8(index), state);

        /// <summary>
        /// Sets an identified bit to a supplied value
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="pos">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit, Closures(AllNumeric)]
        public static T setbit<T>(T src, byte pos, bit state)
            where T : unmanaged
                => state ? enable(src, pos) : disable(src, pos);

        /// <summary>
        /// Calculates z := (src & ~(1 << pos)) | (value << pos) with the intent of enabling/disabling a bit without branching
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        /// <remarks>See https://stackoverflow.com/questions/17803889/set-or-reset-a-given-bit-without-branching</remarks>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T setnb<T>(T src, byte pos, bit state)
            where T : unmanaged
        {
            var x = gmath.negate(gmath.sll(one<T>(), pos));
            var y = Numeric.force<uint,T>((uint)state << pos);
            var z = gmath.and(src, x);
            return gmath.and(z, y);
        }
    }
}