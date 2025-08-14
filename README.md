# Ipify.NET

more .NET version support added

<img width="871" height="440" alt="image" src="https://github.com/user-attachments/assets/e38d2e31-4b87-4661-94ff-ce05356f5adb" />


**.NET client library for `ipify <http://www.ipify.org>`: *A Simple IP Address API*.**

##Meta

- Author: David Musgrove
- Email: david@musgroves.us
- Status: maintained, active

##Purpose

This library makes getting your public IP address from .NET languages extremely simple using ipify's api.

##Installation

Install ``Ipify.NET`` using NuGet.

##Usage

Using this library is very simple. Here's a simple example:

```cs
using System;

using Ipify;

class Program
{
    static void main(string[] args)
	{
		Console.WriteLine(Ipify.GetPublicAddress());
	}
}
```

##Change Log

All library changes, in descending order.

####Version 2.0.0
**Release Aug 14, 2025**
- Ipify.net covered all cases for API calls and converted project to .netstandard 2.0
- Nuget package release added

####Version 1.0.0

**Release Sep 23, 2015**

- First release
