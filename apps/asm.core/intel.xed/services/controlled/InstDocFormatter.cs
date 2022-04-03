//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedPatterns;
    using static XedRules;
    using static XedModels;
    using static Markdown;

    partial class XedDocs
    {
        public class InstDocFormatter
        {
            readonly InstDoc Doc;

            readonly RuleTables Rules;

            string Classifier;

            XedOpCode OpCode;

            public InstDocFormatter(RuleTables rules, InstDoc doc)
            {
                Classifier = EmptyString;
                OpCode = XedOpCode.Empty;
                Rules = rules;
                Doc = doc;
            }

            static SectionHeader FormHeader(in InstDocPart part)
                => new(4, string.Format("{0} {1}", string.Format("{0} {1}", part.OcMap, part.OpCode.Value), part.InstForm));

            static SectionHeader ClassHeader(in InstDocPart part)
                => new(3, part.Classifier);

            static SectionHeader TableHeader(in RuleSig sig)
                => new(3, sig.Format());

            static SectionLink Link(in RuleSig sig)
                => Markdown.link(sig.Format(), sig.Format());

            static void RenderSigHeader(in InstDocPart part, ITextBuffer dst)
            {
                var title = new SectionHeader(5, part.Classifier.ToLower());
                dst.Append(title.Format());

                for(var k=0; k<part.OpNames.Count; k++)
                {
                    if(k!=0)
                        dst.Append(Chars.Comma);
                    dst.Append(Chars.Space);
                    dst.Append(part.OpNames[k].Indicator.Format());
                }
                dst.AppendLine();
            }

            void Render(in InstDocPart part, ITextBuffer dst)
            {
                if(part.Classifier != Classifier)
                {
                    Classifier = part.Classifier;
                    dst.AppendLine(ClassHeader(part));
                    dst.AppendLine();
                }

                if(part.OpCode != OpCode)
                {
                    OpCode = part.OpCode;
                    dst.AppendLine(FormHeader(part));
                    dst.AppendLine();
                }

                RenderSigHeader(part,dst);
                dst.AppendLine();

                dst.AppendFormat("{0} |", Classifier);

                if(part.Layout.IsNonEmpty)
                    dst.AppendFormat(" {0}", part.Layout);
                if(part.Constraints.IsNonEmpty)
                    dst.AppendFormat(" <{0}>", part.Constraints);
                dst.AppendLine();

                ref readonly var ops = ref part.Ops;
                for(var k=0; k<ops.Count; k++)
                {
                    ref readonly var op = ref ops[k];
                    var attribs = op.Attribs.Sort();;

                    dst.AppendFormat("{0,-2}", op.Index);
                    dst.AppendFormat("{0,-8}", op.Name);
                    if(op.Action(out var action))
                        dst.AppendFormat("{0,-3}", XedRender.format(action));
                    if(op.Visibility(out var opvis))
                        dst.AppendFormat("{0} ", opvis.Code());
                    else
                        dst.AppendFormat("{0} ", Visibility.Explicit.Code());

                    dst.Append(InstPageFormatter.opwidth(part.Mode, op));

                    if(op.Nonterminal(out var nt))
                    {
                        var sig = new RuleSig(RuleTableKind.Enc,nt.Name);
                        var table = Rules.Table(sig);
                        if(table.IsNonEmpty)
                            dst.Append(Link(sig).Format());
                        else
                        {
                            sig = new RuleSig(RuleTableKind.Dec,nt.Name);
                            table = Rules.Table(sig);
                            if(table.IsNonEmpty)
                                dst.Append(Link(sig).Format());
                            else
                                dst.Append(nt.Format());
                        }
                    }

                    dst.AppendLine();
                }
                dst.AppendLine();
            }

            void RenderTable(in RuleSig sig, in RuleTable table, ITextBuffer dst)
            {
                dst.AppendLine(TableHeader(sig));
                dst.AppendLine();

                var g = XedRules.grid(table);
                for(var i=0; i<g.Count; i++)
                    dst.AppendLine(g[i].Join(Chars.Space));

                dst.AppendLine();
            }

            public string Format()
            {
                var doc = Doc;
                var dst = text.buffer();
                dst.AppendLine(header(1, "Xed Instructions"));
                dst.AppendLine();
                dst.AppendLine(header(2,"Patterns"));
                dst.AppendLine();
                for(var i=0; i<doc.Parts.Count; i++)
                    Render(doc[i],dst);

                dst.AppendLine(header(2,"Rules"));
                dst.AppendLine();

                var sigs = Rules.Sigs();
                for(var i=0; i<sigs.Length; i++)
                {
                    ref readonly var sig =ref sigs[i];
                    RenderTable(sig, Rules.Table(sig), dst);
                }

                return dst.Emit();
            }
        }
    }
}