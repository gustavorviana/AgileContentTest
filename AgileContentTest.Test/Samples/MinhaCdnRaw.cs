namespace AgileContentTest.Test.Samples
{
    public static class MinhaCdnRaw
    {
        public const string Sample1 = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2";
        public const string Sample2 = "101|200|MISS|\"POST /myImages HTTP/1.1\"|319.4";
        public const string Sample3 = "199|404|MISS|\"GET /not-found HTTP/1.1\"|142.9";
        public const string Sample4 = "312|200|INVALIDATE|\"GET /robots.txt HTTP/1.1\"|245.1";
    }
}
