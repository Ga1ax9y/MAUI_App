using Stanishewski253505.Entities;
using Stanishewski253505.Services;
namespace Stanishewski253505;

public partial class SQLitePage : ContentPage
{
	public SQLitePage()
	{
		InitializeComponent();
        
    }
    void PickerSelectedIndexChanged(object sender, EventArgs e)
    {

        header.Text = $"Вы выбрали: {RoomPicker.SelectedItem}";
        SQLiteService service = new SQLiteService();
        CollView.ItemsSource = service.GetRoomService(RoomPicker.SelectedIndex);

    }
    void NewPickerGroup(object sender, EventArgs e)
    {
        SQLiteService service = new SQLiteService();
        RoomPicker.ItemsSource = service.GetAllRooms().ToList();
    }
}