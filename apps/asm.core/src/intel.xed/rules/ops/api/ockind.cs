//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Sources     : all-map-descriptions.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels.OpCodeKind;
    using static XedModels;
    using static core;
    using OCP = XedModels.OcPatternNames;

    partial class XedRules
    {

        internal static void render(ReadOnlySpan<RuleCriterion> src, ITextBuffer dst)
        {
            var count = src.Length;

            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(" && ");
                ref readonly var c = ref skip(src,i);
                dst.Append(c.Format());
            }
        }

        internal static string format(in XedRuleExpr src)
        {
            var sep = src.Kind == RuleFormKind.EncodeStep ? " -> " : " | ";
            var dst = text.buffer();
            render(src.LeftCriteria, dst);
            dst.Append(sep);
            render(src.RightCriteria, dst);
            return dst.Emit();
        }

        public static OpCodeKind ockind(string rule)
        {
            var content = rule;
            var i = NotFound;
            var identity = OpCodeKind.None;

            i = text.index(content, OCP.VexMapClass);
            if(i >= 0)
            {
                i = text.index(content, OCP.VexPattern0F38);
                if(i>=0)
                    return VEX_MAP_0F38;

                i = text.index(content, OCP.VexPattern0F3A);
                if(i>=0)
                    return VEX_MAP_0F3A;

                i = text.index(content, OCP.VexPattern0F);
                if(i>=0)
                    return VEX_MAP_0F;

                return 0;
            }

            i = text.index(content, OCP.EvexMapClass);
            if(i >= 0)
            {
                i = text.index(content, OCP.EvexPattern0F38);
                if(i>=0)
                    return EVEX_MAP_0F38;

                i = text.index(content, OCP.EvexPattern0F3A);
                if(i>=0)
                    return EVEX_MAP_0F3A;

                i = text.index(content, OCP.EvexPattern0F);
                if(i>=0)
                    return EVEX_MAP_0F;

                return 0;
            }

            i = text.index(content, OCP.LegacyPattern2);
            if(i >= 0)
                return LEGACY_MAP2;

            i = text.index(content, OCP.LegacyPattern3);
            if(i >= 0)
                return LEGACY_MAP3;

            i = text.index(content, OCP.Amd3dNowPattern);
            if(i >= 0)
                return AMD_3DNOW;

            i = text.index(content, OCP.LegacyPattern1);
            if(i >= 0)
                return LEGACY_MAP1;

            i = text.index(content, OCP.XopPattern8);
            if(i >= 0)
                return XOP8;

            i = text.index(content, OCP.XopPattern9);
            if(i >= 0)
                return XOP9;

            i = text.index(content, OCP.XopPatternA);
            if(i >= 0)
                return XOPA;

            return LEGACY_MAP0;
        }
    }
}