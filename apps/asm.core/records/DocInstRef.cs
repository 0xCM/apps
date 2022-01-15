//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct DocInstRef
    {
        public uint Seq;

        public LineNumber Line;

        public text31 Name;

        [MethodImpl(Inline)]
        public DocInstRef(uint seq, LineNumber line, string name)
        {
            Seq = seq;
            Line = line;
            Name = name;
        }

        public string Format()
            => string.Format("{0,-8} | {1,-8} | {1}", Seq, Line, Name);

        public override string ToString()
            => Format();
    }
}

