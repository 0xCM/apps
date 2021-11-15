//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmRegClass
    {
        public RegClassCode Code {get;}

        [MethodImpl(Inline)]
        public AsmRegClass(RegClassCode code)
        {
            Code = code;
        }

        [MethodImpl(Inline)]
        public static implicit operator AsmRegClass(RegClassCode src)
            => new AsmRegClass(src);

        [MethodImpl(Inline)]
        public static implicit operator RegClassCode(AsmRegClass src)
            => src.Code;

        [MethodImpl(Inline)]
        public static implicit operator byte(AsmRegClass src)
            => (byte)src.Code;
    }
}