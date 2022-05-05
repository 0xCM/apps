//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class InstLayouts : IDisposable
        {
            readonly NativeCells<InstLayoutBlock> Blocks;

            readonly Index<InstLayout> Data;

            public readonly Index<InstLayoutRecord> Records;

            public InstLayouts(InstLayout[] src, NativeCells<InstLayoutBlock> blocks)
            {
                Data = src;
                Blocks = blocks;
                Records = core.alloc<InstLayoutRecord>(src.Length);;
            }

            [MethodImpl(Inline)]
            public ref InstLayoutRecord Record(uint i)
                => ref Records[i];

            [MethodImpl(Inline)]
            public ref InstLayoutRecord Record(int i)
                => ref Records[i];

            [MethodImpl(Inline)]
            ref readonly InstLayoutBlock Block(int i)
            {
                ref readonly var block = ref Blocks[i];
                return ref block.Content;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public ref InstLayout this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref InstLayout this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsNonEmpty;
            }

            public ReadOnlySpan<InstLayout> View
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public void Render(ITextEmitter dst)
            {
                const string RenderPattern = "{0,-10} | {1,-18} | {2,-22} | {3,-6} | {4}";
                dst.AppendLineFormat(RenderPattern,"PatternId", "Instruction", "OpCode", "Length", "Vector");
                for(var i=0; i<Count; i++)
                {
                    ref readonly var src = ref this[i];
                    dst.AppendLineFormat(RenderPattern, src.PatternId, src.Instruction, src.OpCode, src.Count, src.Format());
                }
            }

            public string Format()
            {
                var dst = text.emitter();
                Render(dst);
                return dst.Emit();
            }

            public override string ToString()
                => Format();

            public void Dispose()
            {
                Blocks.Dispose();
            }
        }
    }
}