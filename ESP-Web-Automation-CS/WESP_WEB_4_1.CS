

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class WESP_4_1 {
    
    public static IWebDriver driver;

    [Test, Order(0)]
    public void ProductSearchByCPN() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_CPN);
            if (driver.FindElement(By.Id("imgProductImage")).Displayed) {
               System.Console.WriteLine("Test Case- Search Product by CPN - Pass");
            }
            else {
               
               System.Console.WriteLine("Test Case-Search Product by CPN - Fail");
            }
            
        }
        catch (NoSuchElementException e) {
           System.Console.WriteLine("Test Case-Search Product by CPN - Fail");
        }
        
    }
    
    [Test,Order(1)]
    public void SearchDecorator() {
        try {
            this.enterPoint();
            this.search_Decorator(TestData.sDecorator);
            Thread.Sleep(5000);
            if (driver.FindElement(By.LinkText(("asi/" + TestData.sDecorator))).Displayed) {
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
               System.Console.WriteLine("Test Case- Perform quick Decorator  Search - Pass");
            }
            else {
               System.Console.WriteLine("Test Case- Perform quick Decorator  Search- Fail");
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            
        }
        catch (System.Exception e) {
           System.Console.WriteLine("Test case-Perform quick Decorator  Search- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(2)]
    public void Search_Advanced_MM() {
        try {
            this.enterPoint();
            this.searchProductByPOID("M&M");
            this.productResult("Quick Search- Perform a quick search and advanced search on \'M&M\'");
            // ==============Advanced Search
            driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
            driver.SwitchTo().ActiveElement();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            driver.FindElement(By.Id("advancedSearchLink")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("productAdvancedSearchAllKeyword")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("productAdvancedSearchAllKeyword")).SendKeys("M&M");
            Thread.Sleep(5000);
            IWebElement compare = driver.FindElement(By.Id("productSearchSubmitBtn"));
            IJavaScriptExecutor js = ((IJavaScriptExecutor)(driver));
            js.ExecuteScript("arguments[0].click();", compare);
            this.productResult("advanced search on \'M&M\'");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-advanced search on \'M&M\'- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(3)]
    public void QuickSearchBy_DropdownList() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.PartialLinkText("Mugs")).Click();
            driver.SwitchTo().ActiveElement();
            this.productResult("Perform quick search by entering a keyword and then clicking a keyword from dropdown list");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Perform quick search by entering a keyword and then clicking a keyword from dropdown list- " +
                "Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(4)]
    public void QuickSearchBy_PriceFrom_PriceTo() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@placeholder=\'Price\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@placeholder=\' min\']")).SendKeys("1");
            driver.FindElement(By.XPath("//input[@placeholder=\' max\']")).SendKeys("5");
            driver.FindElement(By.Id("search-quantity")).SendKeys("50");
            Thread.Sleep(8000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(5000);
            this.productResult("Perform quick Product Search with Price From, Price To, and Quantity");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Perform quick Product Search with Price From, Price To, and Quantity- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(5)]
    public void QuickSearchBy_PriceFrom_QTY() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("search-quantity")).SendKeys("100");
            Thread.Sleep(5000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(8000);
            // ==================================================
            this.productResult("Quick search by  QTY  without price");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Quick search by  QTY  without price- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(6)]
    public void QuickSearchBy_Supplier() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).SendKeys(TestData.sSupplierNo);
            driver.FindElement(By.XPath(".//*[@id=\'QuickSearchGroup\']/div/div/button")).Click();
            driver.FindElement(By.LinkText("Suppliers")).Click();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(6000);
            if (driver.FindElement(By.LinkText("asi/30232")).Displayed) {
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
               System.Console.WriteLine("Test Case- Perform quick Supplier  Search - Pass");
            }
            else {
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
               System.Console.WriteLine("Test Case- Perform quick Supplier  Search- Fail");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Perform quick Supplier  Search- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(7)]
    public void QuickSearchByWithIn() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByKeyword);
            driver.FindElement(By.CssSelector(".form-control.input-sm.ng-pristine.ng-untouched.ng-valid")).Click();
            driver.FindElement(By.CssSelector(".form-control.input-sm.ng-pristine.ng-untouched.ng-valid")).SendKeys("50");
            driver.FindElement(By.Id("btnSearchWithin")).Click();
            Thread.Sleep(5000);
            this.productResult("Perform search within");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Perform search within- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(8)]
    public void OpenOneOfExistingRecentSearch() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            Thread.Sleep(5000);
            driver.FindElement(By.Id("page_searches")).Click();
            Thread.Sleep(5000);
            IWebElement RecentSearchs = driver.FindElement(By.Id("page_recentsearches"));
            Actions action = new Actions(driver);
            action.MoveToElement(RecentSearchs).Build().Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText(TestData.sSearchByProduct_ID)).Click();
            Thread.Sleep(6000);
            this.productResult("Open one of recent searches");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Open one of recent searches- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(9)]
    public void OpenOneOfExistingSaveSearch() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            driver.FindElement(By.LinkText("Save")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("page_searches")).Click();
            driver.FindElement(By.Id("page_savedsearches")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText(TestData.sSearchByProduct_ID)).Click();
            Thread.Sleep(5000);
            this.productResult("Open one of existing saved searches");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Open one of existing saved searches- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(10)]
    public void OpenOneOfExistingTopSearch() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ===============================================================================
            driver.FindElement(By.Id(Elements_Fields.mainPage_Searches)).Click();
            Thread.Sleep(3000);
            IWebElement RecentSearchs = driver.FindElement(By.XPath(("//a[@id=\'" 
                                + (Elements_Fields.mainPage_Searches_RecentSearches + "\']"))));
            Actions action = new Actions(driver);
            action.MoveToElement(RecentSearchs).Build().Perform();
            Thread.Sleep(5000);
            if (!driver.PageSource.Contains("stage")) {
                driver.FindElement(By.LinkText("/n")).Click();
            }
            else {
                driver.FindElement(By.LinkText(TestData.sSearchByProduct_ID)).Click();
                Thread.Sleep(5000);
            }
            
            this.productResult("Open one of Top searches");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Open one of Top searches- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(11)]
    public void OpenExistingTopSeller() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id("page_topsellers")).Click();
            Thread.Sleep(5000);
            // driver.FindElement(By.Id("page_topsearches")).Click();
            Thread.Sleep(5000);
            if (TestData.sURL.Contains("stage")) {
                driver.FindElement(By.PartialLinkText("T-Shirts")).Click();
            }
            else {
                driver.FindElement(By.PartialLinkText("Awwards")).Click();
            }
            
            Thread.Sleep(5000);
            this.productResult("Open one of top sellers");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Open one of top sellers- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(12)]
    public void NarrowProductSearch() {
        try {
            this.enterPoint();
            this.searchProductByPOID("Mugs");
            // ==================================================
            driver.FindElement(By.LinkText("MUGS & STEINS")).Click();
            Thread.Sleep(4000);
            if (driver.FindElement(By.XPath("//div[@class=\'selected-dimension ng-scope\']")).Displayed) {
               System.Console.WriteLine("Test Case- Narrow Product Search - Pass");
            }
            else {
               System.Console.WriteLine("Test Case- Narrow Product Search- Fail");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case- Narrow Product Search- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(13)]
    public void DecoratoryAdvancedSearch() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'QuickSearchGroup\']/div/div/button")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Decorators")).Click();
            driver.FindElement(By.Id("advancedSearchLink")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("decoratorAdvancedSearchDecorator")).SendKeys(TestData.sDecorator);
            driver.FindElement(By.Id("decoratorSearchSubmitBtn")).Click();
            driver.SwitchTo().ActiveElement();
            Thread.Sleep(5000);
            // ==================================================
            if (driver.PageSource.Contains("788888")) {
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
               System.Console.WriteLine("Test Case- Decorator advanced search - Pass");
            }
            else {
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
               System.Console.WriteLine("Test Case- Decorator advanced search- Fail");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Decorator advanced search- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(14)]
    public void DecoratorNarrow() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).SendKeys(TestData.sDecorator);
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'QuickSearchGroup\']/div/div/button")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Decorators")).Click();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(5000);
            // ==================================================
            driver.FindElement(By.Id("lnkClearAll")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("State/Province")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("CA")).Click();
            Thread.Sleep(5000);
            this.productResult("Decorator narrow result");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Decorator narrow result- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(15)]
    public void DecoratorQuickSearch_DecoratorDetailPage() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).SendKeys(TestData.sDecorator);
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'QuickSearchGroup\']/div/div/button")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Decorators")).Click();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.LinkText(("asi/" + TestData.sDecorator))).Displayed) {
               System.Console.WriteLine("Test Case- Perform quick decorator  Search - Pass");
            }
            else {
               System.Console.WriteLine("Test Case- Perform quick decorator  Search- Fail");
            }
            
            driver.FindElement(By.Id("btnSupplierDetail")).Click();
            Thread.Sleep(5000);
            IList<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            Thread.Sleep(5000);
            if (driver.FindElement(By.Id("lblSupplierName")).Displayed) {
                driver.SwitchTo().Window(tabs2[1]).Close();
                driver.SwitchTo().Window(tabs2[0]);
               System.Console.WriteLine("Test Case- Perform quick decorator detail page  - Pass");
            }
            else {
               System.Console.WriteLine("Test case- Perform quick decorator detail page- Fail");
                driver.SwitchTo().Window(tabs2[1]).Close();
                driver.SwitchTo().Window(tabs2[0]);
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Perform quick decorator detail page- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(16)]
    public void SupplierAdvancedSearch() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'QuickSearchGroup\']/div/div/button")).Click();
            driver.FindElement(By.LinkText("Suppliers")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("advancedSearchLink")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("supplierAdvancedSearchKeyword")).SendKeys(TestData.sSupplierNo);
            Thread.Sleep(5000);
            driver.FindElement(By.Id("supplierSearchSubmitBtn")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.LinkText("asi/30232")).Displayed) {
               System.Console.WriteLine("Test Case- Supplier Advanced  Search - Pass");
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            else {
               System.Console.WriteLine("Supplier Advanced Search- Fail");
               driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Supplier Advanced Search- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(17)]
    public void ProductAdvancedSearch_Quantity() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("advancedSearchLink")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("productAdvancedSearchAllKeyword")).SendKeys("Mugs");
            driver.FindElement(By.Id("productSearchSubmitBtn")).Click();
            Thread.Sleep(5000);
            this.productResult("Product Advanced Search");
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("advancedSearchLink")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("productAdvancedSearchQuantity")).SendKeys("50");
            driver.FindElement(By.Id("productSearchSubmitBtn")).Click();
            Thread.Sleep(5000);
            this.productResult("Product Advanced Search quantity");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Product Advanced Search quantity- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(18)]
    public void Decorator_InvokeQuickView() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).SendKeys(TestData.sDecorator);
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'QuickSearchGroup\']/div/div/button")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Decorators")).Click();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(5000);
            // ==================================================
            IWebElement sQucikView = driver.FindElement(By.XPath("//a[@location-code=\'SPLSMR\']"));
            Actions action = new Actions(driver);
            action.MoveToElement(sQucikView).Build().Perform();
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath("//div[@class=\'popover-content\']")).Displayed) {
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
               System.Console.WriteLine("Test Case- Decorator quick view  - Pass");
            }
            else {
               System.Console.WriteLine("Test Case- Decorator Quick View - Fail");
               driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Decorator Quick View Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(19)]
    public void ProductResult_TileView() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByKeyword);
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'Module_271774\']/div/div[1]/div/div[2]/div[1]/div/div/div[2]/div[1]/div/button")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'Module_271774\']/div/div[1]/div/div[2]/div[1]/div/div/div[2]/div[1]/div/ul/li[2]/a")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath(".//*[@id=\'Module_271774\']/div/div[1]/div/div[2]/div[2]/slide-panel/div")).Displayed) {
               System.Console.WriteLine("Test Case- Product Result in Tile view - Pass");
            }
            else {
               System.Console.WriteLine("Test Case- Product Result in Tile view- Fail");
            }
            
            Thread.Sleep(5000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).SendKeys("Mugs");
            Thread.Sleep(5000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Name("txtQuantity")).SendKeys("50");
            driver.FindElement(By.Id("btnChangeQuantity2")).Click();
            Thread.Sleep(5000);
            this.productResult("Product Result narrow result quantity");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Product Result narrow result quantity Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(20)]
    public void VisualSearch_Image() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id("advancedSearchLink")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("productAdvancedSearchVisualSearch")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'visualSearchTabs\']/ul/li[2]")).Click();
            driver.FindElement(By.Id("inputImageUrl")).SendKeys("http://farm4.static.flickr.com/3114/2524849923_1c191ef42e.jpg");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("search-by-image")).Click();
            Thread.Sleep(15000);
            this.productResult("Visual Search-  Upload Image");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case-Visual Search-  Upload Image Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(21)]
    public void Shipping_Estimator() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_CPN);
            Thread.Sleep(5000);
            // ==================================================
            // Add product to clipboard
            driver.FindElement(By.Id("espShippingCalculatorLink")).Click();
            driver.FindElement(By.Id("espSC-items-per-package")).SendKeys("5");
            driver.FindElement(By.Id("espSC-weight-per-package")).SendKeys("10");
            driver.FindElement(By.Id("calculate")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.ClassName("tablewrapper")).Displayed) {
               System.Console.WriteLine("Test Case- Shipping estimator by Package- Pass");
            }
            else {
               System.Console.WriteLine("Test Case- Shipping estimator by Package-- Fail");
            }
            
            driver.FindElement(By.Id("espSC-estimation-unit")).Click();
            Thread.Sleep(5000);
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("espSC-estimation-unit")));
            dropdown.SelectByText("Product");
            driver.FindElement(By.Id("espSC-quantity")).Clear();
            driver.FindElement(By.Id("espSC-quantity")).SendKeys("5");
            driver.FindElement(By.Id("espSC-weight")).SendKeys("10");
            driver.FindElement(By.Id("calculate")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.ClassName("tablewrapper")).Displayed) {
               System.Console.WriteLine("Test Case- Shipping estimator by Product- Pass");
               driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            else {
               System.Console.WriteLine("Test Case- Shipping estimator by Product- Fail");
               driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test case- Shipping estimator by Product Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(22)]
    public void NewSupplier_Page() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id("page_newsuppliers")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.Id("ContentZone1")).Displayed) {
               System.Console.WriteLine("Test Case- New SUpplier page- Pass");
               driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            else {
               System.Console.WriteLine("Test Case- New SUpplier page- Fail");
               driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test New SUpplier page Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(23)]
    public void VerifyPOTDAd() {
        try {
            this.enterPoint();
            if (driver.FindElement(By.XPath("//div[@class=\'product-wrapper prod prod-tile\']")).Displayed) {
               System.Console.WriteLine(" Test Case- Product of the day - Pass");
            }
            else {
               System.Console.WriteLine(" Test Case- Product of the day - Fail");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-Product of the day- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    // =========================== Add Product Functionality =================================================
    [Test,Order(24)]
    public void AddProductTOClipboard_ComparePage() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            this.clickbyxpath("//button[@location-code=\'PRRPRC\']");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@ng-click=\'vm.toggleChecked()\']")).Click();
            // =======================
            Thread.Sleep(1000);
            this.onMouseEvent("//li[@ng-if=\'vm.checkCopyTo()\']");
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("Clipboard")).Click();
            // clickbyxpath("//a[@ng-click='vm.addToClipboard($event)']");
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath("//a[@id=\'Clipboard\']")).Displayed) {
                this.clearClipboard();
                Thread.Sleep(3000);
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
               System.Console.WriteLine("Test Case- Add product to clipboard from compare page- Pass");
                Thread.Sleep(5000);
            }
            else {
                Thread.Sleep(5000);
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
               System.Console.WriteLine("Test Case- Add product to clipboard from compare page- Fail");
                this.clearClipboard();
                Thread.Sleep(1000);
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case- Add product to clipboard from compare page- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(25)]
    public void AddProductToClipBoardFromProductResult() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            Thread.Sleep(5000);
            this.clickbyxpath("//button[@location-code=\'CLPPRS\']");
            // ==================================================
            if (driver.FindElement(By.XPath("//div[@ng-if=\'products.Length\']")).Displayed) {
               System.Console.WriteLine("Test Case- Add products to clipboard from product result - Pass");
                this.clearClipboard();
                Thread.Sleep(5000);
            }
            else {
               System.Console.WriteLine("Test Case- Add products to clipboard from product result- Fail");
                this.clearClipboard();
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Add products to clipboard from product result- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(26)]
    public void AddProductTOProject_ComparePage() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            Thread.Sleep(5000);
            // ==================================================
            this.clickbyxpath(Elements_Fields.productRsult_CompareButton);
            // Add product to clipboard
            Thread.Sleep(5000);
            // ========================
            driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@ng-click=\'vm.toggleChecked()\']")).Click();
            Thread.Sleep(3000);
            this.onMouseEvent("//div[@id=\'ngProductCompare\']//a[.=\'Copy To \']");
            // =======================
            Thread.Sleep(1000);
            this.onMouseEvent("//div[@id=\'ngProductCompare\']/div/div[2]/div/product-toolbar-redux/div/ul/li[4]/ul");
            Thread.Sleep(6000);
            driver.FindElement(By.LinkText("My Projects")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("My Projects")).Click();
            // driver.FindElement(By.LinkText("Add(0)")).Click();    
            Thread.Sleep(5000);
            // driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
            // Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Projects")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.PartialLinkText("Saved Products")).Click();
            Thread.Sleep(2000);
            if (driver.FindElement(By.XPath("//div[@class=\'media-left prod-img ng-isolate-scope\']")).Displayed) {
                Thread.Sleep(5000);
                // driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                // Thread.Sleep(5000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
               System.Console.WriteLine("Test Case- Add product to project from compare page- Pass");
            }
            else {
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
               System.Console.WriteLine("Test Case- Add product to project from compare page- Fail");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Add product to project from compare page- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(27)]
    public void AddProducttoShoppingFromComparePage() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            this.clickbyxpath("//button[@location-code=\'PRRPRC\']");
            Thread.Sleep(5000);
            // ========================
            driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@ng-click=\'vm.toggleChecked()\']")).Click();
            // =======================
            Thread.Sleep(1000);
            // =======================
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//i[@class=\'fa fa-shopping-cart\']")).Click();
            // driver.FindElement(By.XPath(".//*[@id='prod_770064800']/div/div[1]/a[2]")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@placeholder=\'QTY\']")).SendKeys("7");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("html/body/div[3]/div/div/form/div/div/section/div/div/div/div[2]/div/div[2]/div/div/button[1]")).Click();
            Thread.Sleep(5000);
            // driver.FindElement(By.XPath("//div[@ng-if='products.Length']")).Displayed
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath("//div[@ng-if=\'products.Length\']")).Displayed) {
                this.clearShoppingCart();
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
               System.Console.WriteLine("Test Case- Add product to shopping cart from compare page- Pass");
                Thread.Sleep(5000);
            }
            else {
                Thread.Sleep(5000);
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
               System.Console.WriteLine("Test Case- Add product to shopping cart from compare page- Fail");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Add product to shopping cart from compare page- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(28)]
    public void AddtoCompareFromClipboard() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            this.clickbyxpath("//button[@location-code=\'CLPPRS\']");
            Thread.Sleep(5000);
            // ========================
            driver.FindElement(By.XPath("//a[@id=\'Clipboard\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[2]/ul/li/div/label/input")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//a[@ng-click=\'methods.toolbar.addMarkedProductsToCompare($event, locationCodes.compare)\']")).Click();
            Thread.Sleep(3000);
            driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath(".//*[@id=\'Clipboard\']/div")).Displayed) {
                Thread.Sleep(5000);
                this.clearClipboard();
                Thread.Sleep(5000);
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
               System.Console.WriteLine("Test Case- Add products to clipboard from Compare - Pass");
            }
            else {
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
               System.Console.WriteLine("Test Case- Add products to clipboard from Compare Page- Fail");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Add products to clipboard from Compare Page- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(29)]
    public void AddtoCompareFromProductDetail() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_CPN);
            Thread.Sleep(5000);
            // ==================================================
            driver.FindElement(By.Id("btnAddToCompare")).Click();
            // ==================================================
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Displayed) {
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
               System.Console.WriteLine("Test Case- Add products to clipboard from product detail - Pass");
                //  driver.FindElement(By.XPath("//a[@id='Clipboard']")).Click();
                Thread.Sleep(5000);
            }
            else {
               System.Console.WriteLine("Test Case- Add products to clipboard from product detail- Fail");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Add products to clipboard from product detail-- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(30)]
    public void AddtoCompareFromProductResult() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            this.clickbyxpath("//button[@location-code=\'PRRPRC\']");
            // ==================================================
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Displayed) {
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
               System.Console.WriteLine("Test Case- Add products to clipboard from product result - Pass");
                //  driver.FindElement(By.XPath("//a[@id='Clipboard']")).Click();
                Thread.Sleep(5000);
            }
            else {
               System.Console.WriteLine("Test Case- Add products to clipboard from product result- Fail");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Add products to clipboard from product result- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(31)]
    public void AddtoCompareFromQuickview() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            IWebElement compare = driver.FindElement(By.XPath("//button[@class=\'btn btn-quickview\']"));
            IJavaScriptExecutor js = ((IJavaScriptExecutor)(driver));
            js.ExecuteScript("arguments[0].click();", compare);
            Thread.Sleep(5000);
            // ========================
            driver.FindElement(By.XPath("//div[@class=\'col-xs-4\']")).Click();
            // =======================
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Displayed) {
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
               System.Console.WriteLine("Test Case- Add products to compare from product result - Pass");
                //  driver.FindElement(By.XPath("//a[@id='Clipboard']")).Click();
                Thread.Sleep(5000);
            }
            else {
               System.Console.WriteLine("Test Case- Add products to compare from product result- Fail");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Add products to compare from product result- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(32)]
    public void Remove_Product_ComparePage() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            this.clickbyxpath("//button[@location-code=\'PRRPRC\']");
            // ==================================================
            Thread.Sleep(5000);
            // ========================
            driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@ng-click=\'vm.toggleChecked()\']")).Click();
            Thread.Sleep(3000);
            // =======================
            while (driver.PageSource.Contains("Remove")) {
                driver.FindElement(By.XPath("//button[@ng-click=\'vm.removeItem(product, $event)\']")).Click();
                Thread.Sleep(1000);
               System.Console.WriteLine("Test Case- Remove product from compare page- Pass");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Remove product from compare page- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(33)]
    public void RemoveProductSingleProductFromPresentation() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            this.clickbyxpath("//button[@location-code=\'PRRPRC\']");
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Displayed) {
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(".//*[@id=\'prod_1\']/div/a/span")).Click();
               System.Console.WriteLine("Test Case- Remove SIngle Item From COmpare - Pass");
                //  driver.FindElement(By.XPath("//a[@id='Clipboard']")).Click();
                Thread.Sleep(5000);
            }
            else {
               System.Console.WriteLine("Test Case- Remove Single Item From Compare- Fail");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Remove Single Item From Compare- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(34)]
    public void ShowHide_ComparePage() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            this.clickbyxpath("//button[@location-code=\'PRRPRC\']");
            // ==================================================
            Thread.Sleep(5000);
            // ========================
            driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Click();
            Thread.Sleep(5000);
            // =======================
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[@class=\'asi-product-compare-table\']/div/div[1]/div[2]/ul/li[1]/ul/li[1]/div/span/input")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.TagName("html")).Text.Contains("marked fields")) {
                driver.FindElement(By.XPath("//button[@ng-click=\'vm.toggleMarked()\']")).Click();
            }
            
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath("//ul[@class=\'asi-product-compare-fieldset-group asi-product-compare-list\']")).Displayed) {
                Thread.Sleep(5000);
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
               System.Console.WriteLine("Test Case- Show Hide from compare page- Pass");
                //  driver.FindElement(By.XPath("//a[@id='Clipboard']")).Click();
                Thread.Sleep(5000);
            }
            else {
                Thread.Sleep(5000);
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
               System.Console.WriteLine("Test Case- Show Hide from compare page- Fail");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Show Hide from compare page- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    // ============================================Product and Supplier Detail===========================================================
    [Test,Order(35)]
    public void ChangeSortbyOption_ProductResult() {
        try {
            this.enterPoint();
            this.searchProductByPOID("Mugs");
            Thread.Sleep(6000);
            // ==================================================
            String[] thisIsAStringArray = new String[] {
                    "Price: Low to High",
                    "Price: High to Low",
                    "Cost: Low to High",
                    "Cost: High to Low",
                    "Profit",
                    "Canadian Priced",
                    "Product Name",
                    "Product Number",
                    "Confirmed Product",
                    "New Product"};
            for (int i = 0; (i < thisIsAStringArray.Length); i++) {
                driver.FindElement(By.XPath("//button[@class=\'btn btn-default btn-sm dropdown-toggle sort-by ng-binding\']")).Click();
                Thread.Sleep(5000);
                // Select dropdown = new Select(driver.FindElement(By.Id("CmbSort")));
                String element = thisIsAStringArray[i];
                driver.FindElement(By.LinkText(element.ToString())).Click();
                // dropdown.selectByVisibleText(element);
                Thread.Sleep(5000);
                //System.Console.WriteLine( element ); 
                if (driver.FindElement(By.ClassName("prod-count")).Displayed) {
                    String sResult = driver.FindElement(By.ClassName("prod-count")).Text;
                   System.Console.WriteLine(("Test Case- Product Result  sort by " + ("-" 
                                    + (element.ToString() + ("-" 
                                    + (sResult + " - Pass"))))));
                }
                else {
                    String sResult = driver.FindElement(By.ClassName("prod-count")).Text;
                   System.Console.WriteLine(("Test Case- Product Result sort by " + ("-" 
                                    + (element.ToString() + ("-" 
                                    + (sResult + " - Fail"))))));
                }
                
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Product Result sort by- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(36)]
    public void Decorator_sort() {
        try {
            this.enterPoint();
            this.search_Decorator(TestData.sDecorator);
            Thread.Sleep(5000);
            // ==================================================
            driver.FindElement(By.Id("lnkClearAll")).Click();
            Thread.Sleep(8000);
            String[] thisIsAStringArray = new String[] {
                    "ASI Number",
                    "Zip Code",
                    "Area Code"};
            for (int i = 0; (i < thisIsAStringArray.Length); i++) {
                SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("CmbSort")));
                String element = thisIsAStringArray[i];
                dropdown.SelectByText(element);
                Thread.Sleep(5000);
                //System.Console.WriteLine( element ); 
                if (driver.FindElement(By.ClassName("prod-count")).Displayed) {
                    String sResult = driver.FindElement(By.ClassName("prod-count")).Text;
                   System.Console.WriteLine(("Test Case- Decorator sort by " + ("-" 
                                    + (element.ToString() + ("-" 
                                    + (sResult + " - Pass"))))));
                }
                else {
                   System.Console.WriteLine(("Test Case- Decorator sort by " + ("-" 
                                    + (element.ToString() + " - Fail"))));
                }
                
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Decorator sort by- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(37)]
    public void ProductDetail_ConfigureProduct() {
        try {
            this.enterPoint();
            this.searchProductByPOID("CPN-551038511");
            Thread.Sleep(5000);
            // ==================================================
            // String sOrder = driver.FindElement(By.XPath("//div[@class='price-includes']")).getAttribute("Order");
            // driver.FindElement(By.LinkText(sOrder)).Click();
            Thread.Sleep(3000);
            if (driver.FindElement(By.XPath("//div[@id=\'prod-info\']/div[2]/div[1]/div[1]/button")).Displayed) {
                driver.FindElement(By.XPath("//div[@id=\'prod-info\']/div[2]/div[1]/div[1]/button")).Click();
                Thread.Sleep(5000);
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//input[@placeholder=\'QTY\']")).SendKeys("5");
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
                Thread.Sleep(5000);
                // div[@class='form-group']//select[.='LabelingUnimprinted']//option[1]
                if (driver.FindElement(By.XPath("//select[@ng-model=\'decoration.selectedImprint\']")).Displayed) {
                    SelectElement dropdown = new SelectElement(driver.FindElement(By.XPath("//select[@ng-model=\'decoration.selectedImprint\']")));
                    dropdown.SelectByIndex(1);
                }
                else {
                   System.Console.WriteLine("Test Case-  Product Detail - product does not have Product Configrations please select diffrent produ" +
                        "ct- Warning");
                }
                
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("//button[@ng-click=\'::vm.save()\']")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("//a[@id=\'ShoppingCart\']")).Click();
                Thread.Sleep(5000);
                if (driver.FindElement(By.LinkText("Product Options")).Displayed) {
                   System.Console.WriteLine("Test Case- Product Detail - Product Configration- Pass");
                    driver.FindElement(By.XPath("//li[1]/div/label")).Click();
                    Thread.Sleep(5000);
                    driver.FindElement(By.XPath(".//*[@id=\'appMenu\']/li[4]/a")).Click();
                    Thread.Sleep(5000);
                    driver.FindElement(By.XPath("html/body/div[4]/div/div/div/div/button[2]")).Click();
                    Thread.Sleep(5000);
                }
                else {
                    driver.FindElement(By.XPath("//li[1]/div/label")).Click();
                    Thread.Sleep(5000);
                    driver.FindElement(By.XPath(".//*[@id=\'appMenu\']/li[4]/a")).Click();
                    Thread.Sleep(5000);
                    driver.FindElement(By.XPath("html/body/div[4]/div/div/div/div/button[2]")).Click();
                    Thread.Sleep(5000);
                   System.Console.WriteLine("Test Case- Product Detail - Product Configration- Fail");
                }
                
            }
            else {
               System.Console.WriteLine("Test Case- Product Detail - selected Product does not have Configration- Fail");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Product Detail - Product Configration- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(38)]
    public void ProductDetail_Theme_Category_UpdatedDate() {
        try {
            this.enterPoint();
            this.searchProductByPOID("CPN-5067090");
            Thread.Sleep(5000);
            // ==================================================
            driver.FindElement(By.XPath(".//*[@id=\'prod-info\']/div[2]/div[1]/div[1]/button")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@placeholder=\'QTY\']")).SendKeys("5");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@ng-if=\'vm.nextButtonText\']")).Click();
            Thread.Sleep(5000);
            // driver.FindElement(By.XPath("html/body/div[4]/div/div/form/div/div/section/div/div/div/div[1]/div[2]/div/div[1]/div[1]/div/select")).Click();
            Thread.Sleep(5000);
            //  driver.FindElement(By.XPath(".//*[@id='visualSearchPopup']/div/p/a")).Click();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name=\'DecorationType\']")));
            dropdown.SelectByText("Pad Print");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.save()\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@id=\'ShoppingCart\']")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.LinkText("Product Options")).Displayed) {
               System.Console.WriteLine("Test Case- Product Detail - Product Configration- Pass");
                driver.FindElement(By.XPath("//li[1]/div/label")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(".//*[@id=\'appMenu\']/li[4]/a")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("html/body/div[4]/div/div/div/div/button[2]")).Click();
                Thread.Sleep(5000);
            }
            else {
               System.Console.WriteLine("Test Case- Product Detail - Product Configration- Fail");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Product Detail - Product Configration- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(39)]
    public void SupplierDetail_AllTabs() {
        try {
            this.enterPoint();
            this.search_Supplier(TestData.sSupplierNo);
            Thread.Sleep(5000);
            // ==================================================
            driver.FindElement(By.XPath(".//*[@id=\'btnSupplierDetail\']")).Click();
            // ==================================================
            Thread.Sleep(5000);
            IList<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'tabRatings\']/a")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath("//div[@class=\'tab-content\']")).Displayed) {
               System.Console.WriteLine("Test Case- Supplier Detail-  Ratings tab  - Pass");
            }
            else {
               System.Console.WriteLine("Test Case- Supplier Detail- Ratings tab - Fail");
            }
            
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'tabCompliance\']/a")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath("//div[@class=\'tab-content\']")).Displayed) {
               System.Console.WriteLine("Test Case- Supplier Detail-  safty and compliance tab  - Pass");
            }
            else {
               System.Console.WriteLine("Test Case- Supplier Detail- safty and compliance tab - Fail");
            }
            
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'tabPreferred\']/a")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath("//div[@class=\'tab-content\']")).Displayed) {
               System.Console.WriteLine("Test Case- Supplier Detail-  Preferred tab  - Pass");
            }
            else {
               System.Console.WriteLine("Test Case- Supplier Detail- Preferred tab - Fail");
            }
            
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'tabNotes\']/a")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath(".//*[@id=\'UpdatePanel_UserNotes\']/div[1]/h6")).Displayed) {
               System.Console.WriteLine("Test Case- Supplier Detail-  Note tab  - Pass");
                driver.SwitchTo().Window(tabs2[1]).Close();
                driver.SwitchTo().Window(tabs2[0]);
            }
            else {
               System.Console.WriteLine("Test Case- Supplier Detail- Note tab - Fail");
                driver.SwitchTo().Window(tabs2[1]).Close();
                driver.SwitchTo().Window(tabs2[0]);
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  SupplierDetail_AllTabs- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(40)]
    public void SupplierDetail() {
        try {
            this.enterPoint();
            this.search_Supplier(TestData.sSupplierNo);
            Thread.Sleep(5000);
            // ==================================================
            driver.FindElement(By.XPath(".//*[@id=\'btnSupplierDetail\']")).Click();
            // ==================================================
            Thread.Sleep(5000);
            IList<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            if (driver.FindElement(By.LinkText("Detail")).Displayed) {
               System.Console.WriteLine("Test Case- Supplier Detail Page - Pass");
            }
            else {
               System.Console.WriteLine("Test Case- Supplier Detail Page- Fail");
            }
            
            driver.FindElement(By.Id("lbReadReviews")).Click();
            if (driver.FindElement(By.XPath("//div[@class=\'topad section\']")).Displayed) {
               System.Console.WriteLine("Test Case- Supplier Detail Page- Comments - Pass");
                driver.SwitchTo().Window(tabs2[1]).Close();
                driver.SwitchTo().Window(tabs2[0]);
            }
            else {
               System.Console.WriteLine("Test Case- Supplier Detail Page-Comments- Fail");
                driver.SwitchTo().Window(tabs2[1]).Close();
                driver.SwitchTo().Window(tabs2[0]);
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Supplier Detail Page-Comments- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(41)]
    public void POTD_ProductDetail() {
        try {
            this.enterPoint();
            driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@class=\'ng-binding ng-isolate-scope\']")).Click();
            Thread.Sleep(5000);
            IList<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath("//img[@id=\'imgProductImage\']")).Displayed) {
               System.Console.WriteLine("Test Case- POTD Product detail page - Pass");
                driver.SwitchTo().Window(tabs2[1]).Close();
                driver.SwitchTo().Window(tabs2[0]);
            }
            else {
               System.Console.WriteLine("Test case-POTD product detail page - Fail");
                driver.SwitchTo().Window(tabs2[1]).Close();
                driver.SwitchTo().Window(tabs2[0]);
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  POTD product detail page- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    // ==================================================Presentations===================================================================
    [Test,Order(42)]
    public void Presentation_Download() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            Thread.Sleep(5000);
            // ==================================================
            driver.FindElement(By.XPath(Elements_Fields.productRsult_MarkProduct)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Create Presentation")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("html/body/div[3]/div/div/form/div[2]/div[1]/input")).SendKeys(TestData.sCustomerName);
            Thread.Sleep(5000);
            if (!driver.FindElement(By.XPath("//input[@class=\'item-checkbox ng-pristine ng-untouched ng-valid\']")).Selected) {
                driver.FindElement(By.XPath("//input[@class=\'item-checkbox ng-pristine ng-untouched ng-valid\']")).Click();
            }
            
            driver.FindElement(By.XPath("//button[@ng-click=\'vm.methods.ok()\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@class=\'btn btn-success action-item\']")).Click();
            if (driver.FindElement(By.XPath("//a[@onclick=\'recordDownloadPrsnStats();\']")).Displayed) {
                driver.FindElement(By.XPath("//a[@onclick=\'recordDownloadPrsnStats();\']")).Click();
                Thread.Sleep(5000);
               System.Console.WriteLine("Test Case-Download Presentation - Pass- ");
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            else {
               System.Console.WriteLine("Test Case-Download Presentation - Fail- ");
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Download Presentation- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(43)]
    public void NewPresentation_ComparePage() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            Thread.Sleep(5000);
            // ==================================================
            // Add product to clipboard
            this.clickbyxpath(Elements_Fields.productRsult_CompareButton);
            // ========================
            driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@ng-click=\'vm.toggleChecked()\']")).Click();
            driver.FindElement(By.XPath("//a[@on-create=\'vm.presentationCreated(data)\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@name=\'presentationName\']")).SendKeys(TestData.sCustomerName);
            Thread.Sleep(5000);
            if (!driver.FindElement(By.XPath("//input[@class=\'item-checkbox ng-pristine ng-untouched ng-valid\']")).Selected) {
                driver.FindElement(By.XPath("//input[@class=\'item-checkbox ng-pristine ng-untouched ng-valid\']")).Click();
            }
            
            driver.FindElement(By.XPath("//button[@ng-click=\'vm.methods.ok()\']")).Click();
            Thread.Sleep(6000);
            if (driver.FindElement(By.LinkText("Edit Products")).Displayed) {
                Thread.Sleep(5000);
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(".//*[@id=\'productCompareToolbar\']/div/div/div/div[3]/button[1]")).Click();
               System.Console.WriteLine("Test Case- Create New Presentation from compare page- Pass-");
                //  driver.FindElement(By.XPath("//a[@id='Clipboard']")).Click();
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
                Thread.Sleep(5000);
            }
            else {
               System.Console.WriteLine("Test Case- Create New Presentation from compare page- Fail- ");
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case-  Create New Presentation from compare page- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(44)]
    public void NewPresentation_AddPrduct_Clipboard_Project_Search() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ===============================================Add to clipboard
            this.clickbyxpath(Elements_Fields.productRsult_saveTOClipboard);
            // ================================================== Add to Project
            driver.FindElement(By.XPath(Elements_Fields.productRsult_MarkProduct)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Copy To")).Click();
            Thread.Sleep(5000);
            IWebElement AddButton = driver.FindElement(By.LinkText("Project"));
            Actions action = new Actions(driver);
            action.MoveToElement(AddButton).Build().Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("My Projects")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("page_presentationnavigation")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("page_createpresentation")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@name=\'presentationName\']")).SendKeys(TestData.sCustomerName);
            Thread.Sleep(5000);
            if (!driver.FindElement(By.XPath("//input[@class=\'item-checkbox ng-pristine ng-untouched ng-valid\']")).Selected) {
                driver.FindElement(By.XPath("//input[@class=\'item-checkbox ng-pristine ng-untouched ng-valid\']")).Click();
            }
            
            driver.FindElement(By.XPath("//button[@ng-click=\'vm.methods.ok()\']")).Click();
            Thread.Sleep(8000);
            // =====================================
            // Add from Project folder
            driver.FindElement(By.XPath(".//*[@id=\'PresentationBuilder_Step1\']/ul/li[1]/div[2]")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Add to Presentation")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.LinkText("Remove")).Displayed) {
               System.Console.WriteLine("Test Case- Create New Presentation-  Add product from project- Pass- ");
            }
            else {
               System.Console.WriteLine("Test Case- Create New Presentation- Add product from project- Fail- ");
            }
            
            driver.FindElement(By.XPath(".//*[@id=\'PresentationBuilder_Step1\']/ul/li[3]/div[2]")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Add to Presentation")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.LinkText("Remove")).Displayed) {
               System.Console.WriteLine("Test Case- Create New Presentation-  Add product from Search- Pass- ");
            }
            else {
               System.Console.WriteLine("Test Case- Create New Presentation- Add product from Search- Fail- ");
            }
            
            driver.FindElement(By.XPath("//li[@class=\'clipboard\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Add to Presentation")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.LinkText("Remove")).Displayed) {
               System.Console.WriteLine("Test Case- Create New Presentation-  Add product from clipboard- Pass- ");
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            else {
               System.Console.WriteLine("Test Case- Create New Presentation- Add product from clipboard- Fail- ");
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case- Create New Presentation- Add product from clipboard- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(45)]
    public void NewPresentation_RemoveProduct() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            Thread.Sleep(5000);
            // =========================================================
            driver.FindElement(By.XPath(Elements_Fields.productRsult_MarkProduct)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Create Presentation")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("html/body/div[3]/div/div/form/div[2]/div[1]/input")).SendKeys(TestData.sCustomerName);
            Thread.Sleep(5000);
            if (!driver.FindElement(By.XPath("//input[@class=\'item-checkbox ng-pristine ng-untouched ng-valid\']")).Selected) {
                driver.FindElement(By.XPath("//input[@class=\'item-checkbox ng-pristine ng-untouched ng-valid\']")).Click();
            }
            
            driver.FindElement(By.XPath("//button[@ng-click=\'vm.methods.ok()\']")).Click();
            Thread.Sleep(5000);
            
            IWebElement compare = driver.FindElement(By.XPath("//a[@class=\'last\']"));
            IJavaScriptExecutor js = ((IJavaScriptExecutor)(driver));
            js.ExecuteScript("arguments[0].click();", compare);
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath("//div[@class=\'hint infoHint\']")).Displayed) {
               System.Console.WriteLine("Test Case- remove product from  Presentation - Pass- ");
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            else {
               System.Console.WriteLine("Test Case- remove product from  Presentation - Fail- ");
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case- NewPresentation_RemoveProduct- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(46)]
    public void NewPresentation_SaveAs() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            // Add product to clipboard
            this.clickbyxpath("//button[@location-code=\'PRRPRC\']");
            Thread.Sleep(5000);
            // ========================
            driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//input[@ng-click=\'vm.toggleChecked()\']")).Click();
            
            // =======================
            Thread.Sleep(5000);
            IWebElement compare_NewPrest = driver.FindElement(By.XPath("//a[@on-create=\'vm.presentationCreated(data)\']"));
            IJavaScriptExecutor js2 = ((IJavaScriptExecutor)(driver));
            js2.ExecuteScript("arguments[0].click();", compare_NewPrest);
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@name=\'presentationName\']")).SendKeys(TestData.sCustomerName);
            Thread.Sleep(5000);
            if (!driver.FindElement(By.XPath("//input[@class=\'item-checkbox ng-pristine ng-untouched ng-valid\']")).Selected) {
                driver.FindElement(By.XPath("//input[@class=\'item-checkbox ng-pristine ng-untouched ng-valid\']")).Click();
            }
            
            driver.FindElement(By.XPath("//button[@ng-click=\'vm.methods.ok()\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'Module_271888\']/div[1]/div/div[2]/div/a/span")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'Module_271888\']/div[1]/div/div[2]/div/ul/li[2]/a")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@name=\'templateName\']")).Clear();
            driver.FindElement(By.XPath("//input[@name=\'templateName\']")).SendKeys("Automation");
            driver.FindElement(By.XPath(".//*[@id=\'saveAsTemplateModal\']/div/div/div[3]/button[2]")).Click();
            Thread.Sleep(5000);
            // driver.FindElement(By.XPath(".//*[@id='page_presentationnavigation']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("page_presentationnavigation")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("page_presentations")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath(".//*[@id=\'templateRow\']/li[2]/div/div[2]/div[1]/span")).Displayed) {
                IWebElement compare1 = driver.FindElement(By.XPath(".//*[@id=\'templateRow\']/li[2]/div/div[2]/div[2]/a[1]/i"));
                IJavaScriptExecutor js1 = ((IJavaScriptExecutor)(driver));
                js1.ExecuteScript("arguments[0].click();", compare1);
                // driver.FindElement(By.XPath(".//*[@id='templateRow']/li[2]/div/div[2]/div[2]/a[1]/i")).Click();
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(".//*[@id=\'productCompareToolbar\']/div/div/div/div[3]/button[1]")).Click();
               System.Console.WriteLine("Test Case- Create New Presentation save as template- Pass- ");
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            else {
               System.Console.WriteLine("Test Case- Create New Presentation save as template- Fail- ");
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case- NewPresentation_SaveAs- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(47)]
    public void NewPresentation_noproduct() {
        try {
            driver.FindElement(By.Id("page_presentationnavigation")).Click();
            driver.FindElement(By.Id("page_createpresentation")).Click();
            driver.FindElement(By.XPath("//input[@name=\'presentationName\']")).SendKeys(TestData.sCustomerName);
            Thread.Sleep(5000);
            if (!driver.FindElement(By.XPath("//input[@class=\'item-checkbox ng-pristine ng-untouched ng-valid\']")).Selected) {
                driver.FindElement(By.XPath("//input[@class=\'item-checkbox ng-pristine ng-untouched ng-valid\']")).Click();
            }
            
            driver.FindElement(By.XPath("//button[@ng-click=\'vm.methods.ok()\']")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath(".//*[@id=\'HelpfulHintContent\']/div")).Displayed) {
               System.Console.WriteLine("Test Case- Create New Presentation with no product- Pass-");
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            else {
               System.Console.WriteLine("Test Case- Create New Presentation with no product- Fail-");
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case- NewPresentation_noproduct- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    // ===============================================Orders=====================================================
    [Test,Order(48)]
    public void OrderFromClipboard() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            Thread.Sleep(5000);
            // ==================================================
            // Add product to clipboard
            this.clickbyxpath(Elements_Fields.productRsult_saveTOClipboard);
            // ==================================================
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@id=\'Clipboard\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[2]/ul/li/div/label/input")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'ngClipboard\']/ul/li/div/div[4]/div/button")).Click();
            Thread.Sleep(3000);
            IList<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            Thread.Sleep(5000);
            while (!driver.FindElement(By.XPath("//span[@ng-if=\'vm.order.Number\']")).Displayed) {
                Thread.Sleep(5000);
            }
            
            if (driver.FindElement(By.XPath("//span[@ng-if=\'vm.order.Number\']")).Displayed) {
                driver.SwitchTo().Window(tabs2[1]).Close();
                Thread.Sleep(2000);
                driver.SwitchTo().Window(tabs2[0]);
                Thread.Sleep(5000);
                //  driver.FindElement(By.XPath("//a[@id='Clipboard']")).Click();
                Thread.Sleep(5000);
                if (!driver.FindElement(By.XPath("//input[@ng-click=\'methods.toolbar.checkAll()\']")).Selected) {
                    driver.FindElement(By.XPath("input[@ng-click=\'methods.toolbar.checkAll()\']")).Click();
                    Thread.Sleep(5000);
                }
                
                driver.FindElement(By.LinkText("Delete")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("html/body/div[3]/div/div/div/div/button[2]")).Click();
                Thread.Sleep(5000);
                this.navigateToWESP();
               System.Console.WriteLine("Test Case- Order from clipboard- Pass");
            }
            else {
                driver.SwitchTo().Window(tabs2[1]).Close();
                Thread.Sleep(5000);
                driver.SwitchTo().Window(tabs2[0]);
                Thread.Sleep(5000);
                this.navigateToWESP();
               System.Console.WriteLine("Test Case- Order from clipboard- Fail");
            }
            
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case- OOrderFromClipboard- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(49)]
    public void Order_Presentation() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            // Add product to clipboard
            this.clickbyxpath(Elements_Fields.productRsult_CompareButton);
            // ==================================================
            Thread.Sleep(5000);
            // ========================
            driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'ngProductCompare\']/div/div[2]/div/product-toolbar-redux/div/ul/li[1]/div/label/input")).Click();
            // =======================
            Thread.Sleep(3000);
            this.clickbyxpath("//a[@on-create=\'vm.presentationCreated(data)\']");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@name=\'presentationName\']")).SendKeys((TestData.sCustomerName + "P-49"));
            Thread.Sleep(5000);
            if (!driver.FindElement(By.XPath("//input[@class=\'item-checkbox ng-pristine ng-untouched ng-valid\']")).Selected) {
                driver.FindElement(By.XPath("//input[@class=\'item-checkbox ng-pristine ng-untouched ng-valid\']")).Click();
            }
            
            driver.FindElement(By.XPath("//button[@ng-click=\'vm.methods.ok()\']")).Click();
            Thread.Sleep(5000);
            IJavaScriptExecutor jse = ((IJavaScriptExecutor)(driver));
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("Order")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@placeholder=\'QTY\']")).SendKeys("5");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
            //  driver.FindElement(By.XPath("html/body/div[3]/div/div/form/div/div/section/div/div/div/div[2]/div/div[2]/div/div/button[2]")).Click();
            Thread.Sleep(5000);
            // =======================================================
            driver.FindElement(By.LinkText("Add New Customer")).Click();
            Thread.Sleep(5000);
            // input[@name='ST_ACK_NUM']
            driver.FindElement(By.XPath("//input[@name=\'name\']")).SendKeys(TestData.sCustomerName);
            Thread.Sleep(5000);
            // input[@placeholder='QTY']
            driver.FindElement(By.XPath("//button[@ng-click=\'vm.save(vm.quickAddForm)\']")).Click();
            Thread.Sleep(5000);
            // ========================================================
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
            Thread.Sleep(20000);
            IList<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            Thread.Sleep(5000);
            // driver.FindElement(By.XPath("html/body/div[3]/div/div/form/div/div/section/div/div/div/div[2]/div/div[2]/div/div/button")).Click();
            while (!driver.FindElement(By.XPath("//span[@ng-if=\'vm.order.Number\']")).Displayed) {
                Thread.Sleep(5000);
            }
            
            this.orderVerification("Order from presentation -");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case- Order_Presentation- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(50)]
    public void Order_ProductDetail_Grid() {
        try {
            driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
            Thread.Sleep(5000);
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_CPN);
            Thread.Sleep(5000);
            // ==================================================
            IJavaScriptExecutor jse = ((IJavaScriptExecutor)(driver));
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            driver.FindElement(By.XPath("//div[@class=\'pull-right hidden-print\']")).Click();
            // ==================================================
            Thread.Sleep(5000);
            // ========================
            driver.FindElement(By.XPath("//input[@placeholder=\'QTY\']")).SendKeys("5");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Add New Customer")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@name=\'name\']")).SendKeys((TestData.sCustomerName + "P50"));
            Thread.Sleep(5000);
            // input[@placeholder='QTY']
            driver.FindElement(By.XPath("//button[@ng-click=\'vm.save(vm.quickAddForm)\']")).Click();
            // driver.FindElement(By.XPath("html/body/div[4]/div/div/div[3]/button[2]")).Click();
            Thread.Sleep(5000);
            // ========================================================
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
            Thread.Sleep(5000);
            this.orderVerification("Order from product detail page  price grid");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case- Order_ProductDetail_Grid- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(51)]
    public void Order_ProductDetail() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_CPN);
            // ==================================================
            driver.FindElement(By.XPath("//button[@class=\'btn btn-default btn-block text-primary-alt ng-isolate-scope\']")).Click();
            // ==================================================
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@placeholder=\'QTY\']")).SendKeys("5");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Add New Customer")).Click();
            Thread.Sleep(5000);
            // input[@name='ST_ACK_NUM']
            driver.FindElement(By.XPath("//input[@name=\'name\']")).SendKeys((TestData.sCustomerName + "P51"));
            Thread.Sleep(5000);
            // input[@placeholder='QTY']
            driver.FindElement(By.XPath("//button[@ng-click=\'vm.save(vm.quickAddForm)\']")).Click();
            // driver.FindElement(By.XPath("html/body/div[4]/div/div/div[3]/button[2]")).Click();
            Thread.Sleep(5000);
            // ========================================================
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
            this.orderVerification("Order from product detail page-");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case- Order_ProductDetail- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(52)]
    public void Order_ProductResult() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            // Add product to clipboard
            this.clickbyxpath("//button[@class=\'btn btn-xs btn-default ng-isolate-scope\']");
            // ==================================================
            Thread.Sleep(5000);
            // ========================
            driver.FindElement(By.XPath("//input[@placeholder=\'QTY\']")).SendKeys("5");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Add New Customer")).Click();
            Thread.Sleep(5000);
            // input[@name='ST_ACK_NUM']
            driver.FindElement(By.XPath("//input[@name=\'name\']")).SendKeys((TestData.sCustomerName + "P52"));
            Thread.Sleep(5000);
            // input[@placeholder='QTY']
            driver.FindElement(By.XPath("//button[@ng-click=\'vm.save(vm.quickAddForm)\']")).Click();
            // driver.FindElement(By.XPath("html/body/div[4]/div/div/div[3]/button[2]")).Click();
            Thread.Sleep(5000);
            // ========================================================
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
            this.orderVerification("Order from product result page");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case- Order_ProductResult- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(53)]
    public void OrderFrom_Project() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            Thread.Sleep(5000);
            // ==================================================
            this.clickbyxpath("//input[@ng-change=\'::methods.markProduct(product)\']");
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Copy To")).Click();
            IWebElement Projects = driver.FindElement(By.XPath(".//*[@id=\'125117\']/ul/li[2]/a"));
            Actions action = new Actions(driver);
            action.MoveToElement(Projects).Build().Perform();
            Thread.Sleep(5000);
            // ==================================================
            // ==================================================
            // Add product to clipboard
            driver.FindElement(By.XPath("//a[@title=\'My Projects\']")).Click();
            // ==================================================
            Thread.Sleep(5000);
            // ========================
            // driver.FindElement(By.XPath("//input[@placeholder='QTY']")).SendKeys("5");
            driver.FindElement(By.Id("page_projects")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.PartialLinkText("Saved Products")).Click();
            Thread.Sleep(5000);
            // =======================================
            IWebElement RecentSearchs = driver.FindElement(By.XPath("//a[@xng-click=\'::methods.productDetailClick($event, product, 0, $index)\']"));
            // driver.FindElement(By.ClassName("section container")).Click();
            action.MoveToElement(RecentSearchs).Build().Perform();
            Thread.Sleep(5000);
            // =======================================
            driver.FindElement(By.XPath("//button[@class=\'btn btn-sm btn-default btn-block ng-isolate-scope\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@placeholder=\'QTY\']")).SendKeys("5");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("Add New Customer")).Click();
            Thread.Sleep(5000);
            // input[@name='ST_ACK_NUM']
            driver.FindElement(By.XPath("//input[@name=\'name\']")).SendKeys((TestData.sCustomerName + "P53"));
            Thread.Sleep(5000);
            // input[@placeholder='QTY']
            driver.FindElement(By.XPath("//button[@ng-click=\'vm.save(vm.quickAddForm)\']")).Click();
            Thread.Sleep(5000);
            // ========================================================
            driver.FindElement(By.XPath("//button[@ng-click=\'::vm.next()\']")).Click();
            this.orderVerification("Order from project page-");
        }
        catch (Exception e) {
           System.Console.WriteLine("Test Case- OrderFrom_Project- Fail");
            Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test,Order(54)]
    public void GiftstAndIncentives() {
        try {
            this.enterPoint();
            driver.FindElement(By.XPath(Elements_Fields.QuickView_AllProducts)).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//li[@class=\'quicksearch-type-incentive\']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath("//span[@ng-if=\'::product.IsIncentive\']")).Displayed) {
                this.productResult("Gifts & Incentives product result");
                driver.FindElement(By.XPath("//a[@class=\'prod-title ellipsis ng-binding\']")).Click();
                Thread.Sleep(5000);
                IList<String> tabs2 = new List<String>(driver.WindowHandles);
                driver.SwitchTo().Window(tabs2[1]);
                if (driver.FindElement(By.XPath("//span[@class=\'feature feature-incentive margin-left-5\']")).Displayed) {
                   System.Console.WriteLine("Test Case-Gifts and Incentives prodct detail page displayed- Pass");
                    String sCPN = driver.FindElement(By.XPath("//div[@id=\'pnlCodedProdNum\']")).Text;
                    Thread.Sleep(3000);
                    String fCPN = sCPN;
                    driver.SwitchTo().Window(tabs2[1]).Close();
                    driver.SwitchTo().Window(tabs2[0]);
                    Thread.Sleep(3000);
                    driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                    Thread.Sleep(3000);
                    driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
                    driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).SendKeys(fCPN);
                    driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
                    Thread.Sleep(3000);
                }
                else {
                   System.Console.WriteLine("Test Case-Gifts and Incentives prodct detail page displayed- Fail");
                }
                
                if (driver.FindElement(By.XPath("//span[@class=\'feature feature-incentive margin-left-5\']")).Displayed) {
                   System.Console.WriteLine("Test Case-Product search by CPN- Gifts and Incentives prodct detail page displayed- Pass");
                }
                else {
                   System.Console.WriteLine("Test Case-Product search by CPN- Gifts and Incentives prodct detail page displayed- Fail");
                }
                
            }
            else {
               System.Console.WriteLine("Test Case-Gifts & Incentives product result- Fail");
                Thread.Sleep(5000);
            }
            
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        
    }
    
    // ==========================================================================================================
    [OneTimeSetUp]
    public void setUp() {
        try {
            //  CloseBrowser();
          //  Runtime.getRuntime().exec(TestData.sKillChrome);
         //   System.setProperty("webdriver.chrome.driver", TestData.sChromePath);
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(TestData.sURL);
            driver.Manage().Window.Maximize();
            driver.SwitchTo().ActiveElement();
            // Thread.Sleep(5000);
            driver.FindElement(By.Id("asilogin_AsiNumber")).Clear();
            driver.FindElement(By.Id("asilogin_UserName")).Clear();
            driver.FindElement(By.Id("asilogin_Password")).Clear();
            driver.FindElement(By.Id("asilogin_AsiNumber")).SendKeys(TestData.sASINumber);
            driver.FindElement(By.Id("asilogin_UserName")).SendKeys(TestData.sUserName);
            driver.FindElement(By.Id("asilogin_Password")).SendKeys(TestData.sPassword);
            if (driver.FindElement(By.Id("rememberMe")).Selected) {
                driver.FindElement(By.Id("rememberMe")).Click();
            }
            
            driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(3000);
            try {
              //  Robot robot = new Robot();
             //   Thread.Sleep(3000);
            //    robot.keyPress(KeyEvent.VK_ENTER);
           //     Thread.Sleep(2000);
           //     robot.keyRelease(KeyEvent.VK_ENTER);
            //    Thread.Sleep(2000);
                if (driver.FindElement(By.LinkText("ESP Web Home Page")).Displayed) {
                    this.LicenceAgrement();
                    driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                    Thread.Sleep(3000);
                }
                
               System.Console.WriteLine(("Environment - " + TestData.sURL));
               System.Console.WriteLine("Department QA ");
               System.Console.WriteLine(("User- " + TestData.sUserName));
            }
            catch (Exception e) {
                
            }
            
            Thread.Sleep(5000);
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        
    }
    
   // [AfterTest()]
    [OneTimeTearDown]
    public void CloseBrowser() {
        try {
           // Runtime.getRuntime().exec(TestData.sKillChrome);
         //   Runtime.getRuntime().exec(TestData.sKillChromedriver);
         //   System.exit(0);
        }
        catch (Exception e) {
            
        }
        
    }
    
    public void searchProductByPOID(String sProdID) {
        try {
            this.enterPoint();
            IWebElement myDynamicElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementExists(By.Id(Elements_Fields.QuicViewSearchtxt)));
            Thread.Sleep(5000);
            myDynamicElement.Click();
            myDynamicElement.SendKeys(sProdID);
            this.selectAllProduct();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(5000);
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        
    }
    
    public void search_Supplier(String sSupplier) {
        try {
            IWebElement myDynamicElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementExists(By.Id(Elements_Fields.QuicViewSearchtxt)));
            myDynamicElement.Click();
            // driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            // Thread.Sleep(1000);
            myDynamicElement.SendKeys(sSupplier);
            // driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).SendKeys(sSupplier);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(".//*[@id=\'QuickSearchGroup\']/div/div/button")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Suppliers")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(5000);
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        
    }
    
    public void search_Decorator(String sDecorator) {
        try {
            IWebElement myDynamicElement = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists(By.Id(Elements_Fields.QuicViewSearchtxt)));
            myDynamicElement.Click();
            myDynamicElement.SendKeys(sDecorator);
            driver.FindElement(By.XPath(Elements_Fields.QuickView_AllProducts)).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText(Elements_Fields.QuickView_SelectDecorator)).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(5000);
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        
    }
    
    public void clearClipboard() {
        try {
            driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@id=\'Clipboard\']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@ng-click=\'methods.toolbar.checkAll()\']")).Click();
            // driver.FindElement(By.XPath("//div[2]/ul/li/div/label/input")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(".//*[@id=\'appMenu\']/li[6]/a")).Click();
            // driver.FindElement(By.XPath("//li[6]/a")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("html/body/div[3]/div/div/div/div/button[2]")).Click();
            Thread.Sleep(5000);
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        
    }
    
    public void clickbyxpath(String sSelectProduct) {
        try {
            IWebElement compare = driver.FindElement(By.XPath(sSelectProduct));
            IJavaScriptExecutor js = ((IJavaScriptExecutor)(driver));
            js.ExecuteScript("arguments[0].click();", compare);
            Thread.Sleep(3000);
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        
    }
    
    public void navigateToWESP() {
        try {
            this.enterPoint();
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        
    }
    
    public void enterPoint() {
        try {
            Thread.Sleep(3000);
            if ((!driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Displayed 
                        && !driver.FindElement(By.LinkText("All Products")).Selected)) {
                driver.Navigate().GoToUrl(TestData.sNavigateToWESP);
                Thread.Sleep(5000);
            }
            
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        
    }
    
    public void selectAllProduct() {
        try {
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@class=\'input-group-btn dropdown\']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("All Products")).Click();
            Thread.Sleep(1000);
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        
    }
    
    public void onMouseEvent(String sElemnt) {
        try {
            IWebElement AddButton = driver.FindElement(By.XPath(sElemnt));
            Actions action = new Actions(driver);
            action.MoveToElement(AddButton).Build().Perform();
            Thread.Sleep(3000);
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        
    }
    
    public void createPresentation() {
        try {
            Thread.Sleep(5000);
            driver.SwitchTo().Frame(0);
            Thread.Sleep(3000);
            driver.FindElement(By.Id(Elements_Fields.createPresentation_Nametxt)).SendKeys(TestData.sCustomerName);
            Thread.Sleep(5000);
            if (!driver.FindElement(By.Id(Elements_Fields.createPresentation_ProjectCheckbox)).Selected) {
                driver.FindElement(By.Id(Elements_Fields.createPresentation_ProjectCheckbox)).Click();
            }
            
            driver.FindElement(By.Id(Elements_Fields.createPresentation_Okbutton)).Click();
            driver.SwitchTo().ActiveElement();
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        
    }
    
    public void productResult(String sTestCase) {
        try {
            IWebElement myDynamicElement = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists(By.XPath("//div[@class=\'prod-count\']")));
            while (!myDynamicElement.Displayed) {
                Thread.Sleep(5000);
            }
            
            String sProductSearchResultValidation = myDynamicElement.Text;
            if ((sProductSearchResultValidation != null)) {
               System.Console.WriteLine(("Test Case-" 
                                + (sTestCase + ("-" 
                                + (sProductSearchResultValidation + "- Pass")))));
            }
            else {
               System.Console.WriteLine(("Test Case-" 
                                + (sTestCase + ("-" 
                                + (sProductSearchResultValidation + "- Fail")))));
            }
            
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        
    }
    
    public void clearShoppingCart() {
        try {
            IWebElement myDynamicElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementExists(By.XPath("//a[@id=\'ShoppingCart\']")));
            myDynamicElement.Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//li[1]/div/label")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(".//*[@id=\'appMenu\']/li[4]/a")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("html/body/div[3]/div/div/div/div/button[2]")).Click();
            Thread.Sleep(5000);
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        
    }
    
    public void LicenceAgrement() {
        try {
            Thread.Sleep(3000);
            if (driver.PageSource.Contains("ESP (ALL) Terms & Conditions")) {
                driver.FindElement(By.Id(Elements_Fields.license_1stAcceptCheckbox)).Click();
                driver.FindElement(By.Id(Elements_Fields.license_2ndAcceptCheckbox)).Click();
                driver.FindElement(By.XPath(("//input[@value=\'" 
                                    + (Elements_Fields.license_Signaturetxt + "\']")))).SendKeys("QA");
                driver.FindElement(By.Id(Elements_Fields.license_Acceptbtn)).Click();
                Thread.Sleep(5000);
            }
            
            if (driver.FindElement(By.XPath(("//button[@class=\'" 
                                + (Elements_Fields.license_GetStartedbtn + "\']")))).Displayed) {
                driver.FindElement(By.XPath(("//button[@class=\'" 
                                    + (Elements_Fields.license_GetStartedbtn + "\']")))).Click();
                Thread.Sleep(3000);
            }
            
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        
    }
    
    public void orderVerification(String sTestCase) {
        try {
            Thread.Sleep(3000);
            IList<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            Thread.Sleep(5000);
            while (!driver.FindElement(By.XPath("//span[@ng-if=\'vm.order.Number\']")).Displayed) {
                Thread.Sleep(5000);
            }
            
            if (driver.FindElement(By.XPath("//span[@ng-if=\'vm.order.Number\']")).Displayed) {
                String sOrder = driver.FindElement(By.XPath("//span[@ng-if=\'vm.order.Number\']")).Text;
               System.Console.WriteLine(("Test Case-" 
                                + (sTestCase + ("-" 
                                + (sOrder + "- Pass")))));
                driver.SwitchTo().Window(tabs2[1]).Close();
                Thread.Sleep(5000);
                driver.SwitchTo().Window(tabs2[0]);
                Thread.Sleep(3000);
            }
            else {
                driver.SwitchTo().Window(tabs2[1]).Close();
                Thread.Sleep(5000);
                driver.SwitchTo().Window(tabs2[0]);
               System.Console.WriteLine(("Test Case-" 
                                + (sTestCase + "- Fail")));
                Thread.Sleep(3000);
            }
            
            Thread.Sleep(5000);
        }
        catch (Exception e) {
            Thread.Sleep(5000);
           System.Console.WriteLine(("Test Case-" 
                            + (sTestCase + "- Fail")));
            Thread.Sleep(5000);
        }
        
    }
}