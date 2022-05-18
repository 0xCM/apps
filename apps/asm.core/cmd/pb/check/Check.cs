//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    using static PbChecks.Field32;

    using FK = PbChecks.Field32.FieldName;

    public partial class PbChecks
    {
        AppServices AppSvc;

        ITextEmitter Emitter;

        public PbChecks(IWfRuntime wf)
        {
            AppSvc = wf.AppServices();
            Emitter = text.emitter();
        }

        AppDb AppDb => AppSvc.AppDb;

        static BfDataset<FieldName,Field32> opcodes()
            => BfDatasets.create<FieldName,FieldWidth,Field32>("xed.opcodes");

        public static Index<Field32> pack(BfDataset<FieldName,Field32> spec, ReadOnlySpan<Field32Source> src, bool pll = true)
        {
            var dst = bag<Field32>();
            iter(src,opcode => dst.Add(pack(spec,opcode)), pll);
            return dst.Index().Sort();
        }

        [MethodImpl(Inline)]
        public static Field32 pack(BfDataset<FieldName,Field32> spec, Field32Source src)
            => math.or(
                (uint)src.InstClass << (int)spec.Offset(FK.Class),
                (uint)src.OpCode << (int)spec.Offset(FK.Hex8),
                (uint)src.Mod << (int)spec.Offset(FK.Mod),
                (uint)src.Lock << (int)spec.Offset(FK.Lock),
                (uint)src.RexW << (int)spec.Offset(FK.Rex),
                (uint)src.Rep << (int)spec.Offset(FK.Rep)
                );

        public static Func<Field32,string> formatter(BfDataset<FieldName,Field32> spec)
            => src => string.Format("{0,-18} | 0x{1} | {2,-6} | {3,-6} | {4,-6}",
                    spec.Extract<InstClass>(FK.Class, src),
                    spec.Extract<Hex8>(FK.Hex8, src),
                    spec.Extract<BitIndicator>(FK.Lock, src),
                    spec.Extract<BitIndicator>(FK.Rex, src),
                    spec.Extract<BitIndicator>(FK.Mod, src)
                    );

        public static PbChecks create(IWfRuntime wf)
            => new PbChecks(wf);

        enum Fields3
        {
            Field0,

            Field1,

            Field2
        }

        static string[] DsHeaders = new string[]{"Name", "Fields", "SegPattern", "Intervals"};

        static string DsPattern = "{0,-16} | {1,-6} | {2,-32} | {3}";

        static ReadOnlySpan<byte> Widths0 => new byte[3]{4,3,5};

        void RenderHeader(ITextEmitter dst)
            => dst.AppendLineFormat(DsPattern, DsHeaders);

        void Render(IBfDataset src)
        {
            Emitter.AppendLineFormat(DsPattern, src.Name, src.FieldCount, src.BitstringPattern, src.Intervals);
        }

        void Check(N0 n)
        {
            var bf = BfDatasets.create<Fields3>($"Bf{n}", Widths0);
            Render(bf);
        }

        void Check(N1 n)
        {
            var bf = opcodes();
            var formatter = Tables.formatter<BfSegModel>();
            var intervals = bf.Intervals;
            var segs = BfDatasets.segs(bf);
            AppSvc.TableEmit(segs, AppDb.Targets("pb").Table<BfSegModel>($"{bf.Name}"));

            // Write(formatter.FormatHeader());
            // iter(segs, seg => Write(formatter.Format(seg)));
            // for(var i=0; i<intervals.Count; i++)
            // {
            //     Write(intervals[i]);
            // }

        }

        public void Run()
        {
            RenderHeader(Emitter);
            Check(n0);
            Check(n1);
            //AppSvc.Write(Emitter.Emit());
        }
    }


    partial class PolyBits
    {
        public void Check()
        {
            Targets.Delete();
            BitCheckers.run();
            //Classifiers.Checks(Wf).Run();
            var n = n8;
            var count = Numbers.count(n);
            var convert = BitConverters.converter(n);
            for(var i=0; i<count; i++)
            {
                ref readonly var hex = ref convert.Chars(base16, (ushort)i);
                ref readonly var bin = ref convert.Chars(base2, (ushort)i);
            }

            PbChecks.create(Wf).Run();
        }
    }
}