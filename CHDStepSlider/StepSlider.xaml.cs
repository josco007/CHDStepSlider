using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CHD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StepSlider : ContentView
    {
        private List<object> _options;
        private double StepValue;

        public Color OptionHideColor { get; set; } = Color.LightGray;
        public Color OptionShowColor { get; set; } = Color.Black;

        public Action<StepSlider, int> OnPositionChanged;
        private int _oldPosition;
        private int _currentPosition;

        public StepSlider()
        {
            InitializeComponent();
            StepValue = 1.0;
        }

        private void SetOptions()
        {
            OptionsRlt.Children.Clear();
            for (int i = 0; i < _options.Count; i++)
            {
                AddToOptionsRlt(_options[i], i);
            }

        }

        private void AddToOptionsRlt(object obj, int position)
        {
            if (obj is string str)
            {

                Label lblText = new Label
                {
                    HorizontalOptions = LayoutOptions.Start,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalOptions = LayoutOptions.EndAndExpand
                };

                lblText.Text = str;
                OptionsRlt.Children.Add(lblText);
                lblText.TranslateTo(position * ((SliderMain.Width - 40) / SliderMain.Maximum), 0, 100);
            }
            else if (obj is View view)
            {
                OptionsRlt.Children.Add(view);
                view.HorizontalOptions = LayoutOptions.Start;
                view.VerticalOptions = LayoutOptions.EndAndExpand;
                view.TranslateTo(position * ((SliderMain.Width - 40) / SliderMain.Maximum), 0, 100);
            }

            HideOrShowWhatIsNeeded();

        }

        private void SetMaximum()
        {
            SliderMain.Maximum = _options.Count == 0 || _options.Count == 1 ? 1 : _options.Count - 1;
        }

        public void SetBackgroundColor(Color color)
        {
            RootRlt.BackgroundColor = color;
            SliderMain.BackgroundColor = color;
        }

        public void SetThumbColor(Color color)
        {
            SliderMain.ThumbColor = color;
        }

        public void SetMaximumTrackColor(Color color)
        {
            SliderMain.MaximumTrackColor = color;
        }

        public void SetMinimumTrackColor(Color color)
        {
            SliderMain.MinimumTrackColor = color;
        }

        public void SetThumbImage(FileImageSource imageSrc)
        {
            SliderMain.ThumbImage = imageSrc;
        }

        public void SetOptions(List<string> options)
        {
            _options = new List<object>();
            SetMaximum();
            foreach (string str in options)
            {
                AddOption(str);
            }

        }
        public void AddOption(string option)
        {
            _options.Add(option);
            SetMaximum();
            AddToOptionsRlt(option, _options.Count - 1);
        }


        /*
        public void SetOptions(List<View> options)
        {
            _options = new List<object>();
            SetMaximum();
            foreach (View view in options)
            {
                AddOption(view);
            }
        }

        public void AddOption(View view)
        {
            _options.Add(view);
            SetMaximum();
            AddToOptionsRlt(view, _options.Count - 1);
        }
        */

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            _currentPosition = Convert.ToInt32(Math.Round(e.NewValue / StepValue));

            SliderMain.Value = _currentPosition * StepValue;

            HideOrShowWhatIsNeeded();
            if (_oldPosition != _currentPosition)
            {
                OnPositionChanged?.Invoke(this, _currentPosition);
            }
            _oldPosition = _currentPosition;
        }

        private void HideOrShowWhatIsNeeded()
        {
            int i = 0;
            foreach (View view in OptionsRlt.Children)
            {
                if (SliderMain.Value < i)
                {
                    view.TranslateTo(i * ((SliderMain.Width - 40) / SliderMain.Maximum), 15, 100);
                    if (view is Label label)
                    {
                        label.TextColor = OptionHideColor;
                    }

                }
                else
                {
                    view.TranslateTo(i * ((SliderMain.Width - 40) / SliderMain.Maximum), 0, 100);
                    if (view is Label label)
                    {
                        label.TextColor = OptionShowColor;
                    }
                }
                i++;
            }
        }

        private void SliderMain_SizeChanged(object sender, EventArgs e)
        {
            SetOptions();
        }
        public int GetPosition()
        {
            return _currentPosition;
        }
    }
}