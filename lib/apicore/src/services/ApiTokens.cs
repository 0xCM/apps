//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class ApiTokens
    {
        [Op]
        public static ApiTokens service()
            => _Instance;

        [MethodImpl(Inline), Op]
        public static Hash32 hash(ApiToken src)
            => (uint)src.Value;

        [MethodImpl(Inline), Op]
        public static ushort index(ApiToken src)
            => (ushort)(src.Value >> 32);

        [MethodImpl(Inline), Op]
        public static string format(ApiToken src)
            => service().Buffer[index(src)];

        [MethodImpl(Inline), Op]
        static ApiToken token(ushort index, in OpUri uri)
            => new ApiToken(((ulong)index << 32) | alg.hash.marvin(uri.UriText));

        public ApiToken Tokenize(in OpUri src)
        {
            lock(Locker)
            {
                if(Current < Last)
                {
                    Buffer[Current] = src.UriText;
                    var t = token(Current, src);
                    Current++;
                    return t;
                }
            }
            return ApiToken.Empty;
        }

        ApiTokens()
        {
            Buffer = Storage;
            Locker = new object();
            Current = 1;
        }

        readonly Index<ushort,string> Buffer;

        const ushort Capacity = ushort.MaxValue;

        const ushort Last = Capacity - 1;

        object Locker;

        ushort Current;

        static ApiTokens _Instance = new ApiTokens();

        static Index<ushort,string> Storage;

        static ApiTokens()
        {
            var buffer = alloc<string>(Capacity);
            Storage = buffer;
            ref var dst = ref first(buffer);
            for(ushort i=0; i<Last; i++)
                seek(dst,i) = EmptyString;
        }
    }
}