//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static IntrinsicsDoc;

    public partial class IntelIntrinsicSvc : AppService<IntelIntrinsicSvc>
    {
        const int MaxDefCount = Pow2.T13;

        AppServices AppSvc => Service(Wf.AppServices);

        AppDb AppDb => Service(Wf.AppDb);

        public Index<IntrinsicDef> Emit()
        {
            var parsed = ParseDoc();
            EmitAlgorithms(parsed);
            var records = EmitRecords(parsed);
            EmitRecords(records,"Integer");
            EmitDeclarations(parsed);
            return parsed;
        }

        public void Check()
        {
            var specs = new NativeOpDef[3];
            using var dispenser = Alloc.allocate();

            var intrinsics = new IntrinsicSigs();
            var f0 = intrinsics._mm_add_epi8();
            Write(f0.Format(SigFormatStyle.C));

            var f0x = dispenser.Sig(f0);
            Write(f0x.Format(SigFormatStyle.C));

            var f1 = intrinsics._mm_add_epi16();
            Write(f1.Format(SigFormatStyle.C));

            var f1x = dispenser.Sig(f1);
            Write(f1x.Format(SigFormatStyle.C));

            var f2 = intrinsics._mm_add_epi32();
            Write(f2.Format(SigFormatStyle.C));

            var f2x = dispenser.Sig(f2);
            Write(f2x.Format(SigFormatStyle.C));

            var f3 = intrinsics._mm_add_epi64();
            Write(f3.Format(SigFormatStyle.C));

            var f3x = dispenser.Sig(f3);
            Write(f3x.Format(SigFormatStyle.C));

            seek(specs,0) = NativeTypes.op("op0", NativeTypes.u8());
            seek(specs,1) = NativeTypes.op("op1", NativeTypes.i16());
            seek(specs,2) = NativeTypes.op("op2", NativeTypes.u32());
        }

        XmlDoc LoadDocXml()
            => XmlSource().ReadUtf8();

        Index<IntrinsicDef> ParseDoc()
            => read(LoadDocXml());
    }
}