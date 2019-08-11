#if !DEBUG
#pragma warning disable 67
#endif

//#define TEST
#define VERIFY

using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

#region Possible Targets
#pragma warning disable 67

[assembly: MyAttr(1)]         // Applied to assembly
[module: MyAttr(2)]           // Applied to module
#endregion

public static class Program
{
    public static void Main()
    {
        //DetectingAttributes.Go();
        //MatchingAttributes.Go();
        ConditionalAttributeDemo.Go();
    }

    [Serializable]
    [DefaultMemberAttribute("Main")]
    [SomeAttribute("Al", 12, new Type[] { typeof(int) })]
    [DebuggerDisplayAttribute("Richter", Name = "Jeff", Target = typeof(DetectingAttributes))]
    public sealed class DetectingAttributes
    {
        [Conditional("Debug")]
        [Conditional("Release")]
        public void DoSomething() { }

        public DetectingAttributes()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [STAThread]
        public static void Go()
        {
            Go(ShowAttributes);
            Go(ShowAttributesReflectionOnly);
        }

        private static void Go(Action<MemberInfo> showAttributes)
        {
            // Show the set of attributes applied to this type
            showAttributes(typeof(DetectingAttributes));

            // Get the set of methods associated with the type
            var members =
               from m in typeof(DetectingAttributes).GetTypeInfo().DeclaredMembers.OfType<MethodBase>()
               where m.IsPublic
               select m;

            foreach (MemberInfo member in members)
            {
                // Show the set of attributes applied to this member
                showAttributes(member);
            }
        }

        private static void ShowAttributes(MemberInfo attributeTarget)
        {
            var attributes = attributeTarget.GetCustomAttributes<Attribute>();

            Console.WriteLine("Attributes applied to {0}: {1}",
               attributeTarget.Name, (attributes.Count() == 0 ? "None" : String.Empty));

            foreach (Attribute attribute in attributes)
            {
                // Display the type of each applied attribute
                Console.WriteLine("  {0}", attribute.GetType().ToString());

                if (attribute is DefaultMemberAttribute)
                    Console.WriteLine("    MemberName={0}",
                       ((DefaultMemberAttribute)attribute).MemberName);

                if (attribute is ConditionalAttribute)
                    Console.WriteLine("    ConditionString={0}",
                       ((ConditionalAttribute)attribute).ConditionString);

                if (attribute is CLSCompliantAttribute)
                    Console.WriteLine("    IsCompliant={0}",
                       ((CLSCompliantAttribute)attribute).IsCompliant);

                DebuggerDisplayAttribute dda = attribute as DebuggerDisplayAttribute;
                if (dda != null)
                {
                    Console.WriteLine("    Value={0}, Name={1}, Target={2}",
                       dda.Value, dda.Name, dda.Target);
                }
            }
            Console.WriteLine();
        }

        private static void ShowAttributesReflectionOnly(MemberInfo attributeTarget)
        {
            IList<CustomAttributeData> attributes =
               CustomAttributeData.GetCustomAttributes(attributeTarget);

            Console.WriteLine("Attributes applied to {0}: {1}",
               attributeTarget.Name, (attributes.Count == 0 ? "None" : String.Empty));

            foreach (CustomAttributeData attribute in attributes)
            {
                // Display the type of each applied attribute
                Type t = attribute.Constructor.DeclaringType;
                Console.WriteLine("  {0}", t.ToString());
                Console.WriteLine("    Constructor called={0}", attribute.Constructor);

                IList<CustomAttributeTypedArgument> posArgs = attribute.ConstructorArguments;
                Console.WriteLine("    Positional arguments passed to constructor:" +
                   ((posArgs.Count == 0) ? " None" : String.Empty));
                foreach (CustomAttributeTypedArgument pa in posArgs)
                {
                    Console.WriteLine("      Type={0}, Value={1}", pa.ArgumentType, pa.Value);
                }


                IList<CustomAttributeNamedArgument> namedArgs = attribute.NamedArguments;
                Console.WriteLine("    Named arguments set after construction:" +
                   ((namedArgs.Count == 0) ? " None" : String.Empty));
                foreach (CustomAttributeNamedArgument na in namedArgs)
                {
                    Console.WriteLine("     Name={0}, Type={1}, Value={2}",
                       na.MemberInfo.Name, na.TypedValue.ArgumentType, na.TypedValue.Value);
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
