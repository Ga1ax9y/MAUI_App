namespace Stanishewski253505;

public partial class CalculatorPage : ContentPage
{
	public CalculatorPage()
	{
		InitializeComponent();
        OnClear(this, null);
    }




    string currentLine = "";
    double firstNum,secondNum;
    string mathOperator;
    int state = 1;
    int commacount = 0;

    void OnComma(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string pressed = button.Text;
        
        
        if (commacount < 1 )
        {
            commacount++;
            currentLine += pressed;
            this.resultText.Text += pressed;
        }
    }
    void OnNumber(object sender, EventArgs e)
	{
        Button button = (Button)sender;
        string pressed = button.Text;
        currentLine += pressed;
        if (this.resultText.Text == "0")
        {
            this.resultText.Text = "";
        }

        this.resultText.Text += pressed;

    }
    void OnSqrtX(object sender, EventArgs e)
    {
        LockNum(this.resultText.Text);
        double result = Math.Sqrt(firstNum);
        this.resultText.Text = result.ToString();
        currentLine = result.ToString();
        firstNum = result;
    }
    void OnClear(object sender, EventArgs e)
    {
        
        this.resultText.Text = "0";
        currentLine = string.Empty;
    }
    void OnCalculate(object sender, EventArgs e)
    {
        
        if (state == 2)
        {
            LockNum(currentLine);
            if (mathOperator == "÷" && secondNum == 0)
            {
                resultText.Text = "Ошибка: деление на ноль";
                firstNum = 0;
                currentLine = string.Empty;
            }
            else
            {
                double result = Calculate(firstNum, secondNum, mathOperator);
                this.resultText.Text = result.ToString();
                state = 1;
                currentLine = result.ToString();
                firstNum = result;
            }
            secondNum = 0;
            commacount = 0;

        }
    }
    void OnXX(object sender, EventArgs e)
    {
        LockNum(this.resultText.Text);
        double result = firstNum * firstNum;
        this.resultText.Text = result.ToString();
        currentLine = result.ToString();
        firstNum = result;
    }
    void OnNeg(object sender, EventArgs e)
    {
        if (resultText.Text == "0" || resultText.Text == "0,") { }
        else if (!this.resultText.Text.Contains("-"))
        {
            currentLine = currentLine.Insert(0, "-");
            this.resultText.Text = currentLine;
        }
        else
        {
            currentLine = currentLine.Remove(0,1);
            this.resultText.Text = currentLine;
        }
    }
    void OnDivX(object sender, EventArgs e)
    {
        LockNum(this.resultText.Text);
        if (firstNum != 0)
        {
            double result = 1 / firstNum;
            this.resultText.Text = result.ToString();
            currentLine = result.ToString();
            firstNum = result;
        }
        else
        {
            resultText.Text = "Ошибка: деление на ноль";
            firstNum = 0;
            currentLine = string.Empty;
        }
    }
    void OnRemoveOne(object sender, EventArgs e)
    {
        bool flag = false;
        if (resultText.Text.Contains(","))   flag = true;

        if (resultText.Text.Length != 0)
        {
            resultText.Text = resultText.Text.Remove(this.resultText.Text.Length - 1, 1);
            currentLine = resultText.Text;
            if (resultText.Text.Length == 1 && resultText.Text.Contains("-"))
            {
                resultText.Text = resultText.Text.Remove(this.resultText.Text.Length - 1, 1);
                currentLine = resultText.Text;
            }
            if (resultText.Text.Length == 0) 
                resultText.Text = "0";
                currentLine = resultText.Text;
            if (flag)
            {
                if (!resultText.Text.Contains(","))
                {
                    commacount = 0;
                }
            }
            



        }
        if (currentLine.Length != 0)
        currentLine = currentLine.Remove(currentLine.Length - 1,1);
        
        
        
    }
    void OnOperator(object sender, EventArgs e)
    {
        if (state == 1)
        {
            state = 1;
            LockNum(this.resultText.Text);

            state++;
            Button button = (Button)sender;
            string pressed = button.Text;

            mathOperator = pressed;
            this.resultText.Text = string.Empty;
            currentLine = string.Empty;
            commacount = 0;
        }

    }
    void LockNum(string text)
    {
        double num;
        if (double.TryParse(text, out num))
        {
            if(state == 1)
            {
                firstNum = num;
            }
            else
            {
                secondNum = num;
            }
            currentLine = string.Empty;
        }
    }
    public double Calculate(double val1,double val2,string mathOp)
    {
        double result = 0;
        switch (mathOp)
        {
            case "+":
                result = val1+val2; 
                break;
            case "-":
                result = val1-val2;
                break;
            case "×":
                result = val1 * val2;
                break;
            case "÷":
                result = val1 / val2;
                break;
            case "mod":
                result = val1 % val2;
                break;          
        }
        return result;
    }


}