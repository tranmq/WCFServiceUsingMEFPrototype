namespace Shared
{
    public interface IRadioConfigFeeder
    {
        string RadioType { get; }
        RadioPluginData GetRadioConfigData();
    }
}