//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedGrids
    {
        public interface IValue
        {
        }

        public interface IValue<T> : IValue
            where T : unmanaged
        {
            T Storage {get;}
        }
    }
}