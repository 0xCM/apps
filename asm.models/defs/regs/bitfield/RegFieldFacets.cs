//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [LiteralProvider]
    public readonly struct RegFieldFacets
    {
        /// <summary>
        /// The number of provisioned register indicies
        /// </summary>
        public const byte IndexCount = 32;

        /// <summary>
        /// The number of register classes
        /// </summary>
        public const byte ClassCount = 17;

        /// <summary>
        /// The number of register withs
        /// </summary>
        public const byte WidthCount = 8;

        /// <summary>
        /// The position of the first bit in the index segment
        /// </summary>
        public const byte IndexField = 0;

        /// <summary>
        /// The position of the first bit in the class segment
        /// </summary>
        public const byte ClassField = 5;

        /// <summary>
        /// The position of the first bit in the width segment
        /// </summary>
        public const byte WidthField = 10;
    }
}