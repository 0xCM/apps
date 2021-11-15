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
        [Op]
        internal static Document[] documents(ISymUnmanagedMethod src)
            => src.GetDocumentsForMethod().Select(adapt);
    }
}