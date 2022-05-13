//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using Asm;

    partial class XTend
    {
        public static PolyBits PolyBits(this IWfRuntime wf)
            => Z0.PolyBits.create(wf);
    }

    public partial class PolyBits : AppService<PolyBits>
    {
        public void RunChecks()
        {
            BitCheckers.run();

            CheckBitConverters();
        }

        void CheckPatterns()
        {

        }


        static void GenBitfield(ITextEmitter dst)
        {
            var modrm = Bitfields.pattern(ModRm.BitPattern);
            dst.WriteLine(modrm.Descriptor);

            var rex = Bitfields.pattern(RexPrefix.BitPattern);
            dst.WriteLine(rex.Descriptor);

            var vexC4 = Bitfields.pattern(VexPrefixC4.BitPattern);
            dst.WriteLine(vexC4.Descriptor);

            var vexC5 = Bitfields.pattern(VexPrefixC5.BitPattern);
            dst.WriteLine(vexC5.Descriptor);

            var sib = Bitfields.pattern(Sib.BitPattern);
            dst.WriteLine(sib.Descriptor);

            byte data = 0b10_110_011;
            dst.WriteLine(Bitfields.bitstring(sib, data));
        }


        void CheckBitConverters()
        {
            var n = n8;
            var count = num.count(n);
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


        AppServices AppSvc
            => Service(Wf.AppServices);

        //BitfieldServices Bitfields => Service(Wf.Bitfields);

        public Index<BitfieldModel> BvEmit(DbSources sources, string filter, FS.FolderPath dst)
            => BvEmit(BvCalc(sources.Files(FileKind.Csv).Where(f => f.FileName.StartsWith(filter))), dst);

        public Index<BitfieldModel> BvCalc(FS.Files lists)
            => bvmodels(lists);

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