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

            XedOpCode Result;

            AsmOcValue OcValue;

            void Clear()
            {
                VClass = null;
                VKind = null;
                Map = -1;
                OcIndex = null;
                Result = XedOpCode.Empty;
            }

            public XedOpCode Parse(in InstPattern src)
            {
                Clear();
                ref readonly var body = ref src.Body;
                Result.PatternId = src.PatternId;
                Result.InstId = src.InstId;
                Result.Pattern = XedRender.format(body);
                Result.Class = src.Class;

                OcValue = ocvalue(body);
                for(var i=0; i<body.PartCount; i++)
                    Parse(body[i]);

                if(OcIndex == null)
                {
                    if(OcValue[0] == 0x0F)
                    {
                        if(OcValue[1] == 0x38)
                        {
                            OcIndex = OpCodeIndex.LegacyMap2;
                        }
                        else if(OcValue[1] == 0x3A)
                        {
                            OcIndex = OpCodeIndex.LegacyMap3;

                        }
                        else
                            OcIndex = OpCodeIndex.LegacyMap1;
                    }
                    else
                        OcIndex = OpCodeIndex.LegacyMap0;
                }

                Result.Value = OcValue;
                if(OcIndex != null)
                {
                    Result.Index = (sbyte)OcIndex.Value;
                    Result.Kind = ockind(OcIndex.Value);
                }
                else
                {
                    Result.Index = -1;
                }

                return Result;
            }

            void Parse(in InstDefSeg src)
            {
                if(InstDefs.vexclass(src, out var vc))
                {
                    VClass = vc;
                }
                else if(InstDefs.vexkind(src, out var vk))
                {
                    VKind = vk;
                }
                else if(InstDefs.map(src, out var map))
                {
                    Map = (sbyte)map;
                    if(VClass != null)
                    {
                        switch(VClass.Value)
                        {
                            case VexClass.VV0:
                            case VexClass.VV1:
                            {
                                OcIndex = ocindex((VexMapKind)Map);
                            }
                            break;
                            case VexClass.EVV:
                            {
                                OcIndex = ocindex((EvexMapKind)Map);
                            }
                            break;
                            case VexClass.XOPV:
                            {
                                OcIndex = ocindex((XopMapKind)Map);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}