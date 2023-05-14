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

##### [Property syntax](https://learn.microsoft.com/en-us/dotnet/csharp/properties#property-syntax)

```c#
public class Person
{
    public string? FirstName { get; set; }

    public string FirstName1 { get; set; } = string.Empty;

	public string? FirstName2
    {
        get { return _firstName; }
        set { _firstName = value; }
    }
    private string? _firstName;

	public string? FirstName3
    {
        get => _firstName3;
        set => _firstName3 = value;
    }
    private string? _firstName3;

    // Omitted for brevity.
}
```

##### [Validation](https://learn.microsoft.com/en-us/dotnet/csharp/properties#validation)

* The examples above showed one of the simplest cases of property definition: a read-write property with no validation. By writing the code you want in the get and set accessors, you can create many different scenarios.
```c#
public class Person
{
    public string? FirstName
    {
        get => _firstName;
        set => _firstName = (!string.IsNullOrWhiteSpace(value)) ? value : throw new ArgumentException("First name must not be blank");
    }
    private string? _firstName;

    // Omitted for brevity.
}
```

##### [Access control](https://learn.microsoft.com/en-us/dotnet/csharp/properties#access-control)

* Up to this point, all the property definitions you have seen are read/write properties with public accessors. That's not the only valid accessibility for properties. You can create read-only properties, or give different accessibility to the set and get accessors. 
```c#
public class Person
{
    public string? FirstName { get; private set; }

    // Omitted for brevity.
}
```

##### [Read-only](https://learn.microsoft.com/en-us/dotnet/csharp/properties#read-only)

```c#
public class Person
{
    public Person(string firstName) => FirstName = firstName;

    public string FirstName { get; }

    // Omitted for brevity.
}
```

##### [Init-only](https://learn.microsoft.com/en-us/dotnet/csharp/properties#init-only)

* The preceding example requires callers to use the constructor that includes the FirstName parameter. Callers can't use object initializers to assign a value to the property. To support initializers, you can make the set accessor an init accessor, as shown in the following code:
```c#
public class Person
{
    public Person() { }
    public Person(string firstName) => FirstName = firstName;

    public string? FirstName { get; init; }

    // Omitted for brevity.
}
```
* The preceding example allows a caller to create a Person using the default constructor, even when that code doesn't set the FirstName property. Beginning in C# 11, you can require callers to set that property:
```c#
public class Person
{
    public Person() { }

    [SetsRequiredMembers]
    public Person(string firstName) => FirstName = firstName;

    public required string FirstName { get; init; }

    // Omitted for brevity.
}

var person = new VersionNinePoint2.Person("John");
person = new VersionNinePoint2.Person{ FirstName = "John"};
// Error CS9035: Required member `Person.FirstName` must be set:
//person = new VersionNinePoint2.Person();
```

##### [Computed properties](https://learn.microsoft.com/en-us/dotnet/csharp/properties#computed-properties)

* You can also use an expression-bodied member, which provides a more succinct way to create the computed FullName property:
```c#
public class Person
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}
```

##### [Cached evaluated properties](https://learn.microsoft.com/en-us/dotnet/csharp/properties#cached-evaluated-properties)

* You can mix the concept of a computed property with storage and create a cached evaluated property. For example, you could update the FullName property so that the string formatting only happened the first time it was accessed:
```c#
public class Person
{
    private string? _firstName;
    public string? FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            _fullName = null;
        }
    }

    private string? _lastName;
    public string? LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            _fullName = null;
        }
    }

    private string? _fullName;
    public string FullName
    {
        get
        {
            if (_fullName is null)
                _fullName = $"{FirstName} {LastName}";
            return _fullName;
        }
    }
}
```
* This final version evaluates the `FullName` property only when needed. If the previously calculated version is valid, it's used. If another state change invalidates the previously calculated version, it will be recalculated. `Developers that use this class don't need to know the details of the implementation. None of these internal changes affect the use of the Person object. That's the key reason for using Properties to expose data members of an object.`

##### [Attaching attributes to auto-implemented properties](https://learn.microsoft.com/en-us/dotnet/csharp/properties#attaching-attributes-to-auto-implemented-properties)

* Field attributes can be attached to the compiler generated backing field in auto-implemented properties. For example, consider a revision to the `Person` class that adds a unique integer `Id` property. You write the `Id` property using an auto-implemented property, but your design doesn't call for persisting the `Id` property. The [NonSerializedAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.nonserializedattribute) can only be attached to fields, not properties. You can attach the NonSerializedAttribute to the backing field for the Id property by using the `field:` specifier on the attribute, as shown in the following example:
```c#
public class Person
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [field:NonSerialized]
    public int Id { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}
```

##### [Implementing INotifyPropertyChanged](https://learn.microsoft.com/en-us/dotnet/csharp/properties#implementing-inotifypropertychanged)

* A final scenario where you need to write code in a property accessor is to support the [INotifyPropertyChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged) interface used to notify data binding clients that a value has changed. When the value of a property changes, the object raises the [INotifyPropertyChanged.PropertyChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged.propertychanged) event to indicate the change. The data binding libraries, in turn, update display elements based on that change. The code below shows how you would implement `INotifyPropertyChanged` for the `FirstName` property of this person class.
```c#
public class Person : INotifyPropertyChanged
{
    public string? FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("First name must not be blank");
            if (value != _firstName)
            {
                _firstName = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }
    }
    private string? _firstName;

    public event PropertyChangedEventHandler? PropertyChanged;
}
```
* The `?.` operator is called the null conditional operator. It checks for a null reference before evaluating the right side of the operator. The end result is that if there are no subscribers to the `PropertyChanged` event, the code to raise the event doesn't execute. It would throw a `NullReferenceException` without this check in that case. For more information, see [events](https://learn.microsoft.com/en-us/dotnet/csharp/events-overview). This example also uses the new `nameof` operator to convert from the property name symbol to its text representation. Using `nameof` can reduce errors where you've mistyped the name of the property.

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
