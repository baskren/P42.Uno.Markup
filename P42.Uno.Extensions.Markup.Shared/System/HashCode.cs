using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

#nullable enable
namespace System;

internal struct HashCode
{
    private const uint Prime1 = 2654435761;
    private const uint Prime2 = 2246822519;
    private const uint Prime3 = 3266489917;
    private const uint Prime4 = 668265263;
    private const uint Prime5 = 374761393;
    private static readonly uint seed = GenerateGlobalSeed();
    private uint v1;
    private uint v2;
    private uint v3;
    private uint v4;
    private uint queue1;
    private uint queue2;
    private uint queue3;
    private uint length;

    private static uint GenerateGlobalSeed()
    {
        byte[] data = new byte[4];
        RandomNumberGenerator.Create().GetBytes(data);
        return BitConverter.ToUInt32(data, 0);
    }

    public void Add<T>(T value)
        => Add(value?.GetHashCode() ?? 0);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Initialize(out uint v1, out uint v2, out uint v3, out uint v4)
    {
        v1 = (uint)((int)seed - 1640531535 - 2048144777);
        v2 = seed + Prime2;
        v3 = seed;
        v4 = seed - Prime1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint Round(uint hash, uint input)
        => RotateLeft(hash + input * Prime2, 13) * Prime1;
    

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint QueueRound(uint hash, uint queuedValue)
        => RotateLeft(hash + queuedValue * Prime3, 17) * Prime4;
    

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint MixState(uint v1, uint v2, uint v3, uint v4)
        => RotateLeft(v1, 1) + RotateLeft(v2, 7) + RotateLeft(v3, 12) + RotateLeft(v4, 18);
    

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint MixEmptyState() 
        => seed + Prime5;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint MixFinal(uint hash)
    {
        hash ^= hash >> 15;
        hash *= Prime2;
        hash ^= hash >> 13;
        hash *= Prime3;
        hash ^= hash >> 16 /*0x10*/;
        return hash;
    }

    private void Add(int value)
    {
        uint num = length++;
        switch (num % 4u)
        {
            case 0u:
                queue1 = (uint)value;
                return;
            case 1u:
                queue2 = (uint)value;
                return;
            case 2u:
                queue3 = (uint)value;
                return;
        }
        if (num == 3)
            Initialize(out v1, out v2, out v3, out v4);

        v1 = Round(v1, queue1);
        v2 = Round(v2, queue2);
        v3 = Round(v3, queue3);
        v4 = Round(v4, (uint)value);
    }

    public int ToHashCode()
    {
        uint length = this.length;
        uint num = length % 4U;
        uint hash = 
            (length < 4U 
                ? MixEmptyState() 
                : MixState(v1, v2, v3, v4)
            ) + length * 4U;

        if (num > 0U)
        {
            hash = QueueRound(hash, queue1);
            if (num > 1U)
            {
                hash = QueueRound(hash, queue2);
                if (num > 2U)
                    hash = QueueRound(hash, queue3);
            }
        }
        return (int)MixFinal(hash);
    }

    [Obsolete("HashCode is a mutable struct and should not be compared with other HashCodes. Use ToHashCode to retrieve the computed hash code.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode()
        => throw new NotSupportedException();

    [Obsolete("HashCode is a mutable struct and should not be compared with other HashCodes.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) 
        => throw new NotSupportedException();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint RotateLeft(uint value, int offset)
        => (value << offset) | (value >> 32 - offset);
    
}
