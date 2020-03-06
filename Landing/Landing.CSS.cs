using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;


namespace NUnitTestProject1
{
    public class Landing_CSS
    {
        //URL
        protected string URL = "http://automationpractice.com/index.php";
        //Login Button
        protected string SignInLink = "login";
        //EMail
        protected string IdEmail = "email";
        protected string EmailAd = "iam2@intelliroph.com";
        //Password
        protected string IdPass = "passwd";
        protected string Pass = "abc123";
        //Submit Button
        protected string IdSubmitBtn = "SubmitLogin";

        protected string Fpath = @"C:\\Users\\ACER\\Documents\\selenium\\Credentials.csv";
        protected string Dlimiter = ",";
    }
}
