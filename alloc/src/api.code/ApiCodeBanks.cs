//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    // public class ApiCodeBanks : AppService<ApiCodeBanks>
    // {

        // public EncodedMembers Encoding()
        // {
        //     var result = LoadCollected(out var index, out var code);
        //     if(result.Fail)
        //         Errors.Throw(result.Message);
        //     return Alloc.members(index,code);
        // }

        // public EncodedMembers Encoding(string spec)
        // {
        //     var result = Outcome.Success;
        //     if(text.nonempty(spec))
        //     {
        //         var i = text.index(spec, Chars.FSlash);
        //         if(i>0)
        //             return Encoding(ApiHostUri.define(ApiParsers.part(text.left(spec,i)), text.right(spec,i)));
        //         else
        //             return Encoding(ApiParsers.part(spec));
        //     }
        //     else
        //     {
        //         return Encoding();
        //     }
        // }

        // public EncodedMembers Encoding(PartId src)
        // {
        //     var result = LoadCollected(src, out var index, out var code);
        //     if(result.Fail)
        //         Errors.Throw(result.Message);
        //     return Alloc.members(index,code);
        // }

        // public EncodedMembers Encoding(ApiHostUri src)
        // {
        //     var result = LoadCollected(src, out var index, out var code);
        //     if(result.Fail)
        //         Errors.Throw(result.Message);
        //     return Alloc.members(index,code);
        // }

        // Outcome LoadCollected(PartId src, out Index<EncodedMember> index, out BinaryCode data)
        // {
        //     var result = Outcome.Success;
        //     var rA = LoadIndex(DataPaths.Path(src,FS.Csv), out index);
        //     var rB = LoadData(DataPaths.Path(src,FS.Hex), out data);
        //     if(rA.Fail)
        //         result = rA;
        //     else
        //         result = rB;
        //     return result;
        // }

        // Outcome LoadCollected(out Index<EncodedMember> index, out BinaryCode data)
        // {
        //     var result = Outcome.Success;
        //     var rA = LoadIndex(DataPaths.Path(FS.Csv), out index);
        //     var rB = LoadData(DataPaths.Path(FS.Hex), out data);
        //     if(rA.Fail)
        //         result = rA;
        //     else
        //         result = rB;
        //     return result;
        // }

        // Outcome LoadCollected(ApiHostUri src, out Index<EncodedMember> index, out BinaryCode data)
        // {
        //     var result = Outcome.Success;
        //     var rA = LoadIndex(DataPaths.Path(src, FS.Csv), out index);
        //     var rB = LoadData(DataPaths.Path(src, FS.Hex), out data);
        //     if(rA.Fail)
        //         result = rA;
        //     else
        //         result = rB;
        //     return result;
        // }

        // Outcome LoadIndex(FS.FilePath src, out Index<EncodedMember> dst)
        // {
        //     var result = Outcome.Success;
        //     var lines = src.ReadLines(true);
        //     var count = lines.Count - 1;
        //     dst = alloc<EncodedMember>(count);
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var line = ref lines[i + 1];
        //         result = ApiCode.parse(line, out dst[i]);
        //         if(result.Fail)
        //             break;
        //     }

        //     return result;
        // }

        // Outcome LoadData(FS.FilePath path, out BinaryCode dst)
        // {
        //     var result = Outcome.Success;
        //     var cells = path.ReadLines().SelectMany(x => text.split(x,Chars.Space));
        //     var count = cells.Count;
        //     var data = alloc<byte>(count);
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var cell = ref cells[i];
        //         result = HexParser.parse8u(cell, out seek(data,i));
        //         if(result.Fail)
        //             break;
        //     }
        //     if(result)
        //         dst = data;
        //     else
        //         dst = BinaryCode.Empty;
        //     return result;
        // }
    //}
}