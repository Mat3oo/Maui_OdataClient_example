namespace testOdataMaui;

public partial class MainPage : ContentPage
{
	int count = 0;
	readonly ODataServiceContext odataContext;

	public MainPage()
	{
		InitializeComponent();
		odataContext = new(new Uri("http://services.odata.org/TripPinRESTierService/(S(3mslpb2bc0k5ufk24olpghzx))/"));
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		try
		{
			var result = odataContext.People.Execute();
		}
		catch (Exception ex)
		{
			string displayMessage = $"{ex.Message}\n\n{ex.StackTrace}";
			const string title = "OData error";
#if MACCATALYST
			_ = await DisplayPromptAsync(title, displayMessage, "Ok");
#else
			await DisplayAlert(title, displayMessage, "Ok");
#endif
		}

		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}
