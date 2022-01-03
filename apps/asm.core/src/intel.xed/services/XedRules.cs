//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static XedModels;
    using static core;
    using static Root;

    using static XedModels.RuleNames;
    using EK = XedModels.RuleExprKind;

    [ApiHost]
    public partial class XedRules : AppService<XedRules>
    {
        Symbols<IClass> Classes;

        Symbols<CategoryKind> Categories;

        Symbols<ExtensionKind> Extensions;

        Symbols<OperandWidthType> OpWidthTypes;

        Symbols<DataType> DataTypes;

        Symbols<IsaKind> IsaKinds;

        Symbols<IFormType> Forms;

        Symbols<RuleOpKind> OpKinds;

        Index<RulePart,string> PartNames;

        Index<PointerWidth> PointerWidths;

        Symbols<PointerWidthKind> PointerWidthSymbols;
        public XedRules()
        {
            Classes = Symbols.index<IClass>();
            Categories = Symbols.index<CategoryKind>();
            Extensions = Symbols.index<ExtensionKind>();
            Forms = Symbols.index<IFormType>();
            IsaKinds = Symbols.index<IsaKind>();
            OpWidthTypes = Symbols.index<OperandWidthType>();
            DataTypes = Symbols.index<DataType>();
            OpKinds = Symbols.index<RuleOpKind>();
            PointerWidthSymbols = Symbols.index<PointerWidthKind>();
            PointerWidths = map(PointerWidthSymbols.View, s => (PointerWidth)s);
            PartNames = new string[]{ICLASS,IFORM,ATTRIBUTES,CATEGORY,EXTENSION,FLAGS,PATTERN,OPERANDS,ISA_SET};
        }

        public void EmitCatalog()
        {
            var enc = EmitEncInstDefs();
            var dec = EmitDecInstDefs();
            EmitRulePatterns(enc,dec);
            EmitEncRuleTables();
            EmitDecRuleTables();
            EmitEncDecRuleTables();
            EmitOperandWidths();
            EmitPointerWidths();
        }

        public Index<OperandWidth> EmitOperandWidths()
        {
            var src = ParseOperandWidths();
            var dst = ProjectDb.TablePath<OperandWidth>("xed");
            TableEmit(src.View,dst);
            return src;
        }

        public Index<PointerWidthRecord> EmitPointerWidths()
        {
            var src = mapi(PointerWidths.Where(x => x.Kind != 0), (i,w) => w.ToRecord((byte)i));
            var dst = RuleTarget(RuleDocKind.PointerWidths);
            TableEmit(src.View, PointerWidthRecord.RenderWidths, dst);
            return src;
        }

        public Index<PointerWidthRecord> LoadPointerWidths()
            => Data(nameof(LoadPointerWidths), () => mapi(PointerWidths, (i,w) => w.ToRecord((byte)i)));

        public Index<OperandWidth> LoadOperandWidths()
            => Data(nameof(LoadOperandWidths), ParseOperandWidths);

        public Index<RuleTable> ParseEncRuleTables()
            => ParseRuleTables(RuleSource(RuleDocKind.EncRuleTable));

        public Index<RuleTable> ParseDecRuleTables()
            => ParseRuleTables(RuleSource(RuleDocKind.DecRuleTable));

        public Index<RuleTable> ParseEncDecRuleTables()
            => ParseRuleTables(RuleSource(RuleDocKind.EncDecRuleTable));

        Index<RulePattern> ExtractRulePatterns(ReadOnlySpan<InstDef> src)
        {
            var buffer = hashset<RulePattern>();
            var instcount = src.Length;
            for(var i=0; i<instcount; i++)
            {
                ref readonly var inst = ref skip(src,i);
                var operands = inst.PatternOps;
                var opcount = operands.Length;
                for(var j=0; j<opcount;j++)
                {
                    ref readonly var op = ref operands[j];
                    var pattern = new RulePattern();
                    pattern.Class = inst.Class;
                    pattern.Content = op.Pattern;
                    pattern.Hash = alg.hash.calc(op.Pattern.Text);
                    buffer.Add(pattern);
                }
            }

            var dst = buffer.Array().Sort();
            var count = dst.Length;
            var hashes = hashset<Hash32>();

            for(var i=0u; i<count; i++)
            {
                ref var record = ref seek(dst,i);
                record.Seq = i;
                hashes.Add(record.Hash);
            }

            if(hashes.Count != count)
                Warn(string.Format("Rule hash imperfect"));
            else
                Status(string.Format("Rule hash perfect"));

            return dst;
        }

        Index<RulePattern> EmitRulePatterns(Index<InstDef> x, Index<InstDef> y)
        {
            var enc = x.SelectMany(x => x.PatternOps).Select(x => x.Pattern).Distinct().Sort();
            var dec = y.SelectMany(x => x.PatternOps).Select(x => x.Pattern).Distinct().Sort();
            var count = Require.equal(enc.Count, dec.Count);
            var patterns = ExtractRulePatterns(x);
            // var buffer = alloc<RulePattern>(count);
            // var hashes = hashset<Hash32>();
            // for(var i=0u; i<count; i++)
            // {
            //     ref readonly var a = ref enc[i];
            //     ref readonly var b = ref dec[i];
            //     ref var dst = ref seek(buffer,i);
            //     dst.Seq = i;
            //     dst.Content = Require.equal(a,b);
            //     dst.Hash = alg.hash.calc(dst.Content.Text);
            //     hashes.Add(dst.Hash);
            // }

            var path = RuleTarget(RuleDocKind.Patterns);
            TableEmit(patterns.View, RulePattern.RenderWidths, path);
            return patterns;
        }

        public Index<InstDef> EmitEncInstDefs()
        {
            var src = ParseEncInstDefs();
            EmitEncInstDefs(src);
            return src;
        }

        public Index<InstDef> EmitDecInstDefs()
        {
            var src = ParseDecInstDefs();
            EmitDecInstDefs(src);
            return src;
        }

        public Index<RuleTable> EmitEncRuleTables()
        {
            var src = ParseEncRuleTables();
            EmitEncRuleTables(src);
            return src;
        }

        public Index<RuleTable> EmitDecRuleTables()
        {
            var src = ParseDecRuleTables();
            EmitDecRuleTables(src);
            return src;
        }

        public Index<RuleTable> EmitEncDecRuleTables()
        {
            var src = ParseEncDecRuleTables();
            EmitEncDecRuleTables(src);
            return src;
        }

        public Index<InstDef> ParseEncInstDefs()
            => ParseInstDefs(RuleSource(RuleDocKind.EncInstDef));

        public Index<InstDef> ParseDecInstDefs()
            => ParseInstDefs(RuleSource(RuleDocKind.DecInstDef));

        public FS.FilePath EmitEncInstDefs(ReadOnlySpan<InstDef> src)
            => EmitInstDefs(src, RuleTarget(RuleDocKind.EncInstDef));

        public FS.FilePath EmitDecInstDefs(ReadOnlySpan<InstDef> src)
            => EmitInstDefs(src, RuleTarget(RuleDocKind.DecInstDef));

        public FS.FilePath EmitEncRuleTables(ReadOnlySpan<RuleTable> src)
            => EmitRuleTables(src, RuleTarget(RuleDocKind.EncRuleTable));

        public FS.FilePath EmitDecRuleTables(ReadOnlySpan<RuleTable> src)
            => EmitRuleTables(src, RuleTarget(RuleDocKind.DecRuleTable));

        public FS.FilePath EmitEncDecRuleTables(ReadOnlySpan<RuleTable> src)
            => EmitRuleTables(src, RuleTarget(RuleDocKind.EncDecRuleTable));

        bool Part(string src, out RulePart part)
        {
            var count = PartNames.Count;
            var result = false;
            part = default;
            for(var i=0; i<count; i++)
            {
                var p = (RulePart)i;
                ref readonly var n = ref PartNames[p];
                if(n == src)
                {
                    part = p;
                    result = true;
                    break;
                }
            }
            return result;
        }

        Outcome ParseIClass(string src, out IClass dst)
            => Classes.ExprKind(src, out dst);

        Outcome ParseIsaKind(string src, out IsaKind dst)
            => IsaKinds.ExprKind(src, out dst);

        Outcome ParseCategory(string src, out Category dst)
        {
            dst = default;
            var result = Categories.ExprKind(src, out var kind);
            if(result)
                dst = kind;
            return result;
        }

        Outcome ParseAttribKinds(string src, out Index<AttributeKind> dst)
        {
            dst = attributes(src,Chars.Space);
            return true;
        }

        Outcome ParseExtension(string src, out Extension dst)
        {
            dst = default;
            var result = Extensions.ExprKind(src, out var kind);
            if(result)
                dst = kind;
            return result;
        }

        Outcome ParseIForm(string src, out IForm dst)
        {
            dst = default;
            Outcome result = Forms.ExprKind(src, out var kind);
            if(result)
                dst = kind;
            else
                result = (false, Msg.ParseFailure.Format(nameof(IFormType), src));
            return result;
        }

        FS.FolderPath Sources()
            => ProjectDb.Sources("intel/xed.primary");

        FS.FolderPath Targets()
            => ProjectDb.Subdir("xed");

        FS.FilePath RuleSource(RuleDocKind kind)
            => Sources() + FS.file(Symbols.format(kind), FS.Txt);

        FS.FilePath RuleTarget(RuleDocKind kind)
            => Targets() + ( kind switch{
                 RuleDocKind.EncInstDef => FS.file("xed.rules.encoding", FS.Txt),
                 RuleDocKind.DecInstDef=> FS.file("xed.rules.decoding", FS.Txt),
                 RuleDocKind.EncRuleTable => FS.file("xed.rules.encoding.tables", FS.Txt),
                 RuleDocKind.DecRuleTable => FS.file("xed.rules.decoding.tables", FS.Txt),
                 RuleDocKind.EncDecRuleTable => FS.file("xed.rules.encdec.tables", FS.Txt),
                 RuleDocKind.Widths => FS.file("xed.rules.widths", FS.Csv),
                 RuleDocKind.PointerWidths => Tables.filename<PointerWidthRecord>(),
                 RuleDocKind.Patterns => Tables.filename<RulePattern>(),
                 _ => FS.FileName.Empty
            });


        const string RuleDeclMarker = "()::";

        const string InvokeMarker = "()";

        const string EncStepMarker = " -> ";

        const string DecStepMarker = " |";

        const string SeqDeclMarker = "SEQUENCE ";

        static EK ClassifyExpr(TextLine src)
        {
            var i = text.index(src.Content, Chars.Hash);
            var content = (i> 0 ? text.left(src.Content,i) : src.Content).Trim();

            if(content.EndsWith(RuleDeclMarker))
                return EK.RuleDeclaration;
            if(content.Contains(EncStepMarker))
                return EK.EncodeStep;
            if(content.Contains(DecStepMarker))
                return EK.DecodeStep;
            if(content.EndsWith(InvokeMarker))
                return EK.Invocation;
            if(content.StartsWith(SeqDeclMarker))
                return EK.SeqDeclaration;
            return 0;
        }

        ConstLookup<string,OperandWidth> OpWidthLookup()
        {
            return Data(nameof(OpWidthLookup), Load);
            ConstLookup<string,OperandWidth> Load()
            {
                var widths = LoadOperandWidths();
                var dst = dict<string,OperandWidth>();
                var symbols = Symbols.index<OperandWidthType>();
                var count = widths.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var src = ref widths[i];
                    var symbol = symbols[src.Code];
                    dst[symbol.Expr.Format()] = src;
                }
                return dst;
            }
        }

        static MsgPattern<string> StepParseFailed => "Failed to parse step from '{0}'";
    }
}