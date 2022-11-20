using CommunityToolkit.Mvvm.ComponentModel;

namespace ShareInvest.Models;

public partial class ObservableStock : ObservableObject
{
    [ObservableProperty]
    int current;

    [ObservableProperty]
    int compareToPreviousDay;

    [ObservableProperty]
    double rate;

    [ObservableProperty]
    ulong volume;

    [ObservableProperty]
    ulong transactionAmount;

    [ObservableProperty]
    string compareToPreviousSign;

    [ObservableProperty]
    char sign;

    [ObservableProperty]
    Color color;

    [ObservableProperty]
    FontAttributes attributes;

    public ObservableStock(string code,
                           string name,
                           string current,
                           string rate,
                           string compareToPreviousDay,
                           string compareToPreviousSign,
                           string volume,
                           string transactionAmount,
                           string state)
    {
        switch (current[0])
        {
            case '-':
                color = AppTheme.Dark == Application.Current.RequestedTheme ? Colors.DeepSkyBlue :
                                                                              Colors.Blue;
                attributes = "4".Equals(compareToPreviousSign) ? FontAttributes.Bold :
                                                                 FontAttributes.None;
                sign = '▼';
                break;

            case '+':
                attributes = "1".Equals(compareToPreviousSign) ? FontAttributes.Bold :
                                                                 FontAttributes.None;
                color = Colors.Red;
                sign = '▲';
                break;

            default:
                color = AppTheme.Dark == Application.Current.RequestedTheme ? Colors.Snow :
                                                                              Colors.DimGray;
                sign = ' ';
                break;
        }
        Code = code;
        Name = name;
        State = state;

        this.transactionAmount = Convert.ToUInt64(transactionAmount);
        this.volume = Convert.ToUInt64(volume);
        this.rate = Math.Abs(Convert.ToDouble(rate));
        this.current = Math.Abs(Convert.ToInt32(current));
        this.compareToPreviousDay = Math.Abs(Convert.ToInt32(compareToPreviousDay));
        this.compareToPreviousSign = compareToPreviousSign;
    }
    public string Code
    {
        get;
    }
    public string Name
    {
        get;
    }
    public string State
    {
        get;
    }
}