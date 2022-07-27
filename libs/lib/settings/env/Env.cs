//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public abstract class Env<E>
        where E : IEquatable<E>, IExpr, new()
    {

    }


    public class Env
    {

        public record struct Machine
        {
            public utf8 _NT_SYMBOL_PATH;

        }

    }
}