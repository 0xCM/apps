//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;
    using static XedPatterns;
    using static XedModels;
    using static XedFields;

    partial class XedPatterns
    {
    }

    partial class XedRules
    {
        Index<PatternOpCode> CalcPatternOpCodes(Index<InstPattern> src)
        {
            var count = src.Count;
            var buffer = alloc<PatternOpCode>(count);
            for(var i=0; i<count; i++)
                poc(src[i], out seek(buffer,i));
            return buffer;
        }

        void EmitOpCodes(Index<InstPattern> src)
        {
            var opcodes = CalcPatternOpCodes(src);
            TableEmit(opcodes.View, PatternOpCode.RenderWidths, XedPaths.Table<PatternOpCode>());
        }

        static void poc(in InstPattern pattern, out PatternOpCode dst)
        {
            dst = default;
            (var fields, var layout) = split(pattern.Body);
            dst.PatternId = pattern.PatternId;
            dst.OpCode = pattern.OpCode;
            dst.Class = pattern.Class;
            dst.LOCK = LockIndicator.None;

            var lookup = mapi(fields, (i,p) => ((byte)i, p)).ToDictionary();
            var remainder = list<InstDefPart>();

            for(byte j=0; j<fields.PartCount; j++)
            {
                ref readonly var part = ref fields[j];

                if(part.PartKind == DefSegKind.FieldAssign)
                {
                    var a = part.AsAssign();
                    switch(a.Field)
                    {
                        case FieldKind.MODE:
                            dst.Mode = (ModeKind)a.Value;
                        break;
                        case FieldKind.MOD:
                            dst.MOD = ModKind.specific(a.Value);
                        break;
                        case FieldKind.LOCK:
                            dst.LOCK = (LockIndicator)a.Value;
                        break;
                        case FieldKind.OSZ:
                            dst.OSZ = XedFields.osz(a.Value);
                        break;
                        case FieldKind.EOSZ:
                            dst.EOSZ = (EOSZ)a.Value;
                        break;
                        case FieldKind.VEXVALID:
                            dst.VEXVALID = (VexClass)a.Value;
                        break;
                        case FieldKind.VEX_PREFIX:
                            dst.VEX_PREFIX = (VexKind)a.Value;
                        break;
                        default:
                            remainder.Add(part);
                        break;
                    }
                }
                else if(part.PartKind == DefSegKind.Constraint)
                {
                    var c = part.AsConstraint();
                    switch(c.Field)
                    {
                        case FieldKind.MOD:
                            dst.MOD = ModKind.constrain();
                            lookup.Remove(j);
                        break;
                        default:
                            remainder.Add(part);
                        break;
                    }
                }
                }

            InstPatternBody b = remainder.ToArray();
            dst.Fields = b.Format();
            dst.Layout = layout.Format();
        }

        static Pair<InstPatternBody> split(in InstPatternBody src)
        {
            var criteria = dict<byte,InstDefPart>();
            var parts = mapi(src, (i,p) => ((byte)i, p)).ToDictionary();

            var count = src.PartCount;
            for(byte i=0; i<count; i++)
            {
                ref readonly var part = ref src[i];
                switch(part.PartKind)
                {
                    case DefSegKind.Constraint:
                    case DefSegKind.FieldAssign:
                        criteria[i] = part;
                        parts.Remove(i);
                    break;
                    default:
                        break;
                }
            }

            var right = alloc<InstDefPart>(parts.Count);
            var keys = parts.Keys.Array().Sort();
            for(var i=0; i<keys.Length; i++)
                seek(right,i) = parts[skip(keys,i)];

            var left = alloc<InstDefPart>(criteria.Count);
            keys = criteria.Keys.Array().Sort();
            for(var i=0; i<keys.Length; i++)
                seek(left,i) = criteria[skip(keys,i)];

            return (left,right);
        }

    }
}