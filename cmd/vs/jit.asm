--- d:\views\dev\z0\libs\api.md\src\ClrJit.cs ----------------------------------
     4: //-----------------------------------------------------------------------------
     5: namespace Z0
     6: {
     7:     using static core;
     8:
     9:     [ApiHost]
    10:     public readonly struct ClrJit
    11:     {
    12:         [Op, MethodImpl(Inline)]
    13:         static MemoryAddress fptr(MethodInfo src)
    14:             => src.MethodHandle.GetFunctionPointer();
00007FFE185BBDF0 55                   push        rbp
00007FFE185BBDF1 41 57                push        r15
00007FFE185BBDF3 41 56                push        r14
00007FFE185BBDF5 41 55                push        r13
00007FFE185BBDF7 41 54                push        r12
00007FFE185BBDF9 57                   push        rdi
00007FFE185BBDFA 56                   push        rsi
00007FFE185BBDFB 53                   push        rbx
00007FFE185BBDFC 48 83 EC 78          sub         rsp,78h
00007FFE185BBE00 48 8D AC 24 B0 00 00 00 lea         rbp,[rsp+0B0h]
00007FFE185BBE08 48 8B F1             mov         rsi,rcx
00007FFE185BBE0B 48 8D 4D 80          lea         rcx,[rbp-80h]
00007FFE185BBE0F 49 8B D2             mov         rdx,r10
00007FFE185BBE12 E8 09 BB C6 5B       call        JIT_InitPInvokeFrame (07FFE74227920h)
00007FFE185BBE17 48 8B F8             mov         rdi,rax
00007FFE185BBE1A 48 8B CC             mov         rcx,rsp
00007FFE185BBE1D 48 89 4D A0          mov         qword ptr [rbp-60h],rcx
00007FFE185BBE21 48 8B CD             mov         rcx,rbp
00007FFE185BBE24 48 89 4D B0          mov         qword ptr [rbp-50h],rcx
00007FFE185BBE28 48 8B CE             mov         rcx,rsi
00007FFE185BBE2B 48 8B 06             mov         rax,qword ptr [rsi]
00007FFE185BBE2E 48 8B 40 60          mov         rax,qword ptr [rax+60h]
00007FFE185BBE32 FF 10                call        qword ptr [rax]
00007FFE185BBE34 48 8B F0             mov         rsi,rax
00007FFE185BBE37 48 89 75 C0          mov         qword ptr [rbp-40h],rsi
00007FFE185BBE3B 48 8B CE             mov         rcx,rsi
00007FFE185BBE3E E8 6D 12 16 FC       call        Method stub for: System.RuntimeMethodHandle.EnsureNonNullMethodInfo(System.IRuntimeMethodInfo) (07FFE1471D0B0h)
00007FFE185BBE43 48 8B C8             mov         rcx,rax
00007FFE185BBE46 49 BB C8 08 5F 14 FE 7F 00 00 mov         r11,offset Pointer to: CLRStub[VSD_LookupStub]@7ffe146001a0 (07FFE145F08C8h)
00007FFE185BBE50 FF 15 72 4A 03 FC    call        qword ptr [Pointer to: CLRStub[VSD_LookupStub]@7ffe146001a0 (07FFE145F08C8h)]
00007FFE185BBE56 48 8B C8             mov         rcx,rax
00007FFE185BBE59 48 B8 D0 F6 93 14 FE 7F 00 00 mov         rax,7FFE1493F6D0h
00007FFE185BBE63 48 89 45 90          mov         qword ptr [rbp-70h],rax
00007FFE185BBE67 48 8D 05 16 00 00 00 lea         rax,[Z0.ClrJit.fptr(System.Reflection.MethodInfo)+094h (07FFE185BBE84h)]
00007FFE185BBE6E 48 89 45 A8          mov         qword ptr [rbp-58h],rax
00007FFE185BBE72 48 8D 45 80          lea         rax,[rbp-80h]
00007FFE185BBE76 48 89 47 10          mov         qword ptr [rdi+10h],rax
00007FFE185BBE7A C6 47 0C 00          mov         byte ptr [rdi+0Ch],0
00007FFE185BBE7E FF 15 04 3E 38 FC    call        qword ptr [7FFE1493FC88h]
00007FFE185BBE84 C6 47 0C 01          mov         byte ptr [rdi+0Ch],1
00007FFE185BBE88 83 3D 6D 9B 03 5C 00 cmp         dword ptr [g_TrapReturningThreads (07FFE745F59FCh)],0
00007FFE185BBE8F 74 06                je          Z0.ClrJit.fptr(System.Reflection.MethodInfo)+0A7h (07FFE185BBE97h)
00007FFE185BBE91 FF 15 01 B5 02 5C    call        qword ptr [hlpDynamicFuncTable+0A8h (07FFE745E7398h)]
00007FFE185BBE97 48 8B 55 88          mov         rdx,qword ptr [rbp-78h]
00007FFE185BBE9B 48 89 57 10          mov         qword ptr [rdi+10h],rdx
00007FFE185BBE9F 48 83 C4 78          add         rsp,78h
00007FFE185BBEA3 5B                   pop         rbx
00007FFE185BBEA4 5E                   pop         rsi
00007FFE185BBEA5 5F                   pop         rdi
00007FFE185BBEA6 41 5C                pop         r12
00007FFE185BBEA8 41 5D                pop         r13
00007FFE185BBEAA 41 5E                pop         r14
00007FFE185BBEAC 41 5F                pop         r15
00007FFE185BBEAE 5D                   pop         rbp
00007FFE185BBEAF C3                   ret
00007FFE185BBEB0 19 10                sbb         dword ptr [rax],edx
00007FFE185BBEB2 09 00                or          dword ptr [rax],eax
00007FFE185BBEB4 10 E2                adc         dl,ah
00007FFE185BBEB6 0C 30                or          al,30h