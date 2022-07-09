//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public uint EmitMsilMetadata(IApiPack dst)
            => EmitMsilMetadata(ApiMd.Components, dst.Metadata("msil"));

        public uint EmitMsilMetadata(ReadOnlySpan<Assembly> src, IDbTargets dst)
        {
            var total = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
                EmitMsilMetadata(skip(src,i), MsilMetadataPath(skip(src,i), dst.Root));
            return total;
        }

        public FS.FilePath MsilMetadataPath(Assembly src, FS.FolderPath dst)
            => dst +  FS.file(src.GetSimpleName(), FileKind.Csv);

        public ReadOnlySpan<MsilRow> EmitMsilMetadata(Assembly src, FS.FilePath dst)
        {
            var methods = ReadOnlySpan<MsilRow>.Empty;
            var srcPath = FS.path(src.Location);
            if(ClrModules.valid(srcPath))
            {
                using var reader = PeReader.create(srcPath);
                methods = reader.ReadMsil();
                var view = methods;
                var count = (uint)methods.Length;
                if(count != 0)
                {
                    var flow = EmittingTable<MsilRow>(dst);
                    Tables.emit(methods, dst);
                    EmittedTable<MsilRow>(flow, count);
                }
            }
            return methods;
        }
    }
}