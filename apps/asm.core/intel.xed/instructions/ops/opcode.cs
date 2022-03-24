//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        public static void poc(InstPattern src, out PatternOpCode dst)
        {
            dst = default;
            (var fields, var layout) = split(src.Body);
            dst.PatternId = src.PatternId;
            dst.OpCode = src.OpCode;
            dst.InstClass = src.InstClass;
            dst.Pattern = src.BodyExpr;

            for(byte j=0; j<fields.FieldCount; j++)
            {
                ref readonly var part = ref fields[j];

                if(part.FieldClass == DefFieldClass.FieldAssign)
                {
                    var a = part.AsAssignment();
                    switch(a.Field)
                    {
                        case FieldKind.MODE:
                            dst.Mode = (ModeKind)a.Value;
                        break;
                        default:
                        break;
                    }
                }
            }

            dst.Layout = layout.Format();
        }

        static Pair<InstPatternBody> split(in InstPatternBody src)
        {
            var criteria = dict<byte,InstDefField>();
            var parts = mapi(src, (i,p) => ((byte)i, p)).ToDictionary();

            var count = src.FieldCount;
            for(byte i=0; i<count; i++)
            {
                ref readonly var part = ref src[i];
                switch(part.FieldClass)
                {
                    case DefFieldClass.Constraint:
                    case DefFieldClass.FieldAssign:
                        criteria[i] = part;
                        parts.Remove(i);
                    break;
                    default:
                        break;
                }
            }

            var right = alloc<InstDefField>(parts.Count);
            var keys = parts.Keys.Array().Sort();
            for(var i=0; i<keys.Length; i++)
                seek(right,i) = parts[skip(keys,i)];

            var left = alloc<InstDefField>(criteria.Count);
            keys = criteria.Keys.Array().Sort();
            for(var i=0; i<keys.Length; i++)
                seek(left,i) = criteria[skip(keys,i)];

            return (left,right);
        }

        public static XedOpCode xedoc(uint pattern, InstPatternBody body)
        {
            var vc = VexClass.None;
            var number = z8;
            var value = ocvalue(body);
            var kind = OpCodeKind.None;
            for(var i=0; i<body.FieldCount; i++)
            {
                ref readonly var part = ref body[i];
                if(part.FieldClass == DefFieldClass.FieldAssign)
                {
                    var assign = part.AsAssignment();
                    if(assign.Field == FieldKind.VEXVALID)
                        vc = (VexClass)assign.Value.Data;
                    else if(assign.Field == FieldKind.MAP)
                        number = (byte)assign.Value.Data;
                }
            }

            switch(vc)
            {
                case VexClass.VV1:
                    kind = ockind(ocindex((VexMapKind)number));
                break;
                case VexClass.XOPV:
                    kind = ockind(ocindex((XopMapKind)number));
                break;
                case VexClass.EVV:
                case VexClass.KVV:
                    kind = ockind(ocindex((EvexMapKind)number));
                break;
                default:
                    kind = ockind((OpCodeIndex)lmap(value));
                break;
            }

            return new XedOpCode(pattern, kind, value);
        }
    }
}