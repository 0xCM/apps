//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Generic;
    using Microsoft.DiaSymReader;

    partial struct PdbModel
    {
        internal sealed class DocumentMethods : Dictionary<ISymUnmanagedDocument,Index<ISymUnmanagedMethod>>
        {

        }
    }
}