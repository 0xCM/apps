//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using static Programs;
    using static core;

    public readonly partial struct Programs
    {



    }


    public class Program<T>
    {
        public Index<string> Names {get;}

        public Index<T> Values {get;}

        public uint Capacity {get;}

        public Program(uint capacity)
        {
            Capacity = capacity;
            Names = alloc<string>(capacity);
            Values = alloc<T>(capacity);
        }

        public void Assign(string name, uint location)
        {
            Names[location] = name;
        }

        public void Assign(uint location, T value)
        {
            Values[location] = value;
        }

        public KeyedValues<string,uint> Environment()
        {
            var dst = alloc<KeyedValue<string,uint>>(Capacity);
            for(var i=0u; i<Capacity; i++)
                seek(dst,i) = (Names[i],i);
            return dst;
        }

        public KeyedValues<uint,T> State()
        {
            var dst = alloc<KeyedValue<uint,T>>(Capacity);
            for(var i=0u; i<Capacity; i++)
                seek(dst,i) = (i,Values[i]);
            return dst;
        }
    }

}