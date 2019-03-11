namespace LeanMobile.Settings
{
    public class AppSettings
    {
        private static AppSettings _current;

        public static AppSettings Current => _current ?? (_current = new AppSettings());

        public AppTheme Theme { get; set; } = AppTheme.Light;
    }
}
