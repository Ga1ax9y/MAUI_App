using Stanishewski253505.Entities;
using Stanishewski253505.Services;
using System.Collections.Generic;
namespace Stanishewski253505;

public partial class SQLitePage : ContentPage
{
    private readonly IDbService _dBService;
    public SQLitePage(IDbService dbService)
	{
		InitializeComponent();
        _dBService = dbService;
        
    }
    void PickerSelectedIndexChanged(object sender, EventArgs e)
    {
      
        CollView.ItemsSource = _dBService.GetRoomService(RoomPicker.SelectedIndex);

    }
    private void RoomPicker_Loaded(object sender, EventArgs e)
    {
        _dBService.Init();
        RoomPicker.ItemsSource = (List<RoomCategory>)_dBService.GetAllRooms();
    }
}