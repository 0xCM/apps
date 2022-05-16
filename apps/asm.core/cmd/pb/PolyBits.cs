//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class PolyBits : AppService<PolyBits>
    {
        AppServices AppSvc => Service(Wf.AppServices);

        AppDb AppDb => Service(Wf.AppDb);

        public void RunChecks()
        {
            BitCheckers.run();
            var dst = text.emitter();
            CheckBitConverters();
        }

        void CheckBitConverters()
        {
            var n = n8;
            var count = Numbers.count(n);
            var convert = BitConverters.converter(n);
            for(var i=0; i<count; i++)
            {
                ref readonly var hex = ref convert.Chars(base16, (ushort)i);
                ref readonly var bin = ref convert.Chars(base2, (ushort)i);
                Write(string.Format("{0,-3} | {1,-3} | {2,-3}", i, hex, bin));
            }

            var checks = Classifiers.Checks(Wf);
            checks.Run();
        }

        public Index<BfModel> BvEmit(DbSources sources, string filter, FS.FolderPath dst)
            => BvEmit(BvCalc(sources.Files(FileKind.Csv).Where(f => f.FileName.StartsWith(filter))), dst);

        public Index<BfModel> BvCalc(FS.Files lists)
            => bvmodels(lists);

        public Index<BfModel> BvEmit(Index<BfModel> src, FS.FolderPath dst)
        {
            dst.Clear();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var bv = ref src[i];
                ref readonly var name = ref bv.Name;
                var target = dst + FS.file(name.Format(), FS.ext("bv"));
                var msg = string.Format("{0} -> {1}", bv.Origin, target.ToUri());
                AppSvc.FileEmit(bv, msg, target);
            }
            return src;
        }
    }
}