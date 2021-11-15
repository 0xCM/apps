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
    /// Defines a cli signature
    /// </summary>
    public readonly struct CliSig : IDataTypeComparable<CliSig>
    {
        public BinaryCode Data {get;}

        [MethodImpl(Inline)]
        public CliSig(BinaryCode src)
            => Data = src;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Data.View);
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        public bool Equals(CliSig src)
            => Data.Equals(src.Data);

        public int CompareTo(CliSig src)
            => Data.CompareTo(src.Data);

        public override bool Equals(object obj)
            => obj is CliSig s && Equals(s);

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static bool operator==(CliSig a, CliSig b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(CliSig a, CliSig b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator CliSig(byte[] src)
            => new CliSig(src);

        [MethodImpl(Inline)]
        public static implicit operator CliSig(BinaryCode src)
            => new CliSig(src);

        [MethodImpl(Inline)]
        public static implicit operator byte[](CliSig src)
            => src.Data;

        public static CliSig Empty
        {
            [MethodImpl(Inline)]
            get => new CliSig(BinaryCode.Empty);
        }
    }
}