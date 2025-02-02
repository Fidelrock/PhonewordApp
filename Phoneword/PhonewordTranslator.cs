﻿using System.Text;

namespace core;

public static class PhonewordTranslator
{
    public static string ToNumber(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
            return null;


        raw = raw.ToUpperInvariant();

        var newNumber = new StringBuilder();

        foreach (var c in raw)
        {
            if (" -0123456789".Contains(c))
                newNumber.Append(c);
            else
            {
                var result = TranslateToNumber(c);
                if (result != null)
                    newNumber.Append(result);
                //Bad Character
                else
                {
                    return null;
                }
            }
        }
        return newNumber.ToString();

    }

    static bool Contains(this string keyString, char C)
    {
        return keyString.IndexOf(C) >= 0;
    }

    static readonly string[] digits =
    {
        "ABC","DEF","GHI","JKL","MNO","PQRS","TUV","WXYZ"
    };

    static int? TranslateToNumber(char C)
    {
        for(int i = 0; i<digits.Length; i++)
        {
            if (digits[i].Contains(C))
                return 2 + i;
        }
        return null;
    }
}