![alt tag](/img/changesetter.png)  

Set only chaged field(s) between objects.

[![NuGet version](https://badge.fury.io/nu/Exporty.svg)](https://badge.fury.io/nu/ChangeSetter)  ![Nuget](https://img.shields.io/nuget/dt/ChangeSetter)

#### Features:
- Set Property
- Set Fields

#### Usages:

```cs
//Generic Change Setter Response
public class ChangeSetterResult<T>
{
    public bool HasChanges { get; set; }
    public T Value { get; set; }
}


var testObject = new TestClass();
var testObject2 = new TestClass2();
 
var changeResult = new ChangeSetter.ChangeSetter().Map<TestClass, TestClass2>(ref testObject, ref testObject2, new List<ChangeSetter.Models.CustomFieldMapping>
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

Console.WriteLine("HasChanges: " + changeResult.HasChanges);

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
```

### Release Notes

#### 1.0.0
* Base Release
