//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedPatterns;
    using static core;

    partial class XedCmdProvider
    {
        [MethodImpl(Inline)]
        public static bits<T> load<T>(T src)
            where T : unmanaged
                => src;

        [MethodImpl(Inline)]
        public static bits<T> load<T>(byte n, T src)
            where T : unmanaged
                => (n,src);

        [CmdOp("xed/check/bits")]
        Outcome CheckBits(CmdArgs args)
        {
            Span<char> buffer = stackalloc char[84];
            ulong input = 0xF0CCAADD33;
            uint n = 24;
            ulong match = 0b1010_1010_1101_1101_0011_0011;
            var output = BitRender.render4x4(Chars.Underscore, n,input,buffer);
            Write(string.Format("{0} | {1}",  "1010_1010_1101_1101_0011_0011", text.format(output)));

            return true;
        }

        static byte _format(InstPattern pattern, Span<string> dst)
        {
            ref readonly var ops = ref pattern.OpSpecs;

            var j=z8;
            seek(dst,j++) = string.Format("{0,-20} | {1,-4} | {2}", pattern.InstClass.Name, pattern.Mode, pattern.BodyExpr);
            seek(dst,j++) = string.Format("{0,-20} | {1}", pattern.OpCode, pattern.InstForm);

            for(var i=0; i<ops.Count; i++)
            {
                ref readonly var op = ref ops[i];
                seek(dst,j++) = string.Format("{0,20} | {1}", string.Format("{0} {1}", op.Index, XedRender.format(op.Name)), XedRender.format(op.Attribs));
            }
            return j;
        }

        [CmdOp("xed/check/patterns")]
        Outcome CheckPatterns(CmdArgs args)
        {
            var blocks = cdict<uint,string[]>();
            var patterns = cdict<uint,InstPattern>();
            var traversals = XedPatterns.traversals()
                .WithPreHandler(PatternTraversal);

            XedPatterns.traverser(traversals).TraversePatterns(Xed.Rules.CalcInstPatterns());

            void PatternTraversal(InstPattern pattern)
            {
                Require.invariant(patterns.TryAdd(pattern.PatternId,pattern));
                ref readonly var ops = ref pattern.OpSpecs;
                var dst = alloc<string>(2 + ops.Count);
                _format(pattern, dst);
                blocks.TryAdd(pattern.PatternId, dst);

            }

            var path = AppDb.Api() + FS.file("xed.inst.patterns.opinfo", FS.Csv);
            var emitting = EmittingFile(path);
            using var writer = path.AsciWriter();
            var counter = 0u;

            var sorted = patterns.Values.Array().Sort();
            var opcode = XedOpCode.Empty;
            for(var i=0; i<sorted.Length; i++)
            {
                ref readonly var pattern = ref skip(sorted,i);
                if(pattern.OpCode != opcode)
                {
                    writer.WriteLine(RP.PageBreak120);
                    opcode = pattern.OpCode;
                }

                var lines = blocks[pattern.PatternId];
                for(var j=0; j<lines.Length; j++, counter++)
                    writer.WriteLine(skip(lines,j));
            }
            EmittedFile(emitting,counter);

            return true;
        }
    }

    partial class XTend
    {
        public static Index<T> Sort<T,C>(this Index<T> src, C comparer)
            where C : IComparer<T>
        {
            System.Array.Sort(src,comparer);
            return src;
        }
    }
}