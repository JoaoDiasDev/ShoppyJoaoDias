using System.Text.RegularExpressions;

namespace ShopJoaoDias.Extensions
{
    public class Functions
    {
        public static string FriendlyUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return "";
            url = url.ToLower().Trim();

            if (url.Length > 100)
            {
                url = url.Substring(0, 100);
            }

            url = url.Replace("Б", "B");
            url = url.Replace("б", "b");
            char[] replacerList = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();

            for (int i = 0; i < replacerList.Length; i++)
            {
                string strChr = replacerList[i].ToString();
                if (url.Contains(strChr))
                {
                    url = url.Replace(strChr, string.Empty);
                }
            }

            Regex r = new Regex("[^a-zA-Z0-9_-]");
            url = r.Replace(url, "-");
            while (url.IndexOf("--") > -1)
                url = url.Replace("--", "-");
            return url;
        }
    }
}
