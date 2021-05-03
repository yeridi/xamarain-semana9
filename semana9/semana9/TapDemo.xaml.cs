using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace semana9.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TapDemo : ContentPage
    {
        int tapCount;
        readonly Label label;
        public TapDemo()
        {
            InitializeComponent();
            var image = new Image
            {
                Source = "dog.jpg",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            var tapGestureRecognier = new TapGestureRecognizer();
            tapGestureRecognier.NumberOfTapsRequired = 2;
            tapGestureRecognier.Tapped += OnTapGestureRecognizer;
            image.GestureRecognizers.Add(tapGestureRecognier);

            label = new Label
            {
                Text = "Tap the photo",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Content = new StackLayout 
            { 
                Padding = new Thickness(20, 100),
                Children =
                { 
                    image,
                    label
                }
            };
        }
        void OnTapGestureRecognizer(object sender, EventArgs args) 
        {
            tapCount++;
            label.Text = String.Format("{0} tap{1} so far!",
                    tapCount,
                    tapCount == 1 ? "" : "s");

            var imageSender = (Image)sender;
            //look the changue of the image
            if (tapCount % 2 == 0)
            {
                imageSender.Source = "dog.jpg";
            }
            else 
            {
                imageSender.Source = "wolf.jpg";
            };
        }
    }
}