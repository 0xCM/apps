//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static LogicSig;

    using BLK = BinaryBitLogicKind;

    /// <summary>
    /// Implements reference bitvector operations
    /// </summary>
    public readonly struct BitVectorLogix : IBitVectorLogix
    {
        public static BitVectorLogix Service => default(BitVectorLogix);

        [Op, Closures(UnsignedInts)]
        public BinaryOp<BitVector<T>> Lookup<T>(BLK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case BLK.True: return BitVector.@true;
                case BLK.False: return BitVector.@false;
                case BLK.And: return BitVector.and;
                case BLK.Nand: return BitVector.nand;
                case BLK.Or: return BitVector.or;
                case BLK.Nor: return BitVector.nor;
                case BLK.Xor: return BitVector.xor;
                case BLK.Xnor: return BitVector.xnor;
                case BLK.Left: return BitVector.left;
                case BLK.Right: return BitVector.right;
                case BLK.LNot: return BitVector.lnot;
                case BLK.RNot: return BitVector.rnot;
                case BLK.Impl: return BitVector.impl;
                case BLK.NonImpl: return BitVector.nonimpl;
                case BLK.CImpl: return BitVector.cimpl;
                case BLK.CNonImpl: return BitVector.cnonimpl;
                default: throw Unsupported.value(sig<T>(kind));
           }
        }

        [Op, Closures(UnsignedInts)]
        public BitVector<T> EvalDirect<T>(BLK kind, BitVector<T> x, BitVector<T> y)
            where T : unmanaged
        {
            switch(kind)
            {
                case BLK.True: return BitVector.@true(x,y);
                case BLK.False: return BitVector.@false(x,y);
                case BLK.And: return BitVector.and(x,y);
                case BLK.Nand: return BitVector.nand(x,y);
                case BLK.Or: return BitVector.or(x,y);
                case BLK.Nor: return BitVector.nor(x,y);
                case BLK.Xor: return BitVector.xor(x,y);
                case BLK.Xnor: return BitVector.xnor(x,y);
                case BLK.Left: return BitVector.left(x,y);
                case BLK.Right: return BitVector.right(x,y);
                case BLK.LNot: return BitVector.lnot(x,y);
                case BLK.RNot: return BitVector.rnot(x,y);
                case BLK.Impl: return BitVector.impl(x,y);
                case BLK.NonImpl: return BitVector.nonimpl(x,y);
                case BLK.CImpl: return BitVector.cimpl(x,y);
                case BLK.CNonImpl: return BitVector.cnonimpl(x,y);
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        [Op, Closures(UnsignedInts)]
        public BitVector<T> EvalRef<T>(BLK kind, BitVector<T> x, BitVector<T> y)
            where T : unmanaged
        {
            switch(kind)
            {
                case BLK.True: return BitVector.@true(x,y);
                case BLK.False: return BitVector.@false(x,y);
                case BLK.And: return and(x,y);
                case BLK.Nand: return nand(x,y);
                case BLK.Or: return or(x,y);
                case BLK.Nor: return nor(x,y);
                case BLK.Xor: return xor(x,y);
                case BLK.Xnor: return xnor(x,y);
                case BLK.Left: return x;
                case BLK.Right: return y;
                case BLK.LNot: return lnot(x,y);
                case BLK.RNot: return rnot(x,y);
                case BLK.Impl: return impl(x,y);
                case BLK.NonImpl: return nonimpl(x,y);
                case BLK.CImpl: return cimpl(x,y);
                case BLK.CNonImpl: return cnonimpl(x,y);
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        BitLogix bitlogix => BitLogix.Service;

        /// <summary>
        /// Computes the bitwise AND of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        BitVector<T> and<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVector.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.And, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise AND of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        BitVector<T> nand<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVector.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.Nand, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise OR of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        BitVector<T> or<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVector.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.Or, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise OR of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        BitVector<T> nor<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVector.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.Nor, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise XOR of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        BitVector<T> xor<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVector.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.Xor, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise XOR of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        BitVector<T> xnor<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVector.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.Xnor, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise LeftNot of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        BitVector<T> lnot<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVector.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = BitLogix.Service.Evaluate(UnaryBitLogicKind.Not, x[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise LeftNot of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        BitVector<T> rnot<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVector.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = BitLogix.Service.Evaluate(UnaryBitLogicKind.Not, y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise Impliction of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        BitVector<T> impl<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVector.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.Impl, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise NotImpliction of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        BitVector<T> nonimpl<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVector.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.NonImpl, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise ConverseImpliction of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        BitVector<T> cimpl<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVector.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.CImpl, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise ConverseImpliction of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        BitVector<T> cnonimpl<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVector.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.CNonImpl, x[i], y[i]);
            return z;
        }

        BitVector<T> select<T>(BitVector<T> x, BitVector<T> y, BitVector<T> z)
            where T : unmanaged
        {
            var len = x.Width;
            var dst = BitVector.alloc<T>();
            for(var i=0; i< len; i++)
                dst[i] = BitLogix.select(x[i], y[i], z[i]);
            return z;
        }
    }
}