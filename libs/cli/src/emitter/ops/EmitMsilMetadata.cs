//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public uint EmitMsilMetadata()
            => EmitMsilMetadata(ApiRuntimeCatalog.Components);

        public uint EmitMsilMetadata(ReadOnlySpan<Assembly> src)
        {
            var total = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
                EmitMsilMetadata(skip(src,i));
            return total;
        }

        public FS.FilePath MsilPath(Assembly src)
            => ProjectDb.TablePath<MsilRow>(MsilScope, src.GetSimpleName());

        public ReadOnlySpan<MsilRow> EmitMsilMetadata(Assembly src)
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
                    var dst = MsilPath(src);
                    var flow = EmittingTable<MsilRow>(dst);
                    Tables.emit(methods, dst);
                    EmittedTable<MsilRow>(flow, count);
                }
            }
            return methods;
        }
    }
}