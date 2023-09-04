# 学习笔记之.NET

## .NET

* [.NET documentation | Microsoft Learn](https://learn.microsoft.com/en-gb/dotnet/)
	* Learn to use .NET to create applications on any platform using C#, F#, and Visual Basic. Browse API reference, sample code, tutorials, and more.
* [.NET fundamentals documentation](https://learn.microsoft.com/en-us/dotnet/fundamentals/)
	* Learn the fundamentals of .NET, an open-source developer platform for building many different types of applications.
* [Framework Design Guidelines | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/)

### [.NET API browser](https://learn.microsoft.com/en-us/dotnet/api/)

#### [System Namespace](https://learn.microsoft.com/en-us/dotnet/api/system?view=netframework-4.8.1)

##### [Environment Class](https://learn.microsoft.com/en-us/dotnet/api/system.environment?view=netframework-4.8.1)

* How to exit program ?
    * In C#, you can use the Environment.Exit method to terminate your application and specify an exit code. Here's an example:
    * `Environment.Exit(0);`
    * In this example, 0 is the exit code. By convention, an exit code of 0 indicates that the program terminated successfully, while any other value (usually a positive integer) indicates an error or abnormal termination.
    * The Environment.Exit method terminates the process immediately, which means that finally blocks and destructors for existing objects are not executed. This can result in resources not being released properly, so it should generally be used sparingly. It's usually better to allow your application to terminate naturally by letting execution reach the end of the Main method or by closing the application's main window.
    * If you're writing a console application and want to specify an exit code, you can also do so by changing your Main method to return an int, like this:
    ```c#
    static int Main()
    {
        // ... your code here ...

        return 0;
    }
    ```
    * In this example, when execution reaches the end of the Main method, the application terminates and the return value of Main is used as the exit code.

##### String Class

###### [String.Substring Method](https://learn.microsoft.com/en-us/dotnet/api/system.string.substring?view=net-7.0)

* Retrieves a substring from this instance.
* This member is overloaded. For complete information about this member, including syntax, usage, and examples, click a name in the overload list.
* Overloads
    * [Substring(Int32)](https://learn.microsoft.com/en-us/dotnet/api/system.string.substring?view=net-7.0#system-string-substring(system-int32))
        * Retrieves a substring from this instance. The substring starts at a specified character position and continues to the end of the string.
    * [Substring(Int32, Int32)](https://learn.microsoft.com/en-us/dotnet/api/system.string.substring?view=net-7.0#system-string-substring(system-int32-system-int32))
        * Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.

#
MISC

* C# Substring ?
    * In C#, the `Substring` method is used to retrieve a substring from a string. It's a method of the `string` class.
    * Here's how you can use it:
        * 1. Substring(int startIndex):
            * This method returns a substring that begins at a specified character position and includes all subsequent characters.
            ```c#
            string text = "Hello World";
            string sub = text.Substring(6);  // Outputs: "World"
            Console.WriteLine(sub);
            ```
        * 2. Substring(int startIndex, int length):
            * This method returns a substring that begins at a specified character position and has a specified length.
            ```c#
            string text = "Hello World";
            string sub = text.Substring(0, 5);  // Outputs: "Hello"
            Console.WriteLine(sub);
            ```
    * Things to consider:
        * If startIndex is equal to the length of the string instance, the method returns an empty string.
        * If startIndex or length is outside the range of valid indices for the current string, the method will throw an ArgumentOutOfRangeException.
        * The index is zero-based, so the first character in the string is at index 0, the second at index 1, and so on.
    * Always ensure that the provided indices are valid for the given string to avoid runtime exceptions.
* C# split string "ABCDEF" into "ABC" and "DEF" and convert them with func foo(string) and then combine them to string and return ?
```c#
using System;

namespace StringManipulation
{
    class Program
    {
        static string foo(string str)
        {
            // Your transformation logic here
            return str.ToLower();  // Example transformation
        }

        static string TransformAndCombine(string input)
        {
            if (input.Length != 6) // Validate length, adjust as needed
            {
                return "Invalid input";
            }

            string part1 = input.Substring(0, 3); // Split into "ABC"
            string part2 = input.Substring(3, 3); // Split into "DEF"

            string transformedPart1 = foo(part1); // Transform "ABC"
            string transformedPart2 = foo(part2); // Transform "DEF"

            return transformedPart1 + transformedPart2; // Combine and return
        }

        static void Main(string[] args)
        {
            string input = "ABCDEF";
            string result = TransformAndCombine(input);
            Console.WriteLine($"Transformed and Combined: {result}");
        }
    }
}
```

#### [System.Collections Namespace](https://learn.microsoft.com/en-us/dotnet/api/system.collections?view=net-7.0)

* Contains interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries.

##### MISC

* C# ToList vs ToArray ?
    * In C#, both ToList() and ToArray() are extension methods provided by the LINQ framework to convert collections into a List<T> or an T[] array, respectively. The choice between the two largely depends on the specific requirements of your application and how you intend to use the resulting collection.
    * Here are some considerations to help you decide between ToList() and ToArray():
        * Mutability:
            * ToList(): Returns a List<T>, which is a dynamic data structure. You can add, remove, or modify items after conversion.
            * ToArray(): Returns a fixed-size array. Once the size is set, you can't add or remove items, though you can change the values of existing items.
        * Performance:
            * ToList(): In general, accessing an item in a list by index (e.g., list[5]) is an O(1) operation, just like arrays. However, adding items can occasionally incur overhead if the list needs to resize.
            * ToArray(): Arrays generally have slightly better cache locality due to their contiguous memory nature, which can lead to better performance in certain scenarios.
        * Memory Overhead:
            * ToList(): A List<T> internally uses an array to manage its elements. However, this array often has a capacity larger than the current count of elements to accommodate future additions without frequent reallocations. This can lead to some memory overhead.
            * ToArray(): Arrays are of fixed size, so there's no additional memory allocated beyond what's needed for the elements it contains.
        * API Compatibility:
            * ToList(): Many APIs, especially older ones, accept IList<T> or List<T> as parameters.
            * ToArray(): Some APIs might specifically require arrays.
        * Intended Usage:
            * ToList(): If you plan to modify (add/remove) the collection after the conversion frequently, List<T> is preferable.
            * ToArray(): If you're creating a collection that should remain fixed in size after creation or you're interfacing with APIs that work better with arrays, then T[] is preferable.
        * Semantics:
            * ToList(): Indicates intent that the data might be modified or that a dynamic data structure is preferable.
            * ToArray(): Indicates intent that the data should be seen as a fixed set or sequence.
    * In general, if you're unsure which to use and don't have a specific need for the features of a List<T>, then ToArray() is a good default choice due to its simpler semantics and potentially better performance characteristics in certain scenarios. However, if you need a flexible, mutable data structure, then ToList() is the way to go.

#### [System.Collections.Generic Namespace](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-7.0)

* Contains interfaces and classes that define generic collections, which allow users to create strongly typed collections that provide better type safety and performance than non-generic strongly typed collections.

##### [`Dictionary<TKey,TValue> Class`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-7.0)

* Examples
    * The following code example creates an empty Dictionary<TKey,TValue> of strings with string keys and uses the Add method to add some elements. The example demonstrates that the Add method throws an ArgumentException when attempting to add a duplicate key.
    * The example uses the Item[] property (the indexer in C#) to retrieve values, demonstrating that a KeyNotFoundException is thrown when a requested key is not present, and showing that the value associated with a key can be replaced.
    * The example shows how to use the TryGetValue method as a more efficient way to retrieve values if a program often must try key values that are not in the dictionary, and it shows how to use the ContainsKey method to test whether a key exists before calling the Add method.
    * The example shows how to enumerate the keys and values in the dictionary and how to enumerate the keys and values alone using the Keys property and the Values property.
    * Finally, the example demonstrates the Remove method.
```c#
// Create a new dictionary of strings, with string keys.
//
Dictionary<string, string> openWith =
    new Dictionary<string, string>();

// Add some elements to the dictionary. There are no
// duplicate keys, but some of the values are duplicates.
openWith.Add("txt", "notepad.exe");
openWith.Add("bmp", "paint.exe");
openWith.Add("dib", "paint.exe");
openWith.Add("rtf", "wordpad.exe");

// The Add method throws an exception if the new key is
// already in the dictionary.
try
{
    openWith.Add("txt", "winword.exe");
}
catch (ArgumentException)
{
    Console.WriteLine("An element with Key = \"txt\" already exists.");
}

// The Item property is another name for the indexer, so you
// can omit its name when accessing elements.
Console.WriteLine("For key = \"rtf\", value = {0}.",
    openWith["rtf"]);

// The indexer can be used to change the value associated
// with a key.
openWith["rtf"] = "winword.exe";
Console.WriteLine("For key = \"rtf\", value = {0}.",
    openWith["rtf"]);

// If a key does not exist, setting the indexer for that key
// adds a new key/value pair.
openWith["doc"] = "winword.exe";

// The indexer throws an exception if the requested key is
// not in the dictionary.
try
{
    Console.WriteLine("For key = \"tif\", value = {0}.",
        openWith["tif"]);
}
catch (KeyNotFoundException)
{
    Console.WriteLine("Key = \"tif\" is not found.");
}

// When a program often has to try keys that turn out not to
// be in the dictionary, TryGetValue can be a more efficient
// way to retrieve values.
string value = "";
if (openWith.TryGetValue("tif", out value))
{
    Console.WriteLine("For key = \"tif\", value = {0}.", value);
}
else
{
    Console.WriteLine("Key = \"tif\" is not found.");
}

// ContainsKey can be used to test keys before inserting
// them.
if (!openWith.ContainsKey("ht"))
{
    openWith.Add("ht", "hypertrm.exe");
    Console.WriteLine("Value added for key = \"ht\": {0}",
        openWith["ht"]);
}

// When you use foreach to enumerate dictionary elements,
// the elements are retrieved as KeyValuePair objects.
Console.WriteLine();
foreach( KeyValuePair<string, string> kvp in openWith )
{
    Console.WriteLine("Key = {0}, Value = {1}",
        kvp.Key, kvp.Value);
}

// To get the values alone, use the Values property.
Dictionary<string, string>.ValueCollection valueColl =
    openWith.Values;

// The elements of the ValueCollection are strongly typed
// with the type that was specified for dictionary values.
Console.WriteLine();
foreach( string s in valueColl )
{
    Console.WriteLine("Value = {0}", s);
}

// To get the keys alone, use the Keys property.
Dictionary<string, string>.KeyCollection keyColl =
    openWith.Keys;

// The elements of the KeyCollection are strongly typed
// with the type that was specified for dictionary keys.
Console.WriteLine();
foreach( string s in keyColl )
{
    Console.WriteLine("Key = {0}", s);
}

// Use the Remove method to remove a key/value pair.
Console.WriteLine("\nRemove(\"doc\")");
openWith.Remove("doc");

if (!openWith.ContainsKey("doc"))
{
    Console.WriteLine("Key \"doc\" is not found.");
}

/* This code example produces the following output:

An element with Key = "txt" already exists.
For key = "rtf", value = wordpad.exe.
For key = "rtf", value = winword.exe.
Key = "tif" is not found.
Key = "tif" is not found.
Value added for key = "ht": hypertrm.exe

Key = txt, Value = notepad.exe
Key = bmp, Value = paint.exe
Key = dib, Value = paint.exe
Key = rtf, Value = winword.exe
Key = doc, Value = winword.exe
Key = ht, Value = hypertrm.exe

Value = notepad.exe
Value = paint.exe
Value = paint.exe
Value = winword.exe
Value = winword.exe
Value = hypertrm.exe

Key = txt
Key = bmp
Key = dib
Key = rtf
Key = doc
Key = ht

Remove("doc")
Key "doc" is not found.
*/
```

#### [System.Linq Namespace](https://learn.microsoft.com/en-us/dotnet/api/system.linq?view=net-7.0)

##### [Queryable Class](https://learn.microsoft.com/en-us/dotnet/api/system.linq.queryable?view=net-7.0)

###### [Queryable.Select Method](https://learn.microsoft.com/en-us/dotnet/api/system.linq.queryable.select?view=net-7.0)

* Projects each element of a sequence into a new form.
* Overloads
    * `Select<TSource,TResult>(IQueryable<TSource>, Expression<Func<TSource,Int32,TResult>>)`
    	* Projects each element of a sequence into a new form by incorporating the element's index.
    * `Select<TSource,TResult>(IQueryable<TSource>, Expression<Func<TSource,TResult>>)`
        * Projects each element of a sequence into a new form.
* `Select<TSource,TResult>(IQueryable<TSource>, Expression<Func<TSource,TResult>>)`
```c#
List<int> range =
    new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Project the square of each int value.
IEnumerable<int> squares =
    range.AsQueryable().Select(x => x * x);

foreach (int num in squares)
    Console.WriteLine(num);

/*
    This code produces the following output:

    1
    4
    9
    16
    25
    36
    49
    64
    81
    100
*/
```

#
MISC

* C# LINQ Select ?
    * In C#, the LINQ (Language Integrated Query) Select method is used to project each element of a sequence into a new form. Essentially, it allows you to transform the items in a collection.
    * Here are some examples:
    * Basic Select Example
        * Transforming an array of integers by squaring each integer:
        ```c#
        using System;
        using System.Linq;
        
        class Program
        {
            static void Main()
            {
                int[] numbers = { 1, 2, 3, 4, 5 };
                var squared = numbers.Select(x => x * x).ToArray();
        
                foreach (var num in squared)
                {
                    Console.WriteLine(num);
                }
            }
        }
        // Output: 1 4 9 16 25
        ```
    * Select With Index
        * The Select method can also use an overload that includes the index of the source element:
        ```c#
        var items = new string[] { "apple", "banana", "mango", "orange" };
        
        var result = items.Select((item, index) => new { Index = index, Value = item.ToUpper() });
        
        foreach (var item in result)
        {
            Console.WriteLine($"Item={item.Value}, Index={item.Index}");
        }
        ```
    * Transforming into a Different Type
        * You can also transform the elements into a different type:
        ```c#
        class Person
        {
            public string Name { get; set; }
        }
        
        var people = new List<Person>
        {
            new Person { Name = "Alice" },
            new Person { Name = "Bob" }
        };
        
        var names = people.Select(person => person.Name).ToList();
        ```
    * Chaining Operations
        * You can chain Select with other LINQ methods for more complex operations:
        ```c#
        var numbers = new[] { 1, 2, 3, 4, 5 };
        var evenSquares = numbers.Where(x => x % 2 == 0).Select(x => x * x);
        ```
    * The Select method is extremely versatile and one of the most commonly used LINQ methods in C#. It works not only on arrays but also on any type that implements IEnumerable.
* C# LINQ Select with function name as parameter only ?
    * If you want to use a function name as a parameter in a LINQ Select statement, you can pass it directly if its signature matches the expected delegate for the Select method. Here's a simple example to demonstrate this:
    * Define a function that matches the expected delegate:
        * For a list of strings, the function should take a string as a parameter and return a value. Let's define a function that returns the length of each string:
        ```c#
        public static int GetLength(string s)
        {
            return s.Length;
        }
        ```
    * Use the function with LINQ:
        * Now, you can use the GetLength function directly in the Select statement without wrapping it in a lambda expression:
        ```c#
        List<string> words = new List<string> { "apple", "banana", "cherry" };
        
        var lengths = words.Select(GetLength);
        
        foreach (var length in lengths)
        {
            Console.WriteLine(length);
        }
        
        // This will output:
        5
        6
        6
        ```
    * Note that the GetLength function matches the expected delegate of the Select method for a list of strings (i.e., a function that takes a string and returns an int). If you have another type of list (e.g., a list of integers), you would need a function that matches the appropriate delegate for that list.
* C# convert element in HashSet with function foo(string) and assign it to a new HashSet ?
    * In C#, you can use LINQ to transform the elements in a `HashSet<string>` using a function and assign it to a new `HashSet<string>`. Here's an example that demonstrates this:
    ```c#
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace HashSetTransformExample
    {
        class Program
        {
            static string Foo(string input)
            {
                // Your transformation logic here.
                return input.ToUpper();
            }
    
            static void Main(string[] args)
            {
                // Initialize the original HashSet.
                HashSet<string> originalHashSet = new HashSet<string> { "apple", "banana", "cherry" };
    
                // Transform the HashSet using Foo and create a new HashSet with the results.
                HashSet<string> transformedHashSet = new HashSet<string>(originalHashSet.Select(Foo));
    
                // Output the original and transformed HashSets to verify.
                Console.WriteLine("Original HashSet:");
                foreach (var item in originalHashSet)
                {
                    Console.WriteLine(item);
                }
    
                Console.WriteLine("\nTransformed HashSet:");
                foreach (var item in transformedHashSet)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
    ```
    * In this example, the function Foo takes a string and returns it in uppercase. The `HashSet<string> originalHashSet` is transformed using Foo, and the result is stored in `HashSet<string> transformedHashSet`. We use LINQ's `Select` method to apply the function to each element in the original set.

#### [System.Text Namespace](https://learn.microsoft.com/en-us/dotnet/api/system.text?view=net-7.0)

* Contains classes that represent ASCII and Unicode character encodings; abstract base classes for converting blocks of characters to and from blocks of bytes; and a helper class that manipulates and formats String objects without creating intermediate instances of String.

##### [StringBuilder Class](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-7.0)

* The following example shows how to call many of the methods defined by the StringBuilder class.
```c#
using System;
using System.Text;

public sealed class App
{
    static void Main()
    {
        // Create a StringBuilder that expects to hold 50 characters.
        // Initialize the StringBuilder with "ABC".
        StringBuilder sb = new StringBuilder("ABC", 50);

        // Append three characters (D, E, and F) to the end of the StringBuilder.
        sb.Append(new char[] { 'D', 'E', 'F' });

        // Append a format string to the end of the StringBuilder.
        sb.AppendFormat("GHI{0}{1}", 'J', 'k');

        // Display the number of characters in the StringBuilder and its string.
        Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());

        // Insert a string at the beginning of the StringBuilder.
        sb.Insert(0, "Alphabet: ");

        // Replace all lowercase k's with uppercase K's.
        sb.Replace('k', 'K');

        // Display the number of characters in the StringBuilder and its string.
        Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());
    }
}

// This code produces the following output.
//
// 11 chars: ABCDEFGHIJk
// 21 chars: Alphabet: ABCDEFGHIJK
```

###### MISC

* C# combine two string into one efficiently ?
    * In C#, there are multiple ways to combine two strings. The most straightforward methods involve using the + operator or the string.Concat method. Both are efficient, but in scenarios where you're concatenating many strings in a loop, it's more efficient to use StringBuilder.
    * Here's a quick overview of each method:
    * Using `+` Operator:
    ```c#
    string str1 = "Hello";
    string str2 = "World";
    string result = str1 + " " + str2;
    Console.WriteLine(result); // Outputs: Hello World
    ```
    * Using `string.Concat`:
    ```c#
    string str1 = "Hello";
    string str2 = "World";
    string result = string.Concat(str1, " ", str2);
    Console.WriteLine(result); // Outputs: Hello World
    ```
    * Using `StringBuilder`:
        * If you are combining strings in a loop or dealing with a larger number of string operations, StringBuilder can offer better performance than the two methods above:
        ```c#
        using System.Text;
        
        StringBuilder sb = new StringBuilder();
        sb.Append("Hello");
        sb.Append(" ");
        sb.Append("World");
        string result = sb.ToString();
        Console.WriteLine(result); // Outputs: Hello World
        ```
    * For most scenarios where you're just concatenating two strings a few times, using the `+` operator or `string.Concat` will be sufficiently efficient and provide clear, concise code. However, if you're performing many string manipulations in a loop or need to concatenate a large number of strings, `StringBuilder` is the better choice due to its optimized memory handling.

### [.NET fundamentals](https://learn.microsoft.com/en-us/dotnet/fundamentals/)

#### [Collections and Data Structures](https://learn.microsoft.com/en-us/dotnet/standard/collections/)

### [.NET tools and diagnostics](https://learn.microsoft.com/en-us/dotnet/navigate/tools-diagnostics/)

#### [Code analysis](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/overview?tabs=net-7)

##### [IDE0039: Use local function instead of lambda](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0039)

```c#
// csharp_style_prefer_local_over_anonymous_function = true
int fibonacci(int n)
{
    return n <= 1 ? 1 : fibonacci(n-1) + fibonacci(n-2);
}

// csharp_style_prefer_local_over_anonymous_function = false
Func<int, int> fibonacci = (int n) =>
{
    return n <= 1 ? 1 : fibonacci(n - 1) + fibonacci(n - 2);
};
```

* C# why Use local function instead of lambda (IDE0039) ?
    * In C#, both lambda expressions and local functions are used to define methods that can be embedded within another method. However, there are some differences and specific scenarios where one may be favored over the other. Starting with C# 7.0, local functions were introduced to address some of the shortcomings of lambda expressions.
    * The code analyzer warning IDE0039 suggests using a local function instead of a lambda in some cases. Here's why:
        * `Performance`: Lambdas, especially when they capture variables, can cause heap allocations because they get converted to delegate instances. Local functions, on the other hand, can be more optimized by the compiler, especially when capturing local variables. In many cases, they can avoid the heap allocation altogether.
        * Readability: For longer methods, local functions can be more readable than lambda expressions. They can be named appropriately, which can make code more self-explanatory.
        * Versatility: Local functions can have multiple statements, can specify return types explicitly, can include ref, out, and in parameters, and can have generic type parameters, all of which aren't straightforward with lambda expressions.
        * `No Delegate Overhead`: Lambdas always create a delegate (or an expression tree). Local functions are just methods and only create delegates when used as such.
        * Clearer Variable Capturing Semantics: With local functions, it's clearer when you're capturing a variable from the outer scope, and you avoid potential issues with late binding of variables which can be an issue with lambdas.
        * Recursion: Local functions can be recursive, which is not directly achievable with lambdas.
    * Here's a basic comparison:
        * Lambda:
        ```c#
        Func<int, int, int> add = (x, y) => x + y;
        Console.WriteLine(add(3, 4));
        ```
        * Local Function:
        ```c#
        int Add(int x, int y) => x + y;
        Console.WriteLine(Add(3, 4));
        ```
    * In conclusion, while lambdas are still incredibly useful for many scenarios, especially for short inline methods or LINQ queries, local functions offer a powerful alternative that can be more efficient and clearer in certain situations. The IDE0039 warning is there to help developers be aware of these benefits in suitable contexts.

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

#### [Language Integrated Query (LINQ)](https://learn.microsoft.com/en-us/dotnet/csharp/linq/)

* Language-Integrated Query (LINQ) is the name for a set of technologies based on the integration of query capabilities directly into the C# language. Traditionally, queries against data are expressed as simple strings without type checking at compile time or IntelliSense support. Furthermore, you have to learn a different query language for each type of data source: SQL databases, XML documents, various Web services, and so on. With LINQ, a query is a first-class language construct, just like classes, methods, events.
* For a developer who writes queries, the most visible "language-integrated" part of LINQ is the query expression. Query expressions are written in a declarative query syntax. By using query syntax, you can perform filtering, ordering, and grouping operations on data sources with a minimum of code. You use the same basic query expression patterns to query and transform data in SQL databases, ADO.NET Datasets, XML documents and streams, and .NET collections.
* The following example shows the complete query operation. The complete operation includes creating a data source, defining the query expression, and executing the query in a `foreach` statement.
```C#
// Specify the data source.
int[] scores = { 97, 92, 81, 60 };

// Define the query expression.
IEnumerable<int> scoreQuery =
    from score in scores
    where score > 80
    select score;

// Execute the query.
foreach (int i in scoreQuery)
{
    Console.Write(i + " ");
}

// Output: 97 92 81
```

#
[Query expression overview](https://learn.microsoft.com/en-us/dotnet/csharp/linq/#query-expression-overview)

* Query expressions can be used to query and to transform data from any LINQ-enabled data source. For example, a single query can retrieve data from a SQL database, and produce an XML stream as output.
* Query expressions are easy to grasp because they use many familiar C# language constructs.
* The variables in a query expression are all strongly typed, although in many cases you do not have to provide the type explicitly because the compiler can infer it. For more information, see Type relationships in LINQ query operations.
* A query is not executed until you iterate over the query variable, for example, in a foreach statement. For more information, see Introduction to LINQ queries.
* At compile time, query expressions are converted to Standard Query Operator method calls according to the rules set forth in the C# specification. Any query that can be expressed by using query syntax can also be expressed by using method syntax. However, in most cases query syntax is more readable and concise. For more information, see C# language specification and Standard query operators overview.
* As a rule when you write LINQ queries, we recommend that you use query syntax whenever possible and method syntax whenever necessary. There is no semantic or performance difference between the two different forms. Query expressions are often more readable than equivalent expressions written in method syntax.
* Some query operations, such as Count or Max, have no equivalent query expression clause and must therefore be expressed as a method call. Method syntax can be combined with query syntax in various ways. For more information, see Query syntax and method syntax in LINQ.
* Query expressions can be compiled to expression trees or to delegates, depending on the type that the query is applied to. IEnumerable<T> queries are compiled to delegates. IQueryable and IQueryable<T> queries are compiled to expression trees. For more information, see Expression trees.

#
[How to enable LINQ querying of your data source](https://learn.microsoft.com/en-us/dotnet/csharp/linq/#how-to-enable-linq-querying-of-your-data-source)

* In-memory data
    * There are two ways you can enable LINQ querying of in-memory data. If the data is of a type that implements [IEnumerable<T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1), you can query the data by using LINQ to Objects. If it does not make sense to enable enumeration of your type by implementing the [IEnumerable<T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) interface, you can define LINQ standard query operator methods in that type or create LINQ standard query operator methods that extend the type. Custom implementations of the standard query operators should use deferred execution to return the results.
* Remote data
    * The best option for enabling LINQ querying of a remote data source is to implement the [IQueryable<T>](https://learn.microsoft.com/en-us/dotnet/api/system.linq.iqueryable-1) interface. However, this differs from extending a provider such as LINQ to SQL for a data source.
 
#
[IQueryable LINQ providers](https://learn.microsoft.com/en-us/dotnet/csharp/linq/#iqueryable-linq-providers)

* LINQ providers that implement [IQueryable<T>](https://learn.microsoft.com/en-us/dotnet/api/system.linq.iqueryable-1) can vary widely in their complexity.

##### Getting Started with LINQ in C#

###### [Introduction to LINQ Queries (C#)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries)

* A query is an expression that retrieves data from a data source. Queries are usually expressed in a specialized query language. Different languages have been developed over time for the various types of data sources, for example SQL for relational databases and XQuery for XML. Therefore, developers have had to learn a new query language for each type of data source or data format that they must support. LINQ simplifies this situation by offering a consistent model for working with data across various kinds of data sources and formats. In a LINQ query, you are always working with objects. You use the same basic coding patterns to query and transform data in XML documents, SQL databases, ADO.NET Datasets, .NET collections, and any other format for which a LINQ provider is available.

###### [Query expression basics](https://learn.microsoft.com/en-us/dotnet/csharp/linq/query-expression-basics)

* This article introduces the basic concepts related to query expressions in C#.

###### [Write LINQ queries in C#](https://learn.microsoft.com/en-us/dotnet/csharp/linq/write-linq-queries)

* Most queries in the introductory Language Integrated Query (LINQ) documentation are written by using the LINQ declarative query syntax. However, the query syntax must be translated into method calls for the .NET common language runtime (CLR) when the code is compiled. These method calls invoke the standard query operators, which have names such as `Where`, `Select`, `GroupBy`, `Join`, `Max`, and `Average`. You can call them directly by using method syntax instead of query syntax.
* Query syntax and method syntax are semantically identical, but many people find query syntax simpler and easier to read. Some queries must be expressed as method calls. For example, you must use a method call to express a query that retrieves the number of elements that match a specified condition. You also must use a method call for a query that retrieves the element that has the maximum value in a source sequence. The reference documentation for the standard query operators in the [System.Linq](https://learn.microsoft.com/en-us/dotnet/api/system.linq) namespace generally uses method syntax. Therefore, even when getting started writing LINQ queries, it is useful to be familiar with how to use method syntax in queries and in query expressions themselves.

###### [Type Relationships in LINQ Query Operations (C#)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/type-relationships-in-linq-query-operations)

* To write queries effectively, you should understand how types of the variables in a complete query operation all relate to each other. If you understand these relationships you will more easily comprehend the LINQ samples and code examples in the documentation. Furthermore, you will understand what occurs behind the scenes when variables are implicitly typed by using var.
* LINQ query operations are strongly typed in the data source, in the query itself, and in the query execution. The type of the variables in the query must be compatible with the type of the elements in the data source and with the type of the iteration variable in the foreach statement. This strong typing guarantees that type errors are caught at compile time when they can be corrected before users encounter them.
* In order to demonstrate these type relationships, most of the examples that follow use explicit typing for all variables. The last example shows how the same principles apply even when you use implicit typing by using [var](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/declarations#implicitly-typed-local-variables).

###### [C# Features That Support LINQ](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/features-that-support-linq)

* These new features are all used to a degree with LINQ queries, they are not limited to LINQ and can be used in any context where you find them useful.

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
* The `?.` operator is called the `null conditional operator`. It checks for a null reference before evaluating the right side of the operator. The end result is that if there are no subscribers to the `PropertyChanged` event, the code to raise the event doesn't execute. It would throw a `NullReferenceException` without this check in that case. For more information, see [events](https://learn.microsoft.com/en-us/dotnet/csharp/events-overview). This example also uses the new `nameof` operator to convert from the property name symbol to its text representation. Using `nameof` can reduce errors where you've mistyped the name of the property.

### [C# Programming Guide](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/?redirectedfrom=MSDN)

#### [Fundamentals](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/)

##### [Classes, structs, and records in C#](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/)

###### MISC

* C# is it ok to ?
    ```c#
    classA key = new classA();
    ...
    key = new classA();
    ```
    * Yes, it's absolutely okay to do that in C#. What you're doing is:
        * Declaring a variable named key of type classA and initializing it with a new instance of classA.
        * Later, re-assigning the key variable to reference a different new instance of classA.
    * Here's a breakdown of the actions:
    ```c#
    classA key = new classA();  // key now references the first instance of classA.
    
    // Some other code...
    
    key = new classA();  // key now references a new (second) instance of classA. 
                         // The reference to the first instance will be lost unless some other reference
                        // still points to it.
    ```
    * `If no other references are pointing to the first instance of classA after the reassignment, then it becomes eligible for garbage collection. The .NET garbage collector will automatically handle the cleanup of unreferenced objects in memory.`
* C# default accessibility modifier for class member ?
    * In C#, if you don't specify an accessibility modifier for a member of a class, it will `default to private`. Similarly, if you don't specify an accessibility modifier for a class itself, it `defaults to internal when declared within a namespace`.
    * Here's a breakdown:
        * Class Members:
            * Fields: private
            * Methods: private
            * Nested Classes: private
            * Nested Interfaces: private
            * Properties: private
            * Events: private
            * Delegates: private
        * Top-Level Types:
            * Classes: internal
            * Interfaces: internal
            * Delegates: internal
            * Enums: internal
            * Structs: internal
    * So, for example, consider the following class:
    ```c#
    class MyClass
    {
        int myField;           // private by default
        void MyMethod() { }    // private by default
    }
    ```
    * myField and MyMethod are both implicitly private.
    * `Remember, it's always a good practice to be explicit about accessibility.` This ensures clarity for anyone reading your code, even though the C# language has these defaults.

### [C# reference](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)

#### Types

##### [Value Types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types)

* Value types and reference types are the two main categories of C# types. A variable of a value type contains an instance of the type. This differs from a variable of a reference type, which contains a reference to an instance of the type. By default, on [assignment](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/assignment-operator), passing an argument to a method, and returning a method result, variable values are copied. In the case of value-type variables, the corresponding type instances are copied. The following example demonstrates that behavior:
* As the preceding example shows, operations on a value-type variable affect only that instance of the value type, stored in the variable.
* If a value type contains a data member of a reference type, only the reference to the instance of the reference type is copied when a value-type instance is copied. Both the copy and original value-type instance have access to the same reference-type instance. The following example demonstrates that behavior:
```c#
using System;
using System.Collections.Generic;

public struct TaggedInteger
{
    public int Number;
    private List<string> tags;

    public TaggedInteger(int n)
    {
        Number = n;
        tags = new List<string>();
    }

    public void AddTag(string tag) => tags.Add(tag);

    public override string ToString() => $"{Number} [{string.Join(", ", tags)}]";
}

public class Program
{
    public static void Main()
    {
        var n1 = new TaggedInteger(0);
        n1.AddTag("A");
        Console.WriteLine(n1);  // output: 0 [A]

        var n2 = n1;
        n2.Number = 7;
        n2.AddTag("B");

        Console.WriteLine(n1);  // output: 0 [A, B]
        Console.WriteLine(n2);  // output: 7 [A, B]
    }
}
```
* `Note` To make your code less error-prone and more robust, define and use immutable value types. This article uses mutable value types only for demonstration purposes.
* Kinds of value types and type constraints
    * A value type can be one of the two following kinds:
        * a structure type, which encapsulates data and related functionality
        * an enumeration type, which is defined by a set of named constants and represents a choice or a combination of choices
    * A nullable value type T? represents all values of its underlying value type T and an additional null value. You cannot assign null to a variable of a value type, unless it's a nullable value type.
    * You can use the struct constraint to specify that a type parameter is a non-nullable value type. Both structure and enumeration types satisfy the struct constraint. You can use System.Enum in a base class constraint (that is known as the enum constraint) to specify that a type parameter is an enumeration type.
* Built-in value types
    * C# provides the following built-in value types, also known as `simple types`:
        * Integral numeric types
        * Floating-point numeric types
        * bool that represents a Boolean value
        * char that represents a Unicode UTF-16 character
    * All simple types are structure types and differ from other structure types in that they permit certain additional operations:
        * You can use literals to provide a value of a simple type. For example, 'A' is a literal of the type char and 2001 is a literal of the type int.
        * You can declare constants of the simple types with the const keyword. It's not possible to have constants of other structure types.
        * Constant expressions, whose operands are all constants of the simple types, are evaluated at compile time.
    * A value tuple is a value type, but not a simple type.

###### [Tuple types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples)

* The tuples feature provides concise syntax to group multiple data elements in a lightweight data structure. 
* Tuple types support equality operators `==` and `!=`. For more information, see the [Tuple equality](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-equality) section.
* Tuple types are value types; tuple elements are public fields. That makes tuples mutable value types.

# 
[Use cases of tuples](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples#use-cases-of-tuples)

* One of the most common use cases of tuples is as a method return type. That is, instead of defining out method parameters, you can group method results in a tuple return type, as the following example shows:
```c#
var xs = new[] { 4, 7, 9 };
var limits = FindMinMax(xs);
Console.WriteLine($"Limits of [{string.Join(" ", xs)}] are {limits.min} and {limits.max}");
// Output:
// Limits of [4 7 9] are 4 and 9

var ys = new[] { -9, 0, 67, 100 };
var (minimum, maximum) = FindMinMax(ys);
Console.WriteLine($"Limits of [{string.Join(" ", ys)}] are {minimum} and {maximum}");
// Output:
// Limits of [-9 0 67 100] are -9 and 100

(int min, int max) FindMinMax(int[] input)
{
    if (input is null || input.Length == 0)
    {
        throw new ArgumentException("Cannot find minimum and maximum of a null or empty array.");
    }

    // Initialize min to MaxValue so every value in the input
    // is less than this initial value.
    var min = int.MaxValue;
    // Initialize max to MinValue so every value in the input
    // is greater than this initial value.
    var max = int.MinValue;
    foreach (var i in input)
    {
        if (i < min)
        {
            min = i;
        }
        if (i > max)
        {
            max = i;
        }
    }
    return (min, max);
}
```
* As the preceding example shows, you can work with the returned tuple instance directly or deconstruct it in separate variables.

#
[Tuple field names](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-field-names)

* You explicitly specify tuple fields names in a tuple initialization expression or in the definition of a tuple type, as the following example shows:
* If you don't specify a field name, it may be inferred from the name of the corresponding variable in a tuple initialization expression, as the following example shows:
* That's called `tuple projection initializers`. The name of a variable isn't projected onto a tuple field name in the following cases:
    * The candidate name is a member name of a tuple type, for example, Item3, ToString, or Rest.
    * The candidate name is a duplicate of another tuple field name, either explicit or implicit.
* In the preceding cases, you either explicitly specify the name of a field or access a field by its default name.
* The default names of tuple fields are `Item1`, `Item2`, `Item3` and so on. You can always use the default name of a field, even when a field name is specified explicitly or inferred, as the following example shows:
* Tuple assignment and tuple equality comparisons don't take field names into account.
* At compile time, the compiler replaces non-default field names with the corresponding default names. As a result, explicitly specified or inferred field names aren't available at run time.

#
[Tuple assignment and deconstruction](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-assignment-and-deconstruction)

* C# supports assignment between tuple types that satisfy both of the following conditions:
    * both tuple types have the same number of elements
    * for each tuple position, the type of the right-hand tuple element is the same as or implicitly convertible to the type of the corresponding left-hand tuple element
* You can also use the assignment operator `=` to deconstruct a tuple instance in separate variables. You can do that in many ways:
    * Use the `var` keyword outside the parentheses to declare implicitly typed variables and let the compiler infer their types:
    ```c#
    var t = ("post office", 3.6);
    var (destination, distance) = t;
    Console.WriteLine($"Distance to {destination} is {distance} kilometers.");
    // Output:
    // Distance to post office is 3.6 kilometers.
    ```
    * Explicitly declare the type of each variable inside parentheses:
    * Declare some types explicitly and other types implicitly (with `var`) inside the parentheses:
    * Use existing variables:
    ```c#
    var destination = string.Empty;
    var distance = 0.0;

    var t = ("post office", 3.6);
    (destination, distance) = t;
    Console.WriteLine($"Distance to {destination} is {distance} kilometers.");
    // Output:
    // Distance to post office is 3.6 kilometers.
    ```
* You can also combine deconstruction with [pattern matching](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching) to inspect the characteristics of fields in a tuple. The following example loops through several integers and prints those that are divisible by 3. It deconstructs the tuple result of [Int32.DivRem](https://learn.microsoft.com/en-us/dotnet/api/system.int32.divrem) and matches against a `Remainder` of 0:
```c#
for (int i = 4; i < 20;  i++)
{
    if (Math.DivRem(i, 3) is ( Quotient: var q, Remainder: 0 ))
    {
        Console.WriteLine($"{i} is divisible by 3, with quotient {q}");
    }
}
```
* For more information about deconstruction of tuples and other types, see [Deconstructing tuples and other types](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct).

#
[Tuple equality](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-equality)

* Tuple types support the `==` and `!=` operators. These operators compare members of the left-hand operand with the corresponding members of the right-hand operand following the order of tuple elements.

#
[Tuples as out parameters](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples#tuples-as-out-parameters)

* Typically, you refactor a method that has out parameters into a method that returns a tuple. However, there are cases in which an out parameter can be of a tuple type. The following example shows how to work with tuples as out parameters:
```c#
var limitsLookup = new Dictionary<int, (int Min, int Max)>()
{
    [2] = (4, 10),
    [4] = (10, 20),
    [6] = (0, 23)
};

if (limitsLookup.TryGetValue(4, out (int Min, int Max) limits))
{
    Console.WriteLine($"Found limits: min is {limits.Min}, max is {limits.Max}");
}
// Output:
// Found limits: min is 10, max is 20
```

#
[Tuples vs `System.Tuple`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples#tuples-vs-systemtuple)

* C# tuples, which are backed by [System.ValueTuple](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple) types, are different from tuples that are represented by [System.Tuple](https://learn.microsoft.com/en-us/dotnet/api/system.tuple) types. The main differences are as follows:
    * `System.ValueTuple` types are [value types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types). `System.Tuple` types are [reference types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types).
    * `System.ValueTuple` types are mutable. `System.Tuple` types are immutable.
    * Data members of `System.ValueTuple` types are fields. Data members of `System.Tuple` types are properties.
* `System.ValueTuple` vs `System.Tuple` ?
    * Both `System.Tuple` and `System.ValueTuple` in C# allow you to encapsulate multiple values of possibly different types. However, they have some differences:
        * Immutability vs Mutability: System.Tuple is an immutable class, meaning once you've created an instance of System.Tuple, you can't change its elements. System.ValueTuple, on the other hand, is a mutable struct, so you can change the elements of a System.ValueTuple after you've created it.
        * Memory Allocation: System.Tuple is a reference type and its objects are allocated on the heap, while System.ValueTuple is a value type and its objects are usually allocated on the stack. This makes System.ValueTuple more lightweight and efficient, especially for short-lived objects.
        * Syntax and Usage: System.ValueTuple provides a more friendly and flexible syntax. You can declare ValueTuple variables with a concise syntax, and you can optionally name the elements of a ValueTuple. This is not possible with System.Tuple. Here is an example of ValueTuple usage:
        ```c#
        var person = (Name: "John", Age: 30);
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        ```
        * Compatibility: System.Tuple has been available since .NET Framework 4.0, while System.ValueTuple was introduced in .NET Framework 4.7 and .NET Core 1.0. If you're working with an older version of .NET, you might need to use System.Tuple.
        * System.Tuple is a reference type, whereas System.ValueTuple is a value type. This means that ValueTuple can have performance benefits in some scenarios because it doesn't allocate on the heap and doesn't cause garbage collection.
        * System.ValueTuple supports field names. This can make your code more readable.
        * Here are examples of how to use both:
        ```c#
        // System.Tuple
        var tuple = new Tuple<int, string>(1, "one");
        Console.WriteLine(tuple.Item1);  // Outputs: 1
        Console.WriteLine(tuple.Item2);  // Outputs: one

        // System.ValueTuple
        var valueTuple = (Number: 1, Word: "one");
        Console.WriteLine(valueTuple.Number);  // Outputs: 1
        Console.WriteLine(valueTuple.Word);    // Outputs: one
        ```
        * As you can see, the ValueTuple syntax is more succinct, and the ability to name fields makes it clearer what each field represents. Note that to use named ValueTuple elements, you must be using C# 7.0 or later.
    * In most cases, `System.ValueTuple` is the better choice because of its improved syntax and performance. However, `System.Tuple` can still be useful in some situations, for example, when you need to ensure immutability or when you're working with older .NET versions.

##### [Reference types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types)

* There are two kinds of types in C#: reference types and value types. Variables of reference types store references to their data (objects), while variables of value types directly contain their data. With reference types, two variables can reference the same object; therefore, operations on one variable can affect the object referenced by the other variable. With value types, each variable has its own copy of the data, and it's not possible for operations on one variable to affect the other (except in the case of in, ref, and out parameter variables; see [in](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/in-parameter-modifier), [ref](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ref), and [out](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out-parameter-modifier) parameter modifier).
* The following keywords are used to declare reference types:
    * [class](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class)
    * [interface](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface)
    * [delegate](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-delegate-type)
    * [record](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record)
* C# also provides the following built-in reference types:
    * [dynamic](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types)
    * [object](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types)
    * [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types)

#### [Keywords](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/)

* Keywords are predefined, reserved identifiers that have special meanings to the compiler. They can't be used as identifiers in your program unless they include @ as a prefix. For example, @if is a valid identifier, but if isn't because if is a keyword.

##### Modifiers

###### [readonly](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly)

#
MISC

* C# readonly ?
    * `In C#, the readonly modifier is used to declare that a field can only be assigned at the time of declaration or within a constructor in the same class. Once assigned, its value cannot be changed, making it effectively immutable for the lifespan of the containing object.`
    * Here are some key points and examples related to readonly:
        * Basic Usage:
            ```c#
            public class MyClass
            {
                private readonly int _myField;
            
                public MyClass(int value)
                {
                    _myField = value;
                }
            }
            ```
            * In the above example, _myField is marked as readonly, so it can be assigned a value only during declaration or in the constructor.
        * Compared to const:
            * While both readonly and const seem similar in that they both prevent a variable from being modified, there are key differences:
                * const: It must be initialized at the time of declaration, and the value cannot change. The value must be a compile-time constant. It's static by default.
                * readonly: It can be initialized at declaration or in a constructor. It's useful for values that are known at runtime but not at compile-time, like values passed into a constructor.
        * When to use readonly:
            * Use readonly when you have a field that you want to prevent from being changed after the object construction, especially if that field's value is determined at runtime. This is often seen in classes that are meant to be immutable after creation.
        * Limitation:
            * If the readonly field is a reference type, the reference itself cannot change, but the object it refers to can be modified. For example:
            ```c#
            public class Data
            {
                public int Value { get; set; }
            }
            
            public class MyClass
            {
                private readonly Data _data = new Data();
            
                public MyClass()
                {
                    _data.Value = 10;
                }
            
                public void SomeMethod()
                {
                    // This is valid. We are modifying the object that _data refers to.
                    _data.Value = 20;
            
                    // This would be invalid. We cannot change the reference itself.
                    // _data = new Data();
                }
            }
            ```
            * In the above example, even though _data is readonly, the Value property on the object it points to can still be modified. If you truly want an immutable object, you'd have to ensure immutability on the object's class itself, not just the readonly reference to it.

##### [Query keywords](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/query-keywords)

###### [select clause](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/select-clause)

* In a query expression, the select clause specifies the type of values that will be produced when the query is executed. The result is based on the evaluation of all the previous clauses and on any expressions in the select clause itself. A query expression must terminate with either a select clause or a group clause.

#### [operators and expressions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/)

##### [Lambda expressions and anonymous functions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions)

* You use a lambda expression to create an anonymous function. Use the lambda declaration operator => to separate the lambda's parameter list from its body. A lambda expression can be of any of the following two forms:
    * Expression lambda that has an expression as its body:
        * `(input-parameters) => expression`
    * Statement lambda that has a statement block as its body:
        * `(input-parameters) => { <sequence-of-statements> }`

###### MISC

* C# lambda function ?
    * In C#, a lambda expression is an anonymous function or a function without a name. Lambda expressions are particularly useful for short functions that are used only a few times and are not required elsewhere. They are often used as arguments to higher-order functions, or as elements of LINQ queries.
    * The lambda expression syntax is as follows:
        * `(parameters) => expression`
    * Or for multiple statements:
        * `(parameters) => { statements }`
    * Examples
        * No parameter:
            * `() => 5`
            * This lambda function takes no parameters and returns 5.
        * One parameter:
            * `x => x * x`
            * This lambda function squares its input.
        * Multiple parameters:
            * `(x, y) => x + y`
            * This lambda function takes two parameters and returns their sum.
        * Multiple statements:
            ```c#
            (x, y) => 
            {
                int sum = x + y;
                return sum;
            }
            ```
            * This lambda function takes two parameters, adds them, and returns the sum.
    * Usage with Func and Action
        * Lambda expressions are often used with `Func` and `Action` types, which are built-in generic delegates.
        ```c#
        Func<int, int> square = x => x * x;
        Console.WriteLine(square(5)); // Outputs "25"
        
        Action<string> greet = name => Console.WriteLine("Hello, " + name);
        greet("Alice"); // Outputs "Hello, Alice"
        
        Func<int, int, int> add = (x, y) => x + y;
        Console.WriteLine(add(3, 4)); // Outputs "7"
        ```
    * Usage in LINQ
        * Lambda expressions are commonly used in LINQ queries:
        ```c#
        var numbers = new[] { 0, 1, 2, 3, 4 };
        var squares = numbers.Select(x => x * x);
        ```
        * In this example, squares will contain {0, 1, 4, 9, 16}.
    * Lambda expressions are a very flexible and powerful feature in C#, especially when working with collections and LINQ.
* C# lambda function vs method ?
    * Lambda expressions and methods in C# serve different purposes and can be used based on different use cases. Let's compare the two in terms of various aspects:
        * Definition:
            * Lambda: A lambda expression is an anonymous function (without a name) that can contain expressions and statements. It uses the => operator.
                * `(x, y) => x + y`
            * Method: A method is a named block of code that can be invoked through its name.
            ```c#
            int Add(int x, int y)
            {
                return x + y;
            }
            ```
        * Scope:
            * Lambda: Usually has a limited scope. Typically defined inside a method to be used for a short span like LINQ queries.
            * Method: Can be accessed from different parts of the class or outside the class based on its access modifier.
        * Reuse:
            * Lambda: Typically used for a one-time, specific purpose. Can't be reused unless assigned to a delegate variable.
            * Method: Defined once and can be called multiple times, promoting reusability.
        * Performance:
            * Lambda: If it captures variables from an outer function, it might cause heap allocations.
            * Method: Generally more performant as it doesn't have the overhead of delegate creation unless used as a delegate.
        * Versatility:
            * Lambda: Short, more concise, and can be written inline. However, it's limited in capabilities (e.g., can't have ref/out parameters).
            * Method: More versatile, can have multiple statements, explicit return types, ref/out parameters, etc.
        * State:
            * Lambda: Can capture and hold onto the state from its enclosing scope. This is termed as a "closure".
            * Method: Does not capture any state from outside its scope unless it's a local function.
        * Readability:
            * Lambda: Great for short operations like LINQ. But for complex operations, it can hamper readability.
            * Method: Clearer to understand, especially for complex operations.
        * Recursion:
            * Lambda: Direct recursion is not straightforward.
            * Method: Can easily be recursive.
    * In conclusion:
        * Use lambda expressions when you need a short-lived, concise function, often as an argument to methods like those in LINQ or when you want to leverage closures.
        * Use methods when you have a block of code that you need to reuse multiple times, for more complex operations, or when you need full method capabilities like explicit access modifiers, ref/out parameters, etc.
    * Each has its place, and understanding their characteristics will help you decide which to use in a given scenario.

#### Statements

##### [using statement - ensure the correct use of disposable objects](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/using)

* The `using` statement ensures the correct use of an [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) instance:
```c#
var numbers = new List<int>();
using (StreamReader reader = File.OpenText("numbers.txt"))
{
    string line;
    while ((line = reader.ReadLine()) is not null)
    {
        if (int.TryParse(line, out int number))
        {
            numbers.Add(number);
        }
    }
}
```
* When the control leaves the block of the `using` statement, an acquired `IDisposable` instance is disposed. In particular, the `using` statement ensures that a disposable instance is disposed even if an exception occurs within the block of the `using` statement. In the preceding example, an opened file is closed after all lines are processed.
* Use the `await using` statement to correctly use an [IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable) instance:
```c#
await using (var resource = new AsyncDisposableExample())
{
    // Use the resource
}
```
* For more information about using of `IAsyncDisposable` instances, see the [Using async disposable](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-disposeasync#using-async-disposable) section of the [Implement a DisposeAsync method](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-disposeasync) article.
* You can also use a `using declaration` that doesn't require braces:
```c#
static IEnumerable<int> LoadNumbers(string filePath)
{
    using StreamReader reader = File.OpenText(filePath);
    
    var numbers = new List<int>();
    string line;
    while ((line = reader.ReadLine()) is not null)
    {
        if (int.TryParse(line, out int number))
        {
            numbers.Add(number);
        }
    }
    return numbers;
}
```
* When declared in a `using declaration`, a local variable is disposed at the end of the scope in which it's declared. In the preceding example, disposal happens at the end of a method.
* A variable declared by the `using` statement or declaration is `readonly`. You cannot reassign it or pass it as a ref or out parameter.
* You can declare several instances of the same type in one `using` statement, as the following example shows:
```c#
using (StreamReader numbersFile = File.OpenText("numbers.txt"), wordsFile = File.OpenText("words.txt"))
{
    // Process both files
}
```
* When you declare several instances in one `using` statement, they are disposed in reverse order of declaration.
* You can also use the `using` statement and declaration with an instance of a [ref struct](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/ref-struct) that fits the disposable pattern. That is, it has an instance `Dispose` method, which is accessible, parameterless and has a `void` return type.
* The `using` statement can also be of the following form:
```c#
using (expression)
{
    // ...
}
```
* where `expression` produces a disposable instance. The following example demonstrates that:
```c#
StreamReader reader = File.OpenText(filePath);

using (reader)
{
    // Process file content
}
```
* Warning
    * In the preceding example, after control leaves the `using` statement, a disposable instance remains in scope while it's already disposed. If you use that instance further, you might encounter an exception, for example, [ObjectDisposedException](https://learn.microsoft.com/en-us/dotnet/api/system.objectdisposedexception). That's why we recommend declaring a disposable variable within the `using statement` or with the `using declaration`.

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
