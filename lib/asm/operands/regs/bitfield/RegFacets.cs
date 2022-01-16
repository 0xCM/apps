//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [LiteralProvider]
    public readonly struct RegFacets
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

        /// <summary>
        /// The number of available BND registers
        /// </summary>
        public const byte BndRegCount = 4;

        /// <summary>
        /// The number of available CR registers
        /// </summary>
        public const byte CrRegCount = 8;

        /// <summary>
        /// The number of available DB registers
        /// </summary>
        public const byte DbRegCount = 8;

        /// <summary>
        /// The number of available FP registers
        /// </summary>
        public const byte FpuRegCount = 8;

        /// <summary>
        /// The number of available IP registers
        /// </summary>
        public const byte IpRegCount = 3;

        /// <summary>
        /// The number of available SYSPTR registers
        /// </summary>
        public const byte SysPtrRegCount = 3;

        /// <summary>
        /// The number of available Test registers
        /// </summary>
        public const byte TestRegCount = 8;

        /// <summary>
        /// The number of available MASK registers
        /// </summary>
        public const byte MaskRegCount = 8;

        /// <summary>
        /// The number of available XMM registers
        /// </summary>
        public const byte XmmRegCount = 32;

        /// <summary>
        /// The number of available YMM registers
        /// </summary>
        public const byte YmmRegCount = 32;

        /// <summary>
        /// The number of available ZMM registers
        /// </summary>
        public const byte ZmmRegCount = 32;

        /// <summary>
        /// The number of available SEG registers
        /// </summary>
        public const byte SegRegCount = 6;

        /// <summary>
        /// The number of available Gp8Hi registers
        /// </summary>
        public const byte Gp8HiRegCount = 4;

        /// <summary>
        /// The number of available Gp8 lo registers
        /// </summary>
        public const byte Gp8LoRegCount = 16;

        /// <summary>
        /// The number of available Gp8 registers
        /// </summary>
        public const byte Gp8RegCount = 20;

        /// <summary>
        /// The number of available Gp16 registers
        /// </summary>
        public const byte Gp16RegCount = 16;

        /// <summary>
        /// The number of available Gp32 registers
        /// </summary>
        public const byte Gp32RegCount = 16;

        /// <summary>
        /// The number of available Gp64 registers
        /// </summary>
        public const byte Gp64RegCount = 16;

        /// <summary>
        /// The number of available Gp registers
        /// </summary>
        public const byte GpRegCount = Gp8RegCount + Gp16RegCount + Gp32RegCount + Gp64RegCount;

        /// <summary>
        /// The number of available MMX registers
        /// </summary>
        public const byte MmxRegCount = 8;
    }
}