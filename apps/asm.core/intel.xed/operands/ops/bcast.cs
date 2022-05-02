//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static core;

    partial class XedOperands
    {
        [MethodImpl(Inline), Op]
        public static bool bcast(in PatternOp src, out BCastKind dst)
        {
            dst = 0;
            if(src.Kind == OpKind.Bcast)
                if(XedParsers.parse(src.SourceExpr, out dst))
                    return true;
            return false;
        }

        [MethodImpl(Inline), Op]
        public static ref readonly BCastKind bcast(in OperandState src)
            => ref @as<BCastKind>(src.BCAST);

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref BCastKind bcast(ref OperandState src)
                => ref @as<BCastKind>(src.BCAST);
        }
    }
}