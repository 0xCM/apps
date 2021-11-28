//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

     partial class bits
     {
          /// <summary>
          /// Disables a sequence of 8 source bits starting at a specified index
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="index">The index at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable8(ushort src, byte index)
          {
               var mask = uint.MaxValue ^ ((uint)byte.MaxValue << index);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 8 source bits starting at a specified index
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="index">The index at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable8(uint src, byte index)
          {
               var mask = uint.MaxValue ^ ((uint)byte.MaxValue << index);
               return mask & src;
          }

          /// <summary>
          /// Disables a sequence of 8 source bits starting at a specified index
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="index">The index at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable8(ulong src, byte index)
          {
               var mask = ulong.MaxValue ^ ((ulong)byte.MaxValue << index);
               return mask & src;
          }
     }
}