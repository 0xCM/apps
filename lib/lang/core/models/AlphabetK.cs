//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines a set of symbols over which strings may be formed
    /// </summary>
    /// <typeparam name="K">The symbol value kind</typeparam>
    public class Alphabet<K> : IDisposable
        where K : unmanaged
    {
        /// <summary>
        /// The name of the alphabet
        /// </summary>
        public Label Name {get;}

        readonly NativeBuffer<K> Buffer;

        readonly Index<Atom<K>> _Atoms;

        public void Dispose()
        {
            Buffer.Dispose();
        }

        [MethodImpl(Inline)]
        internal Alphabet(Label name, Atom<K>[] src)
        {
            Name = name;
            var count = (uint)src.Length;
            Buffer = memory.native<K>(count);
            _Atoms = core.alloc<Atom<K>>(count);
            for(var i=0u; i<src.Length; i++)
            {
                ref readonly var atom = ref skip(src,i);
                Buffer[atom.Key] = skip(atom.Value, i);
                _Atoms[atom.Key] = atom;

            }
        }

        [MethodImpl(Inline)]
        internal Alphabet(Label name, K[] src)
        {
            Name = name;
            var count = (uint)src.Length;
            Buffer = memory.native<K>(count);
            _Atoms = core.alloc<Atom<K>>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var symbol = ref skip(src,i);
                Buffer[i] = symbol;
                _Atoms[i] = (i,symbol);
            }
        }

        [MethodImpl(Inline)]
        public ref readonly Atom<K> Atom(uint key)
            => ref _Atoms[key];

        [MethodImpl(Inline)]
        public Atom<K> Atom(int index)
            => new Atom<K>((uint)index, this[index]);

        [MethodImpl(Inline)]
        public ReadOnlySpan<K> Letters(uint offset, uint count)
            => core.cover(Buffer[offset],count);

        public ref K this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Buffer[index];
        }

        public ref K this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Buffer[index];
        }

        public ReadOnlySpan<K> this[uint offset, uint count]
        {
            [MethodImpl(Inline)]
            get => Letters(offset,count);
        }

        /// <summary>
        /// The symbols that comprise the alpabet
        /// </summary>
        public ReadOnlySpan<K> Members
        {
            [MethodImpl(Inline)]
            get => Buffer.View;
        }

        public uint MemberCount
        {
            [MethodImpl(Inline)]
            get => (uint)Buffer.Count;
        }

        public string Format()
            => lang.format(this);

        public override string ToString()
            => Format();
    }
}