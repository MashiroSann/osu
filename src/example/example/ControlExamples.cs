using System.Reflection;
using osu.Framework.Graphics;

namespace OsuUiKit.Example;

public sealed record ControlExample(string Name, string CallSnippet, Type ControlType);

public static class ControlExamples
{
    public static IReadOnlyList<ControlExample> GetAllCallableControlExamples()
        => getCallableControlTypes()
           .Select(t => new ControlExample(t.FullName ?? t.Name, $"var control = new {t.FullName}();", t))
           .ToArray();

    public static Drawable? CreateInstance(Type controlType)
    {
        if (!typeof(Drawable).IsAssignableFrom(controlType))
            return null;

        if (controlType.GetConstructor(Type.EmptyTypes) is null)
            return null;

        try
        {
            return Activator.CreateInstance(controlType) as Drawable;
        }
        catch
        {
            return null;
        }
    }

    private static IEnumerable<Type> getCallableControlTypes()
        => typeof(OsuColour).Assembly
           .GetExportedTypes()
           .Where(t => t.IsClass
                       && !t.IsAbstract
                       && typeof(Drawable).IsAssignableFrom(t)
                       && !isCompilerGenerated(t)
                       && t.GetConstructor(Type.EmptyTypes) is not null)
           .OrderBy(t => t.FullName, StringComparer.Ordinal);

    private static bool isCompilerGenerated(MemberInfo type)
        => type.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any();
}
