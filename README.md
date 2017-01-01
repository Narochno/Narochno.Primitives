# Narochno.Primitives [![Build status](https://ci.appveyor.com/api/projects/status/cp7e8kiashwtrcdd/branch/master?svg=true)](https://ci.appveyor.com/project/Narochno/narochno-primitives/branch/master)
Classes designed to make working with C# code easier.

## Optional&lt;T&gt;
A generic struct to allow for optional reference values. It allows you to write code that assumes all variables except those wrapped with `Optional<T>` are specified, avoiding the need for null checks and possible null reference exceptions.

It is the same concept as `Nullable<T>`, but can be used for reference types instead of only value types.

### Example Usage
```csharp
public async Task RecordInformation(Information information, Optional<Location> location)
{
    var document = new Document();
    document["name"] = information.Name;
    document["email"] = information.Email;

    if (location.IsSet)
    {
        document["country"] = location.Country;
        document["city"] = location.City;
    }

    await Table.LoadTable(dynamoClient, "Information")
        .PutItemAsync(document);
}
```

The use of `Optional<T>` in the code above to wrap the `Location` object is an explicit way to show that it may not be set, without a null check. Anyone calling and editing the code can see the intent of the parameter from a glance.

## Generic Parsing
A set of classes to provide parsing of strings into types. Allows a single generic function call to invoke parsers for all primitive types, extendable to be used with custom types.

The library also adds support for enum string values.
### Example .Parse&lt;T&gt; Usage
The string extension method `.Parse<T>` or `.Parse(type)` can be used to parse a string to a specific type, and throw an exception if the parse fails.
```csharp
int number = "20".Parse<int>();
float floating = "20.25".Parse<float>();
```
### Example .TryParse&lt;T&gt; Usage
The string extension method `.TryParse<T>` or `.TryParse(type)` can be used to parse a string to a specific type, returning an optional result (and no exception if the parse fails).
```csharp
Optional<int> optionalNumber = "10".TryParse<int>();
Optional<float> optionalFloat = "10.1".TryParse<float>();
```
### Example Enum String Parsing
The library can be used to parse strings to enum values decorated with the `EnumString` attribute.
```csharp
public enum MyEnum
{
    [EnumString("first")]
    One,
    [EnumString("second")]
    Two
}

MyEnum parsed = "second".Parse<MyEnum>();
```

### Extending Parsers
A custom parser will need to inherit from the `Parser` class, which requires the implementation of two methods:
```csharp
public class BoolParser : Parser<bool>
{
    public override bool Parse(string input) => bool.Parse(input);

    public override Optional<bool> TryParse(string input)
    {
        bool result;
        if (bool.TryParse(input, out result))
        {
            return result;
        }

        return new Optional<bool>();
    }
}
```
Additional parsers can be added for the static string extension methods `.Parse` and `.TryParse` by adding to the static `Parsers` dictionary in `DefaultParserLibrary`.
```csharp
DefaultParserLibrary.Parsers.Add(typeof(MyType), new MyTypeParser());
```
### Parsing in a Non-Static Context
The parsing library provides the `DefaultParserLibrary.Instance` static for convenience. This can be re-assigned in your application to anything that implements the interface `IParserLibrary`.

The `DefaultParserLibrary` can also be instantiated, and used as follows, completely avoiding the static extensions.
```csharp
var parser = new DefaultParserLibrary()
    .GetParser<bool>();

bool itsTrue = (bool)parser.Parse("true");
```
Parsing can be used with dependency injection - simply register `DefaultParserLibrary` against the interface `IParserLibrary` in your container and inject into your class constructor. Using the library this way allows you to mock its methods in unit tests.
```csharp
var provider = new ServiceCollection()
    .AddTransient<IParserLibrary, DefaultParserLibrary>()
    .BuildServiceProvider();
```
