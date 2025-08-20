using System.Text.RegularExpressions;
using Urlite.Domain.ValueObjects;

namespace Urlite.Application.Services;

public static class ShortCodeGenerator
{
    private static readonly string ValidChars =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private static readonly Random Random = new();

    public static ShortCode Generate()
    {
        var code = new char[6];
        for (int i = 0; i < code.Length; i++)
        {
            code[i] = ValidChars[Random.Next(ValidChars.Length)];
        }

        return new ShortCode(new string(code));
    }
}
