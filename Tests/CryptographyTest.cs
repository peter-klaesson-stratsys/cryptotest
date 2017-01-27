using Crypto;
using NUnit.Framework;

namespace Tests
{
    public class CryptographyTest
    {
        [Test]
        public void TestEncryptDecrypt()
        {
            var cryptography = new Cryptography();
            var encrypted = cryptography.EncryptString("hemligt", "lösenord");
            var decrypted = cryptography.DecryptString(encrypted, "lösenord");

            Assert.That(decrypted, Is.EqualTo("hemligt"));
        }

        [Test]
        public void EncryptDecryptUrlParameters()
        {
            var cryptography = new Cryptography();
            var encrypted = cryptography.EncryptString("username=user&timeStamp=20170127T09:03:01Z", "Nr8t98k6Se9i11t7");
            var decrypted = cryptography.DecryptString(encrypted, "Nr8t98k6Se9i11t7");

            Assert.That(decrypted, Is.EqualTo("username=user&timeStamp=20170127T09:03:01Z"));
        }
    }
}
