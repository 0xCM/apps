//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static uint assigned(in MacroAssignment src, ref uint i, Span<FieldAssign> dst)
        {
            var i0 = i;
            var count = src.Assigned;
            if(count >= 1)
                seek(dst,i++) = src.A0;
            if(count >= 2)
                seek(dst,i++) = src.A1;
            if(count >= 3)
                seek(dst,i++) = src.A2;
            if(count >= 4)
                seek(dst,i++) = src.A3;
            if(count >= 5)
                seek(dst,i++) = src.A4;
            return i - i0;
        }

        [Op]
        public static uint expand(RuleToken src, Span<FieldAssign> dst)
        {
            var i=0u;
            return expand(src, ref i, dst);
        }

        [Op]
        public static uint expand(RuleToken src, ref uint i, Span<FieldAssign> dst)
        {
            var count = 0u;
            if(src.IsMacro)
            {
                var macro = MacroLookup[src.AsMacro()];
                count = macro.Assignments.Count;
                for(var j=0; j<count; j++)
                    seek(dst,i++) = macro.Assignments[j];
            }
            return count;
        }
    }
}