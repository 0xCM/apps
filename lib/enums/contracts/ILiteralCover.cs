//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILiteralCover : IValueCover
    {

    }

    public interface ILiteralCover<T> : ILiteralCover, IValueCover<T>
    {

    }
}