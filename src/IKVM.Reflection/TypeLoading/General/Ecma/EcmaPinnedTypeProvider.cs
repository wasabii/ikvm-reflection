// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using IKVM.Reflection.TypeLoading.Ecma;

namespace IKVM.Reflection.TypeLoading.Ecma
{
    // This type provider is used to parse local variable signatures (which can have the PINNED constraint.)
    internal sealed class EcmaPinnedTypeProvider : EcmaWrappedTypeProvider
    {
        internal EcmaPinnedTypeProvider(EcmaModule module)
            : base(module)
        {
        }

        public sealed override RoType GetModifiedType(RoType modifier, RoType unmodifiedType, bool isRequired) => unmodifiedType;
        public sealed override RoType GetPinnedType(RoType elementType) => new RoPinnedType(elementType);
    }
}
