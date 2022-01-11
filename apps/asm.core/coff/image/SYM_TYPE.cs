namespace Windows.Image
{
    using Z0;

    [SymSource("image")]
    public enum SYM_TYPE : ushort
    {
        [Symbol("null")]
        IMAGE_SYM_TYPE_NULL  = 0,

        [Symbol("void")]
        IMAGE_SYM_TYPE_VOID  = 1,

        [Symbol("char")]
        IMAGE_SYM_TYPE_CHAR  = 2,

        [Symbol("short")]
        IMAGE_SYM_TYPE_SHORT = 3,

        [Symbol("int")]
        IMAGE_SYM_TYPE_INT   = 4,

        [Symbol("long")]
        IMAGE_SYM_TYPE_LONG  = 5,

        [Symbol("float")]
        IMAGE_SYM_TYPE_FLOAT = 6,

        [Symbol("double")]
        IMAGE_SYM_TYPE_DOUBLE= 7,

        [Symbol("struct")]
        IMAGE_SYM_TYPE_STRUCT= 8,

        [Symbol("union")]
        IMAGE_SYM_TYPE_UNION = 9,

        [Symbol("enum")]
        IMAGE_SYM_TYPE_ENUM  = 10,

        [Symbol("moe")]
        IMAGE_SYM_TYPE_MOE   = 11,

        [Symbol("byte")]
        IMAGE_SYM_TYPE_BYTE  = 12,

        [Symbol("word")]
        IMAGE_SYM_TYPE_WORD  = 13,

        [Symbol("uint")]
        IMAGE_SYM_TYPE_UINT  = 14,

        [Symbol("dword")]
        IMAGE_SYM_TYPE_DWORD = 15
    }
}