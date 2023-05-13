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

# END
