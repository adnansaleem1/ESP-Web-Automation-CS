using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

public class WESP_4_0 {

    public static IWebDriver driver;
    
    [Test, Order(0)]
    public void VerifyPOTDAd() {
        try {
            this.enterPoint();
            if (driver.FindElement(By.XPath(Elements_Fields.HomePage_POTD)).Displayed) {
                 System.Console.WriteLine(" Test Case- Product of the day - Pass");
            }
            else {
                 System.Console.WriteLine(" Test Case- Product of the day - Fail");
            }
            
        }
        catch (Exception e) {
             System.Console.WriteLine(" Test Case- Product of the day - Fail");
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(1)]
    public void QuickSearchBy_PriceFrom_QTY() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            this.selectAllProduct();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchQTYtxt)).SendKeys("100");
            Thread.Sleep(4000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(8000);
            // ==================================================
            this.productResult("Quick search by  QTY  without price");
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
             System.Console.WriteLine(" Test Case- QuickSearchBy_PriceFrom_QTY - Fail");
        }
        
    }
    
    [Test, Order(2)]
    public void QuickSearchBy_PriceFrom_PriceTo() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            this.selectAllProduct();
            driver.FindElement(By.XPath("//input[@placeholder=\'Price\']")).Click();
            // driver.FindElement(By.XPath(".//*[@id='quickSearchHeader']/div/ng-form/div/div/div[3]/div/div[1]/input")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.XPath("//input[@placeholder=\' min\']")).SendKeys("1");
            driver.FindElement(By.XPath("//input[@placeholder=\' max\']")).SendKeys("5");
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchQTYtxt)).SendKeys("50");
            Thread.Sleep(2000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(6000);
            this.productResult("Perform quick Product Search with Price From, Price To, and Quantity");
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
             System.Console.WriteLine(" Test Case- QuickSearchBy_PriceFrom_PriceTo() - Fail");
        }
        
    }
    
    [Test, Order(3)]
    public void QuickSearchBy_DropdownList() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByKeyword);
            Thread.Sleep(6000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.PartialLinkText(TestData.sSearchByKeyword)).Click();
            this.selectAllProduct();
            Thread.Sleep(5000);
            this.productResult("Perform quick search by entering a keyword and then clicking a keyword from dropdown list");
        }
        catch (Exception e) {
            this.tryFailedTestCase("Perform quick search by entering a keyword and then clicking a keyword from dropdown list");
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(4)]
    public void QuickSearchBy_Supplier() {
        try {
            this.enterPoint();
            this.search_Supplier(TestData.sSupplierNo);
            this.productResult("Perform quick Supplier  Search");
        }
        catch (Exception e) {
            this.tryFailedTestCase("Perform quick Supplier  Search");
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(5)]
    public void DecoratorQuickSearch_DecoratorDetailPage() {
        try {
            this.enterPoint();
            this.search_Decorator(TestData.sDecorator);
            this.productResult(" Perform quick decorator  Search");
            driver.FindElement(By.Id("btnSupplierDetail")).Click();
            Thread.Sleep(4000);
            IList<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            Thread.Sleep(2000);
            if (driver.FindElement(By.Id("lblSupplierName")).Displayed) {
                driver.SwitchTo().Window(tabs2[1]).Close();
                Thread.Sleep(2000);
                driver.SwitchTo().Window(tabs2[0]);
                 System.Console.WriteLine("Test Case- Perform quick decorator detail page  - Pass");
            }
            else {
                 System.Console.WriteLine("Test case- Perform quick decorator detail page- Fail");
            }
            
        }
        catch (Exception e) {
            this.tryFailedTestCase("Test case- Perform quick decorator detail page- Fail");
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(6)]
    public void QuickSearchByWithIn() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByKeyword);
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector(".form-control.input-sm.ng-pristine.ng-untouched.ng-valid")).Click();
            driver.FindElement(By.CssSelector(".form-control.input-sm.ng-pristine.ng-untouched.ng-valid")).SendKeys("50");
            driver.FindElement(By.Id("btnSearchWithin")).Click();
            Thread.Sleep(4000);
            this.productResult(" Perform search within");
        }
        catch (Exception e) {
            this.tryFailedTestCase(" Perform search within");
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(7)]
    public void Search_Advanced_MM() {
        try {
            this.enterPoint();
            this.searchProductByPOID("M&M");
            this.productResult("Quick Search- Perform a quick search  \'M&M\'");
            // ==============Advanced Search
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            this.selectAllProduct();
            driver.FindElement(By.Id("advancedSearchLink")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id("productAdvancedSearchAllKeyword")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id("productAdvancedSearchAllKeyword")).SendKeys("M&M");
            Thread.Sleep(4000);
            IWebElement compare = driver.FindElement(By.Id("productSearchSubmitBtn"));
            IJavaScriptExecutor js = ((IJavaScriptExecutor)(driver));
            js.ExecuteScript("arguments[0].click();", compare);
            // driver.FindElement(By.Id("productSearchSubmitBtn")).Click();
            Thread.Sleep(4000);
            this.productResult(" advanced search on \'M&M\'-");
        }
        catch (Exception e) {
            this.tryFailedTestCase(" advanced search on \'M&M\'-");
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(8)]
    public void AddProductToClipBoardFromProductResult() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            this.selectButtonFromProductResult(Elements_Fields.productRsult_saveTOClipboard);
            // ==================================================
            Thread.Sleep(4000);
            if (driver.FindElement(By.XPath("//div[@class=\'badge ng-binding ng-scope\']")).Displayed) {
                 System.Console.WriteLine("Test Case- Add products to clipboard from product result - Pass");
                driver.FindElement(By.XPath("//a[@id=\'Clipboard\']")).Click();
                Thread.Sleep(3000);
                this.clearClipboard();
            }
            else {
                 System.Console.WriteLine("Test Case- Add products to clipboard from product result- Fail");
            }
            
        }
        catch (Exception e) {
            this.tryFailedTestCase("Test Case- Add products to clipboard from product result- Fail");
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(9)]
    public void OpenOneOfExistingSaveSearch() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ===============================================================================
            driver.FindElement(By.LinkText("Save")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id(Elements_Fields.mainPage_Searches)).Click();
            driver.FindElement(By.Id(Elements_Fields.mainPage_Searches_SavedSearches)).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText(TestData.sSearchByProduct_ID)).Click();
            Thread.Sleep(4000);
            this.productResult("Open one of existing saved searches");
        }
        catch (Exception e) {
            this.tryFailedTestCase("Open one of existing saved searches");
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(10)]
    public void OpenOneOfExistingTopSearch() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            Thread.Sleep(5000);
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
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(11)]
    public void OpenOneOfExistingRecentSearch() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // Thread.Sleep(4000);
            driver.FindElement(By.Id(Elements_Fields.mainPage_Searches)).Click();
            Thread.Sleep(5000);
            //  driver.FindElement(By.Id("page_recentsearches")).Click();
            // Thread.Sleep(4000);
            IWebElement RecentSearchs = driver.FindElement(By.Id(Elements_Fields.mainPage_Searches_RecentSearches));
            Actions action = new Actions(driver);
            action.MoveToElement(RecentSearchs).Build().Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText(TestData.sSearchByProduct_ID)).Click();
            Thread.Sleep(6000);
            this.productResult(" Open one of recent searches");
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(12)]
    public void OpenExistingTopSeller() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.mainPage_Searches_TopSellars)).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.PartialLinkText("A")).Click();
            Thread.Sleep(4000);
            this.productResult("Open one of top sellers");
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(13)]
    public void ProductAdvancedSearch_Quantity() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(4000);
            this.selectAllProduct();
            driver.FindElement(By.Id("advancedSearchLink")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id(Elements_Fields.productAdvancedSearch_Allkyewords)).SendKeys("Mugs");
            driver.FindElement(By.Id(Elements_Fields.productAdvancedSearch_Searchbutton)).Click();
            Thread.Sleep(4000);
            this.productResult("Product Advanced Search");
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            this.selectAllProduct();
            Thread.Sleep(4000);
            driver.FindElement(By.Id("advancedSearchLink")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id(Elements_Fields.productAdvancedSearch_Quantitytxt)).SendKeys("50");
            driver.FindElement(By.Id(Elements_Fields.productAdvancedSearch_Searchbutton)).Click();
            Thread.Sleep(4000);
            this.productResult("Product Advanced Search quantity");
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(14)]
    public void SupplierAdvancedSearch() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath(Elements_Fields.QuickView_AllProducts)).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Suppliers")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id("advancedSearchLink")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id(Elements_Fields.supplierAdvancedSearch_Allkyewords)).SendKeys(TestData.sSupplierNo);
            Thread.Sleep(4000);
            driver.FindElement(By.Id(Elements_Fields.supplierAdvancedSearch_Searchbutton)).Click();
            Thread.Sleep(4000);
            if (driver.FindElement(By.LinkText("asi/30232")).Displayed) {
                 System.Console.WriteLine("Test Case- Supplier Advanced  Search - Pass");
            }
            else {
                 System.Console.WriteLine("Test Case- Supplier Advanced Search- Fail");
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(15)]
    public void DecoratorAdvancedSearch() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(4000);
            // driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).SendKeys(TestData.sDecorator);
            Thread.Sleep(4000);
            driver.FindElement(By.XPath(Elements_Fields.QuickView_AllProducts)).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("Decorators")).Click();
            driver.FindElement(By.Id("advancedSearchLink")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id("decoratorAdvancedSearchDecorator")).SendKeys(TestData.sDecorator);
            driver.FindElement(By.Id("decoratorSearchSubmitBtn")).Click();
            Thread.Sleep(4000);
            // ==================================================
            if (driver.FindElement(By.LinkText("asi/788888")).Displayed) {
                 System.Console.WriteLine("Test Case- Decorator advanced search - Pass");
            }
            else {
                 System.Console.WriteLine("Test Case- Deocrator advanced search- Fail");
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(16)]
    public void ProductResult_TileView() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            driver.FindElement(By.XPath("//button[@class=\'btn btn-default btn-sm dropdown-toggle tile-view ng-binding\']")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//i[@class=\'fa fa-th-large\']")).Click();
            Thread.Sleep(4000);
            if (driver.FindElement(By.XPath("//div[@class=\'tile-row clearfix prod-results ng-scope\']")).Displayed) {
                 System.Console.WriteLine("Test Case- Product Result in Tile view - Pass");
            }
            else {
                 System.Console.WriteLine("Test Case- Product Result in Tile view- Fail");
            }
            
            Thread.Sleep(4000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).SendKeys("Mugs");
            Thread.Sleep(4000);
            this.selectAllProduct();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Name("txtQuantity")).SendKeys("50");
            driver.FindElement(By.Id("btnChangeQuantity2")).Click();
            Thread.Sleep(4000);
            this.productResult("Product Result narrow result quantity");
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(17)]
    public void POTD_ProductDetail() {
        try {
            this.enterPoint();
            driver.FindElement(By.XPath("//a[@class=\'ng-binding ng-isolate-scope\']")).Click();
            Thread.Sleep(5000);
            IList<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            Thread.Sleep(3000);
            if (driver.FindElement(By.XPath("//img[@id=\'imgProductImage\']")).Displayed) {
                 System.Console.WriteLine("Test Case- POTD Product detail page - Pass");
                driver.SwitchTo().Window(tabs2[1]).Close();
                Thread.Sleep(2000);
                driver.SwitchTo().Window(tabs2[0]);
            }
            else {
                 System.Console.WriteLine("Test case-POTD product detail page - Fail");
                driver.SwitchTo().Window(tabs2[1]).Close();
                Thread.Sleep(2000);
                driver.SwitchTo().Window(tabs2[0]);
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(18)]
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
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(19)]
    public void ProductQuickview() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            Thread.Sleep(4000);
            IWebElement compare = driver.FindElement(By.XPath("//button[@class=\'btn btn-quickview\']"));
            IJavaScriptExecutor js = ((IJavaScriptExecutor)(driver));
            js.ExecuteScript("arguments[0].click();", compare);
            Thread.Sleep(6000);
            driver.FindElement(By.XPath(".//*[@id=\'productQuickView\']/div[2]/div[2]/div[4]/div/div[1]/button")).Click();
            Thread.Sleep(4000);
            // ========================
            if (driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Displayed) {
                Thread.Sleep(4000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
                 System.Console.WriteLine("Test Case- Display product quick view - Pass");
                //  driver.FindElement(By.XPath("//a[@id='Clipboard']")).Click();
                Thread.Sleep(4000);
            }
            else {
                 System.Console.WriteLine("Test Case- display product quick view- Fail");
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(20)]
    public void ChangeSortbyOption_ProductResult() {
        try {
            this.enterPoint();
            this.searchProductByPOID("Mugs");
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
                Thread.Sleep(4000);
                // Select dropdown = new Select(driver.FindElement(By.Id("CmbSort")));
                String element = thisIsAStringArray[i];
                driver.FindElement(By.LinkText(element.ToString())).Click();
                // dropdown.selectByVisibleText(element);
                Thread.Sleep(5000);
                //  System.Console.WriteLine( element ); 
                this.productResult(("Product Result  sort by " + ("-" + element.ToString())));
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(21)]
    public void AddProductTOClipboard_ComparePage() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            this.selectButtonFromProductResult("//button[@location-code=\'PRRPRC\']");
            // ========================
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//button[@xng-click=\'::methods.compareBtnClick($event)\']")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("Select All")).Click();
            // =======================
            Thread.Sleep(4000);
            IWebElement AddButton = driver.FindElement(By.XPath("//button[@class=\'btn btnAddTrigger btn-sm btn-primary dropdown-toggle\']"));
            Actions action = new Actions(driver);
           action.MoveToElement(AddButton).Build().Perform();
            Thread.Sleep(4000);
            // driver.FindElement(By.LinkText("Add Products to Clipboard")).Click();
            IWebElement Compare_AddToclipboard = driver.FindElement(By.XPath("//a[@ng-click=\'methods.addMarkedProductsToClipboard($event)\']"));
            IJavaScriptExecutor js1 = ((IJavaScriptExecutor)(driver));
            js1.ExecuteScript("arguments[0].click();", Compare_AddToclipboard);
            Thread.Sleep(6000);
            if (driver.FindElement(By.XPath("//a[@id=\'Clipboard\']")).Displayed) {
                Thread.Sleep(3000);
                driver.Url=TestData.sNavigateToWESP;
                Thread.Sleep(4000);
                this.clearClipboard();
                driver.Url=TestData.sNavigateToWESP;
                Thread.Sleep(4000);
                driver.FindElement(By.XPath("//button[@ng-click=\'::methods.clearAll($event)\']")).Click();
                 System.Console.WriteLine("Test Case- Add product to clipboard from compare page- Pass");
                Thread.Sleep(4000);
            }
            else {
                Thread.Sleep(4000);
                driver.Url=TestData.sNavigateToWESP;
                Thread.Sleep(4000);
                driver.FindElement(By.XPath("//button[@ng-click=\'::methods.clearAll($event)\']")).Click();
                 System.Console.WriteLine("Test Case- Add product to clipboard from compare page- Fail");
                Thread.Sleep(5000);
                this.clearClipboard();
                Thread.Sleep(1000);
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(22)]
    public void AddtoCompareFromProductResult() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            // Add product to clipboard
            IWebElement compare = driver.FindElement(By.XPath("//button[@location-code=\'PRRPRC\']"));
            IJavaScriptExecutor js = ((IJavaScriptExecutor)(driver));
            js.ExecuteScript("arguments[0].click();", compare);
            // ==================================================
            Thread.Sleep(4000);
            if (driver.FindElement(By.XPath(".//*[@id=\'productCompareToolbar\']/div/div/div/div[3]/button[2]")).Displayed) {
                Thread.Sleep(4000);
                driver.FindElement(By.XPath(".//*[@id=\'productCompareToolbar\']/div/div/div/div[3]/button[1]")).Click();
                 System.Console.WriteLine("Test Case- Add products to clipboard from product result - Pass");
                //  driver.FindElement(By.XPath("//a[@id='Clipboard']")).Click();
                Thread.Sleep(4000);
            }
            else {
                 System.Console.WriteLine("Test Case- Add products to clipboard from product result- Fail");
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(23)]
    public void AddtoCompareFromQuickview() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            String clickElemnt;
            clickElemnt = "//img[@class=\'img-responsive tile-prod-img ng-pristine ng-untouched ng-valid ng-isolate-scope lazy\']";
            this.onMouseEvent(clickElemnt);
            driver.FindElement(By.XPath("//button[@class=\'btn btn-block btn-sm btn-default\']")).Click();
            // ==================================================
            Thread.Sleep(4000);
            if (driver.FindElement(By.XPath(".//*[@id=\'productCompareToolbar\']/div/div/div/div[3]/button[2]")).Displayed) {
                Thread.Sleep(4000);
                driver.FindElement(By.XPath(".//*[@id=\'productCompareToolbar\']/div/div/div/div[3]/button[1]")).Click();
                 System.Console.WriteLine("Test Case- Add products to comapre from quick view - Pass");
                Thread.Sleep(4000);
            }
            else {
                 System.Console.WriteLine("Test Case- Add products to compare from quick view- Fail");
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(24)]
    public void AddtoCompareFromMarkedItem() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            driver.FindElement(By.XPath("//input[@ng-change=\'::methods.markProduct(product)\']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//a[@xng-click=\'::methods.product.addMarkedProductsToCompare($event)\']")).Click();
            // ==================================================
            Thread.Sleep(4000);
            if (driver.FindElement(By.XPath(".//*[@id=\'productCompareToolbar\']/div/div/div/div[3]/button[2]")).Displayed) {
                Thread.Sleep(4000);
                driver.FindElement(By.XPath(".//*[@id=\'productCompareToolbar\']/div/div/div/div[3]/button[1]")).Click();
                 System.Console.WriteLine("Test Case- Add products to comapre from marked item - Pass");
                Thread.Sleep(4000);
            }
            else {
                 System.Console.WriteLine("Test Case- Add products to compare from market item- Fail");
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(25)]
    public void Remove_Product_ComparePage1() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            // Add product to clipboard
            this.selectButtonFromProductResult(Elements_Fields.productRsult_CompareButton);
            // ==================================================
            Thread.Sleep(4000);
            // ========================
            driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("Select All")).Click();
            // =======================
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("Remove")).Click();
            
            Thread.Sleep(4000);
            if (driver.FindElement(By.XPath(".//*[@id=\'placehoder_1\']")).Displayed) {
                Thread.Sleep(4000);
                driver.Url=TestData.sNavigateToWESP;
                Thread.Sleep(4000);
                //  driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
                 System.Console.WriteLine("Test Case- Remove product from compare page- Pass");
            }
            else {
                Thread.Sleep(4000);
                driver.Url=TestData.sNavigateToWESP;
                Thread.Sleep(4000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
                 System.Console.WriteLine("Test Case- Remove product from compare page- Fail");
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(26)]
    public void AddProductTOProject_ComparePage() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            // Add product to clipboard
            this.selectButtonFromProductResult(Elements_Fields.productRsult_CompareButton);
            Thread.Sleep(4000);
            // ========================
            driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("Select All")).Click();
            // =======================
            Thread.Sleep(4000);
            this.onMouseEvent(Elements_Fields.compareScreen_Addbutton);
            Thread.Sleep(4000);
            Actions action = new Actions(driver);
            IWebElement AddToProject = driver.FindElement(By.LinkText("Add Products to Project Folder"));
            // driver.FindElement(By.className("section container")).Click();
            action.MoveToElement(AddToProject).Build().Perform();
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("My Projects")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("Projects")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.PartialLinkText("Saved Products")).Click();
            Thread.Sleep(2000);
            if (driver.FindElement(By.XPath("//div[@class=\'media-left prod-img ng-isolate-scope\']")).Displayed) {
                Thread.Sleep(4000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
                 System.Console.WriteLine("Test Case- Add product to project from compare page- Pass");
            }
            else {
                Thread.Sleep(4000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
                 System.Console.WriteLine("Test Case- Add product to project from compare page- Fail");
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(27)]
    public void ComparePage_Sort() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            this.selectButtonFromProductResult(Elements_Fields.productRsult_CompareButton);
            Thread.Sleep(4000);
            // ========================
            driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//input[@value=\'prodNum\']")).Click();
            driver.FindElement(By.LinkText("Show only marked")).Click();
            if (driver.FindElement(By.Id("prodQty")).Displayed) {
                 System.Console.WriteLine("Test Case- product compare sort- Fail");
                driver.Url=TestData.sNavigateToWESP;
                Thread.Sleep(4000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
            }
            else {
                 System.Console.WriteLine("Test Case- product compare sort- Pass");
                driver.Url=TestData.sNavigateToWESP;
                Thread.Sleep(4000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(28)]
    public void Remove_Product_ComparePage() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            this.selectButtonFromProductResult(Elements_Fields.productRsult_CompareButton);
            Thread.Sleep(3000);
            // ========================
            driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("Select All")).Click();
            // =======================
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("Remove")).Click();
            
            Thread.Sleep(4000);
            if (driver.FindElement(By.XPath(".//*[@id=\'placehoder_1\']")).Displayed) {
                Thread.Sleep(1000);
                 System.Console.WriteLine("Test Case- Remove product from compare page- Pass");
            }
            else {
                driver.Url=TestData.sNavigateToWESP;
                Thread.Sleep(4000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
                 System.Console.WriteLine("Test Case- Remove product from compare page- Fail");
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(29)]
    public void AddProductTOShoppingCart_ComparePage() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            this.selectButtonFromProductResult(Elements_Fields.productRsult_CompareButton);
            Thread.Sleep(3000);
            // ========================
            driver.FindElement(By.XPath(Elements_Fields.compareToolbar_GoToComparePage)).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.PartialLinkText("Add to Cart")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().Frame(0);
            Thread.Sleep(2000);
            this.selectButtonFromProductResult("//a[@id=\'ctl03_ctl00_btnExcludeOptions\']");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("ctl03_ctl00_btnAddToOrder")).Click();
            Thread.Sleep(4000);
            if (driver.FindElement(By.XPath("//a[@id=\'A1\']")).Displayed) {
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//a[@id=\'A1\']")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//input[@ng-model=\'toolbar.allChecked\']")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//a[@confirm-method=\'methods.toolbar.deleteMarked($event)\']")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("html/body/div[3]/div/div/div/div/button[2]")).Click();
                Thread.Sleep(3000);
                driver.Url=TestData.sNavigateToWESP;
                Thread.Sleep(4000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
                 System.Console.WriteLine("Test Case- Add product to shopping cart from compare page- Pass");
                Thread.Sleep(4000);
            }
            else {
                Thread.Sleep(4000);
                driver.Url=TestData.sNavigateToWESP;
                Thread.Sleep(4000);
                driver.FindElement(By.XPath(Elements_Fields.compareToolbar_ClearAll)).Click();
                 System.Console.WriteLine("Test Case- Add product to shoping cart from compare page- Fail");
                driver.FindElement(By.XPath("//a[@id=\'Clipboard\']")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//input[@ng-model=\'toolbar.allChecked\']")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//a[@confirm-method=\'methods.toolbar.deleteMarked($event)\']")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("html/body/div[3]/div/div/div/div/button[2]")).Click();
                Thread.Sleep(3000);
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(30)]
    public void NewSupplier_Page() {
        try {
            this.enterPoint();
            driver.Url=TestData.sNavigateToWESP;
            Thread.Sleep(4000);
            driver.FindElement(By.Id("page_newsuppliers")).Click();
            Thread.Sleep(4000);
            if (!driver.Title.Contains("New Suppliers")) {
                String sNewSupplier = driver.FindElement(By.Id("lblnosuppmsg")).Text;
                 System.Console.WriteLine(("Test Case- New SUpplier page-" 
                                + (sNewSupplier + "-  Fail")));
            }
            else {
                 System.Console.WriteLine("Test Case- New SUpplier page- Pass");
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(31)]
    public void SupplierDetail_AllTabs() {
        try {
            this.enterPoint();
            this.search_Supplier(TestData.sSupplierNo);
            // ==================================================
            driver.FindElement(By.XPath(".//*[@id=\'btnSupplierDetail\']")).Click();
            // ==================================================
            Thread.Sleep(4000);
            IList<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id=\'tabRatings\']/a")).Click();
            Thread.Sleep(4000);
            if (driver.FindElement(By.XPath("//div[@class=\'tab-content\']")).Displayed) {
                 System.Console.WriteLine("Test Case- Supplier Detail-  Ratings tab  - Pass");
            }
            else {
                 System.Console.WriteLine("Test Case- Supplier Detail- Ratings tab - Fail");
            }
            
            Thread.Sleep(4000);
            driver.FindElement(By.XPath(".//*[@id=\'tabCompliance\']/a")).Click();
            Thread.Sleep(4000);
            if (driver.FindElement(By.XPath("//div[@class=\'tab-content\']")).Displayed) {
                 System.Console.WriteLine("Test Case- Supplier Detail-  safty and compliance tab  - Pass");
            }
            else {
                 System.Console.WriteLine("Test Case- Supplier Detail- safty and compliance tab - Fail");
            }
            
            Thread.Sleep(4000);
            driver.FindElement(By.XPath(".//*[@id=\'tabPreferred\']/a")).Click();
            Thread.Sleep(5000);
            if (driver.FindElement(By.XPath("//div[@class=\'tab-content\']")).Displayed) {
                 System.Console.WriteLine("Test Case- Supplier Detail-  Preferred tab  - Pass");
            }
            else {
                 System.Console.WriteLine("Test Case- Supplier Detail- Preferred tab - Fail");
            }
            
            Thread.Sleep(4000);
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
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(32)]
    public void Presentation_Download() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            // ==================================================
            driver.FindElement(By.XPath("//input[@ng-change=\'::methods.markProduct(product)\']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("Create Presentation")).Click();
            Thread.Sleep(5000);
            this.createPresentation();
            if (driver.FindElement(By.XPath("//a[@onclick=\'recordDownloadPrsnStats();\']")).Displayed) {
                driver.FindElement(By.XPath("//a[@onclick=\'recordDownloadPrsnStats();\']")).Click();
                Thread.Sleep(5000);
                 System.Console.WriteLine("Test Case-Download Presentation - Pass");
            }
            else {
                 System.Console.WriteLine("Test Case-Download Presentation - Fail");
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(33)]
    public void NarrowProductSearch_SearchTextBox() {
        try {
            this.enterPoint();
            this.searchProductByPOID("Mugs");
            // ==================================================
            driver.FindElement(By.LinkText("MUGS & STEINS")).Click();
            Thread.Sleep(4000);
            if (driver.FindElement(By.XPath("//div[@class=\'dimension-subgroup dimension-subgroup-category category-info\']")).Displayed) {
                 System.Console.WriteLine("Test Case- Narrow Product Search - Pass");
            }
            else {
                 System.Console.WriteLine("Test Case- Narrow Product Search- Fail");
            }
            
            driver.FindElement(By.XPath("//a[@xng-click=\'::methods.filters.expandDimension($event, dimension, true)\']")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//input[@name=\'txtQuantity\']")).SendKeys("50");
            Thread.Sleep(8000);
            driver.FindElement(By.XPath("//button[@id=\'btnChangeQuantity2\']")).Click();
            if (driver.FindElement(By.XPath("//div[@ng-if=\'dimension.Open\']")).Displayed) {
                 System.Console.WriteLine("Test Case- Narrow Product Search- text box  - Pass");
            }
            else {
                 System.Console.WriteLine("Test Case- Narrow Product Search- text box-  Fail");
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(34)]
    public void NarrowProductSearchMultiDimension() {
        try {
            this.enterPoint();
            this.searchProductByPOID("Mugs");
            Thread.Sleep(4000);
            // ==================================================
            driver.FindElement(By.LinkText("MUGS & STEINS")).Click();
            Thread.Sleep(4000);
            if (driver.FindElement(By.XPath("//div[@class=\'dimension-group\']")).Displayed) {
                 System.Console.WriteLine("Test Case- Narrow Product Search- Muti Diamension - Pass");
            }
            else {
                 System.Console.WriteLine("Test Case- Narrow Product Search- Muti Diamension- Fail");
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(35)]
    public void SupplierDetail_Comments() {
        try {
            this.enterPoint();
            this.search_Supplier(TestData.sSupplierNo);
            // ==================================================
            driver.FindElement(By.XPath(".//*[@id=\'btnSupplierDetail\']")).Click();
            // ==================================================
            Thread.Sleep(4000);
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
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(36)]
    public void CPN_QuickView_ProductDetail() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_ID);
            this.selectButtonFromProductResult("//button[@class=\'btn btn-quickview\']");
            // driver.FindElement(By.XPath(Elements_Fields.productResult_ProductImage)).Click();
            if (driver.FindElement(By.XPath("//em[@class=\'pull-right ng-binding\']")).Displayed) {
                 System.Console.WriteLine("Test Case- Product Quick View- CPN - Pass");
            }
            else {
                 System.Console.WriteLine("Test Case- Product Quick View- CPN - Fail");
            }
            
            driver.FindElement(By.XPath("//a[@ng-click=\'::methods.productDetailClick($event, product, 0, $index, true)\']")).Click();
            Thread.Sleep(4000);
            // ==================================================
            IList<String> tabs2 = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs2[1]);
            if (driver.FindElement(By.XPath("//div[@id=\'pnlCodedProdNum\']")).Displayed) {
                 System.Console.WriteLine("Test Case- Product Detail page- CPN  - Pass");
                driver.SwitchTo().Window(tabs2[1]).Close();
                Thread.Sleep(4000);
                driver.SwitchTo().Window(tabs2[0]);
                Thread.Sleep(4000);
            }
            else {
                 System.Console.WriteLine("Test Case-  Product Detail page- CPN- Fail");
                driver.SwitchTo().Window(tabs2[1]).Close();
                Thread.Sleep(4000);
                driver.SwitchTo().Window(tabs2[0]);
                Thread.Sleep(4000);
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(37)]
    public void ShippingEstimator() {
        try {
            this.enterPoint();
            this.searchProductByPOID(TestData.sSearchByProduct_CPN);
            driver.FindElement(By.Id("espShippingCalculatorLink")).Click();
            driver.FindElement(By.Id("espSC-items-per-package")).SendKeys("5");
            driver.FindElement(By.Id("espSC-weight-per-package")).SendKeys("10");
            driver.FindElement(By.Id("calculate")).Click();
            Thread.Sleep(4000);
            if (driver.FindElement(By.ClassName("tablewrapper")).Displayed) {
                 System.Console.WriteLine("Test Case- Shipping estimator by Package- Pass");
            }
            else {
                 System.Console.WriteLine("Test Case- Shipping estimator by Package-- Fail");
            }
            
            driver.FindElement(By.Id("espSC-estimation-unit")).Click();
            Thread.Sleep(4000);
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("espSC-estimation-unit")));
            dropdown.SelectByText("Product");
            driver.FindElement(By.Id("espSC-quantity")).Clear();
            driver.FindElement(By.Id("espSC-quantity")).SendKeys("5");
            driver.FindElement(By.Id("espSC-weight")).SendKeys("10");
            driver.FindElement(By.Id("calculate")).Click();
            Thread.Sleep(4000);
            if (driver.FindElement(By.ClassName("tablewrapper")).Displayed) {
                 System.Console.WriteLine("Test Case- Shipping estimator by Product- Pass");
                driver.Url=TestData.sNavigateToWESP;
                Thread.Sleep(5000);
            }
            else {
                 System.Console.WriteLine("Test Case- Shipping estimator by Product- Fail");
                driver.Url=TestData.sNavigateToWESP;
                Thread.Sleep(5000);
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(38)]
    public void ProductTheme() {
        try {
            this.enterPoint();
            this.searchProductByPOID("CPN-5067090");
            driver.FindElement(By.LinkText("BAR ACCESSORIES")).Click();
            this.productResult("Product Category");
            this.searchProductByPOID("CPN-5067090");
            if (driver.FindElement(By.XPath("//span[@class=\'asi-update-datee ng-binding\']")).Displayed) {
                 System.Console.WriteLine("Test Case- Product detail updated date- Pass");
            }
            else {
                 System.Console.WriteLine("Test Case- Product detail updated date- Fail");
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(39)]
    public void ProductAdvancedSearch_witrhoutPrice() {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id("advancedSearchLink")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id("productAdvancedSearchQuantity")).SendKeys("50");
            driver.FindElement(By.Id("productSearchSubmitBtn")).Click();
            Thread.Sleep(6000);
            this.productResult("Product AdvancedSearch witrhout Price");
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(40)]
    public void ProductResultByQTY_NarrowSearch() {
        try {
            this.enterPoint();
            this.searchProductByPOID("Mugs");
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//input[@ng-enter-click=\'#btnChangeQuantity2\']")).SendKeys("50");
            driver.FindElement(By.XPath("//button[@id=\'btnChangeQuantity2\']")).Click();
            Thread.Sleep(2000);
            this.productResult("Product results - narrow results  by entering quantity in the field");
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(41)]
    public void ProductQuickViewByQTY() {
        try {
            this.enterPoint();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("search-quantity")).SendKeys("50");
            Thread.Sleep(1000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(4000);
            this.productResult("Quick Search - search by quantity without entering price");
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(42)]
    public void MarkedItemsToolbar() {
        try {
            this.enterPoint();
            this.searchProductByPOID("Mugs");
            Thread.Sleep(8000);
            driver.FindElement(By.XPath("//input[@ng-change=\'::methods.markProduct(product)\']")).Click();
            Thread.Sleep(3000);
            IJavaScriptExecutor jse = ((IJavaScriptExecutor)(driver));
            jse.ExecuteScript("window.scrollBy(0,500)", "");
            Thread.Sleep(8000);
            if (driver.PageSource.Equals("Create Presentation")) {
                 System.Console.WriteLine("Test Case- Marked Items toolbar should be visible to user as he scrolls down through the page- Pass");
            }
            else {
                 System.Console.WriteLine("Test Case- Marked Items toolbar should be visible to user as he scrolls down through the page- Fail");
            }
            
            if (driver.PageSource.Equals("Create Presentation")) {
                 System.Console.WriteLine("Test Case- Marked Items toolbar should be visible to user as he scrolls down through the page- fixed " +
                    "filter- Pass");
            }
            else {
                 System.Console.WriteLine("Test Case- Marked Items toolbar should be visible to user as he scrolls down through the page- fixed " +
                    "filter - Fail");
            }
            
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [Test, Order(48)]
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
                    driver.Url=TestData.sNavigateToWESP;
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

    [OneTimeSetUp()]
    public void setUp() {
        try {
            //  CloseBrowser();
          //  Runtime.getRuntime().exec(TestData.sKillChrome);
            //System.setProperty("webdriver.chrome.driver", TestData.sChromePath);
            driver = new ChromeDriver();
            driver.Url=TestData.sURL;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            Thread.Sleep(4000);
            driver.FindElement(By.Id("asilogin_AsiNumber")).Clear();
            driver.FindElement(By.Id("asilogin_UserName")).Clear();
            driver.FindElement(By.Id("asilogin_Password")).Clear();
            driver.FindElement(By.Id("asilogin_AsiNumber")).SendKeys(TestData.sASINumber_4);
            driver.FindElement(By.Id("asilogin_UserName")).SendKeys(TestData.sUserName_4);
            driver.FindElement(By.Id("asilogin_Password")).SendKeys(TestData.sPassword_4);
            if (driver.FindElement(By.Id("rememberMe")).Selected) {
                driver.FindElement(By.Id("rememberMe")).Click();
            }
            
            driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(4000);
            try
            {
                //Robot robot = new Robot();
                //Thread.Sleep(3000);
                //robot.keyPress(KeyEvent.VK_ENTER);
                //Thread.Sleep(2000);
                //robot.keyRelease(KeyEvent.VK_ENTER);
                Thread.Sleep(2000);
                driver.SwitchTo().Alert().Accept();
                Thread.Sleep(2000);
                if (driver.FindElement(By.LinkText("ESP Web Home Page")).Displayed)
                {
                    this.LicenceAgrement();
                    driver.Url = TestData.sNavigateToWESP;
                    Thread.Sleep(5000);
                }

            }
            catch (Exception e)
            {

            }
            
            Thread.Sleep(4000);
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    [OneTimeTearDown()]
    public void CloseBrowser() {
        try {
            driver.Quit();
            
            //Runtime.getRuntime().exec(TestData.sKillChrome);
            //Runtime.getRuntime().exec(TestData.sKillChromedriver);
            //System.exit(0);
        }
        catch (Exception e) {
            
        }
        
    }
    
    public void searchProductByCPN(String sProduct_CPN) {
        try {
            this.enterPoint();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).SendKeys(sProduct_CPN);
            Thread.Sleep(1000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchbtn)).Click();
            Thread.Sleep(4000);
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    public void searchProductByPOID(String sProdID) {
        try {
            this.enterPoint();
            Thread.Sleep(3000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).SendKeys(sProdID);
            Thread.Sleep(1000);
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
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).SendKeys(sSupplier);
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
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).Click();
            driver.FindElement(By.Id(Elements_Fields.QuicViewSearchtxt)).SendKeys(sDecorator);
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
            driver.Url=TestData.sNavigateToWESP;
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//a[@id=\'Clipboard\']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@ng-click=\'methods.toolbar.checkAll()\']")).Click();
            // driver.FindElement(By.XPath("//div[2]/ul/li/div/label/input")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//li[6]/a")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("html/body/div[3]/div/div/div/div/button[2]")).Click();
            Thread.Sleep(4000);
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    public void selectButtonFromProductResult(String sSelectProduct) {
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
            driver.Url=TestData.sNavigateToWESP;
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    public void selectAllProduct() {
        try {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@class=\'input-group-btn dropdown\']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("All Products")).Click();
            Thread.Sleep(2000);
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
            Thread.Sleep(3000);
            driver.SwitchTo().Frame(0);
            driver.FindElement(By.Id(Elements_Fields.createPresentation_Nametxt)).SendKeys(TestData.sCustomerName);
            Thread.Sleep(5000);
            if (!driver.FindElement(By.Id(Elements_Fields.createPresentation_ProjectCheckbox)).Selected) {
                driver.FindElement(By.Id(Elements_Fields.createPresentation_ProjectCheckbox)).Click();
            }
            
            driver.FindElement(By.Id(Elements_Fields.createPresentation_Okbutton)).Click();
            Thread.Sleep(6000);
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    public void productResult(String sTestCase) {
        try {
            Thread.Sleep(3000);
            String sProductSearchResultValidation = driver.FindElement(By.XPath("//div[@class=\'prod-count\']")).Text;
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
    
    public void tryFailedTestCase(String sTestCase) {
        try {
            Thread.Sleep(1000);
             System.Console.WriteLine(("Test Case-" 
                            + (sTestCase + "- Fail")));
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
    
    public void onMouse(IWebElement sElemnt) {
        try {
            IWebElement AddButton = sElemnt;
            Actions action = new Actions(driver);
           action.MoveToElement(AddButton).Build().Perform();
            Thread.Sleep(3000);
        }
        catch (Exception e) {
              Console.WriteLine(e.ToString());
        }
        
    }
}
