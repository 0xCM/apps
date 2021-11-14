//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedModels.RegId;
    using static XedModels.EASZ;
    using static XedModels.SAMode;

    partial struct XedRules
    {
        [Op]
        public static RegId ArAX(EASZ easz)
            => easz switch
            {
                easz16 => AX,
                easz32 => EAX,
                easz64 => RAX,
                _ => 0
            };

        [Op]
        public static RegId ArBX(EASZ easz)
            => easz switch
            {
                easz16 => BX,
                easz32 => EBX,
                easz64 => RAX,
                _ => 0
            };

        [Op]
        public static RegId ArCX(EASZ easz)
            => easz switch
            {
                easz16 => CX,
                easz32 => ECX,
                easz64 => RCX,
                _ => 0
            };

        [Op]
        public static RegId ArDX(EASZ easz)
            => easz switch
            {
                easz16 => DX,
                easz32 => EDX,
                easz64 => RDX,
                _ => 0
            };

        [Op]
        public static RegId ArSI(EASZ easz)
            => easz switch
            {
                easz16 => SI,
                easz32 => ESI,
                easz64 => RSI,
                _ => 0
            };

        [Op]
        public static RegId ArDI(EASZ easz)
            => easz switch
            {
                easz16 => DI,
                easz32 => EDI,
                easz64 => RDI,
                _ => 0
            };

        [Op]
        public static RegId ArSP(EASZ easz)
            => easz switch
            {
                easz16 => SP,
                easz32 => ESP,
                easz64 => RSP,
                _ => 0
            };

        [Op]
        public static RegId ArBP(EASZ easz)
            => easz switch
            {
                easz16 => BP,
                easz32 => EBP,
                easz64 => RBP,
                _ => 0
            };

        [Op]
        public static RegId SrSP(SAMode easz)
            => easz switch
            {
                smode16 => SP,
                smode32 => ESP,
                smode64 => RSP,
                _ => 0
            };

        [Op]
        public static RegId SrBP(SAMode easz)
            => easz switch
            {
                smode16 => BP,
                smode32 => EBP,
                smode64 => RBP,
                _ => 0
            };
    }
}