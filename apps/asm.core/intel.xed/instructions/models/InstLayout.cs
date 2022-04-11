//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct InstLayout : IComparable<InstLayout>
        {
            public readonly InstGroupMember GroupMember;

            public readonly InstClass Class;

            public readonly XedOpCode OpCode;

            public readonly Index<LayoutField> Cells;

            [MethodImpl(Inline)]
            public InstLayout(InstClass @class, InstGroupMember member, in XedOpCode oc, LayoutField[] fields)
            {
                GroupMember = member;
                Class = @class;
                OpCode = oc;
                Cells = fields;
            }

            public ref readonly ushort PatternId
            {
                [MethodImpl(Inline)]
                get => ref GroupMember.PatternId;
            }

            public ref readonly byte Index
            {
                [MethodImpl(Inline)]
                get => ref GroupMember.Index;
            }

            public uint CellCount
            {
                [MethodImpl(Inline)]
                get => Cells.Count;
            }

            public ref LayoutField this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Cells[i];
            }

            public ref LayoutField this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Cells[i];
            }

            public InstLayout Replicate()
            {
                var dst = new InstLayout(Class, GroupMember, OpCode, core.alloc<LayoutField>(CellCount));
                for(var i=0; i<CellCount; i++)
                    dst[i] = this[i];
                return dst;
            }

            public string Format()
            {
                var dst = text.buffer();
                for(var i=0; i<Cells.Count; i++)
                {
                    if(i!=0)
                        dst.Append(Chars.Space);

                    dst.Append(Cells[i].Format());
                }
                return dst.Emit();
            }

            public override string ToString()
                => Format();

            public int CompareTo(InstLayout src)
                => GroupMember.CompareTo(src.GroupMember);

            public static InstLayout Empty => new (InstClass.Empty, InstGroupMember.Empty, XedOpCode.Empty, sys.empty<LayoutField>());
        }
    }
}