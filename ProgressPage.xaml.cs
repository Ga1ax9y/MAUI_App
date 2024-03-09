using Microsoft.Maui.Graphics.Text;
using System;
using System.Diagnostics;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Stanishewski253505;

public partial class ProgressPage : ContentPage
{


    CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
    public ProgressPage()
	{
		InitializeComponent();
       
    }
    private async void Start_Action(object sender, EventArgs e)
    {
        Cancel_btn.IsEnabled = true;
        Start_btn.IsEnabled = false;
        MyProgress.Progress = 0;
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Procent_lbl.Text = "0%";
        });
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Progress_lbl.Text = "Вычисление...";
        });

        var progress = new Progress<double>(percent =>
        {
            Procent_lbl.Text = (Math.Round(percent*100,3)).ToString()+"%";

            MyProgress.Progress = percent;
        });

        double res = await Task.Run(()=> RectangleIntegration(progress));
        if (res !=228)
        Progress_lbl.Text = res.ToString();
        Start_btn.IsEnabled = true;
        Cancel_btn.IsEnabled= false;
        
    }
    void Cancel_Action(object sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Progress_lbl.Text = "Задание отменено";
        });
        cancelTokenSource.Cancel();

    }
    private async Task<double> RectangleIntegration(IProgress<double> progress)
    {
        double a = 0; 
        double b = 1;  
        int n = (int)((b - a) / 0.005);  
        double dx = (b - a) / n;  
        double integralSum = 0; 
        CancellationToken token = cancelTokenSource.Token;

        for (int i = 0; i <= n; i++)
        {
            if (token.IsCancellationRequested)
            {
                cancelTokenSource = new CancellationTokenSource();
                return 228;
            }
            
            double x = a + i * dx;
            double y = Math.Sin(x);  
            integralSum += y * dx; 

            await Task.Delay(1);       
            progress.Report((double)i/(double)n);
        }

        return integralSum;
    }
}