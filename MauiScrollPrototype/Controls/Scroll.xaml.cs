namespace MauiScrollPrototype.Controls;

public partial class Scroll : ContentView
{
	public Scroll()
	{
		InitializeComponent();
	}

    private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
    {
        if (e.StatusType == GestureStatus.Completed)
        {
            return;
        }

        Output.Text = e.TotalY.ToString();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Output.Text = "Tap";
    }
}