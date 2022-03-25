//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedParsers;

    using RF = XedRules.RuleFormKind;

    partial class XedRules
    {
        public static RuleTable reify(RuleTableSpec src)
        {
            var body = list<RuleStatement>();
            for(var i=0; i<src.Statements.Count; i++)
            {
                ref readonly var stmt = ref src.Statements[i];
                if(stmt.IsNonEmpty)
                    body.Add(reify(stmt));
            }
            return new (src.Sig, body.ToArray());
        }

        public static RuleStatement reify(StatementSpec src)
        {
            var left = sys.empty<RuleCriterion>();
            if(src.Premise.IsNonEmpty)
                left = premise(src);

            var right = sys.empty<RuleCriterion>();
            if(src.Consequent.IsNonEmpty)
                right = consequent(src);

            return new RuleStatement(left, right);
        }

        public static Index<RuleTable> reify(ReadOnlySpan<RuleTableSpec> src)
        {
            var dst = alloc<RuleTable>(src.Length);
            for(var i=0; i<src.Length; i++)
                seek(dst,i) = reify(skip(src,i));
            return dst;
        }

        static Index<RuleCriterion> premise(StatementSpec src)
            => criteria(true, src.Premise.View);

        static Index<RuleCriterion> consequent(StatementSpec src)
            => criteria(false, src.Consequent.View);

        public static RF RuleForm(string src)
        {
            var i = text.index(src, Chars.Hash);
            var content = (i> 0 ? text.left(src,i) : src).Trim();
            if(IsTableDecl(content))
                return RF.RuleDecl;
            if(IsEncStep(content))
                return RF.EncodeStep;
            if(IsDecStep(content))
                return RF.DecodeStep;
            if(IsNonterminal(content))
                return RF.Invocation;
            if(IsSeqDecl(content))
                return RF.SeqDecl;
            return 0;
        }
    }
}