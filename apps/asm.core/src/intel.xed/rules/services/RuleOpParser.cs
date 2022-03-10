//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules.RuleOpName;
    using static core;

    using K = XedRules.RuleOpKind;

    partial class XedRules
    {
        public readonly struct RuleOpParser
        {
            public static RuleOpParser create()
                => new();

            readonly XedParsers Parsers;

            public RuleOpParser()
            {
                Parsers = XedParsers.create();
            }

            public Index<RuleOpSpec> ParseOps(string src)
            {
                var result = Outcome.Success;
                var buffer = list<RuleOpSpec>();
                var input = text.despace(src);
                var i = text.index(input,Chars.Hash);
                if(i > 0)
                    input = text.left(input,i);

                var parts = input.Contains(Chars.Space) ? text.split(input, Chars.Space) : new string[]{input};
                for(var j=0; j<parts.Length; j++)
                {
                    var parsed = ParseOp(skip(parts,j));
                    if(parsed.IsNonEmpty)
                        buffer.Add(parsed);
                }

                return buffer.ToArray();
            }

            public RuleOpSpec ParseOp(RuleOpName name, string src)
            {
                var input = text.despace(src);
                var attribs = input;
                return ParseOp(attribs, name, text.split(attribs, Chars.Colon).Where(text.nonempty));
            }

            public RuleOpSpec ParseOp(string src)
            {
                var input = text.despace(src);
                var i = text.index(input, Chars.Colon, Chars.Eq);
                var attribs = text.right(src,i);
                opname(src, out var name);
                return ParseOp(attribs, name, text.split(attribs, Chars.Colon).Where(text.nonempty));
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

                return OpNames.ExprKind(text.left(input, index), out dst);
            }

            RuleOpSpec ParseOp(string expr, RuleOpName name, string[] props)
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
                        ParseReg(K.Reg, expr, name, props, out dst);
                    }
                    break;

                    case INDEX:
                    {
                        ParseReg(K.Index, expr, name, props, out dst);
                    }
                    break;

                    case BASE0:
                    case BASE1:
                    {
                        ParseReg(K.Base, expr, name, props, out dst);
                    }
                    break;

                    case SEG0:
                    case SEG1:
                    {
                        ParseReg(K.Seg, expr, name, props, out dst);
                    }
                    break;

                    case SCALE:
                    {
                        ParseScale(K.Scale, expr, name, props, out dst);
                    }
                    break;

                    case DISP:
                    {
                        dst.Kind = K.Disp;
                        dst.Expression = expr;
                        dst.Name = name;
                        dst.Properties = props;
                        dst.Attributes = sys.empty<RuleOpAttrib>();
                    }
                    break;

                    case IMM0:
                    case IMM1:
                    case IMM2:
                    {
                        ParseImm(K.Imm, expr, name, props, out dst);
                    }
                    break;

                    case MEM0:
                    case MEM1:
                    {
                        ParseMem(K.Mem, expr, name, props, out dst);
                    }
                    break;

                    case AGEN:
                    {
                        ParseMem(K.Agen, expr, name, props, out dst);
                    }
                    break;

                    case PTR:
                    {
                        ParsePtr(K.Ptr, expr, name, props, out dst);
                    }
                    break;

                    case RELBR:
                    {
                        ParseRelBr(K.RelBr, expr, name, props, out dst);
                    }
                    break;

                    default:
                    {
                        if(RuleMacros.spec(expr, out var macro))
                        {
                            dst.Name = name;
                            dst.Kind = K.Macro;
                            dst.Properties = props;
                            dst.Attributes = new RuleOpAttrib[]{macro.Name};
                            dst.Expression = expr;
                        }
                    }
                    break;
                 }
                return dst;
            }

            void ParsePtr(K kind, string expr, RuleOpName name, Index<string> props, out RuleOpSpec dst)
            {
                var count = props.Count;
                dst.Kind = kind;
                dst.Name = name;
                dst.Properties = props;
                dst.Expression = expr;
                Span<RuleOpAttrib> buffer = stackalloc RuleOpAttrib[4];
                var i=0;

                if(count >= 1)
                {
                    if(Parsers.Action(props[0], out var action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(Parsers.OpWidth(props[1], out var width))
                        seek(buffer,i++) = width;
                }

                dst.Attributes = slice(buffer,0,i).ToArray();
            }

            void ParseRelBr(K kind, string expr, RuleOpName name, Index<string> props, out RuleOpSpec dst)
            {
                var count = props.Count;
                dst.Kind = kind;
                dst.Name = name;
                dst.Properties = props;
                dst.Expression = expr;
                Span<RuleOpAttrib> buffer = stackalloc RuleOpAttrib[4];
                var i=0;
                if(count >= 1)
                {
                    if(Parsers.Action(props[0], out var action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(Parsers.OpWidth(props[1], out var width))
                        seek(buffer,i++) = width;
                }

                dst.Attributes = slice(buffer,0,i).ToArray();
            }

            void ParseScale(K kind, string expr, RuleOpName name, Index<string> props, out RuleOpSpec dst)
            {
                var count = props.Count;
                dst.Kind = kind;
                dst.Name = name;
                dst.Properties = props;
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
                    if(Parsers.Action(props[1], out var action))
                        seek(buffer,i++) = action;
                }
                if(count >= 3)
                {
                    if(Parsers.PtrWidth(props[2], out var width))
                        seek(buffer,i++) = width;
                }

                dst.Attributes = slice(buffer,0,i).ToArray();
            }

            void ParseImm(K kind, string expr, RuleOpName name, Index<string> props, out RuleOpSpec dst)
            {
                var count = props.Count;
                dst.Kind = kind;
                dst.Name = name;
                dst.Properties = props;
                dst.Expression = expr;

                Span<RuleOpAttrib> buffer = stackalloc RuleOpAttrib[4];
                var i=0;
                if(count >= 1)
                {
                    if(Parsers.Action(props[0], out var action))
                        seek(buffer,i++) = action;
                }

                if(count >= 2)
                {
                    if(Parsers.OpWidth(props[1], out var width))
                        seek(buffer,i++) = width;
                }

                if(count >= 3)
                {
                    if(Parsers.ElementKind(props[2], out var type))
                        seek(buffer,i++) = type;
                }

                dst.Attributes = slice(buffer,0,i).ToArray();
            }

            // MEM0:r:vv:f64:TXT=BCASTSTR
            void ParseMem(K kind, string expr, RuleOpName name, Index<string> props, out RuleOpSpec dst)
            {
                var count = props.Count;
                dst.Kind = kind;
                dst.Name = name;
                dst.Properties = props;
                dst.Expression = expr;
                Span<RuleOpAttrib> buffer = stackalloc RuleOpAttrib[6];
                var i=0;

                if(count >= 1)
                {
                    if(Parsers.Action(props[0], out var action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(Parsers.OpWidth(props[1], out var width))
                        seek(buffer,i++) = width;
                }

                if(count >= 3)
                {
                    if(Parsers.ElementKind(props[2], out var type))
                        seek(buffer,i++) = type;
                }

                if(count >= 4)
                {
                    var j = text.index(props[3], Chars.Eq);
                    if(j > 0)
                    {
                        if(Parsers.OpKind(text.right(props[3], j), out var tp))
                            seek(buffer,i++) = tp;
                    }
                }

                dst.Attributes = slice(buffer,0,i).ToArray();
            }

            void ParseReg(K kind, string expr, RuleOpName name, Index<string> props, out RuleOpSpec dst)
            {
                var result = Outcome.Success;
                var counter = 0;
                var count = props.Count;
                dst.Kind = kind;
                dst.Name = name;
                dst.Properties = props;
                dst.Expression = expr;

                Span<RuleOpAttrib> buffer = stackalloc RuleOpAttrib[8];
                var i=0;
                if(count >= 1)
                {
                    var p0 = props[0];
                    var j = text.index(p0, Chars.LParen);
                    if(j > 0)
                        p0 = text.left(p0,j);

                    if(Parsers.RegLiteral(p0,  out var register))
                        seek(buffer, i++) = register;
                    else
                    {
                        if(Parsers.EncodingGroup(p0, out var group))
                            seek(buffer, i++) = group;
                        else if(Parsers.Nonterm(p0, out var nonterm))
                            seek(buffer, i++) = nonterm;
                        else
                            seek(buffer, i++) = new RuleOpAttrib(RuleOpClass.RegResolver, (uint)RegResolvers.Instance.Create(p0));
                    }
                }

                if(count >= 2)
                {
                    if(Parsers.Action(props[1], out var action))
                        seek(buffer,i++) = action;
                }

                if(count >= 3)
                {
                    if(Parsers.OpWidth(props[2], out var width))
                        seek(buffer,i++) = width;
                    else
                    {
                        if(Parsers.OpVis(props[2], out var supp))
                        {
                            seek(buffer,i++) = supp;
                        }
                    }
                }

                if(count >= 4)
                {
                    if(Parsers.OpWidth(props[3], out var width))
                        seek(buffer,i++) = width;
                    else
                    {
                        var j = text.index(props[3], Chars.Eq);
                        if(j > 0)
                        {
                            if(Parsers.OpKind(text.right(props[3], j), out var tp))
                                seek(buffer,i++) = tp;
                        }
                    }
                }

                if(count >= 5)
                {
                    if(Parsers.ElementKind(props[4], out var type))
                        seek(buffer,i++) = type;
                }

                dst.Attributes = slice(buffer,0,i).ToArray();
            }
        }
   }
}