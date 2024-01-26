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
            Buffer.BlockCopy(timestampBytes, 2, guidBytes, 0, 6);
            Buffer.BlockCopy(randomBytes, 0, guidBytes, 6, 10);
            Array.Reverse(guidBytes, 0, 4);
            Array.Reverse(guidBytes, 4, 2);

            return new Guid(guidBytes);
        }
    }
    public interface IGuidGenerator
    {
        Guid Create();
    }
}
