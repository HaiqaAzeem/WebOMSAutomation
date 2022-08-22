// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using MAUtility.Diagnostics;
using NUnit.Framework;
using WebControls;
using WebOMSHelperLibrary;
using OpenQA.Selenium;

namespace WebOMSAutomation
{
    [TestFixture]
    public class LoginTests
    {


      


        [Test]       
        public void TestMethod()
        {
           
            Login("1", "tester24@mailinator.com", "tester24");
            
            //Thread.Sleep(20000);
            //   BankingInstructionSetupHelper.Instance.PerformActionOnBankingInstructionSetupRow("Delete","0");
            //BankingInstructionSetupHelper.Instance.SelectContextOfBankingInstructionSetup("Info", "Sort Ascending");

            TFA("123456");
         
        }

   


        public void CreateOrder()
        {
            try
            {
                string res1 = OrderEntryHelper.Instance.FillOrderEntryControls("Symbol", "WMT", "Quantity", "11");
                //Assert.AreEqual(Global.SUCCESS, res1);
                string res2 = OrderEntryHelper.Instance.ClickButton("Advanced Trade");
                // Assert.AreEqual(Global.SUCCESS, res2);

                string res3 = OrderEntryHelper.Instance.FillOrderEntryComboControls("OrderType", "L");
                //Assert.AreEqual(Global.SUCCESS, res3);
                Thread.Sleep(2000);
                string res11 = OrderEntryHelper.Instance.FillOrderEntryControls("Price", "10.01");
                string res4 = OrderEntryHelper.Instance.ClickButton("Buy");
                //  Assert.AreEqual(Global.SUCCESS, res4);
                string res5 = OrderEntryHelper.Instance.ClickButton("PlaceOrder");

                //Assert.AreEqual(Global.SUCCESS, res5);
                // string res6 = OrderEntryHelper.Instance.ValidateMarketDataIsPresent();
                //Assert.AreEqual(Global.SUCCESS, res6);
            }
            catch (Exception ex)
            {
                Logger.LogMessage("Exception occurred while creating order: {0} ", ex.Message);
                return;
            }

        }

        public void Login(string alias, string email, string password)
        {
            Logger.LogMessage("Start Test");
                string res1 = WebOMSHelper.Instance.StartNewBrowser(alias);
                Logger.LogMessage("New window started");
           
            string Validation = LoginHelper.Instance.GetLabelText("Validate", "LOGIN");
             Assert.AreEqual(Global.SUCCESS, Validation);   

            Logger.LogMessage("Validation executed");
                string res3 = LoginHelper.Instance.FillLoginControls("LoginPassword", email, "LoginPassword", password);
            Logger.LogMessage("Email password entered ");

            //Thread.Sleep(20000);
            string res4 = LoginHelper.Instance.ClickButton("LoginButton");
            Logger.LogMessage("Login Button clicked");
               
        }

        public void TFA (string code)
        {
            Console.WriteLine("TFA");
            //string res1 = WebOMSHelper.Instance.StartNewBrowser(code);
            string res5 = LoginHelper.Instance.FillLoginControls("VerificationCode", code);
            Console.WriteLine("Verificationcode entered");
            string Validation = LoginHelper.Instance.GetLabelText("ValidateTFA", "Two-Factor Authentication");
           
           // Assert.AreEqual(Global.SUCCESS, Validation);  //uncomment this
           
            string res6 = LoginHelper.Instance.ClickButton("SubmitButton");
            Console.WriteLine("Verification submitted");
            string res7 = LoginHelper.Instance.ClickButton("ProceedButton");
            Console.WriteLine("Proceeded");
        }

        
        

    }
}
