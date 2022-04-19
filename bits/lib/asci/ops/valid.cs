//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Asci
    {
        /// <summary>
        /// Tests whether a byte represents corresponds to an valid asci character
        /// </summary>
        /// <param name="src">The data to test</param>
        [MethodImpl(Inline), Op]
        public static bool valid(byte src)
            => src <= AsciCodeFacets.MaxCodeValue;

        /// <summary>
        /// Tests whether a byte represents corresponds to an invalid asci character
        /// </summary>
        /// <param name="src">The data to test</param>
        [MethodImpl(Inline), Op]
        public static bool invalid(byte src)
            => !valid(src);
    }
}