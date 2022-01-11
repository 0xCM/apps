//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using Windows.Image;

    using static Root;

    /// <summary>
    /// Represents a more user-friendly version of <see cref='IMAGE_SECTION_HEADER'/>
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct CoffSection
    {
        public uint Number;

        public Hex32 VirtualSize;

        public Hex32 VirtualAddress;

        public Size<uint> RawDataSize;

        public Hex32 RawDataPtr;

        public Hex32 RelocationsPtr;

        public Hex32 LineNumbersPtr;

        public uint RelocationCount;

        public uint LineNumberCount;

        public IMAGE_SECTION_FLAGS Characteristics;

        public static CoffSection Empty => default;
    }
}