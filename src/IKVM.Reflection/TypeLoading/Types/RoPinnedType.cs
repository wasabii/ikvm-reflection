// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace IKVM.Reflection.TypeLoading
{
    /// <summary>
    /// This is used to represent a PinnedType. It is quite ill-behaved so the only time it is created is by the EcmaPinnedTypeProvider.
    /// It is only used to implement the MethodBody.LocalVariables property.
    /// </summary>
    internal sealed class RoPinnedType : RoWrappedType
    {
        internal RoPinnedType(RoType unmodifiedType)
            : base(unmodifiedType)
        {
        }
    }
}
