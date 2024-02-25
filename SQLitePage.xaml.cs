using Stanishewski253505.Entities;
using Stanishewski253505.Services;
using System.Collections.Generic;
namespace Stanishewski253505;

public partial class SQLitePage : ContentPage
{
    SQLiteService ss= new SQLiteService();
    public SQLitePage()
	{
		InitializeComponent();
        
    }
    void PickerSelectedIndexChanged(object sender, EventArgs e)
    {
        List<RoomService> service = new List<RoomService>();
        service = (List<RoomService>)ss.GetRoomService(RoomPicker.SelectedIndex);

        CollView.ItemsSource = ss.GetRoomService(RoomPicker.SelectedIndex);

    }
    void NewPickerGroup(object sender, EventArgs e)
    {
        List<RoomCategory> rooms = new List<RoomCategory>();
        rooms = (List<RoomCategory>)ss.GetAllRooms();
        RoomPicker.ItemsSource = rooms;
        
    }
}