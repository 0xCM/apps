//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    public struct TextDocStats
    {
        public long InputSize;

        public long OutputSize;

        public uint LineCount;
    }

    unsafe class XedDumpImporter : IDisposable
    {
        public class DumpBlockReceiver : IBlockReceiver
        {
            /*
                amd_3dnow_opcode: None
                attributes: LOCKABLE
                avx512_tuple: None
                avx512_vsib: None
                avx_vsib: None
                broadcast_allowed: False
                category: BINARY
                cpl: 3
                cpuid: ['N/A']
                default_64b: False
                easz: aszall
                element_size: None
                eosz: oszall
                explicit_operands: ['MEM', 'IMM']
                extension: BASE
                f2_required: False
                f3_required: False
                flags: MUST [ of-mod sf-mod zf-mod af-mod pf-mod cf-tst cf-mod ]
                has_imm8: True
                has_imm8_2: False
                has_immz: False
                has_modrm: True
                iclass: ADC
                iform: ADC_MEMv_IMMb
                imm_sz: 1
                implicit_operands: ['none']
                isa_set: I86
                lower_nibble: 3
                map: 0
                memop_rw: mem-rw
                mod_required: 00/01/10
                mode_restriction: unspecified
                no_prefixes_allowed: False
                ntname: INSTRUCTIONS
                opcode: 0x83
                opcode_base10: 131
                operand_list: ['MEM0:rw:v', 'IMM0:r:b:i8']
                operands: MEM0:rw:v IMM0:r:b:i8
                osz_required: False
                parsed_operands: [<opnds.operand_info_t object at 0x00000169CB35D730>, <opnds.operand_info_t object at 0x00000169CB35D760>]
                partial_opcode: False
                pattern: 0x83 MOD[mm] MOD!=3 REG[0b010] RM[nnn] MODRM() SIMM8() LOCK=0
                real_opcode: Y
                reg_required: 2
                rexw_prefix: unspecified
                rm_required: unspecified
                scalar: False
                sibmem: False
                space: legacy
                undocumented: False
                upper_nibble: 8
                vl: n/a
                EOSZ_LIST: [16, 32, 64]
            */

            readonly AppServices AppSvc;

            public DumpBlockReceiver(AppServices svc)
            {
                AppSvc = svc;
            }

            public void Captured(in DumpBlock block)
            {
                AppSvc.Write(string.Format("{0,-6} {1}", block.Seq, block.Form));

            }

        }

        public ref struct DumpBlock
        {
            public readonly uint Seq;

            public readonly InstForm Form;

            public readonly ReadOnlySpan<string> Lines;

            [MethodImpl(Inline)]
            public DumpBlock(uint seq, InstForm form,ReadOnlySpan<string> content)
            {
                Seq = seq;
                Form = form;
                Lines = content;
            }
        }

        FS.FilePath Source;

        MemoryFile File;

        MemoryAddress Base;

        const uint Partition = 128;

        readonly uint FileSize;

        readonly uint BlockSize;

        readonly uint BlockCount;

        readonly uint Remainder;

        readonly uint Continuous;

        readonly uint Parts;

        readonly uint PartRemainder;

        TextDocStats Stats;

        static W256 w => default;

        const string FirstItemMarker = "amd_3dnow_opcode:";

        const string LastItemMarker = "EOSZ_LIST:";

        public XedDumpImporter(FS.FilePath src)
        {
            Source = src;
            BlockSize = (uint)w.DataWidth/8;
            File = src.MemoryMap();
            FileSize = File.Size;
            Base = File.BaseAddress;
            BlockCount = FileSize/BlockSize;
            Remainder = FileSize%BlockSize;
            Continuous = BlockCount*BlockSize;
            Parts = BlockCount/Partition;
            PartRemainder = BlockCount%Partition;
        }

        void Decode(MemoryAddress src, uint size)
        {
            var data = core.cover(src.Pointer<byte>(), size);
            add(ref Stats.InputSize, data.Length);
            for(var i=0; i<size; i++)
            {
                if(SQ.nl(skip(data,i)))
                    inc(ref Stats.LineCount);
            }

            var storage = CharBlock32.Null;
            var buffer = recover<ushort>(storage.Data);
            if(size == 32)
            {
                var decoded = Asci.decode(cpu.vload(w256,data));
                add(ref Stats.OutputSize, buffer.Length);
            }
            else
            {
                for(var i=0; i<size; i++)
                {
                    seek(buffer,i) = skip(data,i);
                    add(ref Stats.OutputSize,2);
                }
            }
        }

        public TextDocStats Run()
        {
            var counter = 0u;
            var seg = File.Segment();
            var offset = Base;
            for(var i=0u; i<BlockCount; i++)
            {
                Decode(offset,BlockSize);
                offset = offset + BlockSize;
            }
            Decode(offset, Remainder);

            return Stats;
        }

        public void Dispose()
            => File.Dispose();

        public interface IBlockReceiver
        {
            void Captured(in DumpBlock block);
        }

        public static void blocks(FS.FilePath src, IBlockReceiver dst)
        {
            const string Marker = "iform:";
            var lines = src.ReadLines();
            var seq = 0u;
            var i0 = 0u;
            var form = InstForm.Empty;
            for(var i=0u; i<lines.Count; i++)
            {
                var line = text.trim(lines[i]);
                if(text.begins(line,FirstItemMarker))
                    i0 = i;
                else if(text.begins(line, LastItemMarker))
                    dst.Captured(new DumpBlock(seq++, form, segment(lines.View,i0,i)));
                else
                {
                    var j = text.index(line,Marker);
                    if(j >= 0)
                    {
                        var k = text.index(line,Chars.Colon);
                        XedParsers.parse(text.trim(text.right(line,k)), out form);
                    }
                }
            }
        }

        public static LineMap<InstForm> map(FS.FilePath src)
        {
            const string Pattern = "{0,-6} | {1,-6} | {2,-6} | {3,-6} | {4,-64}";
            const string Marker = "iform:";
            var data = src.ReadLines();
            var seq = 0u;
            var i0 = 0u;
            var buffer = list<LineInterval<InstForm>>();
            var form = InstForm.Empty;
            for(var i=0u; i<data.Length; i++)
            {
                var line = text.trim(data[i]);
                if(text.begins(line,FirstItemMarker))
                    i0 = i;
                else if(text.begins(line, LastItemMarker))
                {
                    var seg = new LineInterval<InstForm>(form, i0, i);
                    buffer.Add(seg);
                }
                else
                {
                    var j = text.index(line,Marker);
                    if(j >= 0)
                    {
                        var k = text.index(line,Chars.Colon);
                        XedParsers.parse(text.trim(text.right(line,k)), out form);
                    }
                }
            }

            return buffer.ToArray();

        }
        public static LineMap<InstForm> map(FS.FilePath src, FS.FilePath dst)
        {
            const string Pattern = "{0,-6} | {1,-6} | {2,-6} | {3,-6} | {4,-64}";
            var data = map(src);
           var seq = 0u;

            using var writer = dst.AsciWriter();
            writer.AppendLineFormat(Pattern,"Seq", "Min", "Max", "Lines", "Form");
            for(var i=0u; i<data.IntervalCount; i++)
            {
                ref readonly var seg = ref data[i];
                writer.AppendLineFormat(Pattern, seq++, seg.MinLine, seg.MaxLine, seg.LineCount, seg.Id);
            }

            return data;
        }
    }
}