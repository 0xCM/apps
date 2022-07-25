//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCode : WfSvc<ApiCode>
    {
        [Op]
        public static ByteSize emit(in MemoryBlock src, FS.FilePath dst)
        {
            using var writer = dst.Writer();
            return ApiHex.pack(src, 0, writer);
        }

        [Op]
        public static ByteSize emit(MemoryBlocks src, FS.FilePath dst)
        {
            using var writer = dst.Writer();
            return ApiHex.pack(src, writer);
        }
    }
}