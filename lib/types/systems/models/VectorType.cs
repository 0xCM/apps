//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;


    public class VectorType : IVectorType
    {
        public ScalarType CellType {get;}

        public uint CellCount {get;}

        public ulong Kind {get;}

        public BitWidth ContentWidth
            => CellType.ContentWidth*CellCount;

        public BitWidth StorageWidth
            => CellType.StorageWidth*CellCount;

        internal VectorType(ScalarType cellkind, uint n)
        {
            CellType = cellkind;
            CellCount = n;
            Kind = 0;
        }

        public string Format()
            => CanonicalTypeNames.v(CellCount, CellType);

        public override string ToString()
            => Format();
    }
}