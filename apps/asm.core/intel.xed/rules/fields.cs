//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {

        [MethodImpl(Inline), Op]
        public static ref FieldSet fields(bool premise, in RuleStatement src, ref FieldSet dst)
        {
            var criteria = premise ? ref src.Premise : ref src.Consequent;
            for(var i=0; i<criteria.Count; i++)
                dst.Include(criteria[i].Field);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref FieldSet fields(bool premise, in RuleTable src, ref FieldSet dst)
        {
            for(var i=0; i<src.EntryCount; i++)
                fields(premise, src[i], ref dst);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref FieldSet fields(in RuleTable src, ref FieldSet dst)
        {
            for(var i=0; i<src.EntryCount; i++)
            {
                fields(true, src[i], ref dst);
                fields(false, src[i], ref dst);
            }
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref FieldSet fields(Index<RuleCriterion> src, ref FieldSet dst)
        {
            for(var i=0; i<src.Count; i++)
                dst.Include(src[i].Field);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static FieldSet fields(bool premise, in RuleStatement src)
        {
            var dst = FieldSet.create();
            fields(premise, src, ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static FieldSet fields(Index<RuleCriterion> src)
        {
            var dst = FieldSet.create();
            return fields(src, ref dst);
        }

        [MethodImpl(Inline), Op]
        public static FieldSet fields(bool premise, in RuleTable src)
        {
            var dst = FieldSet.create();
            for(var i=0; i<src.EntryCount; i++)
                fields(premise, src[i], ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static FieldSet fields(in RuleTable src)
        {
            var dst = FieldSet.create();
            fields(src, ref dst);
            return dst;
        }
    }
}