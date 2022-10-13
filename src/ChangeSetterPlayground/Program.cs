// See https://aka.ms/new-console-template for more information 
using ChangeSetter.Extensions;

var testObject = new TestClass();
var testObject2 = new TestClass2();


var changedObject = new ChangeSetter.ChangeSetter().Map<TestClass, TestClass2>(testObject, testObject2, new List<ChangeSetter.Models.CustomFieldMapping>
{
    new ChangeSetter.Models.CustomFieldMapping{
        SourceField = "NamePublic",
        DestinationField = "NamePublic",
        MemberType = ChangeSetter.Models.MemberType.Property
    },
    new ChangeSetter.Models.CustomFieldMapping{
        SourceField = "SurnamePublic",
        DestinationField = "SurnamePublic",
        MemberType = ChangeSetter.Models.MemberType.Field
    }
});

var propertyNames = new List<string>()
{
    "NamePublic",
    "NamePrivate",
    "NameProtected",
    "NameStatic"
};
var fieldNames = new List<string>(){
    "SurnamePublic",
    "SurnamePrivate",
    "SurnameProtected",
    "SurnameStatic"
};

foreach (var propertyName in propertyNames)
{
    if (testObject.HasProperty(propertyName))
    {
        var val = testObject.GetPropertyValue<object>(propertyName);
        Console.WriteLine($"Property: {propertyName} > {val}");
    }
    else
    {
        Console.WriteLine($"Property not exist! > {propertyName}");
    }
}

Console.WriteLine();
Console.WriteLine("-------------");
Console.WriteLine();

foreach (var fieldName in fieldNames)
{
    if (testObject.HasField(fieldName))
    {
        var val = testObject.GetFieldValue<object>(fieldName);
        Console.WriteLine($"Field: {fieldName} > {val}");
    }
    else
    {
        Console.WriteLine($"Field not exist! > {fieldName}");
    }
}

Console.ReadKey();

class TestClass
{
    public string NamePublic { get; set; } = "NamePublicValue";
    public string SurnamePublic = "SurnamePublicValue";

    private string NamePrivate { get; set; } = "NamePrivateValue";
    private string SurnamePrivate = "SurnamePrivateValue";
    
    protected string NameProtected { get; set; } = "NameProtectedValue";
    protected string SurnameProtected = "SurnameProtectedValue";

    static string NameStatic { get; set; } = "NameStaticValue";
    static string SurnameStatic = "SurnameStaticValue";
}

class TestClass2
{
    public string NamePublic { get; set; } = "NamePublicValue2";
    public string SurnamePublic = "SurnamePublicValue";

    private string NamePrivate { get; set; } = "NamePrivateValue2";
    private string SurnamePrivate = "SurnamePrivateValue2";

    protected string NameProtected { get; set; } = "NameProtectedValue2";
    protected string SurnameProtected = "SurnameProtectedValue2";

    static string NameStatic { get; set; } = "NameStaticValue2";
    static string SurnameStatic = "SurnameStaticValue2";
}