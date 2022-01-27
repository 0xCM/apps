//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Defines a rule r:seq[T] -> seq[T] that defines a sequence element that, if found, is replaced with another
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ReplaceRule<T> : IExpr
    {
        /// <summary>
        /// The sequence term to match
        /// </summary>
        public readonly T Match;

        /// <summary>
        /// The replacement value when matched
        /// </summary>
        public readonly T Replace;

        [MethodImpl(Inline)]
        public ReplaceRule(T match, T replace)
        {
            Match = match;
            Replace = replace;
        }

        public Label Name
            => "replace<{0}>";

        public string Format()
            => Rules.format(this);

        public override string ToString()
            => Format();
    }
}