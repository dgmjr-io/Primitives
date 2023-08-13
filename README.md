---
authors:
  - dgmjr
date: 2023-07-02T20:00:10.681Z
description: This package contains several "primitive" types that are used throughout the rest of the Types package.
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
lastMod: 2023-03-19T03:27:38.342Z
license: MIT
slug: primitives
title: Primitives
type: readme
lastmod: 2023-07-02T22:36:04.550Z
project: Dgmjr.Types
version: 0.0.1
---

# Primitives

This package contains several "primitive" types that are used throughout the rest of the Types package.

## Domain Data  Types

- [`EmailAddress`](https://github.com/dgmjr-io/Primitives/blob/main/src/EmailAddress.cs) - An email address value type
- [`PhoneNumber`](https://github.com/dgmjr-io/Primitives/blob/main/src/PhoneNumber.cs) - A phone number value type
- [`ObjectId`](https://github.com/dgmjr-io/Primitives/blob/main/src/ObjectId.cs) - A 24-hex-digit (96-bit) string
- [`YesNo`/`YesNoEnum`](https://github.com/dgmjr-io/Primitives/blob/main/src/Primitives/src/YesNo.cs)
- [`YesNoIdc`/`YesNoIdcEnum`](https://github.com/dgmjr-io/Primitives/blob/main/src/YesNoIdc.cs)

## Numerics

- [`Int24`](https://github.com/dgmjr-io/Primitives/blob/main/src/Int24.cs) - a 24-bit signed integer (*alias: i24*)
- [`UInt24`](https://github.com/dgmjr-io/Primitives/blob/main/src/Int24.cs) - a 24-bit unsigned integer (*alias: ui24*)

## The _R_s

These are a collection of `**blank** resource **blank**`s.

- [`iri`](https://github.com/dgmjr-io/Primitives/blob/main/src/iri.cs) - An internationalized resource identifier
- [`uri`](https://github.com/dgmjr-io/Primitives/blob/main/src/uri.cs) - A uniform resource identifier
- [`url`](https://github.com/dgmjr-io/Primitives/blob/main/src/url.cs) - A uniform resource locator
- [`urn`](https://github.com/dgmjr-io/Primitives/blob/main/src/urn.cs) - A uniform resource name
- [`xri`](https://github.com/dgmjr-io/Primitives/blob/main/src/xri.cs) - An eXtensble resource identifier
