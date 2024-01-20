using System.Security.Cryptography;

namespace LibraryApp.Utils
{
    public class GuidGenerator : IGuidGenerator
    {
        private static readonly RandomNumberGenerator RandomNumberGenerator = RandomNumberGenerator.Create();

        public GuidGenerator()
        {
        }
        public Guid Create()
        {
            var randomBytes = new byte[10];
            RandomNumberGenerator.GetBytes(randomBytes);

            long timestamp = DateTime.UtcNow.Ticks / 10000L;

            byte[] timestampBytes = BitConverter.GetBytes(timestamp);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(timestampBytes);
            }

            byte[] guidBytes = new byte[16];
            return new Guid(guidBytes);
        }
    }
}