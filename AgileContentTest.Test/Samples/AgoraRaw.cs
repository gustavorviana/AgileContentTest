namespace AgileContentTest.Test.Samples
{
    public static class AgoraRaw
    {
        public const string Header = "#Version: 1.0\r\n#Date: 15/12/2017 23:01:06\r\n#Fields: provider http-method status-code uri-path time-taken response-size cache-status\r\n";

        public const string Sample1 = "\"MINHA CDN\" GET 200 /robots.txt 100 312 HIT";
        public const string Sample2 = "\"MINHA CDN\" POST 200 /myImages 319 101 MISS";
        public const string Sample3 = "\"MINHA CDN\" GET 404 /not-found 143 199 MISS";

    }
}
