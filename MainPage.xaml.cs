namespace HandlerContention
{
	public partial class MainPage : ContentPage
	{
		private const int timerInterval = 2;
		private readonly Timer gridStatusLabelTimer;
		private readonly Timer listViewStatusLabelTimer;



		public MainPage()
		{
			InitializeComponent();

			gridStatusLabelTimer = new(GridStatusLabelTimer_Tick, null, Timeout.Infinite, Timeout.Infinite);
			listViewStatusLabelTimer = new(ListViewStatusLabelTimer_Tick, null, Timeout.Infinite, Timeout.Infinite);
		}



		private void Grid_Tapped(object sender, TappedEventArgs e)
		{
			GridStatusLabel.Text = "Grid tapped";
			gridStatusLabelTimer.Change(TimeSpan.FromSeconds(timerInterval), Timeout.InfiniteTimeSpan);
		}



		private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			ListViewStatusLabel.Text = "ListView item tapped";
			listViewStatusLabelTimer.Change(TimeSpan.FromSeconds(timerInterval), Timeout.InfiniteTimeSpan);
		}



		private void GridStatusLabelTimer_Tick(object state)
		{
			MainThread.BeginInvokeOnMainThread(() =>
			{
				GridStatusLabel.Text = "";
			});
			gridStatusLabelTimer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
		}



		private void ListViewStatusLabelTimer_Tick(object state)
		{
			MainThread.BeginInvokeOnMainThread(() =>
			{
				ListViewStatusLabel.Text = "";
			});
			listViewStatusLabelTimer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
		}
	}
}
