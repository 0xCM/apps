//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmInstRef
    {
        public uint Seq;

        public LineNumber Line;

        public AsmId AsmId;

        [MethodImpl(Inline)]
        public AsmInstRef(uint seq, LineNumber line, AsmId name)
        {
            Seq = seq;
            Line = line;
            AsmId = name;
        }

        public string Format()
            => string.Format("{0,-8} | {1,-8} | {1}", Seq, Line, AsmId);

        public override string ToString()
            => Format();
    }
}

