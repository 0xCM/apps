//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Arrays;

    partial class ApiCode
    {
        public static ReadOnlySeq<ApiCatalogEntry> catalog(ApiMembers src)
        {
            var dst = sys.alloc<ApiCatalogEntry>(src.Count);
            if(src.IsNonEmpty)
            {
                var @base = src.BaseAddress;
                var rebase = src[0].BaseAddress;
                for(var i=0u; i<src.Count; i++)
                {
                    ref readonly var member = ref src[i];
                    ref var record = ref seek(dst,i);
                    record.Sequence = i;
                    record.ProcessBase = @base;
                    record.MemberBase = member.BaseAddress;
                    record.MemberOffset = member.BaseAddress - @base;
                    record.MemberRebase = (uint)(member.BaseAddress - rebase);
                    record.HostName = member.Host.HostName;
                    record.PartName = member.Host.Part.Format();
                    record.OpUri = member.OpUri;
                }
            }
            return dst;
        }
    }
}