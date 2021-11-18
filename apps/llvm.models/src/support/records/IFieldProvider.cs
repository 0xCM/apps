//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    public interface IFieldProvider
    {
        Identifier EntityName {get;}

        ReadOnlySpan<RecordField> Fields {get;}
    }
}