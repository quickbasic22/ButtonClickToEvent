using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ButtonClickToEvent
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private int increaseCount;

        public event PropertyChangedEventHandler PropertyChanged;

        public Command<Entry> ButtonClickCommand { get; set; }
        public int IncreaseCount 
        {
            get => increaseCount;
            set 
            { 
                increaseCount = value; 
                OnPropertyChanged(); 
            } 
        }
        public MainPageViewModel()
        {
            increaseCount += 1;
            ButtonClickCommand = new Command<Entry>(Button_Click);
        }

        private void Button_Click(object obj)
        {
           var entry = (Entry)obj;
            int count = 0;

            try
            {
                count = Int32.Parse(entry.Text);
            }
            catch (Exception)
            {
                entry.Text = "Enter a Number";
            }         

            IncreaseCount += count;
        }


        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}