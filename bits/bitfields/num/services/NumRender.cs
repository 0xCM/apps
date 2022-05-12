//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NumRender : IRenderRegistrar
    {
        public static IRenderRegistrar Service => new NumRender();

        public void RegisterFomatters()
        {
            text.RegisterFormatter(Fixed9, RenderStyle.Fixed);
            text.RegisterFormatter(Fixed8, RenderStyle.Fixed);
            text.RegisterFormatter(Fixed4, RenderStyle.Fixed);
        }

        public static RenderDelegate<num4> Fixed4 => src => string.Format("{0:D2}", (byte)src);

        public static RenderDelegate<num8> Fixed8 => src => string.Format("{0:D2}", (byte)src);

        public static RenderDelegate<num9> Fixed9 => src => string.Format("{0:D3}", (byte)src);
    }
}