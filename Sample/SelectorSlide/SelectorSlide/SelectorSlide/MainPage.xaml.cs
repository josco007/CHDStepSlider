using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SelectorSlide
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            
            SelectorSlideSse.SetOptions(new List<string>
            {
                "MX$20",
                "MX$30",
                "MX$40",
                "MX$50+"
            });

            /*SelectorSlideSse.SetBackgroundColor(Color.Violet);
            SelectorSlideSse.OptionHideColor = Color.Green;
            SelectorSlideSse.OptionShowColor = Color.Red;
            SelectorSlideSse.SetThumbColor(Color.Brown);
            SelectorSlideSse.SetMinimumTrackColor(Color.Blue);
            SelectorSlideSse.SetMaximumTrackColor(Color.DarkMagenta);
            ^*/

            SelectorSlideSse.OnPositionChanged += (sse, pos)=>{
                Debug.WriteLine("new pos = " + pos);
                Debug.WriteLine("current pos = " + sse.GetPosition());
            };

        }

    }
}
