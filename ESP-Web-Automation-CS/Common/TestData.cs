using System;





	public static class TestData
	{
	public const string sURL = "http://uat-espweb.asicentral.com";
	public const string sNavigateToWESP = "http://uat-espweb.asicentral.com/Default.aspx?appCode=WESP";
	public const string sChromePath = "Installation/chromedriver.exe";
	public const string sIEBrowserPath = "Installation/IEDriverServer.exe";
	public const string sFFBrowserPath = "Installation/chromedriver.exe";
	public static readonly Random rn = new Random();
	public static readonly Random ch = new Random();
	public static readonly int sRandam = rn.Next(500) + 1;
	public static readonly char schar = (char)(ch.Next(26) + 'a');
	public const string sKillIEBrowser = "TASKKILL /F /IM iexplore.exe";
	public const string sKillChrome = "TASKKILL /F /IM chrome.exe";
	public const string sKillChromedriver = "TASKKILL /F /IM chromedriver.exe";
	public const int sTimeout = 7;
	//public static readonly DateFormat dateFormat = new SimpleDateFormat("MM/dd/yyyy HH:mm:ss");
	public static readonly DateTime date = DateTime.Now;
	//public static readonly string date1 = dateFormat.format(date);
    public static readonly string sCustomerName = ("Automation" + -+sRandam + schar + date.ToString("MM/dd/yyyy HH:mm:ss"));
    public const string sASINumber = "101574";
    public const string sUserName = "autocorp1";
    public const string sPassword = "autotest1";
		public const string sASINumber_4 = "101574";
        public const string sUserName_4 = "autocorp2";
        public const string sPassword_4 = "autotest2";
		public const string sSearchByKeyword = "Mugs";
		public const string sSearchByProduct_ID = "HL-358";
		public const string sSearchByProduct_ID_GI = "AR118";
		public const string sSearchByProduct_CPN = "CPN-550387481";
		public const int sOrderQTY = 5;
		public const string sSupplierNo = "30232";
		public const string sDecorator = "788888";
		public const string sVSProduct = "HL-358";
	}

