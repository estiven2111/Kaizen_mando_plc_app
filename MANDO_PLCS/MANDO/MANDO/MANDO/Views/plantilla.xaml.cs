using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MANDO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class plantilla : ContentPage
    {
        public plantilla()
        {
            InitializeComponent();
        }

        public class CardView : ContentView
        {
            public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(CardView), string.Empty);
            public static readonly BindableProperty CardDescriptionProperty = BindableProperty.Create(nameof(CardDescription), typeof(string), typeof(CardView), string.Empty);
            // ...

            public string CardTitle
            {
                get => (string)GetValue(CardTitleProperty);
                set => SetValue(CardTitleProperty, value);
            }

            public string CardDescription
            {
                get => (string)GetValue(CardDescriptionProperty);
                set => SetValue(CardDescriptionProperty, value);
            }
            // ...
        }

    }
}