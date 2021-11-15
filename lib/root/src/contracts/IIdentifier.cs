//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Characterizes a lexical identifier
    /// </summary>
    /// <typeparam name="H">The reifying type</typeparam>
    public interface IIdentifier<H> : IText, IDataTypeComparable<H>
        where H : struct, IIdentifier<H>
    {

    }

    public interface IIdentifier<H,T> : IIdentifier<H>
        where H : struct, IIdentifier<H,T>
        where T : IComparable<T>
    {
        string IText.Text
            => Format();

        T Value {get;}
    }
}