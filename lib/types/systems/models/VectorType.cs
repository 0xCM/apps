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

        public VectorKind Kind {get;}

        public BitWidth ContentWidth {get;}

        public BitWidth StorageWidth {get;}

        internal VectorType(ScalarType cellkind, uint n)
        {
            CellType = cellkind;
        }
    }
}