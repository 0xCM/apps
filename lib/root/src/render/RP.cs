//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    [ApiHost, LiteralProvider]
    public readonly partial struct RP
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// The end-of-line escape sequence
        /// </summary>
        public const string Eol = Chars.Eol;

        public const char PropertySep = Chars.Colon;

        public const sbyte PropertyPad = -16;

        /// <summary>
        /// Defines the literal '{0} -> {1}'
        /// </summary>
        [RenderPattern("{0} -> {1}")]
        public const string ArrowAxB = "{0} -> {1}";
    }
}