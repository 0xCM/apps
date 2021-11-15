//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct ImageRelocation
    {
        /// <summary>
        /// The virtual address (or count)
        /// </summary>
        public Address32 Value;

        /// <summary>
        /// The symbol table index
        /// </summary>
        public uint SymbolIndex;

        /// <summary>
        /// The relocation type
        /// </summary>
        public ushort Type;

        [MethodImpl(Inline)]
        public ImageRelocation(Address32 value, uint index, ushort type)
        {
            Value = value;
            SymbolIndex = index;
            Type = type;
        }
    }

    public readonly struct RelocationKinds
    {
        public enum I386 : ushort
        {
            ABSOLUTE = 0x0000,  // Reference is absolute, no relocation is necessary

            DIR16 = 0x0001,  // Direct 16-bit reference to the symbols virtual address

            REL16 = 0x0002,  // PC-relative 16-bit reference to the symbols virtual address

            DIR32 = 0x0006,  // Direct 32-bit reference to the symbols virtual address

            DIR32NB = 0x0007,  // Direct 32-bit reference to the symbols virtual address, base not included

            SEG12 = 0x0009,  // Direct 16-bit reference to the segment-selector bits of a 32-bit virtual address

            SECTION = 0x000A,

            SECREL = 0x000B,

            TOKEN = 0x000C,  // clr token

            SECREL7 = 0x000D,  // 7 bit offset from base of section containing target

            REL32 = 0x0014,  // PC-relative 32-bit reference to the symbols virtual address
        }

        /// <summary>
        /// From winnt.h
        /// </summary>
        public enum Amd64 : ushort
        {
            [Symbol("IMAGE_REL_AMD64_ABSOLUTE"," Reference is absolute, no relocation is necessary")]
            ABSOLUTE = 0x0000,

            [Symbol("IMAGE_REL_AMD64_ADDR64","64-bit address (VA)")]
            ADDR64 =  0x0001,

            [Symbol("IMAGE_REL_AMD64_ADDR32","32-bit address (VA)")]
            ADDR32 = 0x0002,

            [Symbol("IMAGE_REL_AMD64_ADDR32NB","32-bit address w/o image base (RVA)")]
            ADDR32NB = 0x0003,

            [Symbol("IMAGE_REL_AMD64_REL32","32-bit relative address from byte following reloc")]
            REL32 = 0x0004,

            [Symbol("IMAGE_REL_AMD64_REL32_1","32-bit relative address from byte distance 1 from reloc")]
            REL32_1 = 0x0005,

            [Symbol("IMAGE_REL_AMD64_REL32_2","32-bit relative address from byte distance 2 from reloc")]
            REL32_2 = 0x0006,

            [Symbol("IMAGE_REL_AMD64_REL32_3","32-bit relative address from byte distance 3 from reloc")]
            REL32_3 = 0x0007,

            [Symbol("IMAGE_REL_AMD64_REL32_4","32-bit relative address from byte distance 4 from reloc")]
            REL32_4 = 0x0008,

            [Symbol("IMAGE_REL_AMD64_REL32_5","32-bit relative address from byte distance 5 from reloc")]
            REL32_5 = 0x0009,

            [Symbol("IMAGE_REL_AMD64_SECTION","Section index")]
            SECTION = 0x000A,

            [Symbol("IMAGE_REL_AMD64_SECREL","32 bit offset from base of section containing target")]
            SECREL =  0x000B,

            [Symbol("IMAGE_REL_AMD64_SECREL7","7 bit unsigned offset from base of section containing target")]
            SECREL7 = 0x000C,

            [Symbol("IMAGE_REL_AMD64_TOKEN","32 bit metadata token")]
            TOKEN = 0x000D,

            [Symbol("IMAGE_REL_AMD64_SREL32","32 bit signed span-dependent value emitted into object")]
            SREL32 = 0x000E,

            [Symbol("IMAGE_REL_AMD64_PAIR")]
            PAIR = 0x000F,

            [Symbol("IMAGE_REL_AMD64_SSPAN32","32 bit signed span-dependent value applied at link time")]
            SSPAN32 = 0x0010,

            [Symbol("IMAGE_REL_AMD64_EHANDLER")]
            EHANDLER = 0x0011,

            [Symbol("IMAGE_REL_AMD64_IMPORT_BR","Indirect branch to an import")]
            IMPORT_BR = 0x0012,

            [Symbol("IMAGE_REL_AMD64_IMPORT_CALL","Indirect call to an import")]
            IMPORT_CALL = 0x0013,

            [Symbol("IMAGE_REL_AMD64_CFG_BR","Indirect branch to a CFG check")]
            CFG_BR = 0x0014,

            [Symbol("IMAGE_REL_AMD64_CFG_BR_REX","Indirect branch to a CFG check, with REX.W prefix")]
            CFG_BR_REX = 0x0015,

            [Symbol("IMAGE_REL_AMD64_CFG_CALL","Indirect call to a CFG check")]
            CFG_CALL = 0x0016,

            [Symbol("IMAGE_REL_AMD64_INDIR_BR","Indirect branch to a target in RAX (no CFG)")]
            INDIR_BR = 0x0017,

            [Symbol("IMAGE_REL_AMD64_INDIR_BR_REX","Indirect branch to a target in RAX, with REX.W prefix (no CFG)")]
            INDIR_BR_REX = 0x0018,

            [Symbol("IMAGE_REL_AMD64_INDIR_CALL","Indirect call to a target in RAX (no CFG)")]
            INDIR_CALL = 0x0019,

            [Symbol("IMAGE_REL_AMD64_INDIR_BR_SWITCHTABLE_FIRST","Indirect branch for a switch table using Reg 0 (RAX)")]
            INDIR_BR_SWITCHTABLE_FIRST = 0x0020,

            [Symbol("IMAGE_REL_AMD64_INDIR_BR_SWITCHTABLE_LAST","Indirect branch for a switch table using Reg 15 (R15)")]
            INDIR_BR_SWITCHTABLE_LAST = 0x002F,
        }
    }

    public readonly struct ImageRelocations
    {

    }
}