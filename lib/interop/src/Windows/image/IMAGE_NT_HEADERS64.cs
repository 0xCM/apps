namespace Windows.Image
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_NT_HEADERS64
    {
        public uint Signature;

        public IMAGE_FILE_HEADER FileHeader;

        public IMAGE_OPTIONAL_HEADER64 OptionalHeader;
    }
}