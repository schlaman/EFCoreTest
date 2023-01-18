# EFCoreTest

## Illustrates problem with .NET Maui and EF Core 7 with Sqlite while invoking EnsureCreated() -- ONLY a problem on physical IOS Device. Works on Windows and Android perfectly.
This project is intended to be a minimum project to demonstrate this 'NullabilityInfoContext' exception issue.
The exception specifically happens when EnsureCreated() is called with the creation of a Sqlite DB where there is a string property in the C# model class that represents the table.
This exception ONLY occurs if the Table model contains a string property.
In this case the Vendor class contains Description. If that field is remarked out then EnsureCreated is successful.

## There is a GitHub issue filed for the problem listed in this readme. I have posted in there (Craig Schlaman)
https://github.com/xamarin/xamarin-macios/issues/16228

### This is in a .NET MAUI test app. I am using VS 17.5.0 Preview 2 and VS 17.4.3 Release. NET7.0 Windows 11. Microsoft.EntityFrameworkCore.Sqlite v6.0.10 OR v7.0.0-rc.22472.11 or v7.0.2

## **This ONLY crashes on a PHYSICAL IOS DEVICE when invoking the EnsureCreated() call. Invoking the call on Windows or Android works perfectly!!!**

**I have  have the following error!!**

# 'NullabilityInfoContext' Error Message:
" NullabilityInfoContext is not supported in the current application because 'System.Reflection.NullabilityInfoContext.IsSupported' is set to false. Set the MSBuild Property 'NullabilityInfoContextSupport' to true in order to enable it.
[0:] An error occurred: 'NullabilityInfoContext is not supported in the current application because 'System.Reflection.NullabilityInfoContext.IsSupported' is set to false. Set the MSBuild Property 'NullabilityInfoContextSupport' to true in order to enable it.'. Callstack: ' at System.Reflection.NullabilityInfoContext.EnsureIsSupported()
"
### As suggested elsewhere, I tried the following in the project file but it does not make any difference:

```
<PropertyGroup>
	<NullabilityInfoContextSupport>true</NullabilityInfoContextSupport>
	<Nullable>enable</Nullable>
</PropertyGroup>
```

### This is my Data Model for a simple example table 'Vendor'

```
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTestDeploy.Data.Models;

[Table("vendor")]
public class Vendor
{
public int VendorId { get; set; }

// If this is remarked out then no 'NullabilityInfoContext' error occurs
public string Description { get; set; }

public int VendorCategoryPrimary { get; set; }
}
```

## Can someone please help with resolving this. It is a very simple use case. When EnsureCreated() is called then the ''NullabilityInfoContext' error occurs as described above upon doing the EnsureCreated() call. Otherwise if you have a Table model without any string properties then everything works perfectly.
### At this point it feels impossible to continue with App development on IOS until this is resolved!!