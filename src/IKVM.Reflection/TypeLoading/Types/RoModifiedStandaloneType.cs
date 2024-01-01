// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using IKVM.Reflection.TypeLoading;

namespace IKVM.Reflection.TypeLoading
{
    /// <summary>
    /// Standard modified types that don't have references to other types.
    /// </summary>
    internal sealed partial class RoModifiedStandaloneType : RoModifiedType
    {
        public RoModifiedStandaloneType(RoType delegatingType) : base(delegatingType) { }
    }
}
