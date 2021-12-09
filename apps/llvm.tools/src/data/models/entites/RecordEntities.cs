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

    public readonly struct RecordEntities
    {
        readonly List<RecordEntity> Data;

        public Identifier Name {get;}

        [MethodImpl(Inline)]
        public RecordEntities(RecordEntity[] src)
        {
            Name = RP.Empty;
            Data = new(src);
        }

        public RecordEntities Children(string parent)
        {
            var children = Data.Where(x => x.Def.Ancestors.Name == parent).ToArray();
            return new RecordEntities(parent, children);
        }

        public SortedDictionary<string,RecordEntities> GroupByParent()
        {
            var name = EmptyString;
            var current = RecordEntities.Empty;
            var dst = new SortedDictionary<string,RecordEntities>();
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
                    dst[entity.ParentName] = new RecordEntities(entity.ParentName, sys.empty<RecordEntity>());
                    dst[entity.ParentName].Include(entity);
                }
            }

            return dst;
        }

        [MethodImpl(Inline)]
        public RecordEntities(Identifier name, RecordEntity[] src)
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

        public RecordEntities Include(params RecordEntity[] src)
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
        public static implicit operator RecordEntities(RecordEntity[] src)
            => new RecordEntities(src);

        [MethodImpl(Inline)]
        public static implicit operator RecordEntities(Index<RecordEntity> src)
            => new RecordEntities(src);

        [MethodImpl(Inline)]
        public static implicit operator RecordEntities((string name, Index<RecordEntity> members) src)
            => new RecordEntities(src.name, src.members);

        public static RecordEntities Empty => new RecordEntities(EmptyString, sys.empty<RecordEntity>());
    }
}