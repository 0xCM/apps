// ------------------------------------------------------------------------------------------------------------------------
// Id:0x600000c        BaseAddress:7ffaa270abd8h    Uri:located://asmrun/sigclient?run1#run1_(CodeBuffers~in)
// CliSig:[7] = [00 01 08 10 11 80 c1]
// Encoded[26] = [02 28 6e 00 00 0a 28 09 00 00 2b 0a 06 1f 2a 20 7a 01 00 00 28 0a 00 00 06 2a]
// int run1(in CodeBuffers src)
{
  IL_0000:  ldarg.0
  IL_0001:  call       0x0A00006E
  IL_0006:  call       0x2B000009
  IL_000b:  stloc.0
  IL_000c:  ldloc.0
  IL_000d:  ldc.i4.s   42
  IL_000f:  ldc.i4     0x17a
  IL_0014:  call       0x0600000A
  IL_0019:  ret
}

// ------------------------------------------------------------------------------------------------------------------------
// Id:0x600000d        BaseAddress:7ffaa270abe0h    Uri:located://asmrun/sigclient?run2#run2_(CodeBuffers~in)
// CliSig:[7] = [00 01 08 10 11 80 c1]
// Encoded[33] = [02 28 6e 00 00 0a 28 09 00 00 2b 28 09 00 00 06 0a 06 0b 1f 2a 20 7a 01 00 00 07 29 06 00 00 11 2a]
// int run2(in CodeBuffers src)
{
  IL_0000:  ldarg.0
  IL_0001:  call       0x0A00006E
  IL_0006:  call       0x2B000009
  IL_000b:  call       0x06000009
  IL_0010:  stloc.0
  IL_0011:  ldloc.0
  IL_0012:  stloc.1
  IL_0013:  ldc.i4.s   42
  IL_0015:  ldc.i4     0x17a
  IL_001a:  ldloc.1
  IL_001b:  calli      0x11000006
  IL_0020:  ret
}

