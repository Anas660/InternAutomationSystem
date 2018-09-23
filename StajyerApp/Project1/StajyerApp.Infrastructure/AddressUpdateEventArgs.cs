public class AddressUpdateEventArgs : System.EventArgs
{
    // add local member variables to hold text
    private int departmanId;
    private string departmanAdi;

    // class constructor
    public AddressUpdateEventArgs(int departmanId,
            string departmanAdi)
    {
        this.departmanId = departmanId;
        this.departmanAdi = departmanAdi;

    }

    // Properties - Viewable by each listener
    public int DepartmanId
    {
        get
        {
            return departmanId;
        }
    }

    public string DepartmanAdi
    {
        get
        {
            return departmanAdi;
        }
    }
}