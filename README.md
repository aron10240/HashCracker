# HashCracker
 
A simple C# tool for cracking hashes using a **dictionary attack** or **simple brute-force** (for short strings). Supports the most common hash algorithms and returns the original plaintext string for a given hash.
 
## Features
 
- **Dictionary Brute-Force** – tests words from a wordlist against the target hash (Wordlist Source: [github.com/danielmiessler](https://github.com/danielmiessler/SecLists/blob/master/Passwords/Common-Credentials/10k-most-common.txt))
- **Simple Brute-Force** – tries all possible character combinations up to a given length (recommended only for short strings, since the search space grows exponentially)

## Supported hash types:
  - `SHA1`
  - `SHA256`
  - `SHA512`
  - `MD5`
    
## Requirements
- .NET SDK (6.0 or later recommended)
