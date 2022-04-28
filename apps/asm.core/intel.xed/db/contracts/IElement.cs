//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDb
    {
        [Free]
        public interface IElement
        {
        }

        [Free]
        public interface IElement<T> : IEquatable<T>, IComparable<T>
            where T : IElement<T>
        {

        }
    }
}