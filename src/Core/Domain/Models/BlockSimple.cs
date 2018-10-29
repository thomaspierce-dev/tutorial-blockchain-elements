namespace BlockBoys.Tutorial.Blockchain.Core.Domain.Models
{
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Services;

    public class BlockSimple : IBlockSimple
    {
        private int _number;
        private string _data;
        private ulong _nonce;
        private string _hash;
        private readonly ICryptoService _cryptoService;

        public int Number { 
            get { return _number; }
            set
            {
                _number = value;
                GenerateHash();
            }
        }
        public string Data { 
            get { return _data; }
            set
            {
                _data = value;
                GenerateHash();
            }
        }
        public ulong Nonce { 
            get { return _nonce; }
            set
            {
                _nonce = value;
                GenerateHash();
            }
        }
        public string Hash 
        { 
            get
            {
                if (string.Empty == _hash) GenerateHash();
                return _hash;
            }
        }

        public BlockSimple(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
            Number = 0;
            Data = string.Empty;
            Nonce = 0;
            _hash = string.Empty;
        }

        public BlockSimple(ICryptoService cryptoService, int number, string data, ulong nonce)
        {
            _cryptoService = cryptoService;
            Number = number;
            Data = data;
            Nonce = nonce;
        }

        public bool IsSolved()
        {
            return IsSolved(Hash);
        }

        public void Mine()
        {
            var digest = string.Empty;
            for (ulong nonce=0; nonce < ulong.MaxValue; nonce++)
            {
                digest = GenerateHash(nonce);
                if (IsSolved(digest))
                {
                    Nonce = nonce;
                    break;
                }
            }
        }

        private void GenerateHash()
        {
            _hash = GenerateHash(Nonce);
        }

        private string GenerateHash(ulong nonce)
        {
            var message = string.Format($"{nonce}{_number}{_data}");
            var digest = _cryptoService.GenerateHash(message);
            return digest;
        }

        private bool IsSolved(string digest)
        {
            const string prefix = "00000";
            return string.Compare(digest, 0, prefix, 0, 5) == 0;
        }
    }
}