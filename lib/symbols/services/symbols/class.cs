//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Symbols
    {
        const string KindScope = "::";

        [Op]
        public static string symgroup(SymClass src)
        {
            var i = text.index(src.Name, KindScope);
            if(i == NotFound)
                return src.Name;
            else
                return text.left(src.Name, i);
        }

        [Op]
        public static string symkind(SymClass src)
        {
            var i = text.index(src.Name, KindScope);
            if(i == NotFound)
                return EmptyString;
            else
                return text.right(src.Name, i + KindScope.Length - 1);
        }

        [Op]
        public static SymClass @class(Type tsym)
        {
            var tag = tsym.Tag<SymSourceAttribute>();
            if(tag)
            {
                var value = tag.Value;
                var kind = value.SymKind;
                var group = value.SymGroup;
                if(kind is string s && text.empty(s))
                    return new SymClass(tag.Value.SymGroup);
                else
                    return new SymClass(string.Format("{0}::{1}", tag.Value.SymGroup, kind));
            }
            else
                return new SymClass(EmptyString);
        }
    }
}