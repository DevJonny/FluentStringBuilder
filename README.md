# Fluent String Builder

## Purpose

Fluent String Builder is a small library for concatenating strings
with conditions in a fluent manner.

## How to use

### Simple Conditions

```csharp
var result = new FluentStringBuilder("Seed.")
    // Append a string if it's not null or empty
    .Append(" ").If.NotNull()
    .Append("String that will be checked.").If.NotNullOrEmpty()
    // Append a string if it's not null or whitespace
    .Append(" Another string.").If.NotNullOrWhitespace()
    // Finally construct the string
    .Build();

// result: Seed. String that will be checked. Another string

```