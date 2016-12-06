using AdventOfCode.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.DayFive
{
    public class ChessPass : IProgram
    {
        public Control Run()
        {
            Console.Write("Please input the door id:\n> ");
            var input = Console.ReadLine();

            var generationModes = new List<IProgram>();
            generationModes.Add(new LinearPasswordGeneration(input));
            generationModes.Add(new OrderedPasswordGeneration(input));
            var menu = new Menu<IProgram>("Select Password Generation Mode:", generationModes);

            return menu.Ask().Run();
        }

        public override string ToString()
        {
            return "Day 5: How About a Nice Game of Chess?";
        }
    }

    internal class InterestingHash
    {
        public InterestingHash(string hash, long location)
        {
            this.hash = hash;
            this.location = location;
        }

        public string hash { get; }
        public long location { get; }
    }

    public class LinearPasswordGeneration : IProgram
    {
        protected static readonly int TASK_COUNT = 4;
        protected static readonly int CHUNK_SIZE = 50000;

        protected readonly string input;

        public LinearPasswordGeneration(string input)
        {
            this.input = input;
        }

        public Control Run()
        {
            var pass = GeneratePassword(8);

            Console.WriteLine("Generated password: {0}", pass);

            return Control.Continue;
        }

        public virtual string GeneratePassword(uint length)
        {
            var safeHashes = new ConcurrentBag<InterestingHash>();

            
            for (long alloc = 0; safeHashes.Count < length;)
            {
                var tasks = new Task[TASK_COUNT];

                for (int t = 0; t < TASK_COUNT; ++t)
                {
                    long from = alloc;
                    long to = alloc + CHUNK_SIZE;
                    alloc = to;
                    tasks[t] = Task.Factory.StartNew(() => {
                        using (MD5 md5 = MD5.Create())
                        {
                            for (long y = from; y < to; ++y)
                            {
                                var hash = GetMd5Hash(md5, string.Format("{0}{1}", input, y));

                                if (hash.StartsWith("00000"))
                                {
                                    safeHashes.Add(new InterestingHash(hash, y));
                                }
                            }
                        }
                    });
                }

                Task.WaitAll(tasks);
            }

            var hashes = safeHashes.ToArray();
            Array.Sort(hashes, ((a, b) => {
                if (a.location < b.location)
                {
                    return -1;
                }
                else if (a.location > b.location)
                {
                    return 1;
                }

                return 0;
            }));

            var password = new StringBuilder();
            for (int x = 0; x < length; ++x)
            {
                password.Append(hashes[x].hash[5]);
            }

            return password.ToString();
        }

        public string GetMd5Hash(string str)
        {
            using (MD5 md5 = MD5.Create())
            {
                return GetMd5Hash(md5, str);
            }
        }

        public string GetMd5Hash(MD5 md5, string str)
        {
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            StringBuilder hash = new StringBuilder();

            for (int i = 0; i < data.Length; ++i)
            {
                hash.Append(data[i].ToString("x2"));
            }

            return hash.ToString();
        }

        public override string ToString()
        {
            return "Linear Password Generation";
        }
    }

    internal class OrderedPasswordGeneration : LinearPasswordGeneration
    {
        public OrderedPasswordGeneration(string input) : base(input)
        { }

        public override string GeneratePassword(uint length)
        {
            var password = new char?[length];

            long alloc = 0;
            while (!Complete(password))
            {
                var safeHashes = new ConcurrentBag<InterestingHash>();
                var tasks = new Task[TASK_COUNT];

                for (int t = 0; t < TASK_COUNT; ++t)
                {
                    long from = alloc;
                    long to = alloc + CHUNK_SIZE;
                    alloc = to;
                    tasks[t] = Task.Factory.StartNew(() => {
                        using (MD5 md5 = MD5.Create())
                        {
                            for (long y = from; y < to; ++y)
                            {
                                var hash = GetMd5Hash(md5, string.Format("{0}{1}", input, y));

                                if (hash.StartsWith("00000"))
                                {
                                    safeHashes.Add(new InterestingHash(hash, y));
                                }
                            }
                        }
                    });
                }

                Task.WaitAll(tasks);

                var hashes = safeHashes.ToArray();
                Array.Sort(hashes, (a, b) => {
                    if (a.location < b.location)
                    {
                        return -1;
                    }
                    else if (a.location > b.location)
                    {
                        return 1;
                    }

                    return 0;
                });

                foreach (var hash in hashes)
                {
                    ApplyHash(hash, password);
                }
            }

            var pass = new StringBuilder();
            for (int i = 0; i < password.Length; ++i)
            {
                pass.Append(password[i].Value);
            }
            return pass.ToString();
        }

        private void ApplyHash(InterestingHash hash, char?[] password)
        {
            int idx = ExtractIndex(hash);
            if (!Occupied(password, idx))
            {
                password[idx] = ExtractChar(hash);
                PrintFound(password);
            }
        }

        private void PrintFound(char?[] password)
        {
            foreach (var ch in password)
            {
                if (ch.HasValue)
                {
                    Console.Write(ch.Value);
                }
                else
                {
                    Console.Write('_');
                }
            }
            Console.WriteLine();
        }

        private int ExtractIndex(InterestingHash hash)
        {
            switch (hash.hash[5])
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                default:
                    return -1;
            }
        }

        private char ExtractChar(InterestingHash hash)
        {
            return hash.hash[6];
        }

        private bool Occupied(char?[] password, int idx)
        {
            if (idx >= 0 && idx < password.Length)
            {
                return password[idx].HasValue;
            }

            return true;
        }

        private bool Complete(char?[] password)
        {
            for (int i = 0; i < password.Length; ++i)
            {
                if (!password[i].HasValue)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return "Ordered Password Generation";
        }
    }
}
