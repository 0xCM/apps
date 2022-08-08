//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    public class SymbolHash : Allocation<SymHash>, ISymbolHash
    {
        public static SymbolHash alloc(uint count, byte symlength)
            => new SymbolHash(count, symlength*count);

        StringBuffer _Strings;

        Index<SymHash> _Symbols;

        uint Allocated;

        uint SymIndex;

        internal SymbolHash(uint count, ByteSize capacity)
        {
            _Symbols = sys.alloc<SymHash>(count);
            _Strings = StringBuffers.buffer(capacity/2);
            Allocated = 0;
            SymIndex = 0;
        }

        protected override void Dispose()
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

        public bool HashSymbol(string src)
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
                    _Symbols[SymIndex++] = new SymHash(new StringRef(_Strings.Address(offset), len), core.hash(src));
                    return true;
                }
            }
            return false;
        }

        protected override Span<SymHash> Data
        {
            [MethodImpl(Inline)]
            get => slice(_Symbols.Edit, 0, SymIndex);
        }

        public override MemoryAddress BaseAddress
            => _Strings.BaseAddress;

        public override ByteSize Size
            => _Strings.Size;
    }
}