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

        Symbols<RuleOpName> OpKinds;

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
            OpKinds = Symbols.index<RuleOpName>();
            PointerWidthSymbols = Symbols.index<PointerWidthKind>();
            PointerWidths = map(PointerWidthSymbols.View, s => (PointerWidth)s);
            PartNames = new string[]{ICLASS,IFORM,ATTRIBUTES,CATEGORY,EXTENSION,FLAGS,PATTERN,OPERANDS,ISA_SET};
        }

        OpCodeMaps DeriveOpCodeMaps()
            => Data(nameof(DeriveOpCodeMaps), () => new OpCodeMaps());

        public OpCodeMaps LoadOpCodeMaps()
            => DeriveOpCodeMaps();

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

        public Index<InstDef> ParseEncInstDefs()
            => ParseInstDefs(RuleSource(RuleDocKind.EncInstDef));

        public Index<InstDef> ParseDecInstDefs()
            => ParseInstDefs(RuleSource(RuleDocKind.DecInstDef));

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