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
    /// Defines a <see cref='CommandOptionSpec'/> index
    /// </summary>
    public readonly struct CmdOptionSpecs : IIndex<CmdOptionSpecs,ushort,CmdOptionSpec>
    {
        readonly Index<CmdOptionSpec> Data;

        [MethodImpl(Inline)]
        public CmdOptionSpecs(CmdOptionSpec[] src)
            => Data = src;

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref CmdOptionSpec this[ushort index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public CmdOptionSpec[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public string Format()
            => seq.format(Storage);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdOptionSpecs(CmdOptionSpec[] src)
            => new CmdOptionSpecs(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdOptionSpec[](CmdOptionSpecs src)
            => src.Storage;
    }
}