# cryptotest  
## Test of AES encryption - decryption using .NET  

The encrypted message is base64 encoded and could be used to encrypt/decrypt URL parameters using a private key.  
The IV is generated upon encryption and prepended to the encrypted data to garantee that the same message does not get encrypted to the same encrypted message twice.