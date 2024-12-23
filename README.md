# Old Phone Keypad Decoder
The decoder turns any old phone pad input into the correct output.

Example:  
```
“4433555 555666#” --> HELLO
```
here `#` means sending the text.

# Assumption
- Pressing `0` multiple times without pause results in one space.

# Description
- `IronSoft.OldPhonePad: ` implements the necessary logics to decode the old phone keypad input.
- `IronSoft.Tests: ` tests the decoder.
- `Time Complexity: ` `O(n)` where `n = length of input string`.
- `Space Complexity: ` `O(1)`, Not using any extra variable length space.  

# Run
```
cd IronSoft.Tests

dotnet test

```