//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using Asm;

    partial class XedRules
    {
        public struct XedOpCodeParser
        {
            public static XedOpCodeParser create()
                => new XedOpCodeParser();

            VexClass? VClass;

            VexKind? VKind;

            OpCodeIndex? OcIndex;

            sbyte Map;

            InstPatternInfo Result;

            AsmOcValue OcValue;

            void Clear()
            {
                VClass = null;
                VKind = null;
                Map = -1;
                OcIndex = null;
                Result = InstPatternInfo.Empty;
            }

            public XedOpCode Parse(InstPattern src)
            {
                Clear();
                ref readonly var body = ref src.Body;
                OcValue = XedPatterns.ocvalue(body);
                for(var i=0; i<body.PartCount; i++)
                    Parse(body[i]);
                CalcOcIndex();
                return new XedOpCode(src.PatternId, src.Class, OcIndex != null ? XedPatterns.ockind(OcIndex.Value) : OpCodeKind.None, OcValue);
            }

            public XedOpCode Parse(InstPatternSpec src)
            {
                Clear();
                ref readonly var body = ref src.Body;
                OcValue = XedPatterns.ocvalue(body);
                for(var i=0; i<body.PartCount; i++)
                    Parse(body[i]);
                CalcOcIndex();
                return new XedOpCode(src.PatternId, src.Class, OcIndex != null ? XedPatterns.ockind(OcIndex.Value) : OpCodeKind.None, OcValue);
            }

            void CalcOcIndex()
            {
                if(OcIndex == null)
                {
                    if(OcValue[0] == 0x0F)
                    {
                        if(OcValue[1] == 0x38)
                            OcIndex = OpCodeIndex.LegacyMap2;
                        else if(OcValue[1] == 0x3A)
                            OcIndex = OpCodeIndex.LegacyMap3;
                        else
                            OcIndex = OpCodeIndex.LegacyMap1;
                    }
                    else
                        OcIndex = OpCodeIndex.LegacyMap0;
                }
            }

            void Parse(in InstDefPart src)
            {
                if(XedPatterns.vexclass(src, out var vc))
                    VClass = vc;
                else if(XedPatterns.vexkind(src, out var vk))
                    VKind = vk;
                else if(XedPatterns.map(src, out var map))
                {
                    Map = (sbyte)map;
                    if(VClass != null)
                    {
                        switch(VClass.Value)
                        {
                            case VexClass.None:
                            case VexClass.VV1:
                            {
                                OcIndex = XedPatterns.ocindex((VexMapKind)Map);
                            }
                            break;
                            case VexClass.EVV:
                            {
                                OcIndex = XedPatterns.ocindex((EvexMapKind)Map);
                            }
                            break;
                            case VexClass.XOPV:
                            {
                                OcIndex = XedPatterns.ocindex((XopMapKind)Map);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}