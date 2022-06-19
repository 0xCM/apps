//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

    [ApiHost]
    public readonly struct ApiCodeBlocks
    {
        public const string CaptureAddressMismatch = "The parsed address does not match the extration address";

        public static ReadOnlySpan<ApiMemberCode> filter(ReadOnlySpan<ApiMemberCode> src, ApiClassKind kind)
        {
            var count = src.Length;
            var dst = list<ApiMemberCode>();
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                if(code.KindId == kind)
                    dst.Add(code);
            }
            return dst.ViewDeposited();
        }


        [Op]
        static ReadOnlySpan<ApiHostBlocks> hosted(Index<ApiCodeBlock> src)
        {
            if(src.IsEmpty)
                return array<ApiHostBlocks>();
            else
            {
                var keyed = src.Storage.Where(x => x.HostUri.IsNonEmpty).Select(x => (x.HostUri, x)).ToReadOnlySpan();
                var count = keyed.Length;
                var dst = dict<ApiHostUri,List<ApiCodeBlock>>();
                for(var i=0; i<count; i++)
                {
                    ref readonly var code = ref skip(keyed,i);
                    if(dst.TryGetValue(code.HostUri, out var blocks))
                        blocks.Add(code.x);
                    else
                    {
                        var target = list<ApiCodeBlock>();
                        target.Add(code.x);
                        dst.Add(code.HostUri, target);
                    }
                }
                return dst.Map(x => new ApiHostBlocks(x.Key, x.Value.ToArray()));
            }
        }

        [Op]
        public static ReadOnlySpan<ApiHostBlocks> hosted(ReadOnlySpan<ApiCodeBlock> src)
            => hosted(src.ToArray());

        [Op]
        public static ReadOnlySpan<ApiPartBlocks> parts(ReadOnlySpan<ApiHostBlocks> src)
            => src.ToArray().GroupBy(x => x.Part).Map(x => new ApiPartBlocks(x.Key, x.ToArray()));
    }
}