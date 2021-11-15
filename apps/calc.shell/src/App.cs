//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    using System.Reflection;
    using System.IO;

    using Masks = BitMaskLiterals;

    using Alg;

    class App : WfApp<App>
    {
        public static void Main(params string[] args)
            => run(args, PartId.Cpu, PartId.CalcShell);

        IPolySource Source;

        EventQueue Queue;

        IProjectWs Project;

        TextWriter Log;

        void EventRaised(IWfEvent e)
        {

        }

        protected override void OnInit()
        {
            Queue = EventQueue.allocate(GetType(), EventRaised);
            Source = Rng.@default();
            Project = Ws.Project("calcs");
            Log = Project.Log("calcs").AsciWriter();
        }

        protected override void Disposing()
        {
            EmptyQueue();
            Queue.Dispose();
            Log.Dispose();
        }

        void LogHeader<N>(MethodBase src, N n)
            where N : unmanaged, ITypeNat
        {
            Log.WriteLine(string.Format("{0} {1} ", src.Name, n).PadRight(80,Chars.Dash));
        }

        void EmptyQueue()
        {
            while(Queue.Emit(out var e))
                Wf.Raise(e);
        }

        void Run(N1 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);

            var checker = BitLogicChecker.create(Wf, Rng.@default());
            checker.Validate();
        }

        void Run(N2 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);
            using var table = SymbolStores.table(Pow2.T14);
            table.Deposit("abc");
            table.Deposit("def");
            table.Deposit("ghi");
            var src = table.Symbols;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(src,i);
                Log.WriteLine(entry.Format());
            }
        }

        void Run(N3 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);

            var provider = PageBank16x4x4.allocated();
            var block = provider.Block(n0);
            var segsize = 32;
            uint count = block.Size/segsize;
            ref var src = ref block.Segment<Cell256>(0);
            for(var i=0u; i<count; i++)
                seek(src,i) = i;

            for(var i=0; i<count; i++)
            {
                ref readonly var j = ref first(recover<uint>(skip(src,i).Bytes));
                Log.WriteLine(string.Format("{0:D4}:{1}",i, j.FormatHex()));
            }

            Log.WriteLine(block.Describe());
        }

        void Run(N4 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);

            var buffer = span<char>(Pow2.T12);
            var src = (uint)Masks.Hi32x16;
            var dst = ByteBlock32.Empty.Bytes;
            BitPack.unpack1x32(src, dst);
            var count = Hex.render(UpperCase, dst, buffer);
            var hex = text.format(slice(buffer,0,count));

            Log.WriteLine(hex);

            buffer.Clear();
            var k=0;
            for(var i=0; i<32; i++)
            {
                ref readonly var a = ref skip(dst,i);
                for(byte j=0; j<7; j++)
                    seek(buffer,k++) = bit.test(a,j).ToChar();
                seek(buffer,k++) = Chars.Space;
            }

            var bitstring = text.format(slice(buffer,0,k));
            Log.WriteLine(bitstring);
        }

        void Run(N5 n)
        {
            LineageChecks.create(Wf).Run();
        }

        void Run(N8 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);
            var buffer = PageBank16x4x4.allocated();
            var block = buffer.Block(n0);
            var segsize = size<Cell256>();
            uint count = block.Size/segsize;
            ref var src = ref block.Segment<Cell256>(0);
            for(var i=0u; i<count; i++)
                seek(src,i) = i;


            for(var i=0; i<count; i++)
            {
                ref readonly var j = ref first(recover<uint>(skip(src,i).Bytes));
                Log.WriteLine(string.Format("{0:D4}:{1}",i, j.FormatHex()));
            }


            Log.WriteLine(block.Describe());
        }

        void Run(N9 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);
            var checker = BitLogicChecker.create(Wf, Rng.@default());
            checker.Validate();
        }

        void Run(N13 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);
            ApiKeyChecks.create(Wf).Run();
        }


        void Run(N15 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);

            Size<byte> a = 31;
            var b = a.Align(4);
            Log.WriteLine(a.Measure);
            Log.WriteLine(a.Untyped);
            Log.WriteLine(b.Measure);

            Log.WriteLine(string.Format("Align({0}) = {1}", a, b));
        }

        void Run(N16 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);
            Reader(PartId.Cpu, out var reader);
            var strings = reader.ReadStrings(CliStringKind.User);
            var count = strings.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var s = ref skip(strings,i);
                Log.WriteLine(string.Format("{0:D5}:{1}", i, s));
            }
        }

        bool Reader(PartId part, out CliReader dst)
        {
            if(Wf.ApiCatalog.FindComponent(part, out var component))
            {
                dst = CliReader.read(component);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        void Run(N17 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);
            BitfieldChecks.create(Wf).Run();
        }

        void Run(N18 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);
            var m0 = BitMaskLiterals.b00001111x32;
            var m1 = BitMaskLiterals.Even32;
            var m = (ulong)m0 | ((ulong)m1 << 32);
            var bf = Bitfields.create(m);
            var bytes = bf.Bytes;
            var buffer = CharBlock128.Null;
            var count = BitRender.render4x4(bytes, buffer.Data);
            var chars = slice(buffer.Data,0,count);
            var fmt = text.format(chars);
            Log.WriteLine(fmt);
        }

        void Run(N20 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);
            BitMaskChecker.create(Wf).Run(Source);
        }

        void Run(N23 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);
            var log = BitFormatChecks.create().Run(Rng.wyhash64());
            Write(log.Emit());
        }

        void Run(N24 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);
            CalcBuilder.create(Wf).Calc(w128);
        }

        void Run(N25 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);
            Fsm.example1();
            Fsm.example2();
        }

        // void Run(N27 n)
        // {
        //     LogHeader(MethodInfo.GetCurrentMethod(), n);
        //     Parts.BitPack.Resolved.Executor.Run();
        // }

        void Run(N28 n)
        {
            LogHeader(MethodInfo.GetCurrentMethod(), n);
            for(byte i = 120; i<148; i++)
            for(byte j = 120; j<148; j++)
            {
                var cin = math.odd(i + j);
                var y = math.adc(i, j, cin, out var cout);
                Log.WriteLine(string.Format("adc({0},{1}) carry {2} = {3} carry {4}", i,j,cin, y, (uint)cout));
            }
        }


        void Run(N30 n)
        {
            var x0 = "0x3412a";
            var x1 = uint128.Zero;
            var result = Math128.parse(x0, out x1);
            if(result)
            {
                var x2 = x1.Format();
                if(x0 != x2)
                    Error(string.Format("'{0}' != '{1}'", x2, x0));
            }
            else
                Error(result.Message);
        }


        void RunValidators()
        {
            Md5Validator.create(Wf).Run();
            Run("1");
            Run("2");
            Run("3");
            Run("4");
            Run("5");
            Run("8");
            Run("9");
            Run("13");
            Run("15");
            Run("16");
            Run("17");
            Run("18");
            Run("20");
            Run("23");
            Run("24");
            Run("25");
            //Run("27");
            Run("28");
            Run("30");
        }

        void Run(string spec)
        {
            if(uint.TryParse(spec, out var n))
            {
                switch(n)
                {
                    case 1:
                        Run(n1);
                    break;
                    case 2:
                        Run(n2);
                    break;
                    case 3:
                        Run(n3);
                    break;
                    case 4:
                        Run(n4);
                    break;
                    case 5:
                        Run(n5);
                    break;
                    case 8:
                        Run(n8);
                    break;
                    case 9:
                        Run(n9);
                    break;
                    case 13:
                        Run(n13);
                    break;
                    case 15:
                        Run(n15);
                    break;
                    case 16:
                        Run(n16);
                    break;
                    case 17:
                        Run(n17);
                    break;
                    case 18:
                        Run(n18);
                    break;
                    case 20:
                        Run(n20);
                    break;
                    case 23:
                        Run(n23);
                    break;
                    case 24:
                        Run(n24);
                    break;
                    case 25:
                        Run(n25);
                    break;
                    // case 27:
                    //     Run(n27);
                    // break;
                    case 28:
                        Run(n28);
                    break;
                    case 30:
                        Run(n30);
                    break;
                    default:
                     Error(string.Format("Command '{0}' unrecognized", spec));
                    break;
                }
            }
        }

        protected override void Run()
        {
        }

        protected override void Run(string[] args)
        {
            var count = args.Length;
            if(count != 0)
            {
                for(var i=0; i<count; i++)
                    Run(skip(args,i));
            }
            else
            {
                RunValidators();
            }
        }
    }
}