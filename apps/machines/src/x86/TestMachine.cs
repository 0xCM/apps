//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    using System;
    using System.Threading.Tasks;

    using Asm;
    using Flows;
    using Types;

    using static Root;
    using static core;
    using static Asm.RegClasses;

    public class TestMachine : AppCmdService<TestMachine,CmdShellState>
    {
        IPolyrand Random;

        EventQueue Queue;

        X86Machine RM;

        EventSignal Signal;

        public TestMachine()
        {
        }

        void EventRaised(IWfEvent e)
        {
            Write(e.Format());
        }

        protected override void Initialized()
        {
            Random = Rng.@default();
            Queue = EventQueue.allocate(typeof(TestMachine), EventRaised);
            Signal = EventSignals.signal(Queue, GetType());
        }

        protected override void Disposing()
        {
            EmptyQueue();
            Queue.Dispose();
            if(RM != null)
                RM.Dispose();
        }

        void EmptyQueue()
        {
            while(Queue.Emit(out var e))
                Wf.Raise(e);
        }

        [CmdOp(".x86")]
        Outcome RunX86Machine(CmdArgs args)
        {
            if(RM == null)
            {
                RM = X86Control.intel64(Signal);
                RM.Run();
            }
            return true;
        }

        [CmdOp(".regdump")]
        Outcome TestRegs(CmdArgs args)
        {
            var result = Outcome.Success;

            var machine = RM;
            var buffer = text.buffer();
            X86Control.state(machine,buffer);
            Write(buffer.Emit());

            return result;
        }

        [CmdOp(".test-kregs")]
        Outcome KRegTests(CmdArgs args)
        {
            var result = Outcome.Success;
            var grid = default(RegGrid8x64);
            var regs = X86Control.regs(n8,w64);
            var names = recover<AsmRegName>(ByteBlock64.Empty.Bytes);
            var pairs = recover<AsmRegValue<ulong>>(ByteBlock128.Empty.Bytes);

            for(byte i=0; i<7; i++)
            {
                regs[i] = i;
                seek(names,i) = AsmRegs.name(KReg, (RegIndexCode)i);
                grid[i]= asm.regval(skip(names,i), regs[i]);
            }

            for(byte i=0; i<7; i++)
            {
                ref readonly var name = ref skip(names,i);
                ref readonly var value = ref regs[i];
                var output = grid[i].Format();
                Write(output);
            }

            var input = (ulong)PermLits.Perm16Identity;
            for(byte i=0; i<7; i++)
            {
                regs[i] = input << i*3;
                Write(asm.regval(skip(names,i), regs[i]));
            }

            return result;
        }

        [CmdOp(".test-classes")]
        Outcome TestSymNames(CmdArgs args)
        {
            var result = Outcome.Success;

            var classifier = types.classifier<AsciLetterLoSym,byte>();
            var symbols = Symbols.index<AsciLetterLoSym>();
            var classes = classifier.Classes;
            var count = classes.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var c = ref skip(classes,i);
                ref readonly var s = ref symbols[i];
                Require.equal(c.Ordinal, i);
                Require.equal(s.Key.Value, c.Ordinal);
                Require.equal(s.Expr.Format(), c.Symbol.Format());
                Require.equal(s.Name.Format(), c.KindName.Format());
                Write(string.Format("{0,-8:D3} {1,-24} {2,-8} {3}", c.Ordinal, c.ClassName, c.KindName, c.Value));
            }

            return result;
        }

        [CmdOp(".dump-bss")]
        Outcome TestBss(CmdArgs args)
        {
            var result = Outcome.Success;
            var dispenser = BssSections.dispenser();
            var entries = dispenser.Entries();
            var count = entries.Length;
            const sbyte Pad = -16;

            Write(RP.attrib(nameof(dispenser.EntryCount), count));
            for(ushort i=0; i<count; i++)
            {
                //ref readonly var entry = ref skip(entries,i);
                ref readonly var entry = ref dispenser.Entry(i);
                var desc = entry.Descriptor();
                var capacity = desc.Capacity;
                Write(RP.PageBreak32);
                Write(RP.attrib(Pad, nameof(desc.Index), desc.Index));
                Write(RP.attrib(Pad, nameof(desc.BaseAddress), desc.BaseAddress));
                Write(RP.attrib(Pad, nameof(desc.EndAddress), desc.EndAddress));
                Write(RP.attrib(Pad, nameof(capacity.Indicator), capacity.Indicator));
                Write(RP.attrib(Pad, nameof(capacity.CellSize), capacity.CellSize));
                Write(RP.attrib(Pad, nameof(capacity.CellsPerSeg), capacity.CellsPerSeg));
                Write(RP.attrib(Pad, nameof(capacity.SegSize), capacity.SegSize));
                Write(RP.attrib(Pad, nameof(capacity.SegCount), capacity.SegCount));
                Write(RP.attrib(Pad, nameof(capacity.SegsPerBlock), capacity.SegsPerBlock));
                Write(RP.attrib(Pad, nameof(capacity.BlockCount), capacity.BlockCount));
                Write(RP.attrib(Pad, nameof(capacity.BlockSize), capacity.BlockSize));
                Write(RP.attrib(Pad, nameof(capacity.TotalSize), capacity.TotalSize));
            }

            return result;
       }

        [CmdOp(".test-stack")]
        Outcome TestStack(CmdArgs args)
        {
            var result = Outcome.Success;
            var stack = CpuModels.stack<ulong>(24);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            while(stack.Pop(out var cell))
            {
                Write(cell);
            }
            return result;
        }


        [CmdOp(".test-mm")]
        Outcome TestMatchMachine(CmdArgs args)
            => TestMatchMachine();

        [CmdOp(".test-sorters")]
        Outcome RunSorters(CmdArgs args)
        {
            var result = Outcome.Success;
            var sorter = SortingNetworks.define<byte>();
            byte x0 = 9, x1 = 5, x2 = 2, x3 = 6;
            sorter.Send(x0,x1,x2,x3, out var y0, out var y1, out var y2, out var y3);
            Write(string.Format("{0} -> {1}", x0, y0));
            Write(string.Format("{0} -> {1}", x1, y1));
            Write(string.Format("{0} -> {1}", x2, y2));
            Write(string.Format("{0} -> {1}", x3, y3));
            return result;
        }

        Outcome TestMatchMachine()
        {
            var result = Outcome.Success;
            result &= Match(2, first32u(MatchTarget0), MatchInput);
            result &= Match(2, first32u(MatchTarget1), MatchInput);
            result &= Match(3, first32u(MatchTarget2), MatchInput);
            result &= Match(1, first32u(MatchTarget3), MatchInput);
            result &= Match(3, first32u(MatchTarget4), MatchInput);
            return result ? (true, "Pass") : (false, "Fail");
        }

        Outcome Match(byte n, uint src, ReadOnlySpan<byte> input)
        {
            var result = Outcome.Success;
            var spec = Match3x8.specify(n,src);
            var machine = Match3x8.create(spec);
            Write(spec.Format());
            var i = machine.Run(input);
            var matched = i>=0;
            var msg = matched ? string.Format("Matched: i={0}",i) : "Unmatched";
            result = (matched, msg);
            Write(result.Message);
            return result;
        }

        void Run(N3 n)
        {
            var bank = PageBank16x4x4.allocated();
            var size = PageBank16x4x4.BlockSize;
            var w = w128;
            var cells = size/size<Cell128>();

            var left = bank.Block(n0);
            var right = bank.Block(n1);
            var dst = bank.Block(n2);
            Run128(left, right, dst);

            ref var lCell = ref left.Segment<Cell128>(0);
            ref var rCell = ref right.Segment<Cell128>(0);
            ref var target = ref dst.Segment<Cell128>(0);

            for(var i=0u; i<cells; i++)
            {
                ref readonly var a = ref skip(lCell,i);
                ref readonly var b = ref skip(rCell,i);
                ref readonly var result = ref skip(target,i);
                Wf.Row(string.Format("{0:D6} {1}([{2}],[{3}]) = {4}", i, "f", a.V32u.FormatHex(), b.V32u.FormatHex(), result.V32u.FormatHex()));
            }
        }

        void Run128(PageBlock lhs, PageBlock rhs, PageBlock dst)
        {
            var size = lhs.Size;
            var w = w128;
            var cells = size/size<Cell128>();
            ref var left = ref lhs.Segment<Cell128>(0);
            ref var right = ref rhs.Segment<Cell128>(1);
            ref var target = ref dst.Segment<Cell128>(2);
            var f = Calcs.vor<uint>(w);
            for(var i=0u; i<cells; i++)
            {
                ref var a = ref seek(left,i);
                a = cpu.vbroadcast(w,i);
                ref var b = ref seek(right,i);
                b = cpu.vbroadcast(w,i + Pow2.T12);
                seek(target,i) = f.Invoke(a,b);
            }
        }

        void Run(N5 n)
        {
            var bank = PageBank16x4x4.allocated();
            var size = PageBank16x4x4.BlockSize;
            var w = w128;
            var left = bank.Block(n0);
            var right = bank.Block(n1);
            var dst = bank.Block(n2);
            Run128(left, right, dst);

            ref var lCell = ref left.Segment<Cell128>(0);
            ref var rCell = ref right.Segment<Cell128>(0);
            ref var target = ref dst.Segment<Cell128>(0);

            var cells = left.Size/size<Cell128>();
            for(var i=0u; i<cells; i++)
            {
                ref readonly var a = ref skip(lCell,i);
                ref readonly var b = ref skip(rCell,i);
                ref readonly var result = ref skip(target,i);
                Wf.Row(string.Format("{0:D6} {1}([{2}],[{3}]) = {4}", i, "f", a.V32u.FormatHex(), b.V32u.FormatHex(), result.V32u.FormatHex()));
            }
        }

        public void Run(N10 n)
        {
            var stack = StackMachines.create(Pow2.T08);
            stack.Push(2);
            Queue.Deposit(EventFactory.data(stack.state()));
            stack.Push(4);
            Queue.Deposit(EventFactory.data(stack.state()));
            stack.Push(6);
            Queue.Deposit(EventFactory.data(stack.state()));
        }

        void Run(N11 n)
        {
            const uint CellCount = 4096;
            const uint JobCount = 256;
            const uint CycleCount = 256;

            Task<uint> RunMachine(uint cycles)
                => Task.Factory.StartNew(() => new Vmx128x2(CellCount, Rng.@default()).Run(cycles));

            var flow = Wf.Running();
            var clock = Time.counter(true);
            var count = 0ul;
            var tasks = core.stream(0u,JobCount).Map(i => RunMachine(CycleCount));
            Task.WaitAll(tasks);
            foreach(var t in tasks)
                count += t.Result;

            var time = clock.Elapsed();
            Wf.Ran(flow, string.Format("Processed {0:##,#} items in {1} ms", count, time.Ms));
        }

        void Run(N19 n)
        {
            VPipeTests.test(Wf);
        }

        void Run(N21 n)
        {
            BlitMachine.create(Wf).Run();
        }

        void Run(N26 n)
        {
            void receive(uint i, uint j)
            {
                Write(string.Format("{0} -> {1}", i, j));
            }
            var seq = SeqSpecs.finite((0u,57u), i => i + 1);
            Write(string.Format("{0}..{1}", seq.Min, seq.Max));
            var count = seq.Compute(receive);
            count += seq.Compute(receive);
            Write(string.Format("Term Count:{0}", count));
        }

        void Spin()
        {
            var counter = 0u;
            var ticks = 0L;

            void Receiver(long t)
            {
                counter++;
                ticks += t;
                Write(string.Format("{0:D4}:{1:D12}", counter, ticks));
            }

            var spinner = new Spinner(TimeSpan.FromSeconds(1), Receiver);
            spinner.Spin();
        }

        void Run(N28 n)
        {
            Spin();
        }

        void Run(N29 n)
        {
            var inputs = BinaryBitLogicOps.inputs(w1);
            var eval = BinaryBitLogicOps.canonical(w1,inputs);
            var count = inputs.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(inputs,i);
                ref readonly var result = ref skip(eval,i);
                Write(string.Format("{0:D2} | {1}", i, result.Format(BinaryBitLogicOps.FormatOption.Bitstrings)));
            }
        }

        public unsafe void Run(N30 n)
        {
            var count = Pow2.T12;
            using var buffer0 = memory.native<uint>(count);
            using var buffer1 = memory.native<uint>(count);
            using var buffer2 = memory.native<uint>(count);
            Random.Fill(buffer0.Edit);
            Random.Fill(buffer1.Edit);
            var r0 = seq.reader(buffer0);
            var r1 = seq.reader(buffer1);
            var reader = seq.reader(r0,r1);
            var editor = seq.editor(buffer2);

            while(reader.Next(out var c0, out var c1))
            {
                editor.Next(out var _) = math.xor(c0,c1);
            }

            var result = seq.reader(buffer2);
            var counter = 0u;
            while(result.Next(out var r))
            {
                Write(string.Format("{0:D5} {1:x}",counter++, r.FormatHex()));
            }
        }

        void Run(N31 n)
        {
            GraphTests.create(Wf).Run();
        }

        void Run(N32 n)
        {
            var evals = BinaryBitLogicOps.canonical(w1);
            var count = evals.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var eval = ref skip(evals,i);
                Write(eval.Format());
            }
        }

        [CmdOp(".run")]
        Outcome Run(CmdArgs args)
        {
            if(uint.TryParse(arg(args,0).Value, out var n))
            {
                switch(n)
                {
                    case 3:
                        Run(n3);
                    break;
                    case 5:
                        Run(n5);
                    break;
                    case 10:
                        Run(n10);
                    break;
                    case 11:
                        Run(n11);
                    break;
                    case 19:
                        Run(n19);
                    break;
                    case 21:
                        Run(n21);
                    break;
                    case 26:
                        Run(n26);
                    break;
                    case 28:
                        Run(n28);
                    break;
                    case 29:
                        Run(n29);
                    break;
                    case 30:
                        Run(n30);
                    break;
                    case 31:
                        Run(n31);
                    break;
                    case 32:
                        Run(n32);
                    break;

               }
            }
            return true;
        }


        static ReadOnlySpan<byte> MatchTarget0 => new byte[4]{0x24,0x12,0x00,0x00};

        static ReadOnlySpan<byte> MatchTarget1 => new byte[4]{0xCC,0x00,0x00,0x00};

        static ReadOnlySpan<byte> MatchTarget2 => new byte[4]{0x48,0x16,0x19,0x00};

        static ReadOnlySpan<byte> MatchTarget3 => new byte[4]{0x19,0x00,0x00,0x00};

        static ReadOnlySpan<byte> MatchTarget4 => new byte[4]{0xCC,0x00,0x19,0x00};

        static ReadOnlySpan<byte> MatchInput => new byte[]{
            0x52,0x21,0x18,0x00,
            0x23,0x48,0x16,0x19,
            0x22,0x24,0x12,0xCC,
            0xCC,0x00,0x19,0x00
            };
    }
}