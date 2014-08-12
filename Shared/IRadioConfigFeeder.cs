namespace Shared
{
    public interface IRadioConfigFeeder
    {
        string RadioType { get; }
        RadioConfigData GetRadioConfigData();
    }
}