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
        public Index<MacroAssignment> CalcMacroDefs()
        {
            return Data(nameof(CalcMacroDefs),Calc);

            Index<MacroAssignment> Calc()
            {
                var src = RuleMacros.specs();
                var count = src.Length;
                var buffer = alloc<MacroAssignment>(count);
                for(var i=0u; i<count; i++)
                {
                    ref readonly var m = ref src[i];
                    var assignments = m.Assignments;
                    var j=0;
                    var k = m.Assignments.Count;
                    ref var dst = ref seek(buffer,i);
                    dst.Seq = i;
                    dst.Assigned = (byte)assignments.Count;
                    dst.MacroName = m.Name;
                    if(k >= 1)
                        dst.A0 = assignments[j++];
                    if(k >= 2)
                        dst.A1 = assignments[j++];
                    if(k >= 3)
                        dst.A2 = assignments[j++];
                    if(k >= 4)
                        dst.A3 = assignments[j++];
                    if(k >= 5)
                        dst.A4 = assignments[j++];
                }

                return buffer;
            }
        }
    }
}