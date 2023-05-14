# 学习笔记之.NET

## .NET

* [.NET documentation | Microsoft Learn](https://learn.microsoft.com/en-gb/dotnet/)
	* Learn to use .NET to create applications on any platform using C#, F#, and Visual Basic. Browse API reference, sample code, tutorials, and more.
* [.NET fundamentals documentation](https://learn.microsoft.com/en-us/dotnet/fundamentals/)
	* Learn the fundamentals of .NET, an open-source developer platform for building many different types of applications.
* [Framework Design Guidelines | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/)

## C#

* [C# docs - get started, tutorials, reference. | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/)
* [C# Programming Guide | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/?redirectedfrom=MSDN)
* [C# 教程 | 菜鸟教程](https://www.runoob.com/csharp/csharp-tutorial.html)
* [菜鸟教程在线编辑器](https://www.runoob.com/try/runcode.php?filename=string_substr1&type=cs)

#
* [学习笔记之C# / .NET Core 2.0 - 浩然119 - 博客园](https://www.cnblogs.com/pegasus923/p/8621309.html)

### Resources

* [C# Tutorial - Full Course for Beginners - YouTube](https://www.youtube.com/watch?v=GhQdlIFylQ8&list=WL&index=7)

### CONCEPT

#### [Properties in C#](https://learn.microsoft.com/en-us/dotnet/csharp/properties)

* Properties are first class citizens in C#. The language defines syntax that enables developers to write code that accurately expresses their design intent.
* Properties behave like fields when they're accessed. However, unlike fields, properties are implemented with accessors that define the statements executed when a property is accessed or assigned.

### [C# Programming Guide | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/?redirectedfrom=MSDN)

### [C# reference | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)

### FAQ

#### ERROR FIX

* Compiler Error CS0106: The modifier `public' is not valid for this item
    * [Compiler Error CS0106 | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs0106?f1url=%3FappId%3Droslyn%26k%3Dk(CS0106))
        * The modifier 'modifier' is not valid for this item
        * A class or interface member was marked with an invalid access modifier. 
    * In C#, you cannot define static variables in a class member function directly. Static variables must be defined at the class level, outside of any member function. 
```c#
public class MyClass {
    private static int count = 0;

    public void MyMethod() {
        // Use the static variable
        count++;
    }
}
```

* [Compiler Error CS0120 | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs0120?f1url=%3FappId%3Droslyn%26k%3Dk(CS0120))
    * An object reference is required for the nonstatic field, method, or property 'member'
    * In order to use a non-static field, method, or property, you must first create an object instance. For more information about static methods, see Static Classes and Static Class Members. For more information about creating instances of classes, see Instance Constructors.
    * To correct this error, first create an instance of the class
    * To correct this error, you could also add the keyword static to the method definition
    * In this code, the Foo() method is an instance method that references the non-static field x. However, the Bar() method is a static method that tries to call the Foo() method, which is not possible because Foo() is an instance method and requires an instance of the MyClass class to be called.
    ```c#
    class MyClass
    {
        public int x = 0;
        public void Foo()
        {
            Console.WriteLine(x);
        }

        public static void Bar()
        {
            Foo(); // This line will generate CS0120 error
        }
    }
    ```
	* To fix this error, you can either make the non-static member static, or create an instance of the class to call the non-static member. Here are two possible solutions:
    	* Solution 1: Make the Foo() method static:
        ```c#
        class MyClass
        {
            public static int x = 0;
            public static void Foo()
            {
                Console.WriteLine(x);
            }

            public static void Bar()
            {
                Foo(); // This line will work now
            }
        }
        ```
        * Solution 2: Create an instance of the class to call the Foo() method:
        ```c#
        class MyClass
        {
            public int x = 0;
            public void Foo()
            {
                Console.WriteLine(x);
            }

            public static void Bar()
            {
                MyClass obj = new MyClass();
                obj.Foo(); // This line will work now
            }
        }
        ```

# END
