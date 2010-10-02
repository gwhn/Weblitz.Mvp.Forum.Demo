namespace Weblitz.Mvp.Forum.Core.Extensions
{
    public static class String
    {
        public static int ToId(this string source)
        {
            int id;
            int.TryParse(source, out id);
            return id;
        }
    }
}