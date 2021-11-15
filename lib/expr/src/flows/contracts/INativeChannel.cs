//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Flows
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface INativeChannel : ITextual
    {
        /// <summary>
        /// The number of cells carried by the channel
        /// </summary>
        uint CellCount {get;}

        /// <summary>
        /// The width of each cell
        /// </summary>
        uint CellWidth {get;}

        uint Capacity
            => CellCount*CellWidth;

        ChannelMask Mask
            => ChannelMask.Empty;
    }

    public interface INativeChannel<W> : INativeChannel
        where W : unmanaged, ITypeWidth
    {
        uint INativeChannel.CellWidth
            => (uint)Widths.type<W>();
    }

    public interface INativeChannel<N,W> : INativeChannel<W>
        where W : unmanaged, ITypeWidth
        where N : unmanaged, ITypeNat
    {
        uint INativeChannel.CellCount
            => core.nat32u<N>();
    }
}