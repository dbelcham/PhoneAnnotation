PhoneAnnotation
===============
This is an additional DataAnnotation for Model property validation. It's based on the code that AppHarbor blogged about (http://blog.appharbor.com/2012/02/03/net-phone-number-validation-with-google-libphonenumber) and has it's foundation in the .NET port of Google's libphonenumber library (https://bitbucket.org/pmezard/libphonenumber-csharp/wiki/Home).

General
-------
All validation that is performed by the annotation is handled by the Google libphonenumber port. If you need to figure out region codes and valid number formats you'll be best served by looking at these resources.

- https://bitbucket.org/pmezard/libphonenumber-csharp/wiki/Home
- https://code.google.com/p/libphonenumber/

Usage
-----
```
[PhoneNumber]
```
The default attribute will validate the property contents against the US region.

```
[PhoneNumber("CH")]
```
Passing a single region code (Switzerland in this example) will cause the property content to be validated against only that region.

```
[PhoneNumber(new[]{"CH","US","JP"})]
```
Passing multiple region codes will cause the property to be validated against all of them. If the property value is valid in any of the regions then the validation will pass. The property value must be invalid in all of the regions for the validation to fail.
