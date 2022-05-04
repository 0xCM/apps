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
        public static bool scale(in PatternOp src, out MemoryScale dst)
        {
            var result = XedPatterns.first(src.Attribs, OpAttribClass.Scale, out var attrib);
            if(result)
                dst = attrib.ToScale();
            else
                dst = default;

            return result;
        }

        [MethodImpl(Inline), Op]
        public static ref readonly MemoryScale scale(in OperandState src)
            => ref @as<MemoryScale>(src.SCALE);

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref MemoryScale scale(in OperandState src)
                => ref @as<MemoryScale>(src.SCALE);
        }
    }
}