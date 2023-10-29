---

authors:
- dgmjr
date: 2023-07-02T20:00:10.681Z
description: This package contains several *primitive* types that are used throughout the rest of the Types package.
keywords:
- DGMJR-IO
- emailaddress
- int24
- primitives
- phonenumber
- objectid
- types
- uri
- urn
- url
- xri
- iri
license: MIT
slug: primitives
title: DGMJR-IO Primitives
type: readme
lastmod: 2023-07-02T22:36:04.550Z
project: Dgmjr.Types
version: 0.0.1
--------------

# DGMJR-IO Primitives

This package contains several "primitive" types that are used throughout the rest of the Types package.

## Domain Data  Types

### Email Address Value Object

- [`EmailAddress`](https://github.com/dgmjr-io/Primitives/blob/main/src/EmailAddress.cs) - An email address value type

#### Overview

The `EmailAddress` struct represents an email address value. It aims to encapsulate email address parsing, validation, and formatting logic in a reusable way.

Key features:

- Implements value object interfaces like `IEquatable`, `IComparable`, etc.
- Leverages regex for validation.
- Provides implicit conversions to/from string.
- Includes constants for common scenarios.
- Generates a mailto: URI.

#### Usage

`EmailAddress` can be used anywhere an email address value is needed:

```csharp
var email = EmailAddress.From("user@example.com");

if (email.IsEmpty) {
  // use email
}
```

### Phone Number Value Object

- [`PhoneNumber`](https://github.com/dgmjr-io/Primitives/blob/main/src/PhoneNumber.cs) - A phone number value type

This file contains the implementation of the `PhoneNumber` value object for representing phone numbers.

#### Overview

The `PhoneNumber` struct encapsulates parsing, validation, and formatting of phone numbers in a reusable way.

Key features:

- Implements `IRegexValueObject` for parsing and validation.
- Leverages `libphonenumber` for parsing into components.
- Provides implicit conversions to/from string.
- Generates a tel: URI from the number.
- Includes constants like `Empty`, `ExampleValue`, etc.

#### Usage

`PhoneNumber` can be used anywhere a parsed, validated phone number value is needed:

```csharp
var number = PhoneNumber.From("+12025551234");

Console.WriteLine(number.IsEmpty); // true
Console.WriteLine(number.ToString()); // +12025551234
```

### Object ID Value Object

- [`ObjectId`](https://github.com/dgmjr-io/Primitives/blob/main/src/ObjectId.cs) - A 24-hex-digit (96-bit) string

This directory contains the implementation of the `ObjectId` value object.

#### Overview

The `ObjectId` struct represents an ObjectId value commonly used in MongoDB. It aims to encapsulate ObjectId parsing, validation, and formatting logic in a reusable way.

Key features:

- Implements value object interfaces like `IEquatable`, `IComparable`, etc.
- Leverages regex for validation.
- Provides static factory methods like `Parse` and `TryParse`.
- Generates a `URN` identifier `URI`.
- Includes constants for common scenarios.

#### Usage

`ObjectId` can be used anywhere a MongoDB ObjectId value is needed:

```csharp
var id = ObjectId.TryParse("61f7c3692093f4d09f000123", out var oid) ? oid : ObjectId.Empty;

if (id.IsEmpty) {
  // use id
}
```

<!-- - [`YesNo`/`YesNoEnum`](https://github.com/dgmjr-io/Primitives/blob/main/src/Primitives/src/YesNo.cs)
- [`YesNoIdc`/`YesNoIdcEnum`](https://github.com/dgmjr-io/Primitives/blob/main/src/YesNoIdc.cs) -->

## Numerics

- [`Int24`](https://github.com/dgmjr-io/Primitives/blob/main/src/Int24.cs) - a 24-bit signed integer (*alias: i24*)
- [`UInt24`](https://github.com/dgmjr-io/Primitives/blob/main/src/Int24.cs) - a 24-bit unsigned integer (*alias: ui24*)

## The <ins>`blank`</ins> Resource <ins>`blank`</ins>s

These are a collection of <ins>`blank`</ins> Resource <ins>`blank`</ins>s.

- [`iri`](https://github.com/dgmjr-io/Primitives/blob/main/src/iri.cs) - An internationalized resource identifier
- [`uri`](https://github.com/dgmjr-io/Primitives/blob/main/src/uri.cs) - A uniform resource identifier
- [`url`](https://github.com/dgmjr-io/Primitives/blob/main/src/url.cs) - A uniform resource locator
- [`urn`](https://github.com/dgmjr-io/Primitives/blob/main/src/urn.cs) - A uniform resource name
- [`xri`](https://github.com/dgmjr-io/Primitives/blob/main/src/xri.cs) - An eXtensble resource identifier

