//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    public sealed class KeyedAtomics<K>
        where K : unmanaged
    {
        readonly Atoms<K> Data;

        readonly Dictionary<uint,uint> KeyToOrder;

        readonly Dictionary<K,uint> ValueToKey;

        public KeyedAtomics(Atom<K>[] src)
        {
            Data = src;
            ValueToKey = new();
            KeyToOrder = new();
            var count = src.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var s = ref Data[i];
                KeyToOrder[s.Key] = i;
                ValueToKey[s.Value] = s.Key;
            }
        }

        public uint SymbolCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ReadOnlySpan<Atom<K>> Members
        {
            [MethodImpl(Inline)]
            get => Data.Members;
        }

        /// <summary>
        /// Searches for a key-predicated symbol, returning true upon success and false otherwise
        /// </summary>
        /// <param name="key">The symbol key</param>
        /// <param name="dst">The matching symbol, if found</param>
        [MethodImpl(Inline)]
        public bool Atom(uint key, out Atom<K> dst)
        {
            if(KeyToOrder.TryGetValue(key, out var order))
            {
                dst = Data[order];
                return true;
            }
            else
            {
                dst = Atom<K>.Empty;
                return false;
            }
        }

        [MethodImpl(Inline)]
        public bool Key(K src, out uint key)
        {
            if(ValueToKey.TryGetValue(src, out key))
                return true;
            else
            {
                key = default;
                return false;
            }
        }

        public Atom<K> this[uint key]
        {
            [MethodImpl(Inline)]
            get
            {
                if(Atom(key, out var dst))
                    return dst;
                else
                    return Atom<K>.Empty;
            }
        }

        public uint this[K value]
        {
            [MethodImpl(Inline)]
            get => Key(value, out var dst) ? dst : default;
        }
    }
}