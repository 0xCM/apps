//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CellFuncSig
    {
        [MethodImpl(Inline), Op]
        public static CellFuncSig sig(Identifier name, NativeTypeWidth[] args, NativeTypeWidth result)
            => new CellFuncSig(name, args, result);

        public Identifier FuncName {get;}

        public NativeTypeWidth[] ArgWidths {get;}

        public NativeTypeWidth ResultWidth {get;}

        [MethodImpl(Inline)]
        public CellFuncSig(Identifier name, NativeTypeWidth[] args, NativeTypeWidth result)
        {
            FuncName = name;
            ArgWidths = args;
            ResultWidth = result;
        }
    }
}