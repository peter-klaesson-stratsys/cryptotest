using Jose;

namespace jwt
{
    public class JsonWebToken
    {
        private JweAlgorithm _algorithm = JweAlgorithm.PBES2_HS512_A256KW;
        private JweEncryption _encryption = JweEncryption.A256CBC_HS512;

        /// <summary>
        /// Encrypts payload using a shared secret
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="secret"></param>
        /// <returns>The encrypted result as base64Url encoded token</returns>
        public string Encrypt(object payload, string secret)
        {
            return JWT.Encode(payload, secret, _algorithm, _encryption);
        }

        /// <summary>
        /// Decrypts the jwt token using a shared secret
        /// </summary>
        /// <param name="encrypted"></param>
        /// <param name="secret"></param>
        /// <returns>payload of jwt token</returns>
        public T Decrypt<T>(string encrypted, string secret)
        {
            return JWT.Decode<T>(encrypted, secret, _algorithm, _encryption);
        }
    }
}
