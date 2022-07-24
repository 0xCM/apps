//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCode
    {
        public EncodedMembers LoadEncoded(IApiPack src, PartId part)
        {
            Load(src, part, out var seq, out var code);
            return members(Dispense.composite(), seq, code);
        }

        public EncodedMembers LoadEncoded(IApiPack src, ICompositeDispenser symbols, ApiHostUri host)
        {
            Load(src, host, out var seq, out var code);
            return members(symbols, seq, code);
        }

        public EncodedMembers LoadEncoded(IApiPack src, ICompositeDispenser symbols, PartId part)
        {
            Load(src, part, out var seq, out var code);
            return members(symbols, seq, code);
        }

        void Load(IApiPack src, ApiHostUri host, out Seq<EncodedMember> index, out BinaryCode data)
        {
            ApiCode.hex(src.HexExtractPath(host), out data).Require();
            ApiCode.index(src.CsvExtractPath(host), out index).Require();
        }

        void Load(IApiPack src, PartId part, out Seq<EncodedMember> index, out BinaryCode data)
        {
            index = LoadMember(src, part);
            data = LoadCode(src, part);
        }
    }
}