//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-attribute-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using static Root;

    partial struct XedModels
    {
        public struct AttributeBits
        {
            ulong Lo;

            ulong Hi;

            [MethodImpl(Inline)]
            public AttributeBits Set(AttributeKind kind, bit state)
            {
                var i = index(kind);
                if(i < 64)
                    Lo = bit.set(Lo,i,state);
                else
                    Hi = bit.set(Hi,i, state);
                return this;
            }

            public bit Test(AttributeKind kind)
            {
                var i = index(kind);
                if(i < 64)
                    return bit.test(Lo,i);
                else
                    return bit.test(Hi,i);
            }

            public AttributeBits Clear()
            {
                Lo = 0;
                Hi = 0;
                return this;
            }


            [MethodImpl(Inline)]
            static byte index(AttributeKind kind)
                => (byte)kind;


            public static AttributeBits Zero => default;
        }

        [SymSource(xed)]
        public enum AttributeKind : byte
        {
            INVALID,

            AMDONLY,

            ATT_OPERAND_ORDER_EXCEPTION,

            BROADCAST_ENABLED,

            BYTEOP,

            DISP8_EIGHTHMEM,

            DISP8_FULL,

            DISP8_FULLMEM,

            DISP8_GPR_READER,

            DISP8_GPR_READER_BYTE,

            DISP8_GPR_READER_WORD,

            DISP8_GPR_WRITER_LDOP_D,

            DISP8_GPR_WRITER_LDOP_Q,

            DISP8_GPR_WRITER_STORE,

            DISP8_GPR_WRITER_STORE_BYTE,

            DISP8_GPR_WRITER_STORE_WORD,

            DISP8_GSCAT,

            DISP8_HALF,

            DISP8_HALFMEM,

            DISP8_MEM128,

            DISP8_MOVDDUP,

            DISP8_QUARTERMEM,

            DISP8_SCALAR,

            DISP8_TUPLE1,

            DISP8_TUPLE1_4X,

            DISP8_TUPLE1_BYTE,

            DISP8_TUPLE1_WORD,

            DISP8_TUPLE2,

            DISP8_TUPLE4,

            DISP8_TUPLE8,

            DOUBLE_WIDE_MEMOP,

            DOUBLE_WIDE_OUTPUT,

            DWORD_INDICES,

            ELEMENT_SIZE_D,

            ELEMENT_SIZE_Q,

            EXCEPTION_BR,

            FAR_XFER,

            FIXED_BASE0,

            FIXED_BASE1,

            GATHER,

            HALF_WIDE_OUTPUT,

            HLE_ACQ_ABLE,

            HLE_REL_ABLE,

            IGNORES_OSFXSR,

            IMPLICIT_ONE,

            INDEX_REG_IS_POINTER,

            INDIRECT_BRANCH,

            KMASK,

            /// <summary>
            /// Indicates an instruction can be encoded with the lock prefix
            /// </summary>
            LOCKABLE,

            LOCKED,

            MASKOP,

            MASKOP_EVEX,

            MASK_AS_CONTROL,

            MASK_VARIABLE_MEMOP,

            MEMORY_FAULT_SUPPRESSION,

            MMX_EXCEPT,

            MPX_PREFIX_ABLE,

            MULTIDEST2,

            MULTISOURCE4,

            MXCSR,

            MXCSR_RD,

            NONTEMPORAL,

            NOP,

            NOTSX,

            NOTSX_COND,

            NO_RIP_REL,

            PREFETCH,

            PROTECTED_MODE,

            QWORD_INDICES,

            REP,

            REQUIRES_ALIGNMENT,

            RING0,

            SCALABLE,

            SCATTER,

            SIMD_SCALAR,

            SKIPLOW32,

            SKIPLOW64,

            SPECIAL_AGEN_REQUIRED,

            STACKPOP0,

            STACKPOP1,

            STACKPUSH0,

            STACKPUSH1,

            X87_CONTROL,

            X87_MMX_STATE_CW,

            X87_MMX_STATE_R,

            X87_MMX_STATE_W,

            X87_NOWAIT,

            XMM_STATE_CW,

            XMM_STATE_R,

            XMM_STATE_W,
        }
    }
}