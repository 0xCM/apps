//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules.RuleOpName;
    using static XedParsers;
    using static core;

    using K = XedRules.RuleOpKind;

    partial class XedRules
    {
        public readonly struct RuleOpParser
        {
            public static RuleOpParser create()
                => new();

            public RuleOpParser()
            {
            }

            public Index<RuleOpSpec> ParseOps(string src)
            {
                var result = Outcome.Success;
                var buffer = list<RuleOpSpec>();
                var input = text.despace(src);
                var i = text.index(input,Chars.Hash);
                var index = z8;
                if(i > 0)
                    input = text.left(input,i);

                var parts = input.Contains(Chars.Space) ? text.split(input, Chars.Space) : new string[]{input};
                for(var j=0; j<parts.Length; j++)
                {
                    var parsed = ParseOp(index++, skip(parts,j));
                    if(parsed.IsNonEmpty)
                        buffer.Add(parsed);
                    else
                        break;
                }

                return buffer.ToArray();
            }

            public RuleOpSpec ParseOp(byte index, RuleOpName name, string src)
            {
                var input = text.despace(src);
                var attribs = input;
                return ParseOp(index, attribs, name, text.split(attribs, Chars.Colon).Where(text.nonempty));
            }

            RuleOpSpec ParseOp(byte index, string src)
            {
                var input = text.despace(src);
                var i = text.index(input, Chars.Colon, Chars.Eq);
                var attribs = text.right(src,i);
                opname(src, out var name);
                return ParseOp(index, attribs, name, text.split(attribs, Chars.Colon).Where(text.nonempty));
            }

            static bool opname(string src, out RuleOpName dst)
            {
                var input = text.despace(src);
                var i = text.index(input, Chars.Colon);
                var j = text.index(input, Chars.Eq);

                var index = -1;
                if(i > 0 && j > 0)
                {
                    index = i < j ? i : j;
                }
                else if(i>0 && j<0)
                {
                    index = i;
                }
                else if(j>0 && i<0)
                {
                    index = j;
                }

                return parse(text.left(input, index), out  dst);
            }

            RuleOpSpec ParseOp(byte index, string expr, RuleOpName name, string[] props)
            {
                var dst = new RuleOpSpec();
                dst.Expression = expr;
                switch(name)
                {
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
                    {
                        ParseReg(index, K.Reg, expr, name, props, out dst);
                    }
                    break;

                    case INDEX:
                    {
                        ParseReg(index, K.Index, expr, name, props, out dst);
                    }
                    break;

                    case BASE0:
                    case BASE1:
                    {
                        ParseReg(index, K.Base, expr, name, props, out dst);
                    }
                    break;

                    case SEG0:
                    case SEG1:
                    {
                        ParseReg(index, K.Seg, expr, name, props, out dst);
                    }
                    break;

                    case SCALE:
                    {
                        ParseScale(index, K.Scale, expr, name, props, out dst);
                    }
                    break;

                    case DISP:
                    {
                        dst.Index = index;
                        dst.Kind = K.Disp;
                        dst.Expression = expr;
                        dst.Name = name;
                        dst.Attribs = sys.empty<RuleOpAttrib>();
                    }
                    break;

                    case IMM0:
                    case IMM1:
                    case IMM2:
                    {
                        ParseImm(index, K.Imm, expr, name, props, out dst);
                    }
                    break;

                    case MEM0:
                    case MEM1:
                    {
                        ParseMem(index, K.Mem, expr, name, props, out dst);
                    }
                    break;

                    case AGEN:
                    {
                        ParseMem(index, K.Agen, expr, name, props, out dst);
                    }
                    break;

                    case PTR:
                    {
                        ParsePtr(index, K.Ptr, expr, name, props, out dst);
                    }
                    break;

                    case RELBR:
                    {
                        ParseRelBr(index, K.RelBr, expr, name, props, out dst);
                    }
                    break;

                    default:
                    {
                        if(RuleMacros.spec(expr, out var macro))
                        {
                            dst.Index = index;
                            dst.Name = name;
                            dst.Kind = K.Macro;
                            dst.Attribs = new RuleOpAttrib[]{macro.Name};
                            dst.Expression = expr;
                        }
                    }
                    break;
                 }
                return dst;
            }

            void ParsePtr(byte index, K kind, string expr, RuleOpName name, Index<string> props, out RuleOpSpec dst)
            {
                var count = props.Count;
                dst.Index = index;
                dst.Kind = kind;
                dst.Name = name;
                dst.Expression = expr;
                Span<RuleOpAttrib> buffer = stackalloc RuleOpAttrib[4];
                var i=0;

                if(count >= 1)
                {
                    if(parse(props[0], out OperandAction action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(parse(props[1], out OperandWidthCode width))
                        seek(buffer,i++) = width;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            void ParseRelBr(byte index, K kind, string expr, RuleOpName name, Index<string> props, out RuleOpSpec dst)
            {
                var count = props.Count;
                dst.Index = index;
                dst.Kind = kind;
                dst.Name = name;
                dst.Expression = expr;
                Span<RuleOpAttrib> buffer = stackalloc RuleOpAttrib[4];
                var i=0;
                if(count >= 1)
                {
                    if(parse(props[0], out OperandAction action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(parse(props[1], out OperandWidthCode width))
                        seek(buffer,i++) = width;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            void ParseScale(byte index, K kind, string expr, RuleOpName name, Index<string> props, out RuleOpSpec dst)
            {
                var count = props.Count;
                dst.Index = index;
                dst.Kind = kind;
                dst.Name = name;
                dst.Expression = expr;
                Span<RuleOpAttrib> buffer = stackalloc RuleOpAttrib[4];
                var i=0;

                if(count >= 1)
                {
                    if(byte.TryParse(props[0], out var value))
                        seek(buffer,i++) = (ScaleFactor)value;
                }
                if(count >= 2)
                {
                    if(parse(props[1], out OperandAction action))
                        seek(buffer,i++) = action;
                }
                if(count >= 3)
                {
                    if(parse(props[2], out PointerWidthKind pwidth))
                        seek(buffer,i++) = pwidth;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            void ParseImm(byte index, K kind, string expr, RuleOpName name, Index<string> props, out RuleOpSpec dst)
            {
                var count = props.Count;
                dst.Index = index;
                dst.Kind = kind;
                dst.Name = name;
                dst.Expression = expr;

                Span<RuleOpAttrib> buffer = stackalloc RuleOpAttrib[4];
                var i=0;
                if(count >= 1)
                {
                    if(parse(props[0], out OperandAction action))
                        seek(buffer,i++) = action;
                }

                if(count >= 2)
                {
                    if(parse(props[1], out OperandWidthCode width))
                        seek(buffer,i++) = width;
                }

                if(count >= 3)
                {
                    if(parse(props[2], out ElementKind type))
                        seek(buffer,i++) = type;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            // MEM0:r:vv:f64:TXT=BCASTSTR
            void ParseMem(byte index, K kind, string expr, RuleOpName name, Index<string> props, out RuleOpSpec dst)
            {
                var count = props.Count;
                dst.Index = index;
                dst.Kind = kind;
                dst.Name = name;
                dst.Expression = expr;
                Span<RuleOpAttrib> buffer = stackalloc RuleOpAttrib[6];
                var i=0;

                if(count >= 1)
                {
                    if(parse(props[0], out OperandAction action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(parse(props[1], out OperandWidthCode width))
                        seek(buffer,i++) = width;
                }

                if(count >= 3)
                {
                    if(parse(props[2], out ElementKind type))
                        seek(buffer,i++) = type;
                }

                if(count >= 4)
                {
                    var j = text.index(props[3], Chars.Eq);
                    if(j > 0)
                    {
                        if(parse(text.right(props[3], j), out RuleOpModKind mod))
                            seek(buffer,i++) = mod;
                    }
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            void ParseReg(byte index, K kind, string expr, RuleOpName name, Index<string> props, out RuleOpSpec dst)
            {
                var result = Outcome.Success;
                var counter = 0;
                var count = props.Count;
                dst.Kind = kind;
                dst.Name = name;
                dst.Expression = expr;
                dst.Index = index;

                Span<RuleOpAttrib> buffer = stackalloc RuleOpAttrib[8];
                var i=0;
                if(count >= 1)
                {
                    var p0 = props[0];
                    var j = text.index(p0, Chars.LParen);
                    if(j > 0)
                        p0 = text.left(p0,j);

                    if(parse(p0,  out XedRegId regid))
                        seek(buffer, i++) = regid;
                    else
                    {
                        if(parse(p0, out GroupName group))
                            seek(buffer, i++) = group;
                        else if(parse(p0, out NonterminalKind nonterm))
                            seek(buffer, i++) = nonterm;
                        else
                            Errors.Throw(string.Format("Unable to parser rgister specification {0}", p0));
                    }
                }

                if(count >= 2)
                {
                    if(parse(props[1], out OperandAction action))
                        seek(buffer,i++) = action;
                }

                if(count >= 3)
                {
                    if(parse(props[2], out OperandWidthCode width))
                        seek(buffer,i++) = width;
                    else
                    {
                        if(parse(props[2], out OpVisibility supp))
                        {
                            seek(buffer,i++) = supp;
                        }
                    }
                }

                if(count >= 4)
                {
                    if(parse(props[3], out OperandWidthCode width))
                        seek(buffer,i++) = width;
                    else
                    {
                        var j = text.index(props[3], Chars.Eq);
                        if(j > 0)
                        {
                            if(parse(text.right(props[3], j), out RuleOpModKind mod))
                                seek(buffer,i++) = mod;
                        }
                    }
                }

                if(count >= 5)
                {
                    if(parse(props[4], out ElementKind type))
                        seek(buffer,i++) = type;
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }
        }
   }
}