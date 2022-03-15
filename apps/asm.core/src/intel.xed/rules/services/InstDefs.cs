//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;
    using static XedModels;

    partial class XedRules
    {
        [ApiHost]
        public readonly struct InstDefs
        {
            public static VexClass? vex(in InstPatternBody src)
            {
                var result = default(VexClass?);
                for(var i=0; i<src.PartCount; i++)
                {
                    ref readonly var part = ref src[i];
                    if(part.Kind == DefSegKind.FieldAssign)
                    {
                        ref readonly var assign = ref part.AsAssign();
                        if(assign.Field == FieldKind.VEXVALID)
                        {
                            result = (VexClass)assign.Value.Data;
                            break;
                        }
                    }
                }
                return result;
            }

            [MethodImpl(Inline), Op]
            public static bool vexclass(in InstDefSeg src, out VexClass dst)
            {
                var result = false;
                dst = default;
                if(src.Kind == DefSegKind.FieldAssign)
                {
                    ref readonly var assign = ref src.AsAssign();
                    if(assign.Field == FieldKind.VEXVALID)
                    {
                        dst = (VexClass)assign.Value.Data;
                        result = true;
                    }
                }

                return result;
            }

            [MethodImpl(Inline), Op]
            public static bool vexkind(in InstDefSeg src, out VexKind dst)
            {
                var result = false;
                dst = default;
                if(src.Kind == DefSegKind.FieldAssign)
                {
                    ref readonly var assign = ref src.AsAssign();
                    if(assign.Field == FieldKind.VEX_PREFIX)
                    {
                        dst = (VexKind)assign.Value.Data;
                        result = true;
                    }
                }

                return result;
            }

            [MethodImpl(Inline), Op]
            public static bool vexmap(in InstDefSeg src, out VexMapKind dst)
            {
                var result = false;
                dst = default;
                if(src.Kind == DefSegKind.FieldAssign)
                {
                    ref readonly var assign = ref src.AsAssign();
                    if(assign.Field == FieldKind.MAP)
                    {
                        dst = (VexMapKind)assign.Value.Data;
                        result = true;
                    }
                }

                return result;
            }

            [MethodImpl(Inline), Op]
            public static bool map(in InstDefSeg src, out byte dst)
            {
                var result = false;
                dst = default;
                if(src.Kind == DefSegKind.FieldAssign)
                {
                    ref readonly var assign = ref src.AsAssign();
                    if(assign.Field == FieldKind.MAP)
                    {
                        dst = (byte)assign.Value;
                        result = true;
                    }
                }

                return result;
            }

            [MethodImpl(Inline), Op]
            public static bool evexmap(in InstDefSeg src, out EvexMapKind dst)
            {
                var result = false;
                dst = default;
                if(src.Kind == DefSegKind.FieldAssign)
                {
                    ref readonly var assign = ref src.AsAssign();
                    if(assign.Field == FieldKind.MAP)
                    {
                        dst = (EvexMapKind)assign.Value.Data;
                        result = true;
                    }
                }

                return result;
            }
        }
    }
}