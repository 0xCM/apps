//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCode
    {
        [Op]
        public Index<HexPacked> EmitHexPack(SortedIndex<ApiCodeBlock> src, FS.FilePath? dst = null, bool validate = false)
        {
            var _dst = dst ?? Env.Db + FS.folder(EnvFolders.tables) + FS.file("apihex", FS.ext("xpack"));
            var result = ApiCode.pack(src, validate);
            var packed = result.View;
            var emitting = EmittingFile(_dst);
            using var writer = _dst.Writer();
            var count = packed.Length;
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(packed,i).Format());
            EmittedFile(emitting, count);
            return result;
        }
    }
}