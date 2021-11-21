//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm.COFF
{
    /// <summary>
    /// From https://github.com/llvm/llvm-project/blob/d20b013b490e0603ba21b5ccff966d7e11025775/llvm/include/llvm/BinaryFormat/COFF.h
    /// </summary>
    [SymSource]
    public enum SymbolStorageClass
    {
        SSC_Invalid = 0xff,

        [Symbol("","Physical end of function")]
        IMAGE_SYM_CLASS_END_OF_FUNCTION = -1,

        [Symbol("","No symbol")]
        IMAGE_SYM_CLASS_NULL = 0,

        [Symbol("","Stack variable")]
        IMAGE_SYM_CLASS_AUTOMATIC = 1,

        [Symbol("","External symbol")]
        IMAGE_SYM_CLASS_EXTERNAL = 2,

        [Symbol("","Static")]
        IMAGE_SYM_CLASS_STATIC = 3,

        [Symbol("","Register variable")]
        IMAGE_SYM_CLASS_REGISTER = 4,

        [Symbol("","External definition")]
        IMAGE_SYM_CLASS_EXTERNAL_DEF = 5,

        [Symbol("","Label")]
        IMAGE_SYM_CLASS_LABEL = 6,

        [Symbol("","Undefined label")]
        IMAGE_SYM_CLASS_UNDEFINED_LABEL = 7,

        [Symbol("","Member of structure")]
        IMAGE_SYM_CLASS_MEMBER_OF_STRUCT = 8,

        [Symbol("","Function argument")]
        IMAGE_SYM_CLASS_ARGUMENT = 9,

        [Symbol("","Structure tag")]
        IMAGE_SYM_CLASS_STRUCT_TAG = 10,

        [Symbol("","Member of union")]
        IMAGE_SYM_CLASS_MEMBER_OF_UNION = 11,

        [Symbol("","Union tag")]
        IMAGE_SYM_CLASS_UNION_TAG = 12,

        [Symbol("","Type definition")]
        IMAGE_SYM_CLASS_TYPE_DEFINITION = 13,

        [Symbol("","Undefined static")]
        IMAGE_SYM_CLASS_UNDEFINED_STATIC = 14,

        [Symbol("","Enumeration tag")]
        IMAGE_SYM_CLASS_ENUM_TAG = 15,

        [Symbol("","Member of enumeration")]
        IMAGE_SYM_CLASS_MEMBER_OF_ENUM = 16,

        [Symbol("","Register parameter")]
        IMAGE_SYM_CLASS_REGISTER_PARAM = 17,

        [Symbol("","Bit field")]
        IMAGE_SYM_CLASS_BIT_FIELD = 18,

        [Symbol("","'.bb' or '.eb' - beginning or end of block")]
        IMAGE_SYM_CLASS_BLOCK = 100,

        [Symbol("","'.bf' or '.ef' - beginning or end of function")]
        IMAGE_SYM_CLASS_FUNCTION = 101,

        [Symbol("","End of structure")]
        IMAGE_SYM_CLASS_END_OF_STRUCT = 102,

        [Symbol("","File name")]
        IMAGE_SYM_CLASS_FILE = 103,

        [Symbol("","Line number, reformatted as symbol")]
        IMAGE_SYM_CLASS_SECTION = 104,

        [Symbol("","Duplicate tag")]
        IMAGE_SYM_CLASS_WEAK_EXTERNAL = 105,

        [Symbol("","External symbol in dmert public lib")]
        IMAGE_SYM_CLASS_CLR_TOKEN = 107
    }
}