//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using Microsoft.DiaSymReader;

    using static PdbModel;

    partial struct PdbServices
    {
        public static Index<SequencePoint> points(ISymUnmanagedMethod src)
            => src.GetSequencePoints().Array().Select(adapt);
    }
}