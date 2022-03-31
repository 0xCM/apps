//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedPatterns;
    using static XedRules;
    using static XedRules.OpNameKind;
    using static core;

    using K = XedRules.OpKind;

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

            public void Parse(uint pattern, string ops, out Index<PatternOp> dst)
            {
                dst = Parse(pattern,ops);
            }

            public void Parse(uint pattern, string ops, out PatternOps dst)
            {
                dst = Parse(pattern,ops);
            }

            Index<PatternOp> Parse(uint pattern, string ops)
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

                return buffer.ToArray();
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
                        seek(buffer,i++) = Tables.Width(width,Mode);
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            void ParseRelBr(string expr, Index<string> props, ref PatternOp dst)
            {
                var count = props.Count;
                dst.SourceExpr = expr;
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
                        seek(buffer,i++) = Tables.Width(width,Mode);
                }

                dst.Attribs = slice(buffer,0,i).ToArray();
            }

            void ParseScale(string expr, Index<string> props, ref PatternOp dst)
            {
                var count = props.Count;
                dst.SourceExpr = expr;
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

            void ParseImm(string expr, Index<string> props, ref PatternOp dst)
            {
                var count = props.Count;
                dst.SourceExpr = expr;

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
                        seek(buffer,i++) = Tables.Width(width,Mode);
                }

                if(count >= 3)
                {
                    if(XedParsers.parse(props[2], out ElementKind type))
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

                if(count >= 1)
                {
                    if(XedParsers.parse(props[0], out OpAction action))
                        seek(buffer,i++) = action;
                }
                if(count >= 2)
                {
                    if(XedParsers.parse(props[1], out OpWidthCode width))
                        seek(buffer,i++) = Tables.Width(width,Mode);
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

            void ParseReg(string expr, Index<string> props, ref PatternOp dst)
            {
                var result = Outcome.Success;
                var counter = 0;
                var count = props.Count;
                dst.SourceExpr = expr;

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
                        seek(buffer,i++) = Tables.Width(width,Mode);
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
                        seek(buffer,i++) = Tables.Width(width,Mode);
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
        }
    }
}