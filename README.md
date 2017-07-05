# MFPassword

.NET standard library for MIFARE password(MF_Password) generation from MIFARE keys A and B.

> MIFARE password is generated from MIFARE keys A and B, this password can be use to access MIFARE memory in Java Card(since Java Card 2.2.2 if card supported).

## Projects

- src/MFPassword
  - Library for MIFARE password generation
- tests/MFPassword.Consoles
  - Console tests
- tests/MFPassword.Tests
  - Unit tests

## How to Use

See code below or MFPassword.Consoles project.

```cs
using MFPassword;

// ......

var keyA = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
var keyB = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
var mfPwd = MifarePassword.Generate(keyA, keyB);
```