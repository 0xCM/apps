//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource("image")]
    public enum SymStorageClass : byte
    {
        [Symbol("null")]
        IMAGE_SYM_CLASS_NULL = 0,

        [Symbol("auto")]
        IMAGE_SYM_CLASS_AUTOMATIC = 1,

        [Symbol("extern")]
        IMAGE_SYM_CLASS_EXTERNAL = 2,

        [Symbol("static")]
        IMAGE_SYM_CLASS_STATIC = 3,

        [Symbol("register")]
        IMAGE_SYM_CLASS_REGISTER = 4,

        [Symbol("externdef")]
        IMAGE_SYM_CLASS_EXTERNAL_DEF = 5,

        [Symbol("label")]
        IMAGE_SYM_CLASS_LABEL = 6,

        [Symbol("label-undefined")]
        IMAGE_SYM_CLASS_UNDEFINED_LABEL = 7,

        [Symbol("struct-member")]
        IMAGE_SYM_CLASS_MEMBER_OF_STRUCT = 8,

        [Symbol("arg")]
        IMAGE_SYM_CLASS_ARGUMENT = 9,

        [Symbol("struct-tag")]
        IMAGE_SYM_CLASS_STRUCT_TAG = 10,

        [Symbol("union-member")]
        IMAGE_SYM_CLASS_MEMBER_OF_UNION = 11,

        [Symbol("union-tag")]
        IMAGE_SYM_CLASS_UNION_TAG = 12,

        [Symbol("typedef")]
        IMAGE_SYM_CLASS_TYPE_DEFINITION = 13,

        [Symbol("static-undefined")]
        IMAGE_SYM_CLASS_UNDEFINED_STATIC = 14,

        [Symbol("enum-tag")]
        IMAGE_SYM_CLASS_ENUM_TAG = 15,

        [Symbol("enum-member")]
        IMAGE_SYM_CLASS_MEMBER_OF_ENUM = 16,

        [Symbol("reg-param")]
        IMAGE_SYM_CLASS_REGISTER_PARAM = 17,

        [Symbol("bitfield")]
        IMAGE_SYM_CLASS_BIT_FIELD = 18,

        [Symbol("block")]
        IMAGE_SYM_CLASS_BLOCK = 100,

        [Symbol("function")]
        IMAGE_SYM_CLASS_FUNCTION = 101,

        [Symbol("struct-end")]
        IMAGE_SYM_CLASS_END_OF_STRUCT = 102,

        [Symbol("file")]
        IMAGE_SYM_CLASS_FILE = 103,

        [Symbol("section")]
        IMAGE_SYM_CLASS_SECTION = 104,

        [Symbol("extern-weak")]
        IMAGE_SYM_CLASS_WEAK_EXTERNAL = 105,

        [Symbol("clrtoken")]
        IMAGE_SYM_CLASS_CLR_TOKEN = 107,

        [Symbol("function-end")]
        IMAGE_SYM_CLASS_END_OF_FUNCTION = 255,
    }
}