//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct MappedNativeType
    {
        readonly NativeTypeMap Map;

        readonly int SourceId;

        public readonly NativeType Target;

        [MethodImpl(Inline)]
        internal MappedNativeType(NativeTypeMap map, int src, NativeType dst)
        {
            Map = map;
            SourceId = src;
            Target = dst;
        }

        public ref readonly string Source
        {
            [MethodImpl(Inline)]
            get => ref Map[SourceId];
        }

        public string Format()
            => string.Format("{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Target.GetHashCode() | ((int)SourceId << 24);

        public bool Equals(MappedNativeType src)
            => SourceId == src.SourceId && Target == src.Target;
    }

    public class NativeTypeMap
    {
        public static NativeTypeMap build(Action<MapBuilder> f)
        {
            var map = new NativeTypeMap(f);
            f(map._Builder);
            return map;
        }

        public struct MapBuilder
        {
            readonly Dictionary<string,MappedNativeType> Data;

            readonly List<string> Sources;

            int SourceIndex;

            NativeTypeMap _Map;

            internal MapBuilder(NativeTypeMap map, Dictionary<string,MappedNativeType> data, List<string> sources)
            {
                _Map = map;
                Data = data;
                Sources  = sources;
                SourceIndex = 0;
            }

            public MappedNativeType Map(string src, NativeType dst)
            {
                Sources.Add(src);
                var mapped = new MappedNativeType(_Map, SourceIndex++, dst);
                Data[src] = mapped;
                return mapped;
            }
        }

        NativeTypeMap(Action<MapBuilder> f)
        {
            var data = dict<string,MappedNativeType>();
            var sources = list<string>();
            _Builder = new MapBuilder(this, data, sources);
            f(_Builder);
            _Sources = sources.ToArray();
            Data = data;
        }

        readonly MapBuilder _Builder;

        ConstLookup<string,MappedNativeType> Data;

        Index<string> _Sources;

        internal ref readonly string this[int index]
        {
            [MethodImpl(Inline)]
            get => ref _Sources[index];
        }

        internal ref readonly string this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref _Sources[index];
        }

        public ReadOnlySpan<string> Sources
        {
            [MethodImpl(Inline)]
            get => Data.Keys;
        }

        public ReadOnlySpan<MappedNativeType> Targets
        {
            [MethodImpl(Inline)]
            get => Data.Values;
        }

        public bool TryMap(string src, out MappedNativeType dst)
            => Data.Find(src, out dst);

        public MappedNativeType Map(string src)
            => Data[src];

        public MappedNativeType this[string src]
            => Data[src];
    }
}