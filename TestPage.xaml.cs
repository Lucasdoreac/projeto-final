using Microsoft.Maui.Controls;

namespace appClassePessoaBD.Views
{
    public class TestPage : ContentPage
    {
        public TestPage()
        {
            Content = new Label
            {
                Text = "TESTE - APP FUNCIONA!",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
        }
    }
}
