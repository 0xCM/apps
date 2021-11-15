//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IVariant : ITextual
    {
        /// <summary>
        /// The number of bits that are used to store the enclosed data
        /// </summary>
        int DataWidth {get;}

        /// <summary>
        /// The numeric data type if unsegmented or, if segmented, the numeric cell kind
        /// </summary>
        NumericKind CellKind {get;}
    }

    [Free]
    public interface IVariant<V> : IVariant
        where V : unmanaged, IVariant<V>
    {

    }
}