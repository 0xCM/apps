//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// A cover for the <see cref='PartId'/> enum
    /// </summary>
    public readonly struct ApiPartKind
    {
        public readonly PartId Id;

        [MethodImpl(Inline)]
        public ApiPartKind(PartId id)
            => Id = id;

        [MethodImpl(Inline)]
        public string Format()
            => Id.Format();

        [MethodImpl(Inline)]
        public static implicit operator ApiPartKind(PartId src)
            => new ApiPartKind(src);

        [MethodImpl(Inline)]
        public static implicit operator PartId(ApiPartKind src)
            => src.Id;

        public override string ToString()
            => Format();
    }
}