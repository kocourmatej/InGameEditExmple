using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public static class GameTime
    {
        private static int id = 0;
        public static Random random = new Random();

        public static int assignID()
        {
            id++;
            return id;
        }

        public static string assignInstanceName(int digits = 8)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0) { return result; }

            return result + random.Next(16).ToString("X");
        }
    }
}
