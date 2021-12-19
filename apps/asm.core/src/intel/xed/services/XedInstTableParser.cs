//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static XedModels;
    using static XedInstTable;
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

        EnumParser<OperandKind> OperandKinds {get;}

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

        EnumParser<Nonterminal> Nonterminals;

        EnumParser<RegId> Regs;

        EnumParser<OperandElementType> ElementTypes;

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
            if(i > 0)
            {
                var parts = text.split(text.left(content, i), Chars.Space);
                var count = parts.Length;
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

                var attribs = text.split(text.right(content, i + AttribMarker.Length), Chars.Space);
                result = Parse(attribs, out dst.Attributes);
            }

            return result;
        }

        Outcome Parse(ReadOnlySpan<string> src, out AttributeVector dst)
        {
            var result = Outcome.Success;
            var count = src.Length;
            dst = AttributeVector.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var name = ref skip(src,i);
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
            result = DataParser.parse(skip(parts,i++), out dst.OperandIndex);
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

            result = ElementTypes.Parse(skip(parts,i++), out dst.Type);
            if(result.Fail)
                return result;

            if(count > 6)
            {
                if(dst.Lookup == LookupKind.REG)
                    result = Regs.Parse(skip(parts,i++), out dst.Register);
                else
                    result = Nonterminals.Parse(skip(parts,i++), out dst.NonTerm);
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

        public Outcome Parse(FS.FilePath src, out XedInstTable dst)
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
                        result = byte.TryParse(line.Content.Trim(), out inst.OperandCount);
                        break;
                }

                if(result.Fail)
                    break;
            }

            if(operands.Count != 0)
                entries.Add(inst);

            dst = new XedInstTable(entries.ToArray(), allops.ToArray());
            return result;
        }
    }
}