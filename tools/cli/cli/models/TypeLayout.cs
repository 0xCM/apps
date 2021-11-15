//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using Srm = System.Reflection.Metadata;

    public readonly struct TypeLayout : ITextual
    {
        public uint Size {get;}

        public uint Pack {get;}

        [MethodImpl(Inline)]
        public TypeLayout(uint size, uint pack)
        {
            Size = size;
            Pack = pack;
        }

        public bool IsDefault
        {
            [MethodImpl(Inline)]
            get => Size == 0 ? Pack == 0  : false;
        }

        public string Format()
            => string.Format("{0}:{1}", Size, Pack);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TypeLayout((uint size, uint pack) src)
            => new TypeLayout(src.size, src.pack);

        [MethodImpl(Inline)]
        public static implicit operator TypeLayout(Srm.TypeLayout src)
            => core.@as<Srm.TypeLayout,TypeLayout>(src);
    }
}