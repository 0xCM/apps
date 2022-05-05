//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct InstLayout
        {
            public readonly ushort PatternId;

            public readonly InstClass Instruction;

            public readonly XedOpCode OpCode;

            public readonly byte Count;

            public readonly SegRef<LayoutCell> Block;

            public InstLayout(ushort pid, InstClass inst, XedOpCode oc, byte count, SegRef<LayoutCell> block)
            {
                PatternId = pid;
                Instruction = inst;
                OpCode = oc;
                Count = count;
                Block = block;
            }

            public Span<LayoutCell> Cells
            {
                [MethodImpl(Inline)]
                get => Block.Data;
            }

            public ref LayoutCell this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Block[i];
            }

            public ref LayoutCell this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Block[(int)i];
            }

            public string Format()
            {
                var dst = text.emitter();
                dst.Append(Chars.LBracket);
                for(var i=0; i<Count; i++)
                {
                    dst.Append(this[i]);
                    if(i != Count - 1)
                        dst.Append(" | ");
                }
                dst.Append(Chars.RBracket);
                return dst.Emit();
            }


            public override string ToString()
                => Format();

            public static InstLayout Empty => default;

        }
    }
}