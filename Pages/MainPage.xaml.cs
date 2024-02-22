namespace Stanishewski253505
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Spanked {count} time";
            else
            {
                CounterBtn.Text = $"Spanked {count} times";
                if (count == 10) BillyPicture.Source = "billy5.gif";
                else if (count == 25) BillyPicture.Source = "billy4.gif";
                else if (count == 50) BillyPicture.Source = "billy3.gif";
                else if (count == 100) BillyPicture.Source = "billyfinal.gif";
                else if (count == 105)
                {
                    BillyPicture.Source = "billysend.jpg";

                }
            }

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
