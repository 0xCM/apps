//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial class XTend
    {
        /// <summary>
        /// Formats a readonly span as a vector
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="sep">The item separator</param>
        /// <typeparam name="T">The item type</typeparam>
        [TextUtility, Closures(NumericKind.UnsignedInts)]
        public static string FormatVector<T>(this ReadOnlySpan<T> src, char sep = Chars.Comma)
        {
            var body = src.Map(x => x.ToString()).Join(sep);
            return RP.adjacent(Chars.Lt, body, Chars.Gt);
        }

        /// <summary>
        /// Formats a span as a vector
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="sep">The item separator</param>
        /// <typeparam name="T">The item type</typeparam>
        [TextUtility, Closures(NumericKind.UnsignedInts)]
        public static string FormatVector<T>(this Span<T> src, char sep = Chars.Comma)
            => src.ReadOnly().FormatVector(sep);
    }
}