//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

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

        [CmdOp("xed/check/patterns")]
        Outcome CheckPatterns(CmdArgs args)
        {
            var blocks = cdict<uint,string[]>();

            var traversals = XedPatterns.traversals()
                .WithPreHandler(PatternTraversal);

            var traverser = XedPatterns.traverser(traversals);
            traverser.TraverseDefs(Xed.Rules.CalcInstDefs());


            void PatternTraversal(in InstDef def, in InstPatternSpec pattern)
            {
                ref readonly var ops = ref pattern.Ops;
                var dst = alloc<string>(2 + ops.Count);
                var j=0u;
                seek(dst,j++) = string.Format("{0,-20} | {1,-4} | {2}", pattern.InstClass, pattern.Mode, pattern.BodyExpr);
                seek(dst,j++) = string.Format("{0,-20} | {1}", pattern.OpCode, pattern.InstForm);
                for(var i=0; i<ops.Count; i++)
                {
                    ref readonly var op = ref ops[i];
                    seek(dst,j++) = string.Format("{0,-20} | {0} {1}", EmptyString, op.Index, op.Format());
                }
                blocks.TryAdd(pattern.PatternId, dst);
            }

            var path = XedPaths.Targets() + FS.file("xed.inst.patterns.opinfo", FS.Csv);
            var emitting = EmittingFile(path);
            using var writer = path.AsciWriter();
            var keys = blocks.Keys.Array().Sort();
            var counter = 0u;
            for(var i=0; i<keys.Length; i++)
            {
                var lines = blocks[skip(keys,i)];
                for(var j=0; j<lines.Length; j++, counter++)
                    writer.WriteLine(skip(lines,j));
            }

            EmittedFile(emitting,counter);
            return true;
        }
    }
}