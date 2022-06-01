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
        public Index<ApiHexRow> EmitApiHex(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, FS.FolderPath dst)
        {
            var count = src.Length;
            if(count != 0)
            {
                var buffer = alloc<ApiHexRow>(count);
                for(var i=0u; i<count; i++)
                    seek(buffer, i) = apihex(skip(src, i), i);

                var path = Db.ParsedExtractPath(dst, uri);
                AppSvc.TableEmit(buffer, path);
                return buffer;
            }
            else
                return array<ApiHexRow>();
        }

        public Index<ApiHexRow> EmitApiHex(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, FS.FilePath dst)
        {
            var count = src.Length;
            if(count != 0)
            {
                var buffer = alloc<ApiHexRow>(count);
                for(var i=0u; i<count; i++)
                    seek(buffer, i) = apihex(skip(src, i), i);

                AppSvc.TableEmit(buffer, dst);
                return buffer;
            }
            else
                return array<ApiHexRow>();
        }

    }
}