//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using M = XedModels;

    partial struct XedModels
    {
        [LiteralProvider("xed.names.disasm")]
        internal readonly struct DisasmNames
        {
            /// <summary>
            /// A bit indicating whether an instruction has a ModRM byte
            /// </summary>
            public const string HAS_MODRM = nameof(HAS_MODRM);

            /// <summary>
            /// A bit indicating whether an instruction has a SIB byte
            /// </summary>
            public const string HAS_SIB = nameof(HAS_SIB);

            /// <summary>
            /// A base-10 positive integer no greater than 15
            /// </summary>
            public const string MAX_BYTES = nameof(MAX_BYTES);

            /// <summary>
            /// A memory reference expression
            /// </summary>
            public const string MEM0 = nameof(MEM0);

            /// <summary>
            /// A 2-bit base-10 integer that specifes the MOD part of the ModRM bitfield
            /// </summary>
            public const string MOD = nameof(MOD);

            /// <summary>
            /// An 8-bit base-10 integer that specifies the value of the ModRm bytee
            /// </summary>
            public const string MODRM_BYTE = nameof(MODRM_BYTE);

            /// <summary>
            /// A base-10 representation of the primary 8-bit opcode
            /// </summary>
            public const string NOMINAL_OPCODE = nameof(NOMINAL_OPCODE);

            /// <summary>
            /// A 3-bit base-10 integer that specifes the REG part of the ModRM bitfield
            /// </summary>
            public const string REG = nameof(REG);

            /// <summary>
            /// An identifier from <see cref='M.RegId'/>
            /// </summary>
            public const string REG0 = nameof(REG0);

            /// <summary>
            /// An identifier from <see cref='M.RegId'/>
            /// </summary>
            public const string REG1 = nameof(REG1);

            /// <summary>
            /// An identifier from <see cref='M.RegId'/>
            /// </summary>
            public const string REG2 = nameof(REG2);

            /// <summary>
            /// An indicator, when present, that specifies Rex is applicable
            /// </summary>
            public const string REX = nameof(REX);

            /// <summary>
            /// An indicator, when present, that specifies RexB is applicable
            /// </summary>
            public const string REXB = nameof(REXB);

            /// <summary>
            /// An indicator, when present, that specifies RexW is applicable
            /// </summary>
            public const string REXW = nameof(REXW);

            /// <summary>
            /// An indicator, when present, that specifies RexX is applicable
            /// </summary>
            public const string REXX = nameof(REXX);

            /// <summary>
            /// A 3-bit base-10 integer that specifes the RM part of the ModRM bitfield
            /// </summary>
            public const string RM = nameof(RM);
        }
    }
}