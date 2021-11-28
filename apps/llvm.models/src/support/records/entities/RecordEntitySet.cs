//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Linq;

    using static Root;
    using static core;

    public readonly struct RecordEntitySet
    {
        readonly List<RecordEntity> Data;

        public Identifier Name {get;}

        [MethodImpl(Inline)]
        public RecordEntitySet(RecordEntity[] src)
        {
            Name = RP.Empty;
            Data = new(src);
        }

        public RecordEntitySet Children(string parent)
        {
            var children = Data.Where(x => x.Def.Ancestors.Name == parent).ToArray();
            return new RecordEntitySet(parent, children);
        }

        public SortedDictionary<string,RecordEntitySet> GroupByParent()
        {
            var name = EmptyString;
            var current = RecordEntitySet.Empty;
            var dst = new SortedDictionary<string,RecordEntitySet>();
            var src = Data.ViewDeposited();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(src,i);
                if(dst.TryGetValue(entity.ParentName, out var es))
                {
                    es.Include(entity);
                }
                else
                {
                    dst[entity.ParentName] = new RecordEntitySet(entity.ParentName, sys.empty<RecordEntity>());
                    dst[entity.ParentName].Include(entity);
                }
            }

            return dst;
        }

        [MethodImpl(Inline)]
        public RecordEntitySet(Identifier name, RecordEntity[] src)
        {
            Name = name;
            Data = new(src);
        }

        public void Traverse(Action<int,RecordEntity> f)
        {
            var count = Data.Count;
            for(var i=0; i<count; i++)
                f(i,Data[i]);
        }

        public RecordEntitySet Include(params RecordEntity[] src)
        {
            Data.AddRange(src);
            return this;
        }

        public ReadOnlySpan<RecordEntity> Members
        {
            [MethodImpl(Inline)]
            get => Data.ViewDeposited();
        }

        [MethodImpl(Inline)]
        public static implicit operator RecordEntitySet(RecordEntity[] src)
            => new RecordEntitySet(src);

        [MethodImpl(Inline)]
        public static implicit operator RecordEntitySet(Index<RecordEntity> src)
            => new RecordEntitySet(src);

        [MethodImpl(Inline)]
        public static implicit operator RecordEntitySet((string name, Index<RecordEntity> members) src)
            => new RecordEntitySet(src.name, src.members);

        public static RecordEntitySet Empty => new RecordEntitySet(EmptyString, sys.empty<RecordEntity>());
    }
}