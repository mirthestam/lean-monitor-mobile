using System;
using System.Collections.Generic;
using System.Text;
using LeanMobileProto.Enums;

namespace LeanMobileProto.Extensions
{
    public class OnTheme<T>
    {
        // Concept of theming based upon Theme Extension written by Winston Gubantes
        // https://github.com/winstongubantes/Xamarin.Forms
        
        public T Light { get; set; } = default(T);

        public T Dark { get; set; } = default(T);

        public T Current => Dark;

        public static implicit operator T(OnTheme<T> onTheme)
        {
            return onTheme.Current;
        }
    }
}
