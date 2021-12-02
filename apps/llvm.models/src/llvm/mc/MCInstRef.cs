//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct MCInstRef
    {
        public uint Seq;

        public LineNumber Line;

        public text31 Name;

        [MethodImpl(Inline)]
        public MCInstRef(uint seq, LineNumber line, string name)
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

