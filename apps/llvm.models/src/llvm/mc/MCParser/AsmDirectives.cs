//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    // Classifies assembler directives
    // https://github.com/llvm/llvm-project/blob/a8cfa4b9bda3014a88e089cadcc6d366317aec5b/llvm/lib/MC/MCParser/AsmParser.cpp
    [SymSource]
    public enum DirectiveKind
    {
        DK_NO_DIRECTIVE, // Placeholder

        [Symbol(".set")]
        DK_SET,

        [Symbol(".equ")]
        DK_EQU,

        [Symbol(".equiv")]
        DK_EQUIV,

        [Symbol(".ascii")]
        DK_ASCII,

        [Symbol(".asciz")]
        DK_ASCIZ,

        [Symbol(".string")]
        DK_STRING,

        [Symbol(".byte")]
        DK_BYTE,

        [Symbol(".short")]
        DK_SHORT,

        [Symbol(".value")]
        DK_RELOC,

        [Symbol("")]
        DK_VALUE,

        [Symbol("")]
        DK_2BYTE,

        [Symbol("")]
        DK_LONG,

        [Symbol("")]
        DK_INT,

        [Symbol("")]
        DK_4BYTE,

        [Symbol("")]
        DK_QUAD,

        [Symbol("")]
        DK_8BYTE,

        [Symbol("")]
        DK_OCTA,

        [Symbol("")]
        DK_DC,

        [Symbol("")]
        DK_DC_A,

        [Symbol("")]
        DK_DC_B,

        [Symbol("")]
        DK_DC_D,

        [Symbol("")]
        DK_DC_L,

        [Symbol("")]
        DK_DC_S,

        [Symbol("")]
        DK_DC_W,

        [Symbol("")]
        DK_DC_X,

        [Symbol("")]
        DK_DCB,

        [Symbol("")]
        DK_DCB_B,

        [Symbol("")]
        DK_DCB_D,

        [Symbol("")]
        DK_DCB_L,

        [Symbol("")]
        DK_DCB_S,

        [Symbol("")]
        DK_DCB_W,

        [Symbol("")]
        DK_DCB_X,

        [Symbol("")]
        DK_DS,

        [Symbol("")]
        DK_DS_B,

        [Symbol("")]
        DK_DS_D,

        [Symbol("")]
        DK_DS_L,

        [Symbol("")]
        DK_DS_P,

        [Symbol("")]
        DK_DS_S,

        [Symbol("")]
        DK_DS_W,

        [Symbol("")]
        DK_DS_X,

        [Symbol("")]
        DK_SINGLE,

        [Symbol("")]
        DK_FLOAT,

        [Symbol("")]
        DK_DOUBLE,

        [Symbol("")]
        DK_ALIGN,

        [Symbol("")]
        DK_ALIGN32,

        [Symbol("")]
        DK_BALIGN,

        [Symbol("")]
        DK_BALIGNW,

        [Symbol("")]
        DK_BALIGNL,

        [Symbol("")]
        DK_P2ALIGN,

        [Symbol("")]
        DK_P2ALIGNW,

        [Symbol("")]
        DK_P2ALIGNL,

        [Symbol("")]
        DK_ORG,

        [Symbol("")]
        DK_FILL,

        [Symbol("")]
        DK_ENDR,

        [Symbol("")]
        DK_BUNDLE_ALIGN_MODE,

        [Symbol("")]
        DK_BUNDLE_LOCK,

        [Symbol("")]
        DK_BUNDLE_UNLOCK,

        [Symbol("")]
        DK_ZERO,

        [Symbol("")]
        DK_EXTERN,

        [Symbol("")]
        DK_GLOBL,

        [Symbol("")]
        DK_GLOBAL,

        [Symbol("")]
        DK_LAZY_REFERENCE,

        [Symbol("")]
        DK_NO_DEAD_STRIP,

        [Symbol("")]
        DK_SYMBOL_RESOLVER,

        [Symbol("")]
        DK_PRIVATE_EXTERN,

        [Symbol("")]
        DK_REFERENCE,

        [Symbol("")]
        DK_WEAK_DEFINITION,

        [Symbol("")]
        DK_WEAK_REFERENCE,

        [Symbol("")]
        DK_WEAK_DEF_CAN_BE_HIDDEN,

        [Symbol("")]
        DK_COLD,

        [Symbol("")]
        DK_COMM,

        [Symbol("")]
        DK_COMMON,

        [Symbol("")]
        DK_LCOMM,

        [Symbol("")]
        DK_ABORT,

        [Symbol("")]
        DK_INCLUDE,

        [Symbol("")]
        DK_INCBIN,

        [Symbol("")]
        DK_CODE16,

        [Symbol("")]
        DK_CODE16GCC,

        [Symbol("")]
        DK_REPT,

        [Symbol("")]
        DK_IRP,

        [Symbol("")]
        DK_IRPC,

        [Symbol("")]
        DK_IF,

        [Symbol("")]
        DK_IFEQ,

        [Symbol("")]
        DK_IFGE,

        [Symbol("")]
        DK_IFGT,

        [Symbol("")]
        DK_IFLE,

        [Symbol("")]
        DK_IFLT,

        [Symbol("")]
        DK_IFNE,

        [Symbol("")]
        DK_IFB,

        [Symbol("")]
        DK_IFNB,

        [Symbol("")]
        DK_IFC,

        [Symbol("")]
        DK_IFEQS,

        [Symbol("")]
        DK_IFNC,

        [Symbol("")]
        DK_IFNES,

        [Symbol("")]
        DK_IFDEF,

        [Symbol("")]
        DK_IFNDEF,

        [Symbol("")]
        DK_IFNOTDEF,

        [Symbol("")]
        DK_ELSEIF,

        [Symbol("")]
        DK_ELSE,

        [Symbol("")]
        DK_ENDIF,

        [Symbol("")]
        DK_SPACE,

        [Symbol("")]
        DK_SKIP,

        [Symbol("")]
        DK_FILE,

        [Symbol("")]
        DK_LINE,

        [Symbol("")]
        DK_LOC,

        [Symbol("")]
        DK_STABS,

        [Symbol("")]
        DK_CV_FILE,

        [Symbol("")]
        DK_CV_FUNC_ID,

        [Symbol("")]
        DK_CV_INLINE_SITE_ID,

        [Symbol("")]
        DK_CV_LOC,

        [Symbol("")]
        DK_CV_LINETABLE,

        [Symbol("")]
        DK_CV_INLINE_LINETABLE,

        [Symbol("")]
        DK_CV_DEF_RANGE,

        [Symbol("")]
        DK_CV_STRINGTABLE,

        [Symbol("")]
        DK_CV_STRING,

        [Symbol("")]
        DK_CV_FILECHECKSUMS,

        [Symbol("")]
        DK_CV_FILECHECKSUM_OFFSET,

        [Symbol("")]
        DK_CV_FPO_DATA,

        [Symbol("")]
        DK_CFI_SECTIONS,

        [Symbol("")]
        DK_CFI_STARTPROC,

        DK_CFI_ENDPROC,

        DK_CFI_DEF_CFA,

        DK_CFI_DEF_CFA_OFFSET,

        DK_CFI_ADJUST_CFA_OFFSET,

        DK_CFI_DEF_CFA_REGISTER,

        DK_CFI_LLVM_DEF_ASPACE_CFA,

        DK_CFI_OFFSET,

        DK_CFI_REL_OFFSET,

        DK_CFI_PERSONALITY,

        DK_CFI_LSDA,

        DK_CFI_REMEMBER_STATE,

        DK_CFI_RESTORE_STATE,

        DK_CFI_SAME_VALUE,

        DK_CFI_RESTORE,

        DK_CFI_ESCAPE,

        DK_CFI_RETURN_COLUMN,

        DK_CFI_SIGNAL_FRAME,

        DK_CFI_UNDEFINED,

        DK_CFI_REGISTER,

        DK_CFI_WINDOW_SAVE,

        DK_CFI_B_KEY_FRAME,

        DK_MACROS_ON,

        [Symbol("")]
        DK_MACROS_OFF,

        [Symbol("")]
        DK_ALTMACRO,

        [Symbol("")]
        DK_NOALTMACRO,

        [Symbol("")]
        DK_MACRO,

        [Symbol("")]
        DK_EXITM,

        [Symbol("")]
        DK_ENDM,

        [Symbol("")]
        DK_ENDMACRO,

        [Symbol("")]
        DK_PURGEM,

        [Symbol("")]
        DK_SLEB128,

        [Symbol("")]
        DK_ULEB128,

        [Symbol("")]
        DK_ERR,

        [Symbol("")]
        DK_ERROR,

        [Symbol("")]
        DK_WARNING,

        [Symbol("")]
        DK_PRINT,

        [Symbol("")]
        DK_ADDRSIG,

        [Symbol("")]
        DK_ADDRSIG_SYM,

        [Symbol("")]
        DK_PSEUDO_PROBE,

        [Symbol("")]
        DK_LTO_DISCARD,

        [Symbol("")]
        DK_END
    }
}