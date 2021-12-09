//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct LlvmAsmIdentity
    {
        public const string TableId = "llvm.asm.identity";

        public uint Key;

        public AsciBlock32 Name;

        [MethodImpl(Inline)]
        public LlvmAsmIdentity(uint id, in AsciBlock32 name)
        {
            Key = id;
            Name = name;
        }
    }
}
