//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static PbChecks.Field32;

    using FK = PbChecks.Field32.FieldName;

    public partial class PbChecks : Checker<PbChecks>
    {
        ITextEmitter Emitter;

        public void CheckBitParser()
        {
            var input = "0110";
            BitParser.parse(text.slice(input,0,1), 1, out byte b0);
            Demand.eq(bit.Off, (bit)b0);
            BitParser.parse(text.slice(input,1,1), 1, out byte b1);
            Demand.eq(bit.On, (bit)b1);
            BitParser.parse(text.slice(input,2,1), 1, out byte b2);
            Demand.eq(bit.On, (bit)b2);
            BitParser.parse(text.slice(input,3,1), 1, out byte b3);
            Demand.eq(bit.Off, (bit)b3);
        }


        public PbChecks()
        {
            Emitter = text.emitter();
        }

        static BfDataset<FieldName,Field32> dataset(N1 n)
            => PolyBits.dataset<FieldName,FieldWidth,Field32>("field32", NativeSizeCode.W32);

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
                    spec.Extract<num16>(FK.Class, src),
                    spec.Extract<Hex8>(FK.Hex8, src),
                    spec.Extract<BitIndicator>(FK.Lock, src),
                    spec.Extract<BitIndicator>(FK.Rex, src),
                    spec.Extract<BitIndicator>(FK.Mod, src)
                    );

        enum Fields3
        {
            Field0,

            Field1,

            Field2
        }

        static string[] DsHeaders = new string[]{"Name",  "Packed", "Native", "Fields", "SegPattern", "Intervals"};

        static string DsPattern = "{0,-16} | {1,-6} | {2,-6} | {3,-6} | {4,-32} | {5}";

        static ReadOnlySpan<byte> Widths0 => new byte[3]{4,3,5};

        void RenderHeader(ITextEmitter dst)
            => dst.AppendLineFormat(DsPattern, DsHeaders);

        void Render(IBfDataset src)
        {
            Emitter.AppendLineFormat(DsPattern, src.Name, src.Size.Packed, src.Size.Native, src.FieldCount, src.BitstringPattern, src.Intervals);
        }

        void Check(N0 n)
        {
            var bf = PolyBits.dataset<Fields3>($"Bf{n}", NativeSizeCode.W32, Widths0);
            Render(bf);
        }

        void Check(N1 n)
        {
            var bf = dataset(n);
            var formatter = Tables.formatter<BfSegModel>();
            var segs = PolyBits.segs(bf);
            TableEmit(segs, AppDb.DbOut("pb").PrefixedTable<BfSegModel>($"{bf.Name}"));
            var intervals = bf.Intervals;


            // Write(formatter.FormatHeader());
            // iter(segs, seg => Write(formatter.Format(seg)));
            // for(var i=0; i<intervals.Count; i++)
            // {
            //     Write(intervals[i]);
            // }

        }

        protected override void Execute()
        {
            RenderHeader(Emitter);
            Check(n0);
            Check(n1);
            Write(Emitter.Emit());
        }
    }
}