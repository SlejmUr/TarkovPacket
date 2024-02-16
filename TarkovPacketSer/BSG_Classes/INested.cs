namespace TarkovPacketSer.BSG_Classes
{
    public interface INested<T> where T : INested<T>
    {
        INested<T> Nested { get; set; }
    }
}
