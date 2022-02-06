//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CodeBanks : AppService<CodeBanks>
    {
        ApiDataPaths DataPaths => Service(Wf.ApiDataPaths);

        public static EncodingBank encoding(Index<EncodedMemberInfo> index, BinaryCode data)
        {
            var dst = new EncodingData();
            var comparer = EncodedMemberComparer.create(EncodedMemberComparer.ModeKind.Target);
            index.Sort(comparer);
            var bytes = data.View;
            var offset = 0u;
            var count = index.Count;
            var offsets = alloc<uint>(count);
            var tokens = alloc<ApiToken>(count);
            var symbols = SymbolDispenser.alloc();
            for(var i=0; i<count; i++)
            {
                ref readonly var info = ref index[i];
                ref readonly var size = ref info.CodeSize;
                if(offset + size > bytes.Length)
                    Errors.Throw(string.Format("Offset exceeded at {0} for {1}", i, info.Uri));

                seek(offsets,i) = offset;

                var result = entry(info, out var ep);
                if(result.Fail)
                    Errors.Throw(result.Message);

                seek(tokens,i) = ApiToken.create(symbols, ep, info.TargetAddress);
                var code = slice(bytes, offset, size);

                offset += size;
            }

            dst.Symbols = symbols;
            dst.Index = index;
            dst.CodeBuffer = memory.gcpin(data.Storage);
            dst.Offsets = offsets;
            dst.Tokens = tokens;
            return new EncodingBank(dst);
        }

        static Outcome entry(in EncodedMemberInfo src, out MethodEntryPoint dst)
        {
            var result = ApiUri.parse(src.Uri, out var uri);
            dst = MethodEntryPoint.Empty;
            if(result)
            {
                if(uri.IsEmpty)
                    result = (false, string.Format("Empty uri for {0}", src.Uri));
                else
                    dst = new MethodEntryPoint(src.EntryAddress, Require.notnull(uri), src.Sig);
            }
            return result;
        }

        internal class EncodingData
        {
            internal SymbolDispenser Symbols;

            internal Index<EncodedMemberInfo> Index;

            internal ManagedBuffer CodeBuffer;

            internal Index<uint> Offsets;

            internal Index<ApiToken> Tokens;
        }

        public EncodingBank Encoding()
        {
            var result = LoadCollected(out var index, out var code);
            if(result.Fail)
                Errors.Throw(result.Message);
            return encoding(index,code);
        }

        public EncodingBank Encoding(string spec)
        {
            var result = Outcome.Success;
            if(text.nonempty(spec))
            {
                var i = text.index(spec, Chars.FSlash);
                if(i>0)
                    return Encoding(ApiHostUri.define(ApiParsers.part(text.left(spec,i)), text.right(spec,i)));
                else
                    return Encoding(ApiParsers.part(spec));
            }
            else
            {
                return Encoding();
            }
        }

        public EncodingBank Encoding(PartId src)
        {
            var result = LoadCollected(src, out var index, out var code);
            if(result.Fail)
                Errors.Throw(result.Message);
            return CodeBanks.encoding(index,code);
        }

        public EncodingBank Encoding(ApiHostUri src)
        {
            var result = LoadCollected(src, out var index, out var code);
            if(result.Fail)
                Errors.Throw(result.Message);
            return CodeBanks.encoding(index,code);
        }

        Outcome LoadCollected(PartId src, out Index<EncodedMemberInfo> index, out BinaryCode data)
        {
            var result = Outcome.Success;
            var rA = LoadIndex(DataPaths.Path(src,FS.Csv), out index);
            var rB = LoadData(DataPaths.Path(src,FS.Hex), out data);
            if(rA.Fail)
                result = rA;
            else
                result = rB;
            return result;
        }

        Outcome LoadCollected(out Index<EncodedMemberInfo> index, out BinaryCode data)
        {
            var result = Outcome.Success;
            var rA = LoadIndex(DataPaths.Path(FS.Csv), out index);
            var rB = LoadData(DataPaths.Path(FS.Hex), out data);
            if(rA.Fail)
                result = rA;
            else
                result = rB;
            return result;
        }

        Outcome LoadCollected(ApiHostUri src, out Index<EncodedMemberInfo> index, out BinaryCode data)
        {
            var result = Outcome.Success;
            var rA = LoadIndex(DataPaths.Path(src, FS.Csv), out index);
            var rB = LoadData(DataPaths.Path(src, FS.Hex), out data);
            if(rA.Fail)
                result = rA;
            else
                result = rB;
            return result;
        }

        Outcome LoadIndex(FS.FilePath src, out Index<EncodedMemberInfo> dst)
        {
            var result = Outcome.Success;
            var lines = src.ReadLines(true);
            var count = lines.Count - 1;
            dst = alloc<EncodedMemberInfo>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i + 1];
                result = parse(line, out dst[i]);
                if(result.Fail)
                    break;
            }

            return result;
        }

        Outcome LoadData(FS.FilePath path, out BinaryCode dst)
        {
            var result = Outcome.Success;
            var cells = path.ReadLines().SelectMany(x => text.split(x,Chars.Space));
            var count = cells.Count;
            var data = alloc<byte>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var cell = ref cells[i];
                result = HexParser.parse8u(cell, out seek(data,i));
                if(result.Fail)
                    break;
            }
            if(result)
                dst = data;
            else
                dst = BinaryCode.Empty;
            return result;
        }

        static Outcome parse(string src, out EncodedMemberInfo dst)
        {
            const byte FieldCount = EncodedMemberInfo.FieldCount;
            dst = default;
            var cells = text.split(src, Chars.Pipe);
            var count = cells.Length;
            if(count != FieldCount)
                return (false, AppMsg.CsvDataMismatch.Format(FieldCount,count, src));

            var result = Outcome.Success;
            var i=0;
            result = DataParser.parse(skip(cells,i++), out dst.Id);
            result = DataParser.parse(skip(cells,i++), out dst.EntryAddress);
            result = DataParser.parse(skip(cells,i++), out dst.EntryRebase);
            result = DataParser.parse(skip(cells,i++), out dst.TargetAddress);
            result = DataParser.parse(skip(cells,i++), out dst.TargetRebase);
            result = DataParser.parse(skip(cells,i++), out dst.StubAsm);
            result = DataParser.parse(skip(cells,i++), out dst.Disp);
            result = DataParser.parse(skip(cells,i++), out dst.CodeSize);
            dst.Host = text.trim(skip(cells,i++));
            dst.Sig = text.trim(skip(cells,i++));
            dst.Uri = text.trim(skip(cells,i++));
            return result;
        }
    }
}