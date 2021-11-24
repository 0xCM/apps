//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct TypeSyntax
    {
        /// <summary>
        /// Specifies the syntax of an unsigned integer of natural bit-width n > 0
        /// </summary>
        /// <param name="w">The natural bitwidth</param>
        public static string unsigned(uint w)
            => string.Format("u{0}",w);

        /// <summary>
        /// Specifies the syntax of a signed integer of natural bit-width n > 0
        /// </summary>
        /// <param name="w">The natural bitwidth</param>
        public static string signed(uint w)
            => string.Format("i{0}",w);

        /// <summary>
        /// Defines a specifier for an <paramref name='n'/>-dimensional vector with cells of bit-width <paramref name='w'/> of primal class <paramref name='k'/>
        /// </summary>
        /// <param name="n">The vector dimension</param>
        /// <param name="k">The cell's primal class</param>
        /// <param name="w">The cell's width</param>
        [Op]
        public static string vector(uint n, PrimalClass k, uint w)
            => string.Format("v{0}x{1}{2}", n, k, w);
    }
}