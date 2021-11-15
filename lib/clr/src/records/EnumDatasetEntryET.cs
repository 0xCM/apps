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
    /// Defines a <see cref='EnumDataset{E,T}'/> entry
    /// </summary>
    /// <typeparam name="E">The enum type</typeparam>
    /// <typeparam name="T">The refined primitive type</typeparam>
    public struct EnumDatasetEntry<E,T>
        where E : unmanaged, Enum
        where T : unmanaged
    {
        /// <summary>
        /// The artifact identifier of the defining literal
        /// </summary>
        public CliToken Token;

        /// <summary>
        /// The defining <see cref='Enum'/> id
        /// </summary>
        public CliToken EnumId;

        /// <summary>
        /// The 0-based declaration order of the defining literal
        /// </summary>
        public uint Index;

        /// <summary>
        /// The refined primitive value
        /// </summary>
        public T ScalarValue;

        /// <summary>
        /// The literal name
        /// </summary>
        public Name Name;

        /// <summary>
        /// The description, if available
        /// </summary>
        public string Description;

        /// <summary>
        /// The enum value
        /// </summary>
        public E EnumValue;

        [MethodImpl(Inline)]
        public EnumDatasetEntry(CliToken token, CliToken declarer, uint index, string identifier, E literal, T numeric, string description)
        {
            Token = token;
            EnumId = declarer;
            Index = index;
            Name = identifier;
            EnumValue = literal;
            ScalarValue = numeric;
            Description = description;
        }

        public EnumDatasetEntry Untyped
        {
            [MethodImpl(Inline)]
            get => new EnumDatasetEntry(Token, EnumId, Index, Name, core.bw64(ScalarValue), Description);
        }

        [MethodImpl(Inline)]
        public static implicit operator EnumDatasetEntry(EnumDatasetEntry<E,T> src)
            => src.Untyped;
    }
}