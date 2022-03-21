//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static Root;
    using static XedModels;

    partial class XedRules
    {
        [ApiHost]
        public readonly struct InstDefs
        {
            public static Index<InstPattern> patterns(Index<InstDef> defs, bool pll = true)
            {
                var dst = bag<InstPattern>();
                iter(defs, def => patterns(def, dst), pll);
                return dst.ToArray().Sort();
            }

            public static Index<InstPatternInfo> describe(Index<InstDef> src, bool pll = true)
            {
                var dst = bag<InstPatternInfo>();
                iter(src, def => describe(def,dst), pll);
                return dst.ToArray().Sort();
            }

            public static Index<InstPatternInfo> describe(Index<InstPattern> src, bool pll = true)
            {
                var parser = XedOpCodeParser.create();
                var count = src.Count;
                var dst = bag<InstPatternInfo>();
                iter(src, p => dst.Add(describe(p)), pll);
                return dst.Array().Sort();
            }

            static void describe(in InstDef def, ConcurrentBag<InstPatternInfo> dst)
            {
                var specs = def.PatternSpecs;
                for(var j=0; j<specs.Count; j++)
                    dst.Add(describe(specs[j]));
            }

            public static InstPatternInfo describe(InstPattern src)
            {
                ref readonly var body = ref src.Body;
                var dst = InstPatternInfo.Empty;
                var opcode = XedOpCodeParser.create().Parse(src);
                dst.PatternId = src.PatternId;
                dst.InstId = src.InstId;
                dst.OcIndex = XedRules.ocindex(opcode.Kind);
                dst.Class = src.Class;
                dst.OpCode = opcode.Value;
                dst.Body = XedRender.format(body);
                return dst;
            }

            public static InstPatternInfo describe(InstPatternSpec src)
            {
                ref readonly var body = ref src.Body;
                var dst = InstPatternInfo.Empty;
                var opcode = XedOpCodeParser.create().Parse(src);
                dst.PatternId = src.PatternId;
                dst.InstId = src.InstId;
                dst.OcIndex = XedRules.ocindex(opcode.Kind);
                dst.Class = src.Class;
                dst.OpCode = opcode.Value;
                dst.Body = XedRender.format(body);
                return dst;
            }

            public static OpCodeIndex ocindex(in InstPatternBody src)
            {
                var dst = default(OpCodeIndex);
                var _vex = vex(src);
                var _map = z8;
                for(var i=0; i<src.PartCount; i++)
                {
                    if(map(src[i], out _map))
                    {
                        switch(_vex)
                        {
                            case VexClass.VV1:
                                var vv1 = (VexMapKind)_map;
                                break;
                            case VexClass.EVV:
                                var evv = (EvexMapKind)_map;
                                break;
                            case VexClass.XOPV:
                                var xop = (XopMapKind)_map;
                                break;
                            default:
                                var legacy = (LegacyMapKind)_map;
                                break;
                        }
                    }
                }
                return dst;
            }

            static void patterns(in InstDef def, ConcurrentBag<InstPattern> dst)
            {
                var specs = def.PatternSpecs;
                var buffer = list<InstPatternOps>();
                for(var j=0; j<specs.Count; j++)
                {
                    ref readonly var spec = ref specs[j];
                    buffer.Clear();
                    for(byte k=0; k<spec.OpSpecs.Count; k++)
                        buffer.Add(ops(spec,k));
                    dst.Add(new InstPattern(def, spec, buffer.ToArray()));
                }
            }

            static InstPatternOps ops(in InstPatternSpec src, byte k)
            {
                ref readonly var ops = ref src.OpSpecs;
                ref readonly var op = ref ops[k];
                var detail = InstPatternOps.Empty;
                var spec = RuleOpParser.parse(k, op.Name, op.Expression);
                var attribs = spec.Attribs.Sort();
                detail.InstId = src.InstId;
                detail.PatternId = src.PatternId;
                detail.OpIndex = op.Index;
                detail.Name = spec.Name;
                detail.Kind = spec.Kind;
                detail.Expression = op.Expression;
                detail.Mnemonic = src.Class;
                var opwidth = OpWidthCode.INVALID;
                if(attribs.Search(RuleOpClass.Action, out var action))
                    detail.Action = action;
                if(attribs.Search(RuleOpClass.OpWidth, out var w))
                {
                    detail.WidthCode = w;
                    opwidth = w.AsOpWidth();
                    detail.BitWidth = XedModels.bitwidth(opwidth);
                }
                if(attribs.Search(RuleOpClass.ElementType, out var et))
                {
                    detail.CellType = et;
                    detail.CellWidth = bitwidth(opwidth,et.AsElementType());
                }
                if(attribs.Search(RuleOpClass.RegLiteral, out var reglit))
                {
                    detail.RegLit = reglit;
                    detail.BitWidth = XedModels.bitwidth(reglit.AsRegLiteral());
                }
                if(attribs.Search(RuleOpClass.Modifier, out var mod))
                    detail.Modifier = mod;
                if(attribs.Search(RuleOpClass.Visibility, out var visib))
                    detail.Visibility = visib;

                return detail;
            }

            public static OpCodeIndex ocindex(in InstDefPart src)
            {
                InstDefs.map(src, out var map);
                vexclass(src, out var vc);
                switch(vc)
                {
                    case VexClass.VV1:
                        return XedRules.ocindex((VexMapKind)map);
                    case VexClass.EVV:
                        return XedRules.ocindex((EvexMapKind)map);
                    case VexClass.XOPV:
                        return XedRules.ocindex((XopMapKind)map);
                    default:
                        return (OpCodeIndex)map;
                }
            }

            public static VexClass vex(in InstPatternBody src)
            {
                var result = default(VexClass);
                if(src.PartCount != 0)
                {
                    var k = (VexClass)src[0].AsIntLit();

                    switch(k)
                    {
                        case VexClass.VV1:
                        case VexClass.EVV:
                        case VexClass.XOPV:
                        case VexClass.KVV:
                            result = k;
                        break;
                        default:
                            result = VexClass.None;
                        break;
                    }
                }
                return result;
            }

            [MethodImpl(Inline), Op]
            public static bool vexclass(in InstDefPart src, out VexClass dst)
            {
                var result = false;
                dst = default;
                if(src.PartKind == DefSegKind.FieldAssign)
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
            public static bool vexkind(in InstDefPart src, out VexKind dst)
            {
                var result = false;
                dst = default;
                if(src.PartKind == DefSegKind.FieldAssign)
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
            public static bool vexmap(in InstDefPart src, out VexMapKind dst)
            {
                var result = false;
                dst = default;
                if(src.PartKind == DefSegKind.FieldAssign)
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
            public static bool map(in InstDefPart src, out byte dst)
            {
                var result = false;
                dst = default;
                if(src.PartKind == DefSegKind.FieldAssign)
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
            public static bool evexmap(in InstDefPart src, out EvexMapKind dst)
            {
                var result = false;
                dst = default;
                if(src.PartKind == DefSegKind.FieldAssign)
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