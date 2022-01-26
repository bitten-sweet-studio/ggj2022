﻿using System;

public static class StringExtensions
{
    public static string AsProjectRelativePath(this string fullSystemPath)
    {
        int assetsFolderIndexOnString = fullSystemPath.IndexOf("Assets", StringComparison.Ordinal);
        return fullSystemPath.Substring(assetsFolderIndexOnString);
    }
}