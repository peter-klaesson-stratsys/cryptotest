using System;
using jwt;
using NUnit.Framework;

namespace Tests
{
    public class JsonWebTokenTest
    {
        [Test]
        public void TestEncryptDecrypt()
        {
            var jwt = new JsonWebToken();
            var encrypted = jwt.Encrypt("hemligt", "lösenord");
            var decrypted = jwt.Decrypt<string>(encrypted, "lösenord");

            Assert.That(decrypted, Is.EqualTo("hemligt"));
        }

        [Test]
        public void EncryptDecryptUrlParameters()
        {
            var jwt = new JsonWebToken();
            var utcTime = new DateTime(2017, 01, 01, 8, 30, 20).ToUniversalTime();
            var parameters = new Parameters
            {
                UserName = "user",
                TimeStamp = utcTime
            };
            var encrypted = jwt.Encrypt(parameters, "Nr8t98k6Se9i11t7hfhfhfghjgfhjghkrt7etyjrtyjtyjdtyjhdtyjfgyjgfyjy");
            var decrypted = jwt.Decrypt<Parameters>(encrypted, "Nr8t98k6Se9i11t7hfhfhfghjgfhjghkrt7etyjrtyjtyjdtyjhdtyjfgyjgfyjy");

            Assert.That(decrypted.UserName, Is.EqualTo("user"));
            Assert.That(decrypted.TimeStamp, Is.EqualTo(utcTime));
        }

        private class Parameters
        {
            public DateTime TimeStamp { get; set; }
            public string UserName { get; set; }
        }
    }
}