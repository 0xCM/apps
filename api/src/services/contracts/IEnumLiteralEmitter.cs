//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IEnumLiteralEmitter
    {
        void Emit<E,T>(LiteralEmissionKind kind, FS.FilePath dst)
            where E : unmanaged, Enum
            where T : unmanaged;
    }
}