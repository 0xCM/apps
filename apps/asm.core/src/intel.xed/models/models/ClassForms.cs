//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial struct XedModels
    {
        [StructLayout(LayoutKind.Sequential,Pack =1)]
        public readonly struct ClassForms
        {
            public IClass Class {get;}

            public IFormType First {get;}

            public IFormType Last {get;}

            [MethodImpl(Inline)]
            public ClassForms(IClass @class, IFormType first, IFormType last)
            {
                Class = @class;
                First = first;
                Last = last;
            }
        }
    }
}