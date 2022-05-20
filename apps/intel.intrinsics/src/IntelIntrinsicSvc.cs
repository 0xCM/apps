//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Xml;
    using System.IO;

    using static core;
    using static IntrinsicsDoc;

    public partial class IntelIntrinsicSvc  : AppService<IntelIntrinsicSvc>
    {
        const int MaxDefCount = Pow2.T13;

        AppServices AppSvc => Service(Wf.AppServices);

        AppDb AppDb => Service(Wf.AppDb);

        IntrinsicFormatter Formatter => Service(() => new IntrinsicFormatter());

        public void Check()
        {
            var specs = new NativeOperandSpec[3];
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

            seek(specs,0) = NativeSigs.op("op0", NativeTypes.u8());
            seek(specs,1) = NativeSigs.op("op1", NativeTypes.i16());
            seek(specs,2) = NativeSigs.op("op2", NativeTypes.u32());
        }

        public Index<IntrinsicDef> Emit()
        {
            var parsed = ParseXmlDoc().Sort();
            EmitAlgorithms(parsed);
            var records = EmitRecords(parsed);
            EmitRecords(records,"Integer");
            EmitDeclarations(parsed);
            return parsed;
        }

        XmlDoc ReadXmlDoc()
            => XmlSource().ReadUtf8();

        Index<IntrinsicDef> ParseXmlDoc()
            => Parse(ReadXmlDoc());

        Index<IntrinsicDef> Parse(XmlDoc src)
        {
            var entries = new IntrinsicDef[MaxDefCount];
            var i = -1;
            using var reader = XmlReader.Create(new StringReader(src.Content));
            while (reader.Read() && i<MaxDefCount - 1)
            {
                if(reader.NodeType == XmlNodeType.Element)
                {
                    switch(reader.Name)
                    {
                        case IntrinsicDef.ElementName:
                            i++;
                            entries[i] = IntrinsicDef.Empty;
                            entries[i].content = reader.Value;
                            entries[i].tech = reader[nameof(IntrinsicDef.tech)];
                            entries[i].name = reader[nameof(IntrinsicDef.name)];
                        break;

                        case Operation.ElementName:
                            read(reader, ref entries[i].operation);
                        break;

                        case Description.ElementName:
                            read(reader, ref entries[i].description);
                        break;

                        case Return.ElementName:
                            read(reader, ref entries[i].@return);
                        break;

                        case CpuId.ElementName:
                            read(reader, entries[i].CPUID);
                        break;

                        case Category.ElementName:
                            read(reader, ref entries[i].category);
                        break;

                        case Instruction.ElementName:
                            read(reader, entries[i].instructions);
                        break;

                        case InstructionType.ElementType:
                            read(reader, entries[i].types);
                        break;

                        case Parameter.ElementName:
                            read(reader, entries[i].parameters);
                        break;
                        case Header.ElementName:
                            read(reader, ref entries[i].header);
                        break;
                    }
                }
            }

            return slice(span(entries),0,i).ToArray();
        }
    }
}