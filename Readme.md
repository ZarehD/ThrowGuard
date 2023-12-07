# Throw Helpers & Guards

#### A small library of throw helpers and guard methods to optimize and simplify your code.

Throw helpers optimize your methods by moving the IL code required for throwing exceptions to a shared, common place. See below to learn [more](#why-use-throw-helpers).
 
Guard methods simplify and streamline your code, making it cleaner and easier to understand your intent.
Guard methods use throw helpers internally.


## Getting Started

Add the Nuget package to your project.
```
dotnet add package ThrowGuard
```

### Throw Helpers

```C#
using ThrowGuard;

// throw ApplicationException...
Throw.AppException();

// throw ArgumentException...
Throw.BadArg(myParam, msg: "Parameter has an invalid value.");

// throw DirectoryNotFOundException...
Throw.DirectoryNotFound("Directory doesn't exist: {0}".SF(folderName));

// throw CustomException...
Throw.This(new CustomException());

// use alternative style (as an extension method)...
new CustomException("Parameter contains bad content.").Throw();

```


### Guard Methods

The following is a sampling of the available guard methods.

```C#
using ThrowGuard;

namespace GuardsSamples

public class MyClass
{
  private readonly IRepo _repo;

  public MyClass(IRepo repo)
  {
    _repo = Throw.IfNull(repo);
  }

  public MyMethod(Guid id, string? name, string? name2)
  {
    var theId = Throw.IfEmpty(id, "Cannot use Guid.Empty as an identifier.");
    var theName = Throw.IfNullOrWhitespace(name);
    var altName = Throw.IfNullOrWhitespaceWhen(
      name2, () => someCondition, 
      "{0} cannot be null/whitespace when {1} is true".SF(
        nameof(name2), nameof(someCondition)));

    Throw.BadArgWhen(
      () => theName.Equals("Beetlejuice"),
      "No. Just, no!");

    Throw.IfNull(
      _repo.NameSanitizer, argName: "Repo Name Sanitizer",
      ex: new InvalidOperationException(
        "A valid NameSanitizer is required for this operation."));

    Throw.IfNullOrEmpty(
      _repo.NameSanitizer.SafeList, // a collection
      argName: "Repo Sanitizer SafeList"
      ex: new InvalidOperationException(
        "Name sanitizer safe-list is empty."));

    Throw.InvalidOpWhen(
      () => !_repo.NameSanitizer.Sanitize(theName), 
      "Sanitizer: Hey, I'm not a magician!");

    Throw.InvalidOpWhen(
      () =>
      {
        var idExists = _repo.IdExists(theId);
        var nameExists = _repo.NameExists(theName);
        return nameExists && !idExists;
      },
      $"Name and Id combination already in use > {theName}: {theId}");

    Throw.IfNotBetween(
      theName.Length, 4, 40, 
      "Name must be between 4 and 40 characters long.",
      nameof(theName));
  }
}

```



<br>

## Why use throw helpers?

I'm sure you've heard -- repeatedly by now -- that throwing exceptions is expensive. What you may not know, however, is what that means in practical terms. What you may not know is that, in order for your code _to be able to_ throw an exception, specialized IL code must be included alongside the IL for the rest of your method implementation. That means that even if your code never actually throws an exception, that IL code must still be included. This is bloat, and it's replicated in _every_ one of your methods that _might_ throw an exception.

So why should you care if your code is bloated? You shouldn't, unless, of course, you care about performance & efficiency! That's because the size of the generated IL code directly affects how long it takes to load and execute a method, how much memory the code takes up; as well as the disk storage and network bandwidth used. This bloat is completely useless, totally wasteful, and entirely avoidable.

Throw helpers are a highly effective technique for eliminating this bloat. By centralizing the relevant IL code, throw helpers slim down the IL generated for your methods.

So, if you do any of these:
```C#
void MyMethod(MyObject myObject, string myString)
{
  // throw ArgumentNullException if myObject is null
  // otherwise assign it to variable 'obj'
  var obj = myObject ?? throw new ArgumentNullException(nameof(myObject));

  // make sure myString is not null or whitespace 
  // before assigning it to variable 'str'
  if (string.IsNullOrEmpty(myString))
  {
    throw new ArgumentException(
      "Value is null or whitespace.", nameof(myString));
  }
  var str = myString;

  // throw built-in and custom exceptions 
  // based on some condition
  if (IsItTuesday())
  {
    throw new ApplicationException("Yes, because it's Tuesday.");
  }
  if (IsItThursday())
  {
    throw new MyCustomException("Look, I don't make the rules!")
  }
  ...
}
```

...replace them with these:

```C#
void MyMethod(MyObject myObject, string myString)
{
  var obj = Throw.IfNull(myObject);
  var str = Throw.IfNullOrWhitespace(myString);

  Throw.AppExceptionWhen(
    () => IsItTuesday,
    "Yes, because it's Tuesday.");

  Throw.When(
    () => IsItThursday
    new MyCustomException(
      "Look, I don't make the rules!"));
  ...
}
```

<br/>

## License

[Apache 2.0](https://github.com/ZarehD/ThrowGuard/blob/master/LICENSE)

<br/>

If you like this project, or find it useful, please give it a star. Thank you.
