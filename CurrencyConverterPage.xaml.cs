using Stanishewski253505.Services;
using Stanishewski253505.Entities;
using static SQLite.SQLite3;
namespace Stanishewski253505;

public partial class CurrencyConverterPage : ContentPage
{
    private readonly IRateService _RateService;
	private DateTime CurrDate;
    private string? CurrentCurrency { get; set; }
    public List<Rate> RatesList { get; set; }
    public CurrencyConverterPage(IRateService rateservice)
	{
		InitializeComponent();
        RatesList = new();
        _RateService = rateservice;
        CurrDate = DateTime.Now;
	}
    void LoadedLabel(object sender, EventArgs e)
	{
        RatesList = _RateService.GetRates(CurrDate).ToList();
        CollView.ItemsSource = RatesList;
    }
    void GetDateFromPicker(object sender, EventArgs e)
	{
		CurrDate = DatePick.Date;
        LoadedLabel(sender, e);     
	}
    void Byn_changed(object sender, EventArgs e)
    {

            decimal num;
            if (Decimal.TryParse(BYN_entry.Text, out num))
            {
                Rate? curr_rate;
                curr_rate = RatesList.Find(x => x.Cur_Abbreviation == CurrentCurrency);
                decimal result = 0;
                if (curr_rate != null)
                {
                    result = num / (decimal)curr_rate.Cur_OfficialRate;
                    CUR_entry.Text = result.ToString($"F{3}");
                }
            }
            else
            {
                CUR_entry.Text = "Error";
            }
    }
    void Cur_changed(object sender, EventArgs e)
    {

            decimal num;
            if (Decimal.TryParse(CUR_entry.Text, out num))
            {
                Rate? curr_rate;
                curr_rate = RatesList.Find(x => x.Cur_Abbreviation == CurrentCurrency);
                decimal result = 0;
                if (curr_rate != null)
                {
                    result = num * (decimal)curr_rate.Cur_OfficialRate;
                    BYN_entry.Text = result.ToString($"F{3}");
                }
            }
            else
            {
                BYN_entry.Text = "Error";
            }
    }
    void RadioButtonChoise(object sender, EventArgs e)
    {
        RadioButton selectedRadioButton = ((RadioButton)sender);
        CurrentCurrency = selectedRadioButton.Value.ToString();
    }
}