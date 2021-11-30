//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public delegate Outcome LineProcessor(TextLine src);

    public interface ITextLineProcessor
    {
        Outcome Process(TextLine src);

        LineProcessor Handler
            => Process;
    }
}