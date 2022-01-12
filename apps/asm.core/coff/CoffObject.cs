//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class CoffObject
    {
        public Identifier SrcId;

        public FS.FilePath Path;

        public BinaryCode Data;

        internal CoffObject(Identifier id, FS.FilePath path, BinaryCode data)
        {
            SrcId = id;
            Path = path;
            Data = data;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Data.Size;
        }

        public ref readonly byte this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly byte this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public static CoffObject Empty
            => new CoffObject(Identifier.Empty, FS.FilePath.Empty, BinaryCode.Empty);
    }
}