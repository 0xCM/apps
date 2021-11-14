//-----------------------------------------------------------------------------
// Copyright   :  (c) LLVM Project
// License     :  Apache-2.0 WITH LLVM-exceptions
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    public interface ILlvmDataType : ITextual
    {
        Identifier Name {get;}
    }

    public interface ILlvmDataType<T> : ILlvmDataType, IEquatable<T>
        where T : ILlvmDataType<T>
    {
    }
}