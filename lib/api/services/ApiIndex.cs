//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static Root;

    [ApiHost]
    public readonly struct ApiIndex
    {
        internal static ApiMemberIndex create(ApiHostCatalog src)
        {
            var ix = create(src.Members.Storage.Select(h => (h.Id, h)));
            return new ApiMemberIndex(ix.HashTable, ix.Duplicates);
        }

        public static Index<ApiMemberCode> join(ApiMemberIndex members, ApiOpIndex<ApiCodeBlock> code)
        {
            var apicode = from pair in Intersect(members, code).Enumerated
                          let l = pair.Item1
                          let r = pair.Item2
                          select new ApiMemberCode(r.Left, r.Right);
            return apicode.Array();
        }

        [Op, Closures(UInt64k)]
        static ApiOpIndex<Paired<L,R>> Intersect<L,R>(IApiOpIndex<L> left, IApiOpIndex<R> right)
        {
             var keys = left.Keys.ToHashSet();
             keys.IntersectWith(right.Keys);

             var keylist = keys.ToArray();
             var count = keylist.Length;
             var entires = sys.alloc<Paired<OpIdentity, Paired<L,R>>>(count);
             for(var i=0; i<count; i++)
             {
                var key = keylist[i];
                entires[i] = (key, (left[key], right[key]));
             }
             return ApiIndex.create(entires);
         }

        /// Creates an operation index from a uri bitstream
        /// </summary>
        /// <param name="src">The source bits</param>
        public static ApiOpIndex<ApiCodeBlock> create(ApiCodeBlock[] src)
            => distill(src.Select(x => (x.OpUri.OpId, x)));

        [Op, Closures(UInt64k)]
        public static ApiOpIndex<T> create<T>(IEnumerable<(OpIdentity,T)> src)
        {
            var items = src.ToArray();
            var identities = items.Select(x => x.Item1).ToArray();
            var duplicates = (from g in identities.GroupBy(i => i.IdentityText)
                             where g.Count() > 1
                             select g.Key).ToHashSet();

            var dst = new Dictionary<OpIdentity,T>();
            if(duplicates.Count() != 0)
                dst = items.Where(i => !duplicates.Contains(i.Item1.IdentityText)).ToDictionary();
            else
                dst = src.ToDictionary();

            return new ApiOpIndex<T>(dst, duplicates.Select(d => ApiUri.opid(d)).Array());
        }

        [Op, Closures(UInt64k)]
        public static ApiOpIndex<T> create<T>(Paired<OpIdentity,T>[] src)
        {
            var items = src.ToArray();
            var identities = items.Select(x => x.Left).ToArray();
            var duplicates = (from g in identities.GroupBy(i => i.IdentityText)
                             where g.Count() > 1
                             select g.Key).ToHashSet();

            var dst = new Dictionary<OpIdentity,T>();
            if(duplicates.Count() != 0)
                dst = items.Where(i => !duplicates.Contains(i.Left.IdentityText)).ToDictionary();
            else
                dst = src.ToDictionary();

            return new ApiOpIndex<T>(dst, duplicates.Select(d => ApiUri.opid(d)).Array());
        }

        internal static ApiOpIndex<T> distill<T>((OpIdentity,T)[] src)
        {
            try
            {
                var identities = src.Select(x => x.Item1);
                var duplicates = (from g in identities.GroupBy(i => i.IdentityText)
                                where g.Count() > 1
                                select g.Key).ToHashSet();

                var dst = new Dictionary<OpIdentity,T>();
                if(duplicates.Count() != 0)
                    dst = src.Where(i => !duplicates.Contains(i.Item1.IdentityText)).ToDictionary();
                else
                    dst = src.ToDictionary();
                return new ApiOpIndex<T>(dst, duplicates.Select(d => ApiUri.opid(d)).Array());
            }
            catch(Exception e)
            {
                term.error(e);
                return ApiOpIndex<T>.Empty;
            }
        }
    }
}