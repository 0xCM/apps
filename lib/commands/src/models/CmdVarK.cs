//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct CmdVar<K>
        where K : unmanaged
    {
        public K Id {get;}

        public VarContextKind VarContext
            => VarContextKind.Workflow;

        Cell128 _Value;

        [MethodImpl(Inline)]
        public CmdVar(K id)
        {
            Id = id;
            _Value = default;
        }

        [MethodImpl(Inline)]
        public CmdVar(K id, Cell128 value)
        {
            Id = id;
            _Value = value;
        }

        public Cell128 Value
        {
            [MethodImpl(Inline)]
            get => _Value;
        }

        [MethodImpl(Inline)]
        public CmdVar<K> Set(Cell128 value)
        {
            _Value = value;
            return this;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdVar<K>(K name)
            => new CmdVar<K>(name);

        [MethodImpl(Inline)]
        public string Format()
            => _Value.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdVar<K>((K id, Cell128 value) src)
            => new CmdVar<K>(src.id, src.value);

        [MethodImpl(Inline)]
        public static implicit operator CmdVar<K>(Paired<K,Cell128> src)
            => new CmdVar<K>(src.Left, src.Right);
    }
}