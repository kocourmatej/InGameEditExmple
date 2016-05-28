using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public static class MathHelper
    {
        public static T Clamp<T>(T value, T max, T min)
        where T : IComparable<T>
        {
            T result = value;
            if (value.CompareTo(max) > 0)
                result = max;
            if (value.CompareTo(min) < 0)
                result = min;
            return result;
        }

        public static string digitsFromString(string str)
        {
            string resultString = null;
            Regex regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(str, "");

            return resultString;
        }

        public static vec2 MovePointTowards(vec2 start, vec2 end, double distance)
        {
            var vector = new vec2(end.X - start.X, end.Y - start.Y);
            var length = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            var unitVector = new vec2(vector.X / length, vector.Y / length);

            return new vec2(start.X + unitVector.X * distance, start.Y + unitVector.Y * distance);
        }
    }
}
