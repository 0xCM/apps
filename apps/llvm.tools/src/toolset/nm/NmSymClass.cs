//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct NmSymClass : IEquatable<NmSymClass>
    {
        public NmSymCode Code {get;}

        public NmSymKind Kind {get;}

        [MethodImpl(Inline)]
        public NmSymClass(NmSymCode code)
        {
            Code = code;
            Kind = NmSymCalcs.kind(code);
        }

        [MethodImpl(Inline)]
        public bool Equals(NmSymClass src)
            => Code == src.Code;

        public override bool Equals(object src)
            => src is NmSymClass c && Equals(c);

        public override int GetHashCode()
            => (byte)Code;

        [MethodImpl(Inline)]
        public static implicit operator NmSymClass(NmSymCode src)
            => new NmSymClass(src);

        [MethodImpl(Inline)]
        public static implicit operator NmSymCode(NmSymClass src)
            => src.Code;

        [MethodImpl(Inline)]
        public static implicit operator NmSymKind(NmSymClass src)
            => src.Kind;
    }
}