using System.Reflection.Emit;

namespace IKVM.Reflection.Emit
{

    public abstract class EventBuilder
    {

        public abstract void AddOtherMethod(MethodBuilder mdBuilder);

        public abstract void SetAddOnMethod(MethodBuilder mdBuilder);

        public abstract void SetCustomAttribute(CustomAttributeBuilder customBuilder);

        public abstract void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute);

        public abstract void SetRaiseMethod(MethodBuilder mdBuilder);

        public abstract void SetRemoveOnMethod(MethodBuilder mdBuilder);

    }

}
