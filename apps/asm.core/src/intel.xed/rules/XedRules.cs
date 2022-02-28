//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;
    using static XedModels.RuleNames;

    [ApiHost]
    public partial class XedRules : AppService<XedRules>
    {
        Symbols<IClass> Classes;

        Symbols<CategoryKind> Categories;

        Symbols<ExtensionKind> Extensions;

        Symbols<OperandWidthType> OpWidthTypes;

        Symbols<XedDataType> DataTypes;

        Symbols<IsaKind> IsaKinds;

        Symbols<IFormType> Forms;

        Symbols<RuleOpName> OpKinds;

        Index<RulePart,string> PartNames;

        Index<PointerWidth> PointerWidths;

        Symbols<PointerWidthKind> PointerWidthSymbols;

        Symbols<VisibilityKind> Visibilities;

        Symbols<FieldType> FieldTypes;

        Symbols<FieldKind> OperandKinds;

        Symbols<RegFlag> Flags;

        Symbols<FlagActionKind> FlagActionKinds;

        public XedRules()
        {
            Classes = Symbols.index<IClass>();
            Categories = Symbols.index<CategoryKind>();
            Extensions = Symbols.index<ExtensionKind>();
            Forms = Symbols.index<IFormType>();
            IsaKinds = Symbols.index<IsaKind>();
            OpWidthTypes = Symbols.index<OperandWidthType>();
            DataTypes = Symbols.index<XedDataType>();
            OpKinds = Symbols.index<RuleOpName>();
            PointerWidthSymbols = Symbols.index<PointerWidthKind>();
            PointerWidths = map(PointerWidthSymbols.View, s => (PointerWidth)s);
            Visibilities = Symbols.index<VisibilityKind>();
            FieldTypes = Symbols.index<FieldType>();
            OperandKinds = Symbols.index<FieldKind>();
            FlagActionKinds = Symbols.index<FlagActionKind>();
            Flags = Symbols.index<RegFlag>();
            PartNames = new string[]{ICLASS,IFORM,ATTRIBUTES,CATEGORY,EXTENSION,FLAGS,PATTERN,OPERANDS,ISA_SET};
        }

        XedPaths XedPaths => Service(Wf.XedPaths);

        OpCodePatterns DeriveOpCodeMaps()
            => Data(nameof(DeriveOpCodeMaps), () => new OpCodePatterns());

        public OpCodePatterns LoadOpCodeMaps()
            => DeriveOpCodeMaps();

        public Index<PointerWidthInfo> LoadPointerWidths()
            => Data(nameof(LoadPointerWidths), () => mapi(PointerWidths, (i,w) => w.ToRecord((byte)i)));

        public Index<OperandWidth> LoadOperandWidths()
            => Data(nameof(LoadOperandWidths), ParseOperandWidths);

        public Index<RuleTable> ParseEncRuleTables()
            => new RuleTableParser().Parse(XedPaths.RuleSource(RuleDocKind.EncRuleTable));

        public Index<RuleTable> ParseDecRuleTables()
            => new RuleTableParser().Parse(XedPaths.RuleSource(RuleDocKind.DecRuleTable));

        public Index<RuleTable> ParseEncDecRuleTables()
            => new RuleTableParser().Parse(XedPaths.RuleSource(RuleDocKind.EncDecRuleTable));

        public Index<InstDef> ParseEncInstDefs()
            => ParseInstDefs(XedPaths.RuleSource(RuleDocKind.EncInstDef));

        public Index<InstDef> ParseDecInstDefs()
            => ParseInstDefs(XedPaths.RuleSource(RuleDocKind.DecInstDef));

        public ReadOnlySpan<NonterminalKind> NonterminalKinds()
            => Symbols.index<NonterminalKind>().Kinds;

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

        public ConstLookup<string,OperandWidth> OperandWidths()
        {
            return Data(nameof(OperandWidths), Load);

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

        void EmitOperands(ReadOnlySpan<InstDef> defs, FS.FilePath dst)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var count = defs.Length;
            var buffer = text.buffer();
            var counter = 0u;
            var ockinds = Symbols.index<OpCodeKind>();
            for(var i=0; i<count; i++)
            {
                ref readonly var def = ref defs[i];

                var ops = def.PatternOps;
                var patterns = ExtractRulePatterns(def);
                var k = ops.Count;
                Require.equal(patterns.Count, k);
                for(var j=0; j<k; j++)
                {
                    ref readonly var op = ref ops[j];
                    ref readonly var pattern = ref patterns[j];
                    var oc = opcode(pattern);

                    ockinds.MapKind(oc.Kind, out var sym);
                    writer.WriteLine(string.Format("{0,-6} | {1,-16} | {2,-12} | {3,-12} | {4,-8} | {5}", i, def.Class, sym.Expr, oc.Value, EmptyString, op.Expr));
                    counter++;

                    var specs = op.Specs;
                    var m = specs.Count;
                    for(var q=0; q<m; q++)
                    {
                        ref readonly var spec = ref specs[q];
                        writer.WriteLine(string.Format("{0,-6} | {1,-16} | {2,-12} | {3,-12} | {4,-8} | {5}", i, def.Class, q, spec.Name, spec.Kind, spec.Expression));
                        counter++;
                    }
                }
            }

            EmittedFile(emitting,counter);
        }

        static MsgPattern<string> StepParseFailed => "Failed to parse step from '{0}'";
    }
}