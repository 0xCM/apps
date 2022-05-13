//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static PolyBits PolyBits(this IWfRuntime wf)
            => Z0.PolyBits.create(wf);
    }

    public partial class PolyBits : AppService<PolyBits>
    {
        AppServices AppSvc
            => Service(Wf.AppServices);

        BitfieldServices Bitfields => Service(Wf.Bitfields);

        public Index<BitfieldModel> BvEmit(DbSources sources, string filter, FS.FolderPath dst)
            => BvEmit(BvCalc(sources.Files(FileKind.Csv).Where(f => f.FileName.StartsWith(filter))), dst);

        public Index<BitfieldModel> BvCalc(FS.Files lists)
            => Bitfields.BvCalc(lists);

        public Index<BitfieldModel> BvEmit(Index<BitfieldModel> src, FS.FolderPath dst)
        {
            dst.Clear();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var bv = ref src[i];
                ref readonly var name = ref bv.Name;
                var target = dst + FS.file(name, FS.ext("bv"));
                var msg = string.Format("{0} -> {1}", bv.Origin, target.ToUri());
                AppSvc.FileEmit(bv, msg, target);
            }
            return src;
        }
    }
}