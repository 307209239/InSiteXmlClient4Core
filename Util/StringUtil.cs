using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;
using InSiteXmlClient4Core.Exceptions;

namespace InSiteXmlClient4Core.Util
{
    public class StringUtil
    {
        public const char Comma = ',';
        public const char Period = '.';
        public const char Colon = ':';
        public const char Dash = '-';
        public const char Underscore = '_';

        public static void ConvertFirstToUpper(ref string data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (data.Length <= 0)
                return;
            string str = new string(data[0], 1);
            data = data.Remove(0, 1);
            string upper = str.ToUpper();
            data = data.Insert(0, upper);
        }

        public static void ConvertFirstToLower(ref string data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (data.Length <= 0)
                return;
            string str = new string(data[0], 1);
            data = data.Remove(0, 1);
            string lower = str.ToLower();
            data = data.Insert(0, lower);
        }

        public static bool TrimEnd(ref string data, string trimString)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (trimString == null)
                throw new ArgumentNullException(nameof(trimString));
            bool flag = false;
            if (data.EndsWith(trimString))
            {
                data = data.Remove(data.Length - trimString.Length, trimString.Length);
                flag = true;
            }
            return flag;
        }

        public static bool TrimStart(ref string data, string trimString)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (trimString == null)
                throw new ArgumentNullException(nameof(trimString));
            bool flag = false;
            if (data.StartsWith(trimString))
            {
                data = data.Remove(0, trimString.Length);
                flag = true;
            }
            return flag;
        }

        public static bool IsEmptyString(string data)
        {
            return string.IsNullOrEmpty(data);
        }

        public static bool IsNumericString(string data)
        {
            double d = 0;
           return double.TryParse(data, out d);
            
        }

        public static bool ToBool(string data)
        {
            if (data == null)
                throw new CamstarException("CannotConvertValueToBool", "(null)");
            bool flag;
            if (string.Compare(data, bool.TrueString, true) == 0)
                flag = true;
            else if (string.Compare(data, bool.FalseString, true) == 0)
                flag = false;
            else if (string.Compare(data, "1", true) == 0)
            {
                flag = true;
            }
            else
            {
                if (string.Compare(data, "0", true) != 0)
                    throw new CamstarException("CannotConvertValueToBool", data);
                flag = false;
            }
            return flag;
        }

        public static string[] GetStringList(string items, char separator)
        {
            if (string.IsNullOrEmpty(items))
                return new string[0];
            return ((IEnumerable<string>)items.Split(separator)).Select<string, string>((Func<string, string>)(i => i.Trim())).ToArray<string>();
        }

        public static ArrayList GetStringArrayList(string items, char separator)
        {
            ArrayList arrayList = new ArrayList();
            string[] strArray = (string[])null;
            char[] chArray = new char[1] { separator };
            if (items != null)
                strArray = items.Split(chArray);
            if (strArray != null)
            {
                int length = strArray.Length;
                for (int index = 0; index < length; ++index)
                    arrayList.Add((object)strArray[index].Trim());
            }
            return arrayList;
        }

        public static bool FindItem(string item, string items)
        {
            bool flag = false;
            string[] stringList = StringUtil.GetStringList(items, ',');
            if (stringList != null && stringList.Length > 0)
            {
                foreach (string str in stringList)
                {
                    if (str == item)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        public static string BytesArrayToHexString(byte[] bytesArray)
        {
            if (bytesArray == null)
                throw new ArgumentNullException(nameof(bytesArray));
            string empty = string.Empty;
            int length = bytesArray.Length;
            for (int index = 0; index < length; ++index)
                empty += bytesArray[index].ToString("x2");
            return empty;
        }

        public static string UnicodeToCompressedBase64(string inp)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                DeflateStream deflateStream = new DeflateStream((Stream)memoryStream, CompressionMode.Compress, true);
                byte[] bytes = new UnicodeEncoding().GetBytes(inp);
                deflateStream.Write(bytes, 0, bytes.Length);
                deflateStream.Close();
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        //public static string ToDeflatedCompressedBase64String(string inp, string ns)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    TextWriter textWriter = (TextWriter)new StringWriter(sb);
        //    new XmlSerializer(typeof(string), ns).Serialize(textWriter, (object)inp);
        //    textWriter.Close();
        //    sb.ToString();
        //    Deflater deflater = new Deflater(1, true);
        //    MemoryStream memoryStream = new MemoryStream();
        //    byte[] buffer = new byte[256];
        //    deflater.SetInput(new UnicodeEncoding().GetBytes(inp));
        //    deflater.Flush();
        //    int count;
        //    do
        //    {
        //        count = deflater.Deflate(buffer, 0, buffer.Length);
        //        memoryStream.Write(buffer, 0, count);
        //    }
        //    while (count > 0);
        //    return Convert.ToBase64String(memoryStream.ToArray());
        //}

        public static string CompressedBase64ToUnicode(string compressed)
        {
            try
            {
                using (MemoryStream memoryStream1 = new MemoryStream(Convert.FromBase64String(compressed)))
                {
                    DeflateStream deflateStream = new DeflateStream((Stream)memoryStream1, CompressionMode.Decompress, true);
                    byte[] buffer = new byte[256];
                    MemoryStream memoryStream2 = new MemoryStream();
                    int count;
                    do
                    {
                        count = deflateStream.Read(buffer, 0, buffer.Length);
                        memoryStream2.Write(buffer, 0, count);
                    }
                    while (count > 0);
                    deflateStream.Close();
                    return new UnicodeEncoding().GetString(memoryStream2.ToArray());
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string StripHTMLTags(string html)
        {
            string s = (string)null;
            if (html != null)
                s = Regex.Replace(html, "<[^>]+?>", "");
            return HttpUtility.HtmlDecode(s);
        }
    }
}
