using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeanMobile.Client.View.LiveAlgorithm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ContentProperty("ValueContent")]
    public sealed partial class StatisticView : ContentView
    {
        public static readonly BindableProperty LabelProperty = BindableProperty.Create(nameof(Label), typeof(string), typeof(StatisticView));

        public static readonly BindableProperty ValueContentProperty = BindableProperty.Create(nameof(ValueContent), typeof(Xamarin.Forms.View), typeof(StatisticView));

        public StatisticView()
        {
            InitializeComponent();
        }

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public Xamarin.Forms.View ValueContent
        {
            get => (Xamarin.Forms.View)GetValue(ValueContentProperty);
            set => SetValue(ValueContentProperty, value);
        }
    }
}