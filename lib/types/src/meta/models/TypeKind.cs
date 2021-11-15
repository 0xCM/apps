//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource]
    public enum TypeKind : ushort
    {
        None = 0,

        [Symbol("bit")]
        Bit,

        [Symbol("bool")]
        Bool,

        [Symbol("char")]
        Char,

        [Symbol("u8")]
        U8,

        [Symbol("i8")]
        I8,

        [Symbol("u16")]
        U16,

        [Symbol("i16")]
        I16,

        [Symbol("u32")]
        U32,

        [Symbol("i32")]
        I32,

        [Symbol("u64")]
        U64,

        [Symbol("i64")]
        I64,

        [Symbol("f32")]
        F32,

        [Symbol("f64")]
        F64,

        [Symbol("string")]
        String,

        [Symbol("array<{0}>")]
        Array,

        [Symbol("folder")]
        FolderName,

        [Symbol("dir")]
        FolderPath,

        [Symbol("file")]
        FileName,

        [Symbol("path")]
        FilePath,

        [Symbol("ext")]
        FileExt,

        [Symbol("relpath")]
        RelativePath,
    }
}