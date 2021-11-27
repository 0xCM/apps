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

        public text31 Name;

        [MethodImpl(Inline)]
        public MCInstRef(uint seq, string name)
        {
            Seq = seq;
            Name = name;
        }

        public string Format()
            => string.Format("{0,-8} | {1}", Seq, Name);

        public override string ToString()
            => Format();
    }
}

