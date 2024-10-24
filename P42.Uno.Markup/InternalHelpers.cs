﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace P42.Uno.Markup
{
    public static class InternalHelpers
    {
        public static int ToInt(this Enum enumValue) => Convert.ToInt32(enumValue, CultureInfo.InvariantCulture);

        public static List<string> GetExcepts(object except)
        {
            if (except is null)
                return null;
            if (except is string str)
                return new List<string> { str };
            if (except is IEnumerable<string> enumerable)
                return new List<string>(enumerable);
            throw new Exception("BindFont except: argument must be null, string, or IEnumerable<string>");
        }

    }
}
