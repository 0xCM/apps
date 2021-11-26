//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.DiaSymReader;

    using static Root;
    using static PdbModel;

    partial struct PdbServices
    {
        [MethodImpl(Inline), Op]
        internal static Method adapt(ISymUnmanagedMethod src)
            => new Method(src);

        [Op]
        internal static SequencePoint adapt(SymUnmanagedSequencePoint src)
        {
            return new SequencePoint((uint)src.Offset,
                ((uint)src.StartLine, (uint)src.StartColumn),
                ((uint)src.EndLine, (uint)src.EndColumn));
        }

        [Op]
        internal static Document adapt(ISymUnmanagedDocument src)
            => new Document(src.GetName(),src.GetDocumentType());
    }
}