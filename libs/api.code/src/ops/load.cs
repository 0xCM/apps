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
        [Op]
        public static ApiMemberCode load(IApiPack src, PartId part, IWfEventTarget log)
        {
            load(src, part, log, out var seq, out var code);
            return members(Dispense.composite(), seq, code);
        }

        [Op]
        public static ApiMemberCode load(IApiPack src, ICompositeDispenser symbols, ApiHostUri host, IWfEventTarget log)
        {
            load(src, host, log, out var seq, out var code);
            return members(symbols, seq, code);
        }

        [Op]
        public static ApiMemberCode load(IApiPack src, ICompositeDispenser symbols, PartId part, IWfEventTarget log)
        {
            load(src, part, log, out var seq, out var code);
            return members(symbols, seq, code);
        }

        [Op]
        public static void load(IApiPack src, ApiHostUri host, IWfEventTarget log, out Seq<EncodedMember> index, out BinaryCode data)
        {
            hex(src.HexExtractPath(host), out data).Require();
            parse(src.CsvExtractPath(host), out index).Require();
        }

        [Op]
        public static void load(IApiPack src, PartId part, IWfEventTarget log, out Seq<EncodedMember> index, out BinaryCode data)
        {
            index = member(src, part, log);
            data = code(src, part, log);
        }

        [Op]
        static ApiMemberCode members(ICompositeDispenser symbols, Index<EncodedMember> src, BinaryCode code)
        {
            var dst = new ApiMemberCode.EncodingData();
            src.Sort(EncodedMember.comparer(EncodedMember.CmpKind.Target));
            var offset = 0u;
            var count = src.Count;
            var offsets = sys.alloc<uint>(count);
            var tokens = sys.alloc<ApiToken>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var info = ref src[i];
                ref readonly var size = ref info.CodeSize;
                if(offset + size > code.Length)
                    Errors.Throw(string.Format("Offset exceeded at {0} for {1}", i, info.Uri));

                seek(offsets,i) = offset;
                ApiIdentity.parse(info.Uri, out var uri).Require();
                var e = new MethodEntryPoint(info.EntryAddress, Require.notnull(uri), info.Sig);
                seek(tokens,i) = token(symbols, e, info.TargetAddress);
                offset += size;
            }

            dst.Symbols = symbols;
            dst.Members = src;
            dst.CodeBuffer = ManagedBuffer.pin(code.Storage);
            dst.Offsets = offsets;
            dst.Tokens = tokens;
            return ApiMemberCode.own(dst);
        }

        [Op]
        static Seq<EncodedMember> member(IApiPack src, PartId part, IWfEventTarget log)
        {
            var dst = Seq<EncodedMember>.Empty;
            var result = parse(src.CsvExtractPath(part), out dst);
            if(result.Fail)
            {
                log.Deposit(Events.warn(log.Host, result.Message));
                Errors.Throw($"{part.Format()} member load failure");
            }
            return dst;
        }

        [Op]
        static BinaryCode code(IApiPack src, PartId part, IWfEventTarget log)
        {
            var dst = BinaryCode.Empty;
            var result = hex(src.HexExtractPath(part), out dst);
            if(result.Fail)
            {
                log.Deposit(Events.error(log.Host, result.Message));
                Errors.Throw(result.Message);
            }
            return dst;
        }
    }
}