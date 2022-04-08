//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static ref FieldSet include(bool premise, in RuleStatement src, ref FieldSet dst)
        {
            var criteria = premise ? ref src.Premise : ref src.Consequent;
            for(var i=0; i<criteria.Count; i++)
                dst.Include(criteria[i].Field);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref FieldSet include(in RuleTable src, ref FieldSet dst)
        {
            for(var i=0; i<src.RowCount; i++)
            {
                include(true, src[i], ref dst);
                include(false, src[i], ref dst);
            }
            return ref dst;
        }
    }
}