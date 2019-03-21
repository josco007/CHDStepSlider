# CHDStepSlider

If this project help you reduce time to develop, you can give me a cup of coffee :)
 
 [![paypal](https://www.paypalobjects.com/en_US/MX/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=H2TEDQDPJ557A)


This is a step slider component

![Alt Text](https://media.giphy.com/media/1gUp6rI8u5gMOM97rd/giphy.gif)


<table>
<thead>
<tr>
<th>Platform</th>
<th align="center">Version</th>
</tr>
</thead>
<tbody>
<tr>
<td>Xamarin.iOS</td>
<td align="center">Not tested</td>
</tr>
<tr>
<td>Xamarin.Android</td>
<td align="center">API 14+, Not tested on lower</td>
</tr>
<tr>
<td>Windows 10 UWP</td>
<td align="center">Not tested</td>
</tr>
</tbody>
</table>


<h3> Install via nuget</h3>

https://www.nuget.org/packages/CHD.StepSlider

<h3>How to use</h3>


<details><summary><b>XAML expand</b></summary>
<p>



    <?xml version="1.0" encoding="utf-8" ?>
    <ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:SelectorSlide"
             xmlns:chd="clr-namespace:CHD;assembly=CHD.StepSlider"
             x:Class="SelectorSlide.MainPage">

      <StackLayout BackgroundColor="White">

          <chd:StepSlider x:Name="SelectorSlideSse" Margin="15,0,15,0" VerticalOptions="CenterAndExpand"/>
      </StackLayout>

    </ContentPage>


</p>
</details>

   


<details><summary><b>CS expand</b></summary>
<p>

<h5>Your CS code should be like this</h5>
        
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


</p>
</details>

    
    
    
