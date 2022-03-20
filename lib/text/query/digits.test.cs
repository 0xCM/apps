//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using C = AsciCode;

    partial struct SymbolicQuery
    {
        // /// <summary>
        // /// Determines whether an asci span segment defines a sequence of binary digits
        // /// </summary>
        // /// <param name="base">The base selector</param>
        // /// <param name="src">The data source</param>
        // /// <param name="offset">The source offset</param>
        // /// <param name="count">The sequence length</param>
        // [MethodImpl(Inline), Op]
        // public static bit digits(Base2 @base, ReadOnlySpan<C> src, uint offset, uint count)
        // {
        //     for(var i=offset; i<count+offset; i++)
        //     {
        //         ref readonly var c = ref skip(src,i);
        //         if(!digit(@base, c))
        //             return false;
        //     }
        //     return true;
        // }

        // /// <summary>
        // /// Determines whether a character span segment defines a sequence of binary digits
        // /// </summary>
        // /// <param name="base">The base selector</param>
        // /// <param name="src">The data source</param>
        // /// <param name="offset">The source offset</param>
        // /// <param name="count">The sequence length</param>
        // [MethodImpl(Inline), Op]
        // public static bit digits(Base2 @base, ReadOnlySpan<char> src, uint offset, uint count)
        // {
        //     for(var i=offset; i<count+offset; i++)
        //     {
        //         ref readonly var c = ref skip(src,i);
        //         if(!digit(@base, c))
        //             return false;
        //     }
        //     return true;
        // }

        // /// <summary>
        // /// Determines whether an asci span segment defines a sequence of decimal digits
        // /// </summary>
        // /// <param name="base">The base selector</param>
        // /// <param name="src">The data source</param>
        // /// <param name="offset">The source offset</param>
        // /// <param name="count">The sequence length</param>
        // [MethodImpl(Inline), Op]
        // public static bit digits(Base10 @base, ReadOnlySpan<C> src, uint offset, uint count)
        // {
        //     for(var i=offset; i<count+offset; i++)
        //     {
        //         ref readonly var c = ref skip(src,i);
        //         if(!digit(@base, c))
        //             return false;
        //     }
        //     return true;
        // }

        // /// <summary>
        // /// Determines whether a character span segment defines a sequence of decimal digits
        // /// </summary>
        // /// <param name="base">The base selector</param>
        // /// <param name="src">The data source</param>
        // /// <param name="offset">The source offset</param>
        // /// <param name="count">The sequence length</param>
        // [MethodImpl(Inline), Op]
        // public static bit digits(Base10 @base, ReadOnlySpan<char> src, uint offset, uint count)
        // {
        //     for(var i=offset; i<count+offset; i++)
        //     {
        //         ref readonly var c = ref skip(src,i);
        //         if(!digit(@base, c))
        //             return false;
        //     }
        //     return true;
        // }
   }
}