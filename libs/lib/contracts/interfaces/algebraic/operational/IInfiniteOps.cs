//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes operations over operands for which a given reification may be infinite
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface IInfiniteOps<T>
        {

        }

        public interface ISemigroupOps<T>
        {
            /// <summary>
            /// Adjudicates equality between semigroup members
            /// </summary>
            /// <param name="lhs">The first operand</param>
            /// <param name="rhs">The second operand</param>
            bool Equals(T lhs, T rhs);
        }
    }
}