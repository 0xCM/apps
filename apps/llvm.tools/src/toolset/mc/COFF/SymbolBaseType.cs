//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm.COFF
{
    /// <summary>
    /// From https://github.com/llvm/llvm-project/blob/d20b013b490e0603ba21b5ccff966d7e11025775/llvm/include/llvm/BinaryFormat/COFF.h
    /// </summary>
    [SymSource("llvm.mc")]
    public enum SymbolBaseType : uint
    {
        [Symbol("null","No type information or unknown base type")]
        IMAGE_SYM_TYPE_NULL = 0,

        [Symbol("void","Used with void pointers and functions")]
        IMAGE_SYM_TYPE_VOID = 1,

        [Symbol("sbyte","A character (signed byte).")]
        IMAGE_SYM_TYPE_CHAR = 2,

        [Symbol("short","A 2-byte signed integer")]
        IMAGE_SYM_TYPE_SHORT = 3,

        [Symbol("long","A natural integer type on the target")]
        IMAGE_SYM_TYPE_INT = 4,

        [Symbol("int","A 4-byte signed integer")]
        IMAGE_SYM_TYPE_LONG = 5,

        [Symbol("float","A 4-byte floating-point number")]
        IMAGE_SYM_TYPE_FLOAT = 6,

        [Symbol("double","An 8-byte floating-point number")]
        IMAGE_SYM_TYPE_DOUBLE = 7,

        [Symbol("struct","A structure")]
        IMAGE_SYM_TYPE_STRUCT = 8,

        [Symbol("union","An union")]
        IMAGE_SYM_TYPE_UNION = 9,

        [Symbol("enum","An enumerated type")]
        IMAGE_SYM_TYPE_ENUM = 10,

        [Symbol("enumconst"," A member of enumeration (a specific value)")]
        IMAGE_SYM_TYPE_MOE = 11,

        [Symbol("byte","A byte; unsigned 1-byte integer")]
        IMAGE_SYM_TYPE_BYTE = 12,

        [Symbol("ushort","A word; unsigned 2-byte integer")]
        IMAGE_SYM_TYPE_WORD = 13,

        [Symbol("ulong","An unsigned integer of natural size")]
        IMAGE_SYM_TYPE_UINT = 14,

        [Symbol("uint","An unsigned 4-byte integer")]
        IMAGE_SYM_TYPE_DWORD = 15
    }
}