//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    partial struct Symbols
    {
        [Op]
        public static SymClass @class(Type tsym)
        {
            var tag = tsym.Tag<SymSourceAttribute>();
            if(tag)
                return new SymClass(tag.Value.SymKind);
            else
                return new SymClass(EmptyString);
        }
    }
}