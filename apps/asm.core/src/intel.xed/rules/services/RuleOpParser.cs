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
        public class RuleOpParser
        {
            public static RuleOpParser create()
                => new();

            XedParsers Parsers;

            RuleOpParser()
            {
                Parsers = XedParsers.create();
            }

            public RuleOpSpec Parse(string src)
            {
                var input = text.despace(src);
                var i = text.index(input, Chars.Colon);
                var j = text.index(input, Chars.Eq);
                var m = text.index(input, Chars.Eq, Chars.Colon);
                OpNames.ExprKind(text.left(input, m), out var name);
                var attribs = EmptyString;
                if(j > 0)
                    attribs = text.right(input,j);
                else if(i > 0)
                    attribs = text.right(input,i);

                if(empty(attribs) || name == 0)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleOpSpec), input));

                var k = text.index(attribs, Chars.Eq);
                var refinement = EmptyString;
                if(k > 0)
                {
                    var q = text.right(attribs,k);
                    var v = text.xedni(attribs, Chars.Colon);
                    attribs = text.left(attribs,v);
                    refinement = text.right(attribs,v);
                }

                var spec = ParseOperand(attribs, name, text.split(attribs, Chars.Colon).Where(text.nonempty), refinement);
                spec.Refinement = refinement;
                return spec;
            }

            RuleOpSpec ParseOperand(string expr, RuleOpName name, string[] props, string refinement)
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
                        ParseReg(K.Reg, expr, name, props, refinement, out dst);
                    }
                    break;

                    case INDEX:
                    {
                        ParseReg(K.Index, expr, name, props, refinement, out dst);
                    }
                    break;

                    case BASE0:
                    case BASE1:
                    {
                        ParseReg(K.Base, expr, name, props, refinement, out dst);
                    }
                    break;

                    case SEG0:
                    case SEG1:
                    {
                        ParseReg(K.Seg, expr, name, props, refinement, out dst);
                    }
                    break;

                    case SCALE:
                    {
                        ParseScale(K.Scale, expr, name, props, refinement, out dst);
                    }
                    break;

                    case DISP:
                    {
                        dst.Kind = K.Disp;
                        dst.Expression = expr;
                        dst.Name = name;
                        dst.Properties = props;
                        dst.Attributes = sys.empty<OperandAttrib>();
                    }
                    break;

                    case IMM0:
                    case IMM1:
                    case IMM2:
                    {
                        ParseImm(K.Imm, expr, name, props, refinement, out dst);
                    }
                    break;

                    case MEM0:
                    case MEM1:
                    {
                        ParseMem(K.Mem, expr, name, props, refinement, out dst);
                    }
                    break;

                    case AGEN:
                    {
                        ParseMem(K.Agen, expr, name, props, refinement, out dst);
                    }
                    break;

                    case PTR:
                    {
                        ParsePtr(K.Ptr, expr, name, props, refinement, out dst);
                    }
                    break;

                    case RELBR:
                    {
                        ParseRelBr(K.RelBr, expr, name, props, refinement, out dst);
                    }
                    break;

                    // default:
                    //     if(RuleMacros.spec(expr, out var macro))
                    //     {

                    //     }
                    //     else
                    //     {
                    //         Errors.Throw(string.Format("Unhandled case: {0}", name));
                    //     }
                    // break;
                 }
                return dst;
            }


            void ParsePtr(K kind, string expr, RuleOpName name, Index<string> props, string refinement, out RuleOpSpec dst)
            {
                var count = props.Count;
                dst.Kind = kind;
                dst.Name = name;
                dst.Properties = props;
                dst.Expression = expr;
                dst.Refinement = refinement;
                Span<OperandAttrib> buffer = stackalloc OperandAttrib[4];
                var i=0;

                if(count >= 1)
                {
                    if(Parsers.ParseAction(props[0], out var action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(Parsers.ParseOpWidth(props[1], out var width))
                        seek(buffer,i++) = width;
                }

                dst.Attributes = slice(buffer,0,i).ToArray();
            }

            void ParseRelBr(K kind, string expr, RuleOpName name, Index<string> props, string refinement, out RuleOpSpec dst)
            {
                var count = props.Count;
                dst.Kind = kind;
                dst.Name = name;
                dst.Properties = props;
                dst.Expression = expr;
                dst.Refinement = refinement;
                Span<OperandAttrib> buffer = stackalloc OperandAttrib[4];
                var i=0;
                if(count >= 1)
                {
                    if(Parsers.ParseAction(props[0], out var action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(Parsers.ParseOpWidth(props[1], out var width))
                        seek(buffer,i++) = width;
                }

                dst.Attributes = slice(buffer,0,i).ToArray();
            }

            void ParseScale(K kind, string expr, RuleOpName name, Index<string> props, string refinement, out RuleOpSpec dst)
            {
                var count = props.Count;
                dst.Kind = kind;
                dst.Name = name;
                dst.Properties = props;
                dst.Expression = expr;
                dst.Refinement = refinement;
                Span<OperandAttrib> buffer = stackalloc OperandAttrib[4];
                var i=0;

                if(count >= 1)
                {
                    if(byte.TryParse(props[0], out var value))
                        seek(buffer,i++) = (ScaleFactor)value;
                }
                if(count >= 2)
                {
                    if(Parsers.ParseAction(props[1], out var action))
                        seek(buffer,i++) = action;
                }
                if(count >= 3)
                {
                    if(Parsers.ParsePtrWidth(props[2], out var width))
                        seek(buffer,i++) = width;
                }

                dst.Attributes = slice(buffer,0,i).ToArray();
            }

            void ParseImm(K kind, string expr, RuleOpName name, Index<string> props, string refinement, out RuleOpSpec dst)
            {
                var count = props.Count;
                dst.Kind = kind;
                dst.Name = name;
                dst.Properties = props;
                dst.Expression = expr;
                dst.Refinement = refinement;

                Span<OperandAttrib> buffer = stackalloc OperandAttrib[4];
                var i=0;
                if(count >= 1)
                {
                    if(Parsers.ParseAction(props[0], out var action))
                        seek(buffer,i++) = action;
                }

                if(count >= 2)
                {
                    if(Parsers.ParseOpWidth(props[1], out var width))
                        seek(buffer,i++) = width;
                }

                if(count >= 3)
                {
                    if(Parsers.ParseDataType(props[2], out var type))
                        seek(buffer,i++) = type;
                }

                dst.Attributes = slice(buffer,0,i).ToArray();
            }

            void ParseMem(K kind, string expr, RuleOpName name, Index<string> props, string refinement, out RuleOpSpec dst)
            {
                var count = props.Count;
                dst.Kind = kind;
                dst.Name = name;
                dst.Properties = props;
                dst.Expression = expr;
                dst.Refinement = refinement;
                Span<OperandAttrib> buffer = stackalloc OperandAttrib[4];
                var i=0;

                if(count >= 1)
                {
                    if(Parsers.ParseAction(props[0], out var action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(Parsers.ParseOpWidth(props[1], out var width))
                        seek(buffer,i++) = width;
                }

                dst.Attributes = slice(buffer,0,i).ToArray();
            }

            void ParseReg(K kind, string expr, RuleOpName name, Index<string> props, string refinement, out RuleOpSpec dst)
            {
                var result = Outcome.Success;
                var counter = 0;
                var count = props.Count;
                dst.Kind = kind;
                dst.Name = name;
                dst.Properties = props;
                dst.Expression = expr;
                dst.Refinement = refinement;

                Span<OperandAttrib> buffer = stackalloc OperandAttrib[6];
                var i=0;
                if(count >= 1)
                {
                    ref readonly var p0 = ref props[0];
                    if(Parsers.ParseNonterm(p0, out var nonterm))
                    {
                        seek(buffer, i++) = nonterm;
                    }
                    else
                    {
                        if(Parsers.ParseRegLiteral(p0,  out var register))
                            seek(buffer, i++) = register;
                        else
                            seek(buffer, i++) = RegResolvers.resolver(p0);
                    }
                }

                if(count >= 2)
                {
                    if(Parsers.ParseAction(props[1], out var action))
                        seek(buffer,i++) = action;
                }

                if(count >= 3)
                {
                    if(Parsers.ParseOpWidth(props[2], out var width))
                        seek(buffer,i++) = width;
                    else
                    {
                        if(Parsers.ParseSpression(props[2], out var supp))
                        {
                            seek(buffer,i++) = supp;
                        }
                    }
                }

                if(count >= 4)
                {
                    if(Parsers.ParseOpWidth(props[3], out var width))
                        seek(buffer,i++) = width;

                }

                if(count >= 5)
                {
                    if(Parsers.ParseDataType(props[4], out var type))
                        seek(buffer,i++) = type;
                }

                dst.Attributes = slice(buffer,0,i).ToArray();
            }
        }
   }
}