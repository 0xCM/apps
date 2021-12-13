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

    public readonly struct LlvmEntities
    {
        readonly List<LlvmEntity> Data;

        public Identifier Name {get;}

        [MethodImpl(Inline)]
        public LlvmEntities(LlvmEntity[] src)
        {
            Name = RP.Empty;
            Data = new(src);
        }

        [MethodImpl(Inline)]
        LlvmEntities(Identifier name, LlvmEntity[] src)
        {
            Name = name;
            Data = new(src);
        }

        public LlvmEntities Children(string parent)
            => new LlvmEntities(parent, Data.Where(x => x.Def.Ancestors.Name == parent).ToArray());

        public static SortedDictionary<string,LlvmEntities> GroupByParent(Index<LlvmEntity> src)
        {
            var name = EmptyString;
            var dst = new SortedDictionary<string,LlvmEntities>();
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
                    dst[entity.ParentName] = new LlvmEntities(entity.ParentName, sys.empty<LlvmEntity>());
                    dst[entity.ParentName].Include(entity);
                }
            }

            return dst;
        }


        LlvmEntities Include(params LlvmEntity[] src)
        {
            Data.AddRange(src);
            return this;
        }

        public ReadOnlySpan<LlvmEntity> Members
        {
            [MethodImpl(Inline)]
            get => Data.ViewDeposited();
        }

        [MethodImpl(Inline)]
        public static implicit operator LlvmEntities(LlvmEntity[] src)
            => new LlvmEntities(src);

        [MethodImpl(Inline)]
        public static implicit operator LlvmEntities(Index<LlvmEntity> src)
            => new LlvmEntities(src);

        [MethodImpl(Inline)]
        public static implicit operator LlvmEntities((string name, Index<LlvmEntity> members) src)
            => new LlvmEntities(src.name, src.members);

        public static LlvmEntities Empty => new LlvmEntities(EmptyString, sys.empty<LlvmEntity>());
    }
}