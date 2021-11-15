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
    /// Uri for .net clr assembly
    /// </summary>
    public readonly struct PartUri : IApiUri<PartUri>
    {
        /// <summary>
        /// The assembly identifier, constrained to the defining enumeration
        /// </summary>
        public PartId Id {get;}

        /// <summary>
        /// The uri content
        /// </summary>
        public string UriText {get;}

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Id == PartId.None || string.IsNullOrWhiteSpace(UriText);
        }

        [MethodImpl(Inline)]
        internal PartUri(PartId id)
        {
            Id = id;
            UriText = id != 0 ? id.Format() : EmptyString;
        }

        [MethodImpl(Inline)]
        public bool Equals(PartUri src)
            => Identified.equals(this, src);

        [MethodImpl(Inline)]
        public int CompareTo(PartUri other)
            => Identified.compare(this, other);

        public override int GetHashCode()
            => Identified.hash(this);

        public override bool Equals(object obj)
            => Identified.equals(this, obj);

        public override string ToString()
            => UriText;

        public static PartUri Empty
            => new PartUri(0);
    }
}