namespace RobotApp.Extensions
{
    using System.Collections.Generic;

    static class IEnumerableStringExtensions
    {
        public static IEnumerable<string> RemoveEmptyElements(this IEnumerable<string> Container)
        {
            foreach (string Element in Container)
            {
                if (!string.IsNullOrWhiteSpace(Element))
                    yield return Element;
            }
        }
    }
}
