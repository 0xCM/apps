//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    /// <summary>
    /// Represents the empty character
    /// </summary>
    public struct c0 : IChar
    {
        public BitWidth ContentWidth => 0;

        public BitWidth StorageWidth => 0;
    }
}