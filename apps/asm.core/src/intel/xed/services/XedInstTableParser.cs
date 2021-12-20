//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static XedModels;
    using static XedInstructions;
    using static Root;
    using static core;

    using SQ = SymbolicQuery;

    public class XedInstTableParser : AppService<XedInstTableParser>
    {
        enum LineKind : byte
        {
            None,

            Empty,

            Comment,

            Inst,

            OpCount,

            Operand
        }

        LineKind Classify(in TextLine src)
        {
            var kind = LineKind.None;
            var result = Outcome.Success;
            if(src.IsEmpty)
                kind = LineKind.Empty;
            else
            {
                var data = src.Data;
                ref readonly var c0 = ref first(data);
                if(SQ.hash(c0))
                    kind = LineKind.Comment;
                else if(byte.TryParse(src.Content, out var _))
                    kind = LineKind.OpCount;
                else if(SQ.digit(base10,c0))
                    kind = LineKind.Inst;
                else if(SQ.tab(c0))
                    kind = LineKind.Operand;
            }
            return kind;
        }

        EnumParser<IClass> Classes {get;}

        EnumParser<IFormType> IForms {get;}

        EnumParser<Category> Categories {get;}

        EnumParser<Extension> Extensions {get;}

        EnumParser<AttributeKind> Attributes {get;}

        EnumParser<EncodingGroup> Groups {get;}

        EnumParser<OperandTypeKind> OperandKinds {get;}

        EnumParser<OperandVisibility> Visibilities {get;}

        EnumParser<OperandAction> Actions {get;}

        EnumParser<LookupKind> Lookups {get;}

        EnumParser<DataType> DataTypes {get;}

        Index<char> _DigitBuffer;

        [MethodImpl(Inline)]
        Span<char> DigitBuffer()
        {
            _DigitBuffer.Clear();
            return _DigitBuffer;
        }

        EnumParser<IsaKind> IsaKinds;

        EnumParser<IClass> IClassParser;

        EnumParser<IFormType> IFormParser;

        EnumParser<NonterminalKind> Nonterminals;

        EnumParser<RegClass> Regs;

        EnumParser<OperandElementTypeKind> ElementTypes;

        public XedInstTableParser()
        {
            Classes = new();
            IForms = new();
            Categories = new();
            Extensions = new();
            Groups = new();
            Attributes = new();
            OperandKinds = new();
            Visibilities = new();
            Actions = new();
            Lookups = new();
            DataTypes = new();
            IsaKinds = new();
            IClassParser = new();
            IFormParser = new();
            Nonterminals = new();
            Regs = new();
            ElementTypes = new();
            _DigitBuffer = alloc<char>(12);
        }

        Outcome Parse(in TextLine src, out InstInfo dst)
        {
            const string AttribMarker = "ATTRIBUTES:";
            var result = Outcome.Success;

            dst = default;

            var digits = Digits(src);
            result = ushort.TryParse(digits, out dst.Index);
            if(result.Fail)
                return result;

            var content = text.trim(src.Content);

            var i = text.index(content, AttribMarker);

            var parts = i > 0 ? text.split(text.left(content, i), Chars.Space) : text.split(content,Chars.Space);
            var count = parts.Length;
            if(count > 0)
            {
                if(count < 5)
                {
                    result = (false, string.Format("At least 5 components not found in: '{0}'", src));
                    return result;
                }

                var j=0;
                result = DataParser.parse(skip(parts,j++), out dst.Index);
                if(result.Fail)
                    return result;

                result = IClassParser.Parse(skip(parts,j++), out dst.Class);
                if(result.Fail)
                    return result;

                result = IForms.Parse(skip(parts,j++), out dst.Form);
                if(result.Fail)
                    return result;

                result = Categories.Parse(skip(parts,j++), out dst.Category);
                if(result.Fail)
                    return result;

                result = Extensions.Parse(skip(parts,j++), out dst.Extension);
                if(result.Fail)
                    return result;

                result = IsaKinds.Parse(skip(parts,j++), out dst.Isa);
                if(result.Fail)
                    return result;

                if(i > 0)
                {
                     var attribs = text.right(content, i + AttribMarker.Length);
                     dst.Attributes = RP.embrace(ParseAttributes(attribs).Format());
                }

            }

            return result;
        }

        DelimitedIndex<string> ParseAttributes(string src)
        {
            var parts = text.index(text.trim(src), Chars.Space) != 0 ? text.split(src,Chars.Space) : array(text.trim(src));
            return parts.Delimit();
        }

        Outcome Parse(string src, out AttributeVector dst)
        {
            var parts = text.index(text.trim(src),Chars.Space) != 0 ? text.split(src,Chars.Space) : array(text.trim(src));
            var result = Outcome.Success;
            var count = parts.Length;
            dst = AttributeVector.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var name = ref skip(parts,i);
                result = Attributes.Parse(name, out var kind);
                if(result.Fail)
                    break;

                dst.Enable(kind);
            }

            return result;
        }

        Outcome Parse(in TextLine src, ushort instix, out InstOperand dst)
        {
            var result = Outcome.Success;
            var content = text.trim(src.Content);
            dst = default;
            var parts = text.split(content, Chars.Space);
            var count = parts.Length;
            if(count < 6)
            {
                result = (false, string.Format("At least 6 components not found in: '{0}'", src));
                return result;
            }

            dst.InstIndex = instix;
            var i=0;
            result = DataParser.parse(skip(parts,i++), out dst.OpIndex);
            if(result.Fail)
                return result;

            result = OperandKinds.Parse(skip(parts,i++), out dst.Kind);
            if(result.Fail)
                return result;

            result = Visibilities.Parse(skip(parts,i++), out dst.Visibility);
            if(result.Fail)
                return result;

            result = Actions.Parse(skip(parts,i++), out dst.Action);
            if(result.Fail)
                return result;

            result = Lookups.Parse(skip(parts,i++), out dst.Lookup);
            if(result.Fail)
                return result;

            result = ElementTypes.Parse(skip(parts,i++), out var tk);
            if(result)
                dst.Type = tk;
            else
                return result;

            if(count > 6)
            {
                if(dst.Lookup == LookupKind.REG)
                {
                    dst.Register = skip(parts,i++);
                }
                else
                {
                    result = Nonterminals.Parse(skip(parts,i++), out var nt);
                    if(result)
                        dst.NonTerm = nt;
                }
            }

            return result;
        }

        ReadOnlySpan<char> Digits(in TextLine src)
        {
            ref readonly var content = ref src.Content;
            var dst = DigitBuffer();
            var count = SQ.digits(base10,content,dst);
            if(count > 0)
                return slice(dst,0,count);
            else
                return default;
        }

        Outcome Validate(XedInstructions src)
        {
            var instcount = src.InstCount;
            var opcount = src.OperandCount;
            var counter = 0u;
            var j=0u;
            for(var i=z16; i<instcount; i++)
            {
                ref readonly var inst = ref src.Instruction(i);
                for(var k=0; k<inst.OpCount && j<opcount; k++,j++)
                {
                    ref readonly var op = ref src.Operand(j);
                    if(op.InstIndex != inst.Index)
                        return (false, "Mismatch");
                    counter++;
                }
            }
            return counter == opcount;
        }

        public Outcome Parse(FS.FilePath src, out XedInstructions dst)
        {
            using var reader = src.Utf8LineReader();
            var result = Outcome.Success;
            var entries = list<InstInfo>();
            var operands = list<InstOperand>();
            var allops = list<InstOperand>();
            var inst = default(InstInfo);
            var op = default(InstOperand);
            while(reader.Next(out var line))
            {
                var kind = Classify(line);
                switch(kind)
                {
                    case LineKind.None:
                        result = (false, string.Format("Line unclassifiable: {0}", line));
                    break;

                    case LineKind.Comment:
                    case LineKind.Empty:
                        continue;

                    case LineKind.Inst:
                        if(operands.Count != 0)
                        {
                            entries.Add(inst);
                            operands.Clear();
                        }
                        result = Parse(line, out inst);
                        break;

                    case LineKind.Operand:
                        result = Parse(line, inst.Index, out op);
                        if(result)
                            operands.Add(op);
                            allops.Add(op);
                        break;

                    case LineKind.OpCount:
                        result = byte.TryParse(line.Content.Trim(), out inst.OpCount);
                        break;
                }

                if(result.Fail)
                    break;
            }

            if(operands.Count != 0)
                entries.Add(inst);

            dst = new XedInstructions(entries.ToArray(), allops.ToArray());
            result = Validate(dst);
            return result;
        }
    }
}