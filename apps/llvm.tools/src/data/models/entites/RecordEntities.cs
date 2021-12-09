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

        [MethodImpl(Inline)]
        RecordEntities(Identifier name, RecordEntity[] src)
        {
            Name = name;
            Data = new(src);
        }

        public RecordEntities Children(string parent)
            => new RecordEntities(parent, Data.Where(x => x.Def.Ancestors.Name == parent).ToArray());

        public static SortedDictionary<string,RecordEntities> GroupByParent(Index<RecordEntity> src)
        {
            var name = EmptyString;
            var dst = new SortedDictionary<string,RecordEntities>();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref src[i];
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


        // public void Traverse(Action<int,RecordEntity> f)
        // {
        //     var count = Data.Count;
        //     for(var i=0; i<count; i++)
        //         f(i,Data[i]);
        // }

        RecordEntities Include(params RecordEntity[] src)
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