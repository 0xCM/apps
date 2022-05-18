//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static core;

    using static XedModels.OpCodeId;

    using FK = XedModels.OpCodeId.FieldName;
    using FW = XedModels.OpCodeId.FieldWidth;

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

        static BfDataset<FieldName,OpCodeId> opcodes()
            => BfDatasets.create<FieldName,FieldWidth,OpCodeId>("xed.opcodes");

        public static Index<OpCodeId> pack(BfDataset<FieldName,OpCodeId> spec, ReadOnlySpan<InstOpCode> src, bool pll = true)
        {
            var dst = bag<OpCodeId>();
            iter(src,opcode => dst.Add(pack(spec,opcode)), pll);
            return dst.Index().Sort();
        }

        [MethodImpl(Inline)]
        public static OpCodeId pack(BfDataset<FieldName,OpCodeId> spec, InstOpCode oc)
            => math.or(
                (uint)oc.InstClass << (int)spec.Offset(FK.Class),
                (uint)oc.PrimaryByte << (int)spec.Offset(FK.Hex8),
                (uint)oc.Mod << (int)spec.Offset(FK.Mod),
                (uint)oc.Lock << (int)spec.Offset(FK.Lock),
                (uint)oc.RexW << (int)spec.Offset(FK.Rex),
                (uint)oc.Rep << (int)spec.Offset(FK.Rep)
                );

        public static Func<OpCodeId,string> formatter(BfDataset<FieldName,OpCodeId> spec)
            => src => string.Format("{0,-18} | 0x{1} | {2,-6} | {3,-6} | {4,-6}",
                    spec.Extract<InstClass>(FK.Class, src),
                    spec.Extract<Hex8>(FK.Hex8, src),
                    spec.Extract<LockIndicator>(FK.Lock, src),
                    spec.Extract<BitIndicator>(FK.Rex, src),
                    spec.Extract<ModIndicator>(FK.Mod, src)
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
            Classifiers.Checks(Wf).Run();
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