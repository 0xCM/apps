//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        [MethodImpl(Inline)]
        public static BfOrigin<T> origin<T>(T src)
            => src;

        [MethodImpl(Inline)]
        public static BfOrigin<ClrTypeName> origin(Type src)
            => new BfOrigin<ClrTypeName>(src, x => x.ShortName.Format());

        [MethodImpl(Inline)]
        public static BfOrigin<ClrTypeName> origin<T>()
            => origin(typeof(T));

        [MethodImpl(Inline)]
        public static BfOrigin<string> origin(FieldInfo src)
            => string.Format("[{0}/{1}/{2}:{3}]",
                    src.DeclaringType.Assembly.PartName(),
                    src.DeclaringType.Namespace,
                    src.DeclaringType.DisplayName(),
                    src.Name
                    );

        /// <summary>
        /// Creates pattern definitions predicated on tehe literal string fields in a specified type
        /// </summary>
        /// <param name="src">The defining type</param>
        public static Index<BpInfo> patterns2(Type src)
        {
            var strings = Resources.strings(src);
            var define = patterns(src);
            var count = strings.Count + define.Count;
            Index<BpInfo> dst = alloc<BpInfo>(count);
            var k=0u;
            for(var i=0; i<strings.Length; i++,k++)
            {
                ref readonly var res = ref strings[i];
                dst[k] = pattern(origin(src.Name), res.Source.Name, res.Value);
            }

            for(var i=0; i<define.Count; i++, k++)
                dst[k] = define[i];

            return dst;
        }

        public static Index<BpInfo> patterns(Type src)
        {
            var target = typeof(BpInfo);
            var props = src.Properties().Ignore().Static().WithPropertyType(target).Index();
            var fields = src.Fields().Ignore().Static().Where(x => x.FieldType == target).Index();
            var methods = src.Methods().Ignore().Public().WithArity(0).Returns(target).Index();
            var count = props.Count + fields.Count + methods.Count;
            Index<BpInfo> dst = alloc<BpInfo>(count);
            var k=0u;
            for(var i=0; i<props.Count; i++, k++)
                dst[k] = (BpInfo)props[i].GetValue(null);

            for(var i=0; i<fields.Count; i++, k++)
                dst[k] = (BpInfo)fields[i].GetValue(null);

            for(var i=0; i<methods.Count; i++, k++)
                dst[k] = (BpInfo)methods[i].Invoke(null, new object[]{});
            return dst;
        }
    }
}