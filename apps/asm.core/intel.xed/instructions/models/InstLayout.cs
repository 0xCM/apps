//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1,Size=12*16)]
        public struct InstLayoutBlock
        {
            public Span<LayoutCell> Cells
            {
                [MethodImpl(Inline)]
                get => recover<LayoutCell>(bytes(this));
            }

            public ref LayoutCell this[int i]
            {
                [MethodImpl(Inline)]
                get => ref  seek(Cells,i);
            }

            public ref LayoutCell this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref  seek(Cells,i);
            }
        }

        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct InstLayout
        {
            public ushort PatternId;

            public InstClass Instruction;

            public XedOpCode OpCode;

            public byte Count;

            public InstLayoutBlock Block;

            [MethodImpl(Inline)]
            public InstLayout(ushort pid, InstClass inst, XedOpCode oc, byte count)
            {
                PatternId = pid;
                Instruction = inst;
                OpCode = oc;
                Count = count;
                Block = default;
            }

            public InstLayout(ushort pid, InstClass inst, XedOpCode oc, byte count, InstLayoutBlock block)
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
                get => Block.Cells;
            }

            public ref LayoutCell this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Block[i];
            }

            public ref LayoutCell this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Block[i];
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