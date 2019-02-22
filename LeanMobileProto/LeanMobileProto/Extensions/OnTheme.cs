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

        public T Current
        {
            get
            {
                switch (AppSettings.Current.Theme)
                {
                    case AppTheme.Dark:
                        return Dark;
                        
                    case AppTheme.Light:
                        return Light;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public static implicit operator T(OnTheme<T> onTheme)
        {
            return onTheme.Current;
        }
    }
}
