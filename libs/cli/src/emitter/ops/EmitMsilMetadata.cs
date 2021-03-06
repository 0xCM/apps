//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public uint EmitIlDat(IApiPack dst)
            => EmitMsilMetadata(ApiMd.Components, dst);

        public uint EmitMsilMetadata(ReadOnlySpan<Assembly> src, IApiPack dst)
        {
            var total = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
                EmitMsilMetadata(skip(src,i), dst);
            return total;
        }

        public void EmitMsilMetadata(Assembly src, IApiPack dst)
        {
            void Exec()
            {
                var path = dst.Metadata(CliSections.IlData).Table<MsilRow>(src.GetSimpleName());
                var methods = ReadOnlySpan<MsilRow>.Empty;
                var srcPath = FS.path(src.Location);
                if(ClrModules.valid(srcPath))
                {
                    using var reader = PeReader.create(srcPath);
                    methods = reader.ReadMsil();
                    var view = methods;
                    var count = (uint)methods.Length;
                    if(count != 0)
                        TableEmit(methods, path);
                }
            }
            Try(Exec);
        }
    }
}