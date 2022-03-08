//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = XedRules.FieldKind;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1,Size=64), Record(TableId)]
        public struct StateFlags
        {
            public const string TableId = "xed.rules.state.flags";

            [RuleField(K.ASZ, 1)]
            public bit ASZ;

            [RuleField(K.OSZ, 1)]
            public bit OSZ;

            [RuleField(K.DF32, 1)]
            public bit DF32;

            [RuleField(K.DF64, 1)]
            public bit DF64;

            [RuleField(K.NO_SCALE_DISP8, 1)]
            public bit NO_SCALE_DISP8;

            [RuleField(K.AMD3DNOW, 1)]
            public bit AMD3DNOW;

            [RuleField(K.BCRC, 1)]
            public bit BCRC;

            [RuleField(K.CET, 1)]
            public bit CET;

            [RuleField(K.CLDEMOTE, 1)]
            public bit CLDEMOTE;

            [RuleField(K.DUMMY, 1)]
            public bit DUMMY;

            [RuleField(K.ENCODER_PREFERRED, 1)]
            public bit ENCODER_PREFERRED;

            [RuleField(K.ENCODE_FORCE, 1)]
            public bit ENCODE_FORCE;

            [RuleField(K.IMM0, 1)]
            public bit IMM0;

            [RuleField(K.IMM0SIGNED, 1)]
            public bit IMM0SIGNED;

            [RuleField(K.IMM1, 1)]
            public bit IMM1;

            [RuleField(K.LZCNT, 1)]
            public bit LZCNT;

            [RuleField(K.TZCNT, 1)]
            public bit TZCNT;

            [RuleField(K.MODEP5, 1)]
            public bit MODEP5;

            [RuleField(K.MODEP55C, 1)]
            public bit MODEP55C;

            [RuleField(K.MODE_FIRST_PREFIX, 1)]
            public bit MODE_FIRST_PREFIX;

            [RuleField(K.MODE_SHORT_UD0, 1)]
            public bit MODE_SHORT_UD0;

            [RuleField(K.MPXMODE, 1)]
            public bit MPXMODE;

            [RuleField(K.OUT_OF_BYTES, 1)]
            public bit OUT_OF_BYTES;

            [RuleField(K.P4, 1)]
            public bit P4;

            [RuleField(K.PTR, 1)]
            public bit PTR;

            [RuleField(K.AGEN, 1)]
            public bit AGEN;

            [RuleField(K.MEM0, 1)]
            public bit MEM0;

            [RuleField(K.MEM1, 1)]
            public bit MEM1;

            [RuleField(K.LOCK, 1)]
            public bit LOCK;

            [RuleField(K.PREFIX66, 1)]
            public bit PREFIX66;

            [RuleField(K.HAS_MODRM, 1)]
            public bit HAS_MODRM;

            [RuleField(K.HAS_SIB, 1)]
            public bit HAS_SIB;

            [RuleField(K.NEED_SIB, 1)]
            public bit NEED_SIB;

            [RuleField(K.NEEDREX, 1)]
            public bit NEEDREX;

            [RuleField(K.NOREX, 1)]
            public bit NOREX;

            [RuleField(K.REX, 1)]
            public bit REX;

            [RuleField(K.VEX_C4, 1)]
            public bit VEX_C4;

            [RuleField(K.MUST_USE_EVEX, 1)]
            public bit MUST_USE_EVEX;

            [RuleField(K.ZEROING, 1)]
            public bit ZEROING;

            [RuleField(K.SAE, 1)]
            public bit SAE;

            [RuleField(K.REALMODE, 1)]
            public bit REALMODE;

            [RuleField(K.UBIT, 1)]
            public bit UBIT;

            [RuleField(K.WBNOINVD, 1)]
            public bit WBNOINVD;

            [RuleField(K.ILD_F2, 1)]
            public bit ILD_F2;

            [RuleField(K.ILD_F3, 1)]
            public bit ILD_F3;

            [RuleField(K.NEED_MEMDISP, 1)]
            public bit NEED_MEMDISP;

            [RuleField(K.NO_RETURN, 1)]
            public bit NO_RETURN;

            [RuleField(K.USING_DEFAULT_SEGMENT0, 1)]
            public bit USING_DEFAULT_SEGMENT0;

            [RuleField(K.USING_DEFAULT_SEGMENT1, 1)]
            public bit USING_DEFAULT_SEGMENT1;

            [RuleField(K.RELBR, 1)]
            public bit RELBR;
        }
    }
}