//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public ref struct LlvmEtlQuery
    {
        [MethodImpl(Inline)]
        public static LlvmEtlQuery create(in EtlDatasets src)
            => new LlvmEtlQuery(src);

        readonly EtlDatasets Datasets;

        [MethodImpl(Inline)]
        internal LlvmEtlQuery(in EtlDatasets src)
        {
            Datasets = src;
        }

        public bool FindList(Identifier name, out ItemList<string> dst)
        {
            if(Datasets.ListIndex.TryGetValue(name, out var index))
            {
                dst = skip(Datasets.Lists,index);
                return true;
            }
            dst = ItemList<string>.Empty;
            return false;
        }

        public bool FindDefLines(Identifier entity, out ReadOnlySpan<TextLine> dst)
        {
            var map = Datasets.DefMap;
            var src = Datasets.Records;
            var result = false;
            dst = default;
            for(var i=0; i<map.IntervalCount; i++)
            {
                ref readonly var x = ref skip(map.Intervals, i);
                if(x.Id == entity)
                {
                    var l0 = x.MinLine;
                    var l1 = x.MaxLine;
                    dst = slice(src,l0-1, l1 - l0 + 1);
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool FindEntityFields(Identifier entity, out EltFieldSet dst)
        {
            var src = Datasets.Defs;
            var count = src.Length;
            var counter = 0u;
            var offset = 0u;
            var result = false;
            dst = default;
            for(var i=0u; i<count; i++)
            {
                ref readonly var def = ref skip(src,i);

                if(i==count -1 && counter != 0)
                {
                    dst = new EltFieldSet(entity, slice(src,offset,++counter));
                    result = true;
                    break;
                }

                if(def.RecordName != entity && counter != 0)
                {
                    dst = new EltFieldSet(entity, slice(src,offset,counter));
                    result = true;
                    break;
                }

                if(def.RecordName == entity)
                {
                    if(counter == 0)
                        offset = i;
                    counter++;
                }
            }
            return result;
        }
    }
}