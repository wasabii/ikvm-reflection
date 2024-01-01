using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionILGenerator : ILGenerator
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.ILGenerator wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="wrapped"></param>
        public ReflectionILGenerator(ReflectionEmitContext context, System.Reflection.Emit.ILGenerator wrapped)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        public System.Reflection.Emit.ILGenerator Wrapped => wrapped;

        /// <inheritdoc />
        public override void BeginCatchBlock(Type exceptionType) => wrapped.BeginCatchBlock(exceptionType);

        /// <inheritdoc />
        public override void BeginExceptFilterBlock() => wrapped.BeginExceptFilterBlock();

        /// <inheritdoc />
        public override Label BeginExceptionBlock() => wrapped.BeginExceptionBlock();

        /// <inheritdoc />
        public override void BeginFaultBlock() => wrapped.BeginFaultBlock();

        /// <inheritdoc />
        public override void BeginFinallyBlock() => wrapped.BeginFinallyBlock();

        /// <inheritdoc />
        public override void BeginScope() => wrapped.BeginScope();

        /// <inheritdoc />
        public override LocalBuilder DeclareLocal(Type localType, bool pinned) => new ReflectionLocalBuilder(context, wrapped.DeclareLocal(localType, pinned));

        /// <inheritdoc />
        public override LocalBuilder DeclareLocal(Type localType) => new ReflectionLocalBuilder(context, wrapped.DeclareLocal(localType));

        /// <inheritdoc />
        public override Label DefineLabel() => wrapped.DefineLabel();

        /// <inheritdoc />
        public override void Emit(OpCode opcode, LocalBuilder local)
        {
            if (local is ReflectionLocalBuilder b)
                wrapped.Emit(opcode, b.Wrapped);

            throw new ArgumentException("Emit requires a LocalBuilder derived from the Reflection provider.");
        }

        /// <inheritdoc />
        public override void Emit(OpCode opcode, Type cls) => wrapped.Emit(opcode, cls);

        /// <inheritdoc />
        public override void Emit(OpCode opcode, string str) => wrapped.Emit(opcode, str);

        /// <inheritdoc />
        public override void Emit(OpCode opcode, float arg) => wrapped.Emit(opcode, arg);

        /// <inheritdoc />
        public override void Emit(OpCode opcode, sbyte arg) => wrapped.Emit(opcode, arg);

        /// <inheritdoc />
        public override void Emit(OpCode opcode, MethodInfo meth) => wrapped.Emit(opcode, meth);

        /// <inheritdoc />
        public override void Emit(OpCode opcode, SignatureHelper signature)
        {
            if (signature is ReflectionSignatureHelper b)
                wrapped.Emit(opcode, b.Wrapped);

            throw new ArgumentException("Emit requires a SignatureHelper derived from the Reflection provider.");
        }

        /// <inheritdoc />
        public override void Emit(OpCode opcode, Label[] labels) => wrapped.Emit(opcode, labels);

        /// <inheritdoc />
        public override void Emit(OpCode opcode, FieldInfo field) => wrapped.Emit(opcode, field);

        /// <inheritdoc />
        public override void Emit(OpCode opcode, ConstructorInfo con) => wrapped.Emit(opcode, con);

        /// <inheritdoc />
        public override void Emit(OpCode opcode, long arg) => wrapped.Emit(opcode, arg);

        /// <inheritdoc />
        public override void Emit(OpCode opcode, int arg) => wrapped.Emit(opcode, arg);

        /// <inheritdoc />
        public override void Emit(OpCode opcode, short arg) => wrapped.Emit(opcode, arg);

        /// <inheritdoc />
        public override void Emit(OpCode opcode, double arg) => wrapped.Emit(opcode, arg);

        /// <inheritdoc />
        public override void Emit(OpCode opcode, byte arg) => wrapped.Emit(opcode, arg);

        /// <inheritdoc />
        public override void Emit(OpCode opcode) => wrapped.Emit(opcode);

        /// <inheritdoc />
        public override void Emit(OpCode opcode, Label label) => wrapped.Emit(opcode, label);

        /// <inheritdoc />
        public override void EmitCall(OpCode opcode, MethodInfo methodInfo, Type[]? optionalParameterTypes) => wrapped.EmitCall(opcode, methodInfo, optionalParameterTypes);

        /// <inheritdoc />
        public override void EmitCalli(OpCode opcode, CallingConvention unmanagedCallConv, Type? returnType, Type[]? parameterTypes)
        {
#if NETFRAMEWORK || NET
            wrapped.EmitCalli(opcode, unmanagedCallConv, returnType, parameterTypes);
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override void EmitCalli(OpCode opcode, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, Type[]? optionalParameterTypes)
        {
#if NETFRAMEWORK || NET
            wrapped.EmitCalli(opcode, callingConvention, returnType, parameterTypes, optionalParameterTypes);
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override void EmitWriteLine(string value) => wrapped.EmitWriteLine(value);

        /// <inheritdoc />
        public override void EmitWriteLine(FieldInfo fld) => wrapped.EmitWriteLine(fld);

        /// <inheritdoc />
        public override void EmitWriteLine(LocalBuilder localBuilder)
        {
            if (localBuilder is ReflectionLocalBuilder b)
                wrapped.EmitWriteLine(b.Wrapped);

            throw new ArgumentException("EmitWriteLine requires a LocalBuilder derived from the Reflection provider.");
        }

        /// <inheritdoc />
        public override void EndExceptionBlock() => wrapped.EndExceptionBlock();

        /// <inheritdoc />
        public override void EndScope() => wrapped.EndScope();

        /// <inheritdoc />
        public override void MarkLabel(Label loc) => wrapped.MarkLabel(loc);

        /// <inheritdoc />
        public override void ThrowException(Type excType) => wrapped.ThrowException(excType);

        /// <inheritdoc />
        public override void UsingNamespace(string usingNamespace) => wrapped.UsingNamespace(usingNamespace);

        /// <inheritdoc />
        public override string ToString() => Wrapped.ToString();

    }

}
