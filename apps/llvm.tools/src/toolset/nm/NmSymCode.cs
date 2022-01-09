//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// https://llvm.org/docs/CommandGuide/llvm-nm.html
    /// </summary>
    [SymSource("llvm")]
    public enum NmSymCode : byte
    {
        None,

        [Symbol("a", "Absolute symbol")]
        a,

        [Symbol("A", "Absolute symbol")]
        A,

        [Symbol("b", ".bss section")]
        b,

        [Symbol("B", "Uninitialized data (bss) object")]
        B,

        [Symbol("C", "Common symbol. Multiple definitions link together into one definition")]
        C,

        [Symbol("d", "Writable data object (.data)")]
        d,

        [Symbol("D", "Writable data object")]
        D,

        [Symbol("i", "COFF: .idata symbol or symbol in a section with IMAGE_SCN_LNK_INFO set")]
        i,

        [Symbol("l", "COFF: .idata symbol or symbol in a section with IMAGE_SCN_LNK_INFO set")]
        l,

        [Symbol("n", "ELF: local symbol from non-alloc section | COFF: Debug symbol")]
        n,

        [Symbol("N", "ELF: debug section symbol, or global symbol from non-alloc section | Mach-O: absolute symbol or symbol from a section other than __TEXT_EXEC __text, __TEXT __text, __DATA __data, or __DATA __bss")]
        N,

        [Symbol("r", "Read-only data object")]
        r,

        [Symbol("R", "Read-only data object")]
        R,

        [Symbol("s", "ELF: debug section symbol, or global symbol from non-alloc section | Mach-O: absolute symbol or symbol from a section other than __TEXT_EXEC __text, __TEXT __text, __DATA __data, or __DATA __bss")]
        s,

        [Symbol("S", "ELF: debug section symbol, or global symbol from non-alloc section | Mach-O: absolute symbol or symbol from a section other than __TEXT_EXEC __text, __TEXT __text, __DATA __data, or __DATA __bss")]
        S,

        [Symbol("t", ".text section")]
        t,

        [Symbol("T", "Code (text) object")]
        T,

        [Symbol("u", "ELF: GNU unique symbol")]
        u,

        [Symbol("U", "Named object is undefined in this file")]
        U,

        [Symbol("v", "ELF: Undefined weak object. It is not a link failure if the object is not defined")]
        v,

        [Symbol("V", "ELF: Defined weak object symbol")]
        V,

        [Symbol("w", "Undefined weak symbol other than an ELF object symbol. It is not a link failure if the symbol is not defined")]
        w,

        [Symbol("W", "Defined weak symbol other than an ELF object symbol")]
        W,

        [Symbol("-", "Mach-O: N_STAB symbo")]
        N_STAB,
    }
}