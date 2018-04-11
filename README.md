Test project to demonstrate problems writing F# records

There are 3 tests.
1 - TestNestedLikeFSharp
2 - TestFSharpNested
3 - TestCSharpNested

All try to serialize a single record of a nested class.

The C# one works fine. The simulated F# (with a parameterised constructor) and the proper F# ones fail.

The issue is that when writing out nested records, the serializer checks the following.


```
var isDefaultConverter = typeConverterType == typeof( DefaultTypeConverter );
if( isDefaultConverter && ( memberTypeInfo.HasParameterlessConstructor() || memberTypeInfo.IsUserDefinedStruct() ) )
```

No converter has been configured, so the converter used is `DefaultTypeConverter`

The F# record has a parmeterised constructor, but is not a user defined struct, so that test fails. This means that the serializer then doesn't auto map the members and basically ignores the nested F# record (or nested records with a parameterized constructor)


