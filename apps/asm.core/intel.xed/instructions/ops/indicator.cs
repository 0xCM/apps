//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public static Hex16 indicator(in InstGroupSeq gs)
        {
            ref readonly var mod = ref gs.Mod;
            ref readonly var rexw = ref gs.RexW;
            ref readonly var @lock = ref gs.Lock;
            var discrim = EmptyString;
            if(@lock.Lockable)
            {
                discrim = @lock.Locked ? "11" : "01";
            }
            else
                discrim = "00";

            if(rexw.IsNonEmpty)
            {
                var indicator = rexw.Indicator;
                if(indicator == RexIndicator.W)
                    discrim += "1000";
                else if(indicator == RexIndicator.R)
                    discrim += "0100";
                else if(indicator == RexIndicator.X)
                    discrim += "0010";
                else if(indicator == RexIndicator.B)
                    discrim += "0001";

            }
            else
                discrim += "0000";

            if(mod.IsNonEmpty)
            {
                switch(mod.Indicator)
                {
                    case ModIndicator.MOD0:
                        discrim += "1100";
                    break;
                    case ModIndicator.ANY:
                        discrim += "0100";
                    break;
                    case ModIndicator.MOD1:
                        discrim += "0001";
                    break;
                    case ModIndicator.MOD2:
                        discrim += "0010";
                    break;
                    case ModIndicator.MOD3:
                        discrim += "0011";
                    break;
                    case ModIndicator.NE3:
                        discrim += "1000";
                    break;
                }
            }
            else
                discrim += "0000";

            BitParser.parse(discrim, out ushort n);
            return n;
        }
    }
}