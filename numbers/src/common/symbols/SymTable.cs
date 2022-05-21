//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class SymTable : IBufferAllocation
    {
        StringBuffer _Strings;

        Index<SymHash> _Symbols;

        uint Allocated;

        uint SymIndex;

        internal SymTable(uint count, ByteSize capacity)
        {
            _Symbols = alloc<SymHash>(count);
            _Strings = StringBuffers.buffer(capacity/2);
            Allocated = 0;
            SymIndex = 0;
        }


        public void Dispose()
        {
            _Strings.Dispose();
        }

        uint Capacity
        {
            [MethodImpl(Inline)]
            get => _Strings.Length;
        }

        [MethodImpl(Inline)]
        bool Contains(MemoryAddress src)
            => src >= _Strings.BaseAddress && src <= _Strings.BaseAddress + _Strings.Size;

        public bool Deposit(string src)
        {
            if(!Contains(@address(src)) && SymIndex < _Symbols.Length - 1)
            {
                var offset = Allocated;
                var len = (uint)src.Length;
                var total = offset + len;
                if(total > Capacity)
                    return false;

                if(_Strings.Store(src, Allocated))
                {
                    Allocated += len;
                    _Symbols[SymIndex++] = new SymHash(new StringRef(_Strings.Address(offset), len), strings.hash(src));
                    return true;
                }
            }
            return false;
        }

        public ReadOnlySpan<SymHash> Symbols
        {
            [MethodImpl(Inline)]
            get => slice(_Symbols.View, 0, SymIndex);
        }

        public MemoryAddress BaseAddress
            => _Strings.BaseAddress;

        ByteSize IBufferAllocation.Size
            => _Strings.Size;
    }
}