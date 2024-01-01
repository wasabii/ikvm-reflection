using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace IKVM.Reflection.Emit
{

    public abstract class ILGenerator
    {

        public abstract void UsingNamespace(string usingNamespace);

        public abstract LocalBuilder DeclareLocal(Type localType, bool pinned);

        public abstract LocalBuilder DeclareLocal(Type localType);

        public abstract Label DefineLabel();

        public abstract void MarkLabel(Label loc);

        public abstract void BeginCatchBlock(Type exceptionType);

        public abstract void BeginExceptFilterBlock();

        public abstract Label BeginExceptionBlock();

        public abstract void BeginFaultBlock();

        public abstract void BeginFinallyBlock();

        public abstract void EndExceptionBlock();

        public abstract void ThrowException(Type excType);

        public abstract void BeginScope();

        public abstract void EndScope();

        public abstract void Emit(OpCode opcode, LocalBuilder local);

        public abstract void Emit(OpCode opcode, Type cls);

        public abstract void Emit(OpCode opcode, string str);

        public abstract void Emit(OpCode opcode, float arg);

        public abstract void Emit(OpCode opcode, sbyte arg);

        public abstract void Emit(OpCode opcode, MethodInfo meth);

        public abstract void Emit(OpCode opcode, SignatureHelper signature);

        public abstract void Emit(OpCode opcode, Label[] labels);

        public abstract void Emit(OpCode opcode, FieldInfo field);

        public abstract void Emit(OpCode opcode, ConstructorInfo con);

        public abstract void Emit(OpCode opcode, long arg);

        public abstract void Emit(OpCode opcode, int arg);

        public abstract void Emit(OpCode opcode, short arg);

        public abstract void Emit(OpCode opcode, double arg);

        public abstract void Emit(OpCode opcode, byte arg);

        public abstract void Emit(OpCode opcode);

        public abstract void Emit(OpCode opcode, Label label);

        public abstract void EmitCall(OpCode opcode, MethodInfo methodInfo, Type[]? optionalParameterTypes);

#if NETFRAMEWORK || NET

        public abstract void EmitCalli(OpCode opcode, CallingConvention unmanagedCallConv, Type? returnType, Type[]? parameterTypes);

        public abstract void EmitCalli(OpCode opcode, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, Type[]? optionalParameterTypes);

#endif

        public abstract void EmitWriteLine(string value);

        public abstract void EmitWriteLine(FieldInfo fld);

        public abstract void EmitWriteLine(LocalBuilder localBuilder);

    }

}
