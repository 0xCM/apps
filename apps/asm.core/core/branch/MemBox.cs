//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using static Root;
    using Asm;

    [ApiComplete]
    public struct MemBox
    {
        MemoryAddress PhysicalBase {get;}

        MemoryAddress VirtualBase {get;}

        public ByteSize Size {get;}

        MemoryAddress _IP;

        [MethodImpl(Inline)]
        public MemBox(MemoryAddress @base, ByteSize size)
        {
            PhysicalBase = @base;
            VirtualBase = 0;
            Size = size;
            _IP = 0;
        }

        [MethodImpl(Inline)]
        public MemBox(MemoryAddress @base, MemoryAddress virt, ByteSize size)
        {
            PhysicalBase = @base;
            VirtualBase = virt;
            Size = size;
            _IP = @base - virt;
        }

        public readonly MemoryAddress Base
        {
            [MethodImpl(Inline)]
            get => PhysicalBase - VirtualBase;
        }

        public readonly MemoryAddress Max
        {
            [MethodImpl(Inline)]
            get => Base + Size;
        }

        [MethodImpl(Inline)]
        public MemoryAddress IP()
            => _IP;

        [MethodImpl(Inline)]
        public bool IP(MemoryAddress src)
        {
            if(src <= Max && src >=Base)
            {
                _IP = src;
                return true;
            }
            else
                return false;
        }

        [MethodImpl(Inline)]
        public readonly bool Contains(MemoryAddress src)
            => src <= Max && src >=Base;

        [MethodImpl(Inline)]
        public bool Advance(Disp32 dx, out MemoryAddress next)
        {
            var _next = _IP + (MemoryAddress)(int)dx;
            if(Contains(_next))
            {
                _IP = _next;
                next = _IP;
                return true;
            }
            else
            {
                next = 0;
                return false;
            }
        }

        [MethodImpl(Inline)]
        public bool Advance(byte sz, Disp32 dx, out MemoryAddress next)
        {
            var _next = sz + (MemoryAddress)(int)dx + _IP;
            if(Contains(_next))
            {
                _IP = _next;
                next = _IP;
                return true;
            }
            else
            {
                next = 0;
                return false;
            }
        }
    }
}