//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedModels.OpNameKind;
    using static core;

    using K = XedModels.OpKind;

    partial class XedPatterns
    {
        public readonly struct PatternOpParser
        {
            [MethodImpl(Inline)]
            public static PatternOpParser create(MachineMode mode)
                => new(mode);

            readonly MachineMode Mode;

            readonly XedLookups Tables;

            public PatternOpParser(MachineMode mode)
            {
                Mode = mode;
                Tables = XedLookups.Data;
            }

            public void Parse(uint pattern, string ops, out PatternOps dst)
            {
                dst = Parse(pattern, ops);
            }

            PatternOps Parse(uint pattern, string ops)
            {
                var buffer = list<PatternOp>();
                var input = text.despace(ops);
                var i = text.index(input,Chars.Hash);
                if(i > 0)
                    input = text.left(input,i);

                var index = z8;
                var parts = input.Contains(Chars.Space) ? text.split(input, Chars.Space) : new string[]{input};
                for(var j=0; j<parts.Length; j++)
                {
                    var spec = PatternOp.Empty;
                    Parse(index, skip(parts,j), ref spec);
                    if(spec.IsNonEmpty)
                    {
                        spec.PatternId = pattern;
                        spec.Index = index++;
                        buffer.Add(spec);
                    }
                    else
                        break;
                }

                return new(pattern,buffer.ToArray());
            }

            void Parse(byte index, string src, ref PatternOp dst)
            {
                var input = text.despace(src);
                var i = text.index(input, Chars.Colon, Chars.Eq);
                var attribs = text.right(src,i);
                dst.SourceExpr = attribs;
                opname(src, out dst.Name);
                Parse(dst.SourceExpr, text.split(dst.SourceExpr, Chars.Colon).Where(text.nonempty), ref dst);
            }

            static bool opname(string src, out OpName dst)
            {
                var input = text.despace(src);
                var i = text.index(input, Chars.Colon);
                var j = text.index(input, Chars.Eq);
                var index = -1;
                if(i > 0 && j > 0)
                    index = i < j ? i : j;
                else if(i>0 && j<0)
                    index = i;
                else if(j>0 && i<0)
                    index = j;

                return XedParsers.parse(text.left(input, index), out  dst);
            }

            void Parse(string expr, string[] props, ref PatternOp dst)
            {
                switch(dst.Name.Kind)
                {
                    case None:
                    break;
                    case REG0:
                    case REG1:
                    case REG2:
                    case REG3:
                    case REG4:
                    case REG5:
                    case REG6:
                    case REG7:
                    case REG8:
                    case REG9:
                        dst.Kind = K.Reg;
                        ParseReg(expr, props, ref dst);
                    break;

                    case INDEX:
                        dst.Kind = K.Index;
                        ParseReg(expr, props, ref dst);
                    break;

                    case BASE0:
                    case BASE1:
                        dst.Kind = K.Base;
                        ParseReg(expr, props, ref dst);
                    break;

                    case SEG0:
                    case SEG1:
                        dst.Kind = K.Seg;
                        ParseReg(expr, props, ref dst);
                    break;

                    case SCALE:
                        dst.Kind = K.Scale;
                        ParseScale(expr, props, ref dst);
                    break;

                    case DISP:
                    {
                        dst.Kind = K.Disp;
                        dst.SourceExpr = expr;
                        dst.Attribs = sys.empty<OpAttrib>();
                    }
                    break;

                    case IMM0:
                    case IMM1:
                    case IMM2:
                        dst.Kind = K.Imm;
                        ParseImm(expr, props, ref dst);
                    break;

                    case MEM0:
                    case MEM1:
                        dst.Kind = K.Mem;
                        ParseMem(expr, props, ref dst);
                    break;

                    case AGEN:
                        dst.Kind = K.Agen;
                        ParseMem(expr, props, ref dst);
                    break;

                    case PTR:
                        dst.Kind = K.Ptr;
                        ParsePtr(expr, props, ref dst);
                    break;

                    case RELBR:
                        dst.Kind = K.RelBr;
                        ParseRelBr(expr, props, ref dst);
                    break;

                    default:
                        Errors.Throw(string.Format("Unhandled:{0}", dst.Name));
                    break;
                 }
            }

            void ParsePtr(string expr, Index<string> props, ref PatternOp dst)
            {
                var count = props.Count;
                dst.SourceExpr = expr;
                var action = OpAction.None;
                var width = OpWidthCode.INVALID;
                Span<OpAttrib> buffer = stackalloc OpAttrib[4];
                var i=0;

                if(count >= 1)
                {
                    if(XedParsers.parse(props[0], out action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(XedParsers.parse(props[1], out width))
                        seek(buffer,i++) = width;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            void ParseRelBr(string expr, Index<string> props, ref PatternOp dst)
            {
                var count = props.Count;
                dst.SourceExpr = expr;
                var action = OpAction.None;
                var width = OpWidthCode.INVALID;
                Span<OpAttrib> buffer = stackalloc OpAttrib[4];
                var i=0;
                if(count >= 1)
                {
                    if(XedParsers.parse(props[0], out action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(XedParsers.parse(props[1], out width))
                        seek(buffer,i++) = width;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            void ParseScale(string expr, Index<string> props, ref PatternOp dst)
            {
                var count = props.Count;
                dst.SourceExpr = expr;
                var action = OpAction.None;
                Span<OpAttrib> buffer = stackalloc OpAttrib[4];
                var i=0;

                if(count >= 1)
                {
                    if(byte.TryParse(props[0], out var value))
                        seek(buffer,i++) = (ScaleFactor)value;
                }
                if(count >= 2)
                {
                    if(XedParsers.parse(props[1], out action))
                        seek(buffer,i++) = action;
                }
                if(count >= 3)
                {
                    if(XedParsers.parse(props[2], out PointerWidth pwidth))
                        seek(buffer,i++) = pwidth;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            void ParseImm(string expr, Index<string> props, ref PatternOp dst)
            {
                var count = props.Count;
                dst.SourceExpr = expr;

                var type = ElementType.Empty;
                var action = OpAction.None;
                var width = OpWidthCode.INVALID;
                Span<OpAttrib> buffer = stackalloc OpAttrib[4];
                var i=0;
                if(count >= 1)
                {
                    if(XedParsers.parse(props[0], out action))
                        seek(buffer,i++) = action;
                }

                if(count >= 2)
                {
                    if(XedParsers.parse(props[1], out width))
                        seek(buffer,i++) = width;
                }

                if(count >= 3)
                {
                    if(XedParsers.parse(props[2], out type))
                        seek(buffer,i++) = type;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            void ParseMem(string expr, Index<string> props, ref PatternOp dst)
            {
                var count = props.Count;
                dst.SourceExpr = expr;
                Span<OpAttrib> buffer = stackalloc OpAttrib[6];
                var i=0;
                var k=0;
                var width = OpWidthCode.INVALID;
                var action = OpAction.None;
                var vis = OpVisibility.None;
                var type = ElementType.Empty;

                if(count >= 1)
                {
                    ref readonly var p = ref props[k++];
                    if(XedParsers.parse(p, out action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    ref readonly var p = ref props[k++];
                    if(XedParsers.parse(p, out vis))
                        seek(buffer,i++) = vis;
                    else if(XedParsers.parse(p, out width))
                        seek(buffer,i++) = width;
                }

                if(count >= 3)
                {
                    ref readonly var p = ref props[k++];
                    if(width != 0)
                    {
                        if(XedParsers.parse(p, out type))
                             seek(buffer,i++) = type;
                    }
                    else if(XedParsers.parse(p, out width))
                         seek(buffer,i++) = width;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            void ParseReg(string expr, Index<string> props, ref PatternOp dst)
            {
                var result = Outcome.Success;
                var counter = 0;
                var count = props.Count;
                dst.SourceExpr = expr;
                var width = OpWidthCode.INVALID;
                var type = ElementType.Empty;
                var vis = OpVisibility.None;
                var action = OpAction.None;

                Span<OpAttrib> buffer = stackalloc OpAttrib[8];
                var i=0;
                var k=0;
                if(count >= 1)
                {
                    ref readonly var p = ref props[k++];
                    result = XedParsers.reg(p, out seek(buffer,i++));
                    if(!result)
                        Errors.Throw(string.Format("Unable to parser rgister specification {0}", p));
                }

                if(count >= 2)
                {
                    ref readonly var p = ref props[k++];
                    if(XedParsers.parse(p, out action))
                        seek(buffer,i++) = action;
                    else if(XedParsers.parse(p, out width))
                        seek(buffer,i++) = width;
                }

                if(count >= 3)
                {
                    ref readonly var p = ref props[k++];
                    if(width==0 && XedParsers.parse(p, out width))
                        seek(buffer,i++) = width;
                    else if (XedParsers.parse(p, out vis))
                        seek(buffer,i++) = vis;
                }

                if(count >= 4)
                {
                    ref readonly var p = ref props[k++];
                    if(width == 0 && XedParsers.parse(p, out width))
                        seek(buffer,i++) = type;
                    else if(XedParsers.parse(p, out type))
                        seek(buffer,i++) = type;
                    else if(XedParsers.parse(p, out vis))
                        seek(buffer,i++) = vis;
                    else
                    {
                        var j = text.index(p, Chars.Eq);
                        if(j > 0)
                        {
                            if(XedParsers.parse(text.right(p, j), out OpModKind mod))
                                seek(buffer,i++) = mod;
                        }
                    }
                }

                if(count >= 5)
                {
                    ref readonly var p = ref props[k++];
                    if(XedParsers.parse(p, out type))
                        seek(buffer,i++) = type;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }
        }
    }
}