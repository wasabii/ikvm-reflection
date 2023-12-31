// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;

namespace IKVM.Reflection.TypeLoading
{
    /// <summary>
    /// Base type for RoPinnedType. These types are very ill-behaved so they are only produced in very specific circumstances
    /// and quickly peeled away once their usefulness has ended.
    /// </summary>
    internal abstract class RoWrappedType : RoStubType
    {
        internal RoWrappedType(RoType unmodifiedType)
        {
            Debug.Assert(unmodifiedType != null);
            UnmodifiedType = unmodifiedType;
        }

        internal RoType UnmodifiedType { get; }
    }
}
