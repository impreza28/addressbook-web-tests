using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class GroupHelper: HelperBase
    {

        public GroupHelper(IWebDriver driver)
                    : base(driver)
        {
            this.driver = driver;
        }

        public void InitGroupCreation()
        {
            //создание новой группы
            driver.FindElement(By.Name("new")).Click();
        }


        public void FillGroupForm(GroupData group)
        {
            //заполнение формы новой группы
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }
        public void SubmitCreationGroup()
        {
            //подтверждение создания 
            driver.FindElement(By.Name("submit")).Click();
        }

    }
}
