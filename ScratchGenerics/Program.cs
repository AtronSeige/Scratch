using System;

namespace ScratchGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool
            string sbtT = "T";
            string sbtY = "Y";

            string sbfF = "F";
            string sbfN = "N";

            bool btT = To<bool>(sbtT);
            bool btY = To<bool>(sbtY);
            bool bfF = To<bool>(sbfF);
            bool bfN = To<bool>(sbfN);

            bool bd = Default<bool>();
            testme tm = Default<testme>();

            //int16
            string si16_null = null;
            string si16_empty = "";
            string si16_0 = "0";
            string si16_int = "12341234";

            //int32
            //int64

            Console.ReadLine();
        }

        public static T Default<T>()
        {
            T x = default(T);
            //Jaco: make it write out null
            Console.WriteLine($"default<T> is {x}");

            return x;

        }

        public static T To2<T>(string text)
        {
            Type type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

            if (typeof(T) == typeof(bool))
            {
                if (!string.IsNullOrWhiteSpace(text) && (text == "Y" || text == "T"))
                {
                    return (T)Convert.ChangeType("true", type);
                }
                else
                {
                    return default(T);
                }
            }

            //if it is a number, return the default of sero
            if (string.IsNullOrWhiteSpace(text) &&
                ((typeof(T) == typeof(Int16) || typeof(T) == typeof(UInt16)) ||
                ((typeof(T) == typeof(Int32) || typeof(T) == typeof(UInt32)) ||
                ((typeof(T) == typeof(Int64) || typeof(T) == typeof(UInt64))))))
            {
                return default(T);
            }

            //has no value and is nullable
            if (string.IsNullOrWhiteSpace(text) && (Nullable.GetUnderlyingType(typeof(T)) != null))
                return default(T);
            else
                return (T)Convert.ChangeType(text, type);
        }

        public static T To<T>(string text)
        {
            bool isNullable = (Nullable.GetUnderlyingType(typeof(T)) != null);

            Type type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

            if (typeof(T) == typeof(bool))
            {
                if (string.IsNullOrWhiteSpace(text))
                    return default(T);

                if (text == "Y" || text == "T")
                    text = "true";
                else if (text == "N" || text == "F")
                    text = "false";
                else
                    text = "false";
            }
            else if (string.IsNullOrWhiteSpace(text) && (typeof(T) == typeof(Int16) || typeof(T) == typeof(UInt16)))
                text = "0";
            else if (string.IsNullOrWhiteSpace(text) && (typeof(T) == typeof(Int32) || typeof(T) == typeof(UInt32)))
                text = "0";
            else if (string.IsNullOrWhiteSpace(text) && (typeof(T) == typeof(Int64) || typeof(T) == typeof(UInt64)))
                text = "0";

            if (string.IsNullOrWhiteSpace(text) && isNullable)
                return default(T);
            else
                return (T)Convert.ChangeType(text, type);
        }

        public class testme {
            public int ID { get; set; }
			public string Name { get; set; }
		}
    }
}
