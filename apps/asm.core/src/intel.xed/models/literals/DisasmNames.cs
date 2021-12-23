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
            public const string DISP_WIDTH = nameof(DISP_WIDTH);

            /// <summary>
            /// A numeric value from <see cref='M.EASZ'/>
            /// </summary>
            public const string EASZ = nameof(EASZ);

            public const string ELEMENT_SIZE = nameof(ELEMENT_SIZE);

            /// <summary>
            /// A numeric value from <see cref='M.EOSZ'/>
            /// </summary>
            public const string EOSZ = nameof(EOSZ);

            /// <summary>
            /// A bit indicating whether an instruction has a ModRM byte
            /// </summary>
            public const string HAS_MODRM = nameof(HAS_MODRM);

            /// <summary>
            /// A bit indicating whether an instruction has a SIB byte
            /// </summary>
            public const string HAS_SIB = nameof(HAS_SIB);

            /// <summary>
            /// A base-16 integer that specifies the value of an immediate
            /// </summary>
            public const string IMM0 = nameof(IMM0);

            public const string IMM_WIDTH = nameof(IMM_WIDTH);

            /// <summary>
            /// Indicator
            /// </summary>
            public const string LZCNT = nameof(LZCNT);

            /// <summary>
            /// A numeric value from <see cref='M.OpCodeMap'/>
            /// </summary>
            public const string MAP = nameof(MAP);

            public const string MASK = nameof(MASK);

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
            /// An integer from <see cref='M.Mode'/>
            /// </summary>
            public const string MODE = nameof(MODE);

            /// <summary>
            /// An 8-bit base-10 integer that specifies the value of the ModRm bytee
            /// </summary>
            public const string MODRM_BYTE = nameof(MODRM_BYTE);

            public const string NEED_MEMDISP = nameof(NEED_MEMDISP);

            public const string NELEM = nameof(NELEM);

            public const string NPREFIXES = nameof(NPREFIXES);

            public const string NREXES = nameof(NREXES);

            /// <summary>
            /// A base-10 representation of the primary 8-bit opcode
            /// </summary>
            public const string NOMINAL_OPCODE = nameof(NOMINAL_OPCODE);

            /// <summary>
            /// An identifier from <see cref='M.RegId'/>
            /// </summary>
            public const string OUTREG = nameof(OUTREG);

            public const string POS_DISP = nameof(POS_DISP);

            public const string POS_IMM = nameof(POS_IMM);

            public const string POS_MODRM = nameof(POS_MODRM);

            public const string POS_NOMINAL_OPCODE = nameof(POS_NOMINAL_OPCODE);

            public const string POS_SIB = nameof(POS_SIB);

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

            public const string SIBINDEX = nameof(SIBINDEX);

            public const string SIBSCALE = nameof(SIBSCALE);

            public const string SMODE = nameof(SMODE);

            public const string SRM = nameof(SRM);

            public const string TZCNT = nameof(TZCNT);

            public const string UBIT = nameof(UBIT);

            public const string USING_DEFAULT_SEGMENT0 = nameof(USING_DEFAULT_SEGMENT0);

            public const string VEXDEST210 = nameof(VEXDEST210);

            public const string VEXDEST4 = nameof(VEXDEST4);

            public const string VEXVALID = nameof(VEXVALID);

            public const string VEX_PREFIX = nameof(VEX_PREFIX);
        }
    }
}