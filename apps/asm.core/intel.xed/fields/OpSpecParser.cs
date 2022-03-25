//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedPatterns;
    using static XedRules.OpName;
    using static core;

    using K = XedRules.OpKind;

    partial class XedRules
    {
        public readonly struct OpSpecParser
        {
            [MethodImpl(Inline)]
            public static OpSpecParser create(ConstLookup<OpWidthCode,OpWidthInfo> widths, InstPatternBody src)
                => new(widths,src);

            readonly InstPatternBody Body;

            readonly ConstLookup<OpWidthCode,OpWidthInfo> OpWidths;

            readonly MachineMode Mode;

            public OpSpecParser(ConstLookup<OpWidthCode,OpWidthInfo> widths, InstPatternBody body)
            {
                OpWidths = widths;
                Body = body;
                Mode = XedPatterns.mode(body);
            }

            // public InstPatternOp ParseOperand(in InstPatternSpec src, byte k)
            // {
            //     ref readonly var ops = ref src.Ops;
            //     ref readonly var op = ref ops[k];
            //     var dst = InstPatternOp.Empty;
            //     var spec = parse(src.PatternId, k, op.Name, op.Expression);
            //     var attribs = spec.Attribs.Sort();
            //     dst.InstId = src.InstId;
            //     dst.PatternId = src.PatternId;
            //     dst.OpIndex = op.Index;
            //     dst.Name = spec.Name;
            //     dst.Kind = spec.Kind;
            //     dst.Expression = op.Expression;
            //     dst.InstClass = src.InstClass;
            //     dst.OpCode = src.OpCode;
            //     if(attribs.Search(OpClass.Action, out var action))
            //         dst.Action = action;
            //     if(attribs.Search(OpClass.OpWidth, out var w))
            //     {
            //         dst.OpWidth = w.AsOpWidth();
            //         dst.BitWidth = dst.OpWidth.Bits;
            //     }
            //     if(attribs.Search(OpClass.ElementType, out var et))
            //     {
            //         dst.CellType = et.AsElementType();
            //         dst.CellWidth = bitwidth(dst.OpWidth.Code, dst.CellType);
            //     }
            //     if(attribs.Search(OpClass.RegLiteral, out var reglit))
            //     {
            //         dst.RegLit = reglit;
            //         dst.BitWidth = bitwidth(reglit.AsRegLiteral());
            //     }
            //     if(attribs.Search(OpClass.Modifier, out var mod))
            //         dst.Modifier = mod;
            //     if(attribs.Search(OpClass.Visibility, out var visib))
            //         dst.Visibility = visib.AsVisibility();

            //     return dst;
            // }

            Index<OpSpec> parse(uint pattern, string ops)
            {
                var buffer = list<OpSpec>();
                var input = text.despace(ops);
                var i = text.index(input,Chars.Hash);
                var index = z8;
                if(i > 0)
                    input = text.left(input,i);

                var parts = input.Contains(Chars.Space) ? text.split(input, Chars.Space) : new string[]{input};
                for(var j=0; j<parts.Length; j++)
                {
                    var parsed = parse(pattern,index++, skip(parts,j));
                    if(parsed.IsNonEmpty)
                        buffer.Add(parsed);
                    else
                        break;
                }

                return buffer.ToArray();
            }

            public void Parse(uint pattern, string ops, out Index<OpSpec> dst)
            {
                dst = parse(pattern,ops);
            }

            public OpSpec parse(uint pattern, byte index, OpName name, string src)
            {
                var attribs = text.despace(src);
                return parse(pattern, index, attribs, name, text.split(attribs, Chars.Colon).Where(text.nonempty));
            }

            OpSpec parse(uint pattern, byte index, string src)
            {
                var input = text.despace(src);
                var i = text.index(input, Chars.Colon, Chars.Eq);
                var attribs = text.right(src,i);
                opname(src, out var name);
                return parse(pattern, index, attribs, name, text.split(attribs, Chars.Colon).Where(text.nonempty));
            }

            OpSpec parse(uint pattern, byte index, string expr, OpName name, string[] props)
            {
                var dst = new OpSpec();
                dst.Expression = expr;
                switch(name)
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
                        reg(pattern, index, K.Reg, expr, name, props, out dst);
                    break;

                    case INDEX:
                        reg(pattern, index, K.Index, expr, name, props, out dst);
                    break;

                    case BASE0:
                    case BASE1:
                        reg(pattern, index, K.Base, expr, name, props, out dst);
                    break;

                    case SEG0:
                    case SEG1:
                        reg(pattern, index, K.Seg, expr, name, props, out dst);
                    break;

                    case SCALE:
                        scale(pattern, index, K.Scale, expr, name, props, out dst);
                    break;

                    case DISP:
                    {
                        dst.Index = index;
                        dst.PatternId = pattern;
                        dst.Kind = K.Disp;
                        dst.Expression = expr;
                        dst.Name = name;
                        dst.Attribs = sys.empty<OpAttrib>();
                    }
                    break;

                    case IMM0:
                    case IMM1:
                    case IMM2:
                        imm(pattern, index, K.Imm, expr, name, props, out dst);
                    break;

                    case MEM0:
                    case MEM1:
                        mem(pattern, index, K.Mem, expr, name, props, out dst);
                    break;

                    case AGEN:
                        mem(pattern, index, K.Agen, expr, name, props, out dst);
                    break;

                    case PTR:
                        ptr(pattern, index, K.Ptr, expr, name, props, out dst);
                    break;

                    case RELBR:
                        relbr(pattern, index, K.RelBr, expr, name, props, out dst);
                    break;

                    default:
                        Errors.Throw(string.Format("Unhandled:{0}", name));
                    break;
                 }
                return dst;
            }

            void ptr(uint pattern, byte index, K kind, string expr, OpName name, Index<string> props, out OpSpec dst)
            {
                var count = props.Count;
                dst.PatternId = pattern;
                dst.Index = index;
                dst.Kind = kind;
                dst.Name = name;
                dst.Expression = expr;
                Span<OpAttrib> buffer = stackalloc OpAttrib[4];
                var i=0;

                if(count >= 1)
                {
                    if(XedParsers.parse(props[0], out OpAction action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(XedParsers.parse(props[1], out OpWidthCode width))
                        seek(buffer,i++) = CalcOpWidth(width);
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            OpWidth CalcOpWidth(OpWidthCode code)
            {
                var dst = OpWidth.Empty;
                if(code == 0)
                    return dst;
                else if(OpWidths.Find(code, out var info))
                {
                    switch(Mode.Kind)
                    {
                        case ModeKind.Mode16:
                            dst = new OpWidth(Mode, code, info.Width16);
                        break;
                        case ModeKind.Not64:
                        case ModeKind.Mode32:
                            dst = new OpWidth(Mode, code, info.Width32);
                        break;

                        default:
                            dst = new OpWidth(Mode, code, info.Width64);
                        break;
                    }
                }
                else
                    Errors.Throw(code.ToString());
                return dst;

            }
            void relbr(uint pattern, byte index, K kind, string expr, OpName name, Index<string> props, out OpSpec dst)
            {
                var count = props.Count;
                dst.PatternId = pattern;
                dst.Index = index;
                dst.Kind = kind;
                dst.Name = name;
                dst.Expression = expr;
                Span<OpAttrib> buffer = stackalloc OpAttrib[4];
                var i=0;
                if(count >= 1)
                {
                    if(XedParsers.parse(props[0], out OpAction action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(XedParsers.parse(props[1], out OpWidthCode width))
                        seek(buffer,i++) = CalcOpWidth(width);
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            void scale(uint pattern, byte index, K kind, string expr, OpName name, Index<string> props, out OpSpec dst)
            {
                var count = props.Count;
                dst.PatternId = pattern;
                dst.Index = index;
                dst.Kind = kind;
                dst.Name = name;
                dst.Expression = expr;
                Span<OpAttrib> buffer = stackalloc OpAttrib[4];
                var i=0;

                if(count >= 1)
                {
                    if(byte.TryParse(props[0], out var value))
                        seek(buffer,i++) = (ScaleFactor)value;
                }
                if(count >= 2)
                {
                    if(XedParsers.parse(props[1], out OpAction action))
                        seek(buffer,i++) = action;
                }
                if(count >= 3)
                {
                    if(XedParsers.parse(props[2], out PointerWidthKind pwidth))
                        seek(buffer,i++) = pwidth;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            void imm(uint pattern, byte index, K kind, string expr, OpName name, Index<string> props, out OpSpec dst)
            {
                var count = props.Count;
                dst.PatternId = pattern;
                dst.Index = index;
                dst.Kind = kind;
                dst.Name = name;
                dst.Expression = expr;

                Span<OpAttrib> buffer = stackalloc OpAttrib[4];
                var i=0;
                if(count >= 1)
                {
                    if(XedParsers.parse(props[0], out OpAction action))
                        seek(buffer,i++) = action;
                }

                if(count >= 2)
                {
                    if(XedParsers.parse(props[1], out OpWidthCode width))
                        seek(buffer,i++) = CalcOpWidth(width);
                }

                if(count >= 3)
                {
                    if(XedParsers.parse(props[2], out ElementKind type))
                        seek(buffer,i++) = type;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            void mem(uint pattern, byte index, K kind, string expr, OpName name, Index<string> props, out OpSpec dst)
            {
                var count = props.Count;
                dst.PatternId = pattern;
                dst.Index = index;
                dst.Kind = kind;
                dst.Name = name;
                dst.Expression = expr;
                Span<OpAttrib> buffer = stackalloc OpAttrib[6];
                var i=0;

                if(count >= 1)
                {
                    if(XedParsers.parse(props[0], out OpAction action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(XedParsers.parse(props[1], out OpWidthCode width))
                        seek(buffer,i++) = CalcOpWidth(width);
                }

                if(count >= 3)
                {
                    if(XedParsers.parse(props[2], out ElementKind type))
                        seek(buffer,i++) = type;
                }

                if(count >= 4)
                {
                    var j = text.index(props[3], Chars.Eq);
                    if(j > 0)
                    {
                        if(XedParsers.parse(text.right(props[3], j), out OpModKind mod))
                            seek(buffer,i++) = mod;
                    }
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            void reg(uint pattern,byte index, K kind, string expr, OpName name, Index<string> props, out OpSpec dst)
            {
                var result = Outcome.Success;
                var counter = 0;
                var count = props.Count;
                dst.PatternId = pattern;
                dst.Kind = kind;
                dst.Name = name;
                dst.Expression = expr;
                dst.Index = index;

                Span<OpAttrib> buffer = stackalloc OpAttrib[8];
                var i=0;
                if(count >= 1)
                {

                    var p0 = props[0];
                    result = XedParsers.reg(p0, out seek(buffer,i++));
                    if(!result)
                        Errors.Throw(string.Format("Unable to parser rgister specification {0}", p0));
                }

                if(count >= 2)
                {
                    if(XedParsers.parse(props[1], out OpAction action))
                        seek(buffer,i++) = action;
                }

                if(count >= 3)
                {
                    if(XedParsers.parse(props[2], out OpWidthCode width))
                        seek(buffer,i++) = CalcOpWidth(width);
                    else
                    {
                        if(XedParsers.parse(props[2], out OpVisibility supp))
                        {
                            seek(buffer,i++) = supp;
                        }
                    }
                }

                if(count >= 4)
                {
                    if(XedParsers.parse(props[3], out OpWidthCode width))
                        seek(buffer,i++) = CalcOpWidth(width);
                    else
                    {
                        var j = text.index(props[3], Chars.Eq);
                        if(j > 0)
                        {
                            if(XedParsers.parse(text.right(props[3], j), out OpModKind mod))
                                seek(buffer,i++) = mod;
                        }
                    }
                }

                if(count >= 5)
                {
                    if(XedParsers.parse(props[4], out ElementKind type))
                        seek(buffer,i++) = type;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
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
        }
    }
}