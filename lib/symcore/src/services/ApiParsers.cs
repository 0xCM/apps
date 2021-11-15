//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct ApiParsers
    {
        [Op]
        public static PartId partFromFile(string src)
            => part(Path.GetFileName(src).Replace("z0.", EmptyString).Replace(".dll", EmptyString).Replace(".exe", EmptyString));

        [Op]
        public static Outcome path(string src, out ApiPath dst)
        {
            var result = Outcome.Success;
            dst = ApiPath.Empty;
            var _part = PartId.None;
            var i = text.index(src, Chars.FSlash);
            if(i > 0)
            {
                var components = src.Split(Chars.FSlash);
                result = part(text.left(src,i), out _part);
                if(result)
                    dst = ApiPath.define(_part, text.right(src,i));
            }
            else
            {
                result = part(src, out _part);
                if(result)
                    dst = ApiPath.define(_part);
            }

            return result;
        }

        public static PartId part(string src)
        {
            part(src, out var dst);
            return dst;
        }

        [Op]
        public static Outcome part(string src, out PartId dst)
        {
            dst = PartId.None;
            var symbols = Symbols.index<PartId>();
            if(symbols.Lookup(src, out var sym))
            {
                dst = sym.Kind;
                return true;
            }
            return false;
        }

        [Op]
        public static Outcome host(string src, out ApiHostUri dst)
        {
            var result = Outcome.Failure;
            dst = ApiHostUri.Empty;
            var i = text.index(src, Chars.FSlash);
            if(i>0)
            {
                result = part(text.left(src,i), out var p);
                if(result)
                {
                    var h = ApiHostUri.define(p, text.right(src,i));
                    return result;
                }
            }
            return result;
        }

        [Op]
        public static ReadOnlySpan<PartId> parts(ReadOnlySpan<string> parts)
        {
            var count = parts.Length;
            if(count == 0)
                return default;

            var symbols = Symbols.index<PartId>();
            var dst = span<PartId>(count);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var name = ref skip(parts,i);
                if(symbols.Lookup(name, out var sym))
                    seek(dst, counter++) = sym.Kind;
            }
            return slice(dst, 0, counter);
        }
    }
}