public class AppFacade : Facade
{
    private static AppFacade _instance;

    public AppFacade() : base()
    {
    }
    public static AppFacade Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AppFacade();
            }
            return _instance;
        }
    }

    override protected void InitFramework()
    {
        base.InitFramework();
        RegisterCommand(NotiConst.START_UP, typeof(StartUpCommand));
    }

    /// 启动框架
    public void StartUp()
    {
        SendMessageCommand(NotiConst.START_UP);
        RemoveMultiCommand(NotiConst.START_UP);
    }
}

