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
        public Index<MacroDef> CalcMacroDefs()
        {
            return Data(nameof(CalcMacroDefs),Calc);

            Index<MacroDef> Calc()
            {
                var src = RuleMacros.specs();
                var count = src.Length;
                var buffer = alloc<MacroDef>(count);
                for(var i=0u; i<count; i++)
                {
                    ref readonly var m = ref src[i];
                    var expansions = m.Expansions;
                    var j=0;
                    var k = m.Expansions.Count;
                    ref var dst = ref seek(buffer,i);
                    dst.Seq = i;
                    dst.Fields = (byte)expansions.Count;
                    dst.MacroName = m.Name;
                    if(k >= 1)
                    {
                        var e0 = expansions[j++];
                    }
                    if(k >= 2)
                    {
                        var e1 = expansions[j++];
                    }
                    if(k >= 3)
                    {
                        var e2 = expansions[j++];
                    }
                    if(k >= 4)
                    {
                        var e3 = expansions[j++];

                    }
                    if(k >= 5)
                    {
                        var e4 = expansions[j++];
                    }
                }

                return buffer;
            }


        }
        public Index<MacroAssignment> CalcMacroAssignments()
        {
            return Data(nameof(CalcMacroAssignments),Calc);

            Index<MacroAssignment> Calc()
            {
                var src = RuleMacros.specs();
                var count = src.Length;
                var buffer = alloc<MacroAssignment>(count);
                for(var i=0u; i<count; i++)
                {
                    ref readonly var m = ref src[i];
                    var expansions = m.Expansions;
                    var j=0;
                    var k = m.Expansions.Count;
                    ref var dst = ref seek(buffer,i);
                    dst.Seq = i;
                    dst.Fields = (byte)expansions.Count;
                    dst.MacroName = m.Name;
                    if(k >= 1)
                        dst.A0 = expansions[j++];
                    if(k >= 2)
                        dst.A1 = expansions[j++];
                    if(k >= 3)
                        dst.A2 = expansions[j++];
                    if(k >= 4)
                        dst.A3 = expansions[j++];
                    if(k >= 5)
                        dst.A4 = expansions[j++];
                }

                return buffer;
            }
        }
    }
}