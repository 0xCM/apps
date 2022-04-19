//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct ItemLists
    {
        public static ItemList<T> list<T>(ListItem<T>[] items)
            => new ItemList<T>(items);

        public static string format(ItemList src)
        {
            var count = src.Length;
            var dst = text.buffer();
            for(var i=0; i<count; i++)
                dst.AppendLine(src[i].Format());
            return dst.Emit();
        }

        public static string format<T>(ItemList<T> src)
        {
            var count = src.Length;
            var dst = text.buffer();
            for(var i=0; i<count; i++)
                dst.AppendLine(src[i].Format());
            return dst.Emit();
        }

        public static string format<K,T>(ItemList<K,T> src)
        {
            var count = src.Length;
            var dst = text.buffer();
            for(var i=0; i<count; i++)
                dst.AppendLine(src[i].Format());
            return dst.Emit();
        }

        public static ListItem untype<T>(ListItem<T> src)
            => new ListItem(src.Key, text.trim(src.Value?.ToString() ?? EmptyString));

        public static Outcome parse(string src, out ListItem dst)
        {
            dst = default;
            var parts = src.SplitClean(Chars.Pipe);
            if(parts.Length < 2)
                return (false, "A list item requires at least two fields");

            var result = Outcome.Success;
            result = uint.TryParse(skip(parts,0), out var key);
            if(result.Fail)
                return false;

            var value = text.trim(skip(parts, 1));
            dst = new ListItem(key,value);
            return result;
        }
    }
}